using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Constants;
using CleanArchitecture.PracticalTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Entities
{
    public class Paquete : BaseDomainModel
    {
        public Guid PaqueteId { get; set; }
        public string NumeroRastreo { get; set; } = null!;
        public decimal Peso { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal Volumen { get; set; }
        public decimal Distancia { get; set; }
        public Guid EstadoId { get; set; }
        public Estado? EstadoPaquete { get; set; }
        public Guid RutaId { get; set; }
        public Ruta? RutaSeleccionada { get; set; }
        public List<PaqueteHistorial> Historial { get; set; } = null!;
        public decimal? Costo { get; set; }

        // 
        private static readonly Dictionary<Guid, List<Guid>> TransicionesPermitidas = new()
        {
            { CatalogGuids.EnBodega, new() { CatalogGuids.EnTransito, CatalogGuids.Devuelto } },
            { CatalogGuids.EnTransito, new() { CatalogGuids.EnReparto, CatalogGuids.Devuelto } },
            { CatalogGuids.EnReparto, new() { CatalogGuids.Entregado, CatalogGuids.Devuelto } },
            // Entregado y Devuelto no tienen salida (son estados finales)
        };

        public void RegistrarDimensiones(decimal peso, decimal alto, decimal ancho, decimal largo)
        {
            this.Peso = peso;
            this.Alto = alto;
            this.Ancho = ancho;
            this.Largo = largo;
            ActualizarCostoTotal();
        }

        public void ActualizarEstado(Guid nuevoEstadoId)
        {
            // Entregado o Devuelto
            if (EstadoId == CatalogGuids.Entregado || EstadoId == CatalogGuids.Devuelto)
            {
                throw new DomainException("No se puede modificar un estado Entregado o Devuelto", this.Id, this.EstadoId);
            }

            if (!TransicionesPermitidas.ContainsKey(EstadoId) ||
                !TransicionesPermitidas[EstadoId].Contains(nuevoEstadoId))
            {
                throw new DomainException("flujo incorrecto, selecciona otro estado", this.Id, this.EstadoId, nuevoEstadoId);
            }
            
            this.EstadoId = nuevoEstadoId;

            this.UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            this.UpdatedBy = new Guid();
        }

        public void AsignarRutas(Ruta ruta)
        {
            
            if (this.EstadoId == CatalogGuids.Entregado)
            {
                throw new DomainException("El paquete ya se entregó", this.Id);
            }

            if (this.EstadoId != CatalogGuids.EnBodega)
            {
                throw new DomainException("Solo se pueden asignar paquetes con estatus En Bodega", this.Id, this.EstadoId);
            }

            ActualizarCostoTotal();
            this.RutaId = ruta.RutaId;

            this.ActualizarEstado(CatalogGuids.EnTransito);
        }

        private void ActualizarCostoTotal()
        {
            decimal costoBase = 50m;
            decimal costoPeso = Math.Max(0, this.Peso - 1) * 15m;
            decimal costoDistancia = this.Distancia * 2.5m;
            decimal volumen = this.Alto * this.Ancho * this.Largo;

            decimal subtotal = costoBase + costoPeso + costoDistancia;

            // Volumen > 500,000 cm³
            this.Costo = volumen > 500000 ? subtotal * 1.20m : subtotal;
        }
    }
}

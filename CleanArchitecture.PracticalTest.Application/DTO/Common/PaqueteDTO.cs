using CleanArchitecture.PracticalTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.DTO.Common
{
    public class PaqueteDTO
    {
        public Guid Id { get; set; }
        public string NumeroRastreo { get; set; } = null!;
        public decimal Peso { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal Volumen => Alto * Ancho * Largo;
        public Guid EstadoId { get; set; }
        public Guid? RutaId { get; set; }
        public List<PaqueteHistorial> Historial { get; set; } = null!;
        public decimal? Costo { get; set; }
    }
}

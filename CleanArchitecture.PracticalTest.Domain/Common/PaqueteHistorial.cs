using CleanArchitecture.PracticalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Common
{
    public class PaqueteHistorial : BaseDomainModel
    {
        public int Id { get; set; }
        public Guid PaqueteId { get; set; }
        public Paquete Paquete { get; set; } = null!;
        public Guid EstadoId { get; set; }
        public Estado PaqueteEstado { get; set; } = null!;
        public DateTime FechaHoraCambio { get; set; }
        public string Motivo { get; set; }
    }
}

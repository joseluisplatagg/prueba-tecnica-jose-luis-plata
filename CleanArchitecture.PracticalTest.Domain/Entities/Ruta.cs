using CleanArchitecture.PracticalTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Entities
{
    public class Ruta : BaseDomainModel
    {
        public Guid RutaId { get; set; }
        public string Origen { get; set; } = null!;
        public string Destino { get; set; } = null!;
        public decimal Distancia { get; set; }
        public decimal TiempoEstimado { get ; set; }
    }
}

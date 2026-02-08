using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.DTO.Common
{
    public class RutaDTO
    {
        public int RutaId { get; set; }
        public string Origen { get; set; } = null!;
        public string Destino { get; set; } = null!;
        public decimal Distancia { get; set; }
        public decimal TiempoEstimado { get; set; }
    }
}

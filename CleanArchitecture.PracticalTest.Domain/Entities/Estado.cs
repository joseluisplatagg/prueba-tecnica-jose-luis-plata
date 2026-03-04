using CleanArchitecture.PracticalTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Entities
{
    public class Estado : BaseDomainModel
    {
        public string EstadoDescripcion { get; set; }
    }
}

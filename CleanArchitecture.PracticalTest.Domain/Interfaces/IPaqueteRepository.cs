using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Interfaces
{
    public interface IPaqueteRepository : IBaseRepository<Paquete>
    {
        public Task<int> AsignRoute(Guid idPaquete, Guid newEstado, Guid idRuta);

        public Task<Paquete?> GetPaqueteHistorial(Guid id);
    }
}

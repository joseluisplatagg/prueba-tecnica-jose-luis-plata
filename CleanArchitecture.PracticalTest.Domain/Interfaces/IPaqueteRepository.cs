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
        Task<int> AsignRoute(Guid idPaquete, Guid newEstado, Guid idRuta);

        Task<Paquete?> GetPaqueteHistorial(Guid id);
    }
}

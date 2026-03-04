using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using CleanArchitecture.PracticalTest.Domain.Interfaces;
using CleanArchitecture.PracticalTest.Infrastructure.Data;
using CleanArchitecture.PracticalTest.Infrastructure.Data.Repositories;
using CleanArchitecture.PracticalTest.Infrastructure.Data.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Infrastructure.Repositories
{
    public class PaqueteRepository(ContextDb dbContext) : BaseRepository<Paquete>(dbContext), IPaqueteRepository
    {

        public async Task<int> AsignRoute(Guid idPaquete, Guid newEstado, Guid idRuta)
        {
            var paquete = await dbContext.Paquetes.FindAsync(idPaquete);
            if (paquete == null) return 0;
            
            paquete.EstadoId = newEstado;
            paquete.RutaId = idRuta;

            return 1;

        }

        public async Task<Paquete?> GetPaqueteHistorial(Guid id)
        {
            return await dbContext.Paquetes
                .Include(p => p.Historial)
                .ThenInclude(h => h.PaqueteEstado)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}

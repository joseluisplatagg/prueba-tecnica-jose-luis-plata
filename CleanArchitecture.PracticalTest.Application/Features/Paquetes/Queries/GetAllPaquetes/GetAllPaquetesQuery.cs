using AutoMapper;
using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetAllPaquetes
{
    public record GetAllPaquetesQuery(
        Guid? EstadoId = null,
        DateTime? FechaInicio = null,
        DateTime? FechaFin = null) : IRequest<OperationResult<List<PaqueteDTO>>>;
    public class GetAllPaquetesHandler : IRequestHandler<GetAllPaquetesQuery, OperationResult<List<PaqueteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public GetAllPaquetesHandler(IUnitOfWork unitOfWork, IMapper mapper, ILocalizer localizer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<OperationResult<List<PaqueteDTO>>> Handle(GetAllPaquetesQuery request, CancellationToken cancellationToken)
        {
            var paquetes = await _unitOfWork.GetRepository<Paquete>().GetAllWithSpecAsync(,);

            if (paquetes == null) return OperationResult.With<List<PaqueteDTO>>(default!);

            var warning = paquetes.Count() == 0 ? _localizer.GetResponseMessage("Search.NoResults") 
                : _localizer.GetResponseMessage("Search.Results");

            return OperationResult.With(
                _mapper.Map<List<PaqueteDTO>>(paquetes),
                warnings: new List<string> { warning },
                metadata: new Dictionary<string, object> { { "TotalCount", paquetes.Count() } });
        }
    }
}

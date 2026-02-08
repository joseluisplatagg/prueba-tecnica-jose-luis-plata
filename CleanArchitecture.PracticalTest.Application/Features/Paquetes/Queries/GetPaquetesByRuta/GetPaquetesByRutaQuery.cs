using AutoMapper;
using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetPaquetesByRuta
{
    public record GetPaquetesByRutaQuery(
        Guid RutaId) : IRequest<OperationResult<List<PaqueteDTO>>>;

    public class GetPaquetesByRutaHandler : IRequestHandler<GetPaquetesByRutaQuery, OperationResult<List<PaqueteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPaquetesByRutaHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<List<PaqueteDTO>>> Handle(GetPaquetesByRutaQuery request, CancellationToken cancellationToken)
        {
            var paquetes = await _unitOfWork.GetRepository<Paquete>().GetByIdAsync(request.RutaId);
            return OperationResult.With<List<PaqueteDTO>>(_mapper.Map<List<PaqueteDTO>>(paquetes));
        }
    }
}

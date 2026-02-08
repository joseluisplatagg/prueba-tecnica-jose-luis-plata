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

namespace CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetPaqueteById
{
    public record GetPaqueteByIdQuery(
        Guid PaqueteId) : IRequest<OperationResult<PaqueteDTO>>;

    public class GetPaqueteByIdHandler : IRequestHandler<GetPaqueteByIdQuery, OperationResult<PaqueteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPaqueteByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<PaqueteDTO>> Handle(GetPaqueteByIdQuery request, CancellationToken ct)
        {
            var paquete = await _unitOfWork.GetRepository<Paquete>().GetByIdAsync(request.PaqueteId);

            if (paquete == null) return OperationResult.With<PaqueteDTO>(default!);

            return OperationResult.With(_mapper.Map<PaqueteDTO>(paquete));
        }
    }
}

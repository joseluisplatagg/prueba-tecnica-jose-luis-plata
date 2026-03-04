using AutoMapper;
using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Exceptions;
using CleanArchitecture.PracticalTest.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetShippingCost
{
    public record GetShippingCostQuery(
        Guid id) : IRequest<OperationResult<PaqueteDTO>>;

    public class GetShippingCostHandler( 
        IUnitOfWork _unitOfWork,
        ILocalizer _localizer,
        IMapper _mapper) : IRequestHandler<GetShippingCostQuery, OperationResult<PaqueteDTO>>
    {
        public async Task<OperationResult<PaqueteDTO>> Handle(GetShippingCostQuery request, CancellationToken cancellationToken)
        {
            var paqueteTemp = await _unitOfWork.GetRepository<Paquete>().GetByIdAsync(request.id);

            if (paqueteTemp == null) throw new NotFoundException(_localizer.GetExceptionMessage("Paquete.NotFound"),request.id);

            paqueteTemp.RegistrarDimensiones(paqueteTemp.Peso, paqueteTemp.Alto, paqueteTemp.Ancho, paqueteTemp.Largo);

            var dto = _mapper.Map<PaqueteDTO>(paqueteTemp);

            var warning = _mapper.Map<PaqueteDTO>(paqueteTemp) == null ? _localizer.GetResponseMessage("Search.NoResults")
                : _localizer.GetResponseMessage("Search.Results");

            return OperationResult.With(dto, warnings: new List<string> { warning },
                metadata: new Dictionary<string, object> { { "Fecha de cotización", DateTime.UtcNow } });
        }
    }

}

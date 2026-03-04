using AutoMapper;
using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.CreatePaquete;
using CleanArchitecture.PracticalTest.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.UpdateEstadoPaquete
{
    public record UpdateEstadoPaqueteCommand(
        Guid PaqueteId,
        Guid EstadoId) : IRequest<OperationResult<bool>>;

    public class UpdateEstadoPaqueteValidator : AbstractValidator<UpdateEstadoPaqueteCommand>
    {
        public UpdateEstadoPaqueteValidator()
        {
            RuleFor(p => p.PaqueteId).NotEmpty();
            RuleFor(p =>p.EstadoId).NotEmpty();
        }
    }

    public class UpdateEstadoPaqueteHandler(IUnitOfWork _unitOfWork, IMapper _mapper, ILocalizer _localizer) : IRequestHandler<UpdateEstadoPaqueteCommand, OperationResult<bool>>
    {
        public async Task<OperationResult<bool>> Handle(UpdateEstadoPaqueteCommand command, CancellationToken ct)
        {
            var paqueteRepo = _unitOfWork.GetRepository<Paquete>();
            var estadoRepo = _unitOfWork.GetRepository<Estado>();

            var paquete = await paqueteRepo.GetByIdAsync(command.PaqueteId);
            if (paquete == null) return OperationResult.With(false);

            paquete.ActualizarEstado(command.EstadoId);

            var estado = estadoRepo.GetByIdAsync(command.EstadoId);
            if (estado == null) return OperationResult.With(false, new List<string> { "El estado / estatus no existe" });

            paquete.EstadoId = command.EstadoId;
            paqueteRepo.Update(paquete);

            var result = await _unitOfWork.CompleteAsync(ct);

            var warning = _localizer.GetResponseMessage("Actualizado");

            return OperationResult.With(result > 0 ? true : false, warnings: new List<string> { warning },
                metadata: new Dictionary<string, object> { { "Filas afectadas", result } });
        }
    }
}

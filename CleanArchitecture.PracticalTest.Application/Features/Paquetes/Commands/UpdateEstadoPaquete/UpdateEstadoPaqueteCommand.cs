using CleanArchitecture.PracticalTest.Application.Contracts.Data;
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
        Guid EstadoId) : IRequest<bool>;

    public class UpdateEstadoPaqueteValidator : AbstractValidator<UpdateEstadoPaqueteCommand>
    {
        public UpdateEstadoPaqueteValidator()
        {
            RuleFor(p => p.EstadoId).NotEmpty();
            RuleFor(p =>p.EstadoId).NotEmpty();
        }
    }

    public class UpdateEstadoPaqueteHandler : IRequestHandler<UpdateEstadoPaqueteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEstadoPaqueteHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Handle(UpdateEstadoPaqueteCommand command, CancellationToken ct)
        {
            var paqueteRepo = _unitOfWork.GetRepository<Paquete>();
            var estadoRepo = _unitOfWork.GetRepository<Estado>();

            var paquete = await paqueteRepo.GetByIdAsync(command.PaqueteId);
            if (paquete != null) return false;

            paquete.ActualizarEstado(command.EstadoId);

            var estado = estadoRepo.GetByIdAsync(command.EstadoId);
            if (estado != null) return false;

            paquete.EstadoId = command.EstadoId;
            paqueteRepo.Update(paquete);

            var result = await _unitOfWork.CompleteAsync(ct);

            return result > 0;
        }
    }
}

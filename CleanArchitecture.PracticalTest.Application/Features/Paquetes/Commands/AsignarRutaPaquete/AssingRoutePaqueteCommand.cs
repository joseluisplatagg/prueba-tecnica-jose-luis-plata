using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.AsignarRutaPaquete
{
    public record AsignarRutaPaqueteCommand(
        Guid PaqueteId,
        Guid RutaId) : IRequest<OperationResult<bool>>;

    public class AsignarRutaPaqueteValidator : AbstractValidator<AsignarRutaPaqueteCommand>
    {
        public AsignarRutaPaqueteValidator()
        {
            RuleFor(p => p.PaqueteId).NotEmpty();
            RuleFor(p => p.RutaId).NotEmpty(); 
        }
    }

    public class AsignarRutaPaqueteHandler : IRequestHandler<AsignarRutaPaqueteCommand, OperationResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AsignarRutaPaqueteHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        public async Task<OperationResult<bool>> Handle(AsignarRutaPaqueteCommand request, CancellationToken cancellationToken)
        {
            var paqueteRepo = _unitOfWork.GetRepository<Paquete>();
            var rutaRepo = _unitOfWork.GetRepository<Ruta>();

            var paquete = await paqueteRepo.GetByIdAsync(request.PaqueteId);

            if (paquete == null) return OperationResult.With<bool>(false);

            var ruta = await rutaRepo.GetByIdAsync(request.RutaId);
            if (ruta == null) return OperationResult.With(false, new List<string> { "La ruta no existe" });

            paquete.AsignarRutas(ruta);

            paquete.RutaId = request.RutaId;

            paqueteRepo.Update(paquete);

            var result = await _unitOfWork.CompleteAsync(cancellationToken);

            return result > 0 ? OperationResult.With<bool>(true) : OperationResult.With<bool>(false);
        }
    }
}

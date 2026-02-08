using CleanArchitecture.PracticalTest.Application.Contracts.Data;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.CreatePaquete
{
    public record CreatePaqueteCommand(
        Guid PaqueteId,
        string NumeroRastreo,
        decimal Peso,
        decimal Alto,
        decimal Ancho,
        decimal Largo,
        decimal Volumen,
        decimal Distancia,
        Guid EstadoId,
        Guid RutaId,
        decimal Costo) : IRequest<OperationResult<int>>;

    public class CreatePaqueteValidator : AbstractValidator<CreatePaqueteCommand>
    {
        public CreatePaqueteValidator()
        {
            RuleFor(p => p.Peso)
                .NotEmpty().WithMessage("El peso es requerido")
                .GreaterThan(0).WithMessage("El peso debe ser mayor a 0.1 kg")
                .LessThanOrEqualTo(50).WithMessage("El peso no puede exceder los 50 kg");

            RuleFor(p => p.Distancia).NotEmpty();
            RuleFor(p => p.Alto).NotEmpty().GreaterThan(0).LessThanOrEqualTo(50).WithMessage("La dimensión máxima no debe exeder los 150 cm");
            RuleFor(p => p.Ancho).NotEmpty().GreaterThan(0).LessThanOrEqualTo(50).WithMessage("La dimensión máxima no debe exeder los 150 cm"); ;
            RuleFor(p => p.Largo).NotEmpty().GreaterThan(0).LessThanOrEqualTo(50).WithMessage("La dimensión máxima no debe exeder los 150 cm"); ;

            RuleFor(p => p)
                .Must(p => (p.Alto * p.Ancho * p.Largo) <= 1000000)
                .WithMessage("Las dimensiones del paquete exceden el volumen máximo permitido (1m³)")
                .WithName("Dimensiones");

            // Validación Relacional: El peso debe ser coherente con el tamaño (ejemplo lógico)
            RuleFor(p => p)
                .Must(p => p.Peso > 0.1m) // Peso mínimo para cualquier dimensión
                .When(p => p.Alto > 50)
                .WithMessage("Un paquete de gran tamaño no puede pesar menos de 100g");
            RuleFor(p =>p.EstadoId).NotEmpty();
            RuleFor(p =>p.RutaId).NotEmpty();
        }
    }

    public class CreatePaqueteHandler : IRequestHandler<CreatePaqueteCommand , OperationResult<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaqueteHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<OperationResult<int>> Handle(CreatePaqueteCommand command, CancellationToken ct)
        {
            var newPaquete = new Paquete
            {
                PaqueteId = new Guid(),
                NumeroRastreo = command.NumeroRastreo,
                Peso = command.Peso,
                Alto = command.Alto,
                Ancho = command.Ancho,
                Largo = command.Largo,
                Volumen = command.Alto * command.Largo * command.Ancho,
                EstadoId = command.EstadoId,
                RutaId = command.RutaId,
                Costo = command.Costo
            };

            var paqueteRepo = _unitOfWork.GetRepository<Paquete>();

            var result = await paqueteRepo.AddAsync(newPaquete);
            if (result != null) return OperationResult.With<int>(1);
            else return OperationResult.With<int>(0);
        }
    }
}

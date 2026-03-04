using AutoMapper;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.CreatePaquete;
using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Entities;


namespace CleanArchitecture.PracticalTest.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        EnumMappingProfile();

        CommandToDomainMappingProfile();

        DomainToViewModelMappingProfile();
    }

    private void EnumMappingProfile()
    {
        // Mapeo de enumeraciones/ catálogos a DTOs
        CreateMap<Estado, EstadoDTO>();
        CreateMap<Ruta, RutaDTO>();
    }

    private void CommandToDomainMappingProfile()
    {
        // Mapeo de comandos a entidades del dominio
        CreateMap<CreatePaqueteCommand, Paquete>();

    }

    private void DomainToViewModelMappingProfile()
    {
        // Mapeo de entidades del dominio a ViewModels
        CreateMap<Paquete, PaqueteDTO>();
    }
}

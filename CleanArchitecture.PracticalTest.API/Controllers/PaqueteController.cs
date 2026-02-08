using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.AsignarRutaPaquete;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.CreatePaquete;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.UpdateEstadoPaquete;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetPaqueteById;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.PracticalTest.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/packages")]
    public class PaqueteController : BaseController
    {
        public PaqueteController(IMediator mediator, ILocalizer localizer) : base(mediator, localizer)
        {
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse<bool>>> AddPaqueteAsync([FromBody] CreatePaqueteCommand paquete)
        {
            var res = await _mediator.Send(paquete);
            return res is null ? BadRequest(APIResponse.From<bool>(OperationResult.With<bool>(false), "No se pudo realizar la actualización")) :
                                 Ok(APIResponse.From<bool>(OperationResult.With<bool>(true), "Paquete actualizado"));
        }

        [HttpPatch]
        [Route("{id:guid}/status")]
        public async Task<ActionResult<APIResponse<bool>>> UpdateEstadoAsync(Guid PaqueteId, [FromBody] UpdatePackageStatusRequest request)
        {
            var command = new UpdateEstadoPaqueteCommand(PaqueteId, request.EstadoId);
            var res = await _mediator.Send(command);
            return res is false ? BadRequest(APIResponse.From<bool>(OperationResult.With<bool>(false), "No se pudo realizar la actualización de estado")) :
                                 Ok(APIResponse.From<bool>(OperationResult.With<bool>(true), "Estatus de paquete actulizado"));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<APIResponse<PaqueteDTO>>> GetPaqueteById(Guid id)
        {
            var pack = await _mediator.Send(new GetPaqueteByIdQuery(id));
            return pack is null ? BadRequest(APIResponse.From<PaqueteDTO>(pack, "Error al recuperar el paquete")) 
                : Ok(APIResponse.From<PaqueteDTO>(pack));
        }

        [HttpPost]
        [Route("{id:guid}/assign-route")]
        public async Task<ActionResult<APIResponse<bool>>> AssginRouteAsync(Guid id, [FromBody] Guid RutaId)
        {
            var res = await _mediator.Send(new AsignarRutaPaqueteCommand(id, RutaId));
            return res is null ? BadRequest(APIResponse.From<bool>(OperationResult.With<bool>(false), "No se pudo realizar la actualización")) :
                                 Ok(APIResponse.From<bool>(res, "Paquete actualizado"));
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse<PaqueteDTO>>> GetAllPaquetesAsync(Guid id)
        {
            var pack = await _mediator.Send(new GetPaqueteByIdQuery(id));
            return pack is null ? BadRequest(APIResponse.From<PaqueteDTO>(pack, "Error al recuperar el paquete"))
                : Ok(APIResponse.From<PaqueteDTO>(pack));
        }

        [HttpGet]
        [Route("{id:guid}/shipping-cost")]
        public async Task<ActionResult<APIResponse<PaqueteDTO>>>  ShippingCostAsync(Guid id)
        {
            var pack = await _mediator.Send(new GetPaqueteByIdQuery(id));
            return pack is null ? BadRequest(APIResponse.From<PaqueteDTO>(pack, "Error al recuperar el paquete"))
                : Ok(APIResponse.From<PaqueteDTO>(pack));
        }




    }
}

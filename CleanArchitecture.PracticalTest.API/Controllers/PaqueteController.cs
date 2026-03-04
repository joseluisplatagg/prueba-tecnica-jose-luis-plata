using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.AsignarRutaPaquete;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.CreatePaquete;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Commands.UpdateEstadoPaquete;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetAllPaquetes;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetPaqueteById;
using CleanArchitecture.PracticalTest.Application.Features.Paquetes.Queries.GetShippingCost;

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
            var message = base._localizer.GetResponseMessage("Agregado exitosamente");
            return Ok(APIResponse.From(res, message));
        }

        [HttpPatch]
        [Route("{id:guid}/status")]
        public async Task<ActionResult<APIResponse<bool>>> UpdateEstadoAsync(Guid id, [FromBody] UpdatePackageStatusRequest request)
        {
            var command = new UpdateEstadoPaqueteCommand(id, request.EstadoId);
            var res = await _mediator.Send(command);
            var message = base._localizer.GetResponseMessage("Actualización Exitosa");
            return Ok(APIResponse.From(res, message));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<APIResponse<PaqueteDTO>>> GetPaqueteById(Guid id)
        {
            var pack = await _mediator.Send(new GetPaqueteByIdQuery(id));
            var message = base._localizer.GetResponseMessage("Busqueda Exitosa");
            return Ok(APIResponse.From(pack, message));
        }

        [HttpPost]
        [Route("{id:guid}/assign-route")]
        public async Task<ActionResult<APIResponse<bool>>> AssginRouteAsync(Guid id, [FromBody] Guid RutaId)
        {
            var res = await _mediator.Send(new AsignarRutaPaqueteCommand(id, RutaId));

            string message = res.Data == true ? base._localizer.GetResponseMessage("Ruta asignada") : base._localizer.GetResponseMessage("Ruta No asignada");
            return Ok(APIResponse.From(res, message));
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse<List<PaqueteDTO>>>> GetAllPaquetesAsync()
        {
            var packs = await _mediator.Send(new GetAllPaquetesQuery());
            var message = base._localizer.GetResponseMessage("Consulta Exitosa");
            return Ok(APIResponse.From(packs, message));
        }

        [HttpGet]
        [Route("{id:guid}/shipping-cost")]
        public async Task<ActionResult<APIResponse<PaqueteDTO>>>  ShippingCostAsync(Guid id)
        {
            var pack = await _mediator.Send(new GetShippingCostQuery(id));
            var message = base._localizer.GetResponseMessage("Consulta Exitosa");
            return Ok(APIResponse.From(pack, message));
        }
    }
}

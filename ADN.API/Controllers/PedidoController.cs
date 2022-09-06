using ADN.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly ILogger<PedidoController> _log;

        public PedidoController(IPedidoService service,
                                ILogger<PedidoController> log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _log.LogInformation("Iniciando GetAll");
            return Ok(await _service.GetAll());
        }
    }
}

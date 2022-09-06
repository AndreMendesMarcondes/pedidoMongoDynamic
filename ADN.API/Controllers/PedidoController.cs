using ADN.Domain.Domain;
using ADN.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

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

        [HttpPost]
        public async Task<IActionResult> Add(PedidoInsertDTO pedidoDto)
        {
            _log.LogInformation("Inserindo");
            Pedido pedido = new Pedido();

            if (pedidoDto.Valor != null)
            {
                if (pedidoDto.Valor is JsonElement)
                {
                    pedido.Valor = pedidoDto.Valor.ToString().Replace("\"", "'")
                                                             .Replace("\n", "")
                                                             .Replace("\\", "");
                }
                else
                {
                    pedido.Valor = ObjectToString(pedidoDto.Valor);
                }
            }

            await _service.Insert(pedido);

            return StatusCode(201);
        }

        private string ObjectToString(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return Convert.ToBase64String(ms.ToArray());
            }
        }       
    }
}

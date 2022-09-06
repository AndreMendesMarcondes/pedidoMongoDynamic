using ADN.Domain.Domain;
using ADN.Domain.Interfaces.Repositorio;
using ADN.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace ADN.Service.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _repositorio;
        private readonly ILogger<PedidoService> _log;

        public PedidoService(IPedidoRepositorio repositorio,
                             ILogger<PedidoService> log)
        {
            _repositorio = repositorio;
            _log = log;
        }

        public async Task<List<Pedido>> GetAll()
        {
            _log.LogInformation("Buscando PEDIDOS no service");
            return await _repositorio.GetAll();
        }    
    }
}

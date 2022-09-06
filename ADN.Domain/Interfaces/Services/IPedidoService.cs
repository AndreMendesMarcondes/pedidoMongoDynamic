using ADN.Domain.Domain;

namespace ADN.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<List<Pedido>> GetAll();
    }
}

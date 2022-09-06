using ADN.Domain.Domain;

namespace ADN.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<List<PedidoGetDTO>> GetAll();
        Task Insert(Pedido pedido);
    }
}

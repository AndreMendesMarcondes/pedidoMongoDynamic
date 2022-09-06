using ADN.Domain.Domain;

namespace ADN.Domain.Interfaces.Repositorio
{
    public interface IPedidoRepositorio
    {
        Task<List<Pedido>> GetAll();
        Task Insert(Pedido pedido);
    }
}

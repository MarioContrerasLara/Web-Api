using Web2.Controllers;
using Web2.Models;

namespace Web2.Contracts
{
    public interface IProductoRepository
    {
        void AddProduct(Productos nuevoArticulo);
        void IncreaseQuantity(int id, int cantidad);
        void DecreaseQuantity(int id, int cantidad);
    }
}
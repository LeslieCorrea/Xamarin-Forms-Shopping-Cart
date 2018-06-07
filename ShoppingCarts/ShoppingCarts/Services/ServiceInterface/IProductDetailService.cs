using ShoppingCarts.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCarts.Services.ServiceInterface
{
    public interface IProductDetailService
    {
        Task<List<ProductDetail>> GetProducts();
    }
}
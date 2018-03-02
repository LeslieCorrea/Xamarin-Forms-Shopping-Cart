using ShoppingCarts.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCarts.Services.ServiceInterface
{
    public interface IItemService
    {
        Task<List<Item>> GetItems();
    }
}
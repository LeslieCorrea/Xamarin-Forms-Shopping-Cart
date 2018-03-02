using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ShoppingCarts.Services.ServiceImplementation.ItemService))]

namespace ShoppingCarts.Services.ServiceImplementation
{
    public class ItemService : IItemService
    {
        private List<Item> Items;

        public ItemService()
        {
            Items = new List<Item>();

            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item1"
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item1"
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item2"
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item3"
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item4"
            });
        }

        public async Task<List<Item>> GetItems()
        {
            return await Task.FromResult(Items);
        }
    }
}
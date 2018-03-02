using ShoppingCarts.Helpers;
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
                Name = "Item1",
                Status = Settings.ItemStatus1
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item2",
                Status = Settings.ItemStatus2
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item3",
                Status = Settings.ItemStatus3
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item4",
                Status = Settings.ItemStatus4
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item5",
                Status = Settings.ItemStatus5
            });
        }

        public async Task<List<Item>> GetItems()
        {
            return await Task.FromResult(Items);
        }
    }
}
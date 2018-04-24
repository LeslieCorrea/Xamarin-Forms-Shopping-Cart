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
        }

        public async Task<List<Item>> GetItems()
        {
            Items.Clear();

            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item1",
                Index = 1,
                Status = Settings.ItemStatus1
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item2",
                Index = 2,
                Status = Settings.ItemStatus2
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item3",
                Index = 3,
                Status = Settings.ItemStatus3
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item4",
                Index = 4,
                Status = Settings.ItemStatus4
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item5",
                Index = 5,
                Status = Settings.ItemStatus5
            });

            return await Task.FromResult(Items);
        }
    }
}
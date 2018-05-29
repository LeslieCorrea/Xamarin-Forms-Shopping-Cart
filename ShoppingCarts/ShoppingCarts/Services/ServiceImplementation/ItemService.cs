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
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item6",
                Index = 6,
                Status = Settings.ItemStatus6
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item7",
                Index = 7,
                Status = Settings.ItemStatus7
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item8",
                Index = 8,
                Status = Settings.ItemStatus8
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item9",
                Index = 9,
                Status = Settings.ItemStatus9
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item10",
                Index = 10,
                Status = Settings.ItemStatus10
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item11",
                Index = 11,
                Status = Settings.ItemStatus11
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item12",
                Index = 12,
                Status = Settings.ItemStatus12
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item13",
                Index = 13,
                Status = Settings.ItemStatus13
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item14",
                Index = 14,
                Status = Settings.ItemStatus14
            });
            Items.Add(new Item
            {
                Image = "Items",
                Name = "Item15",
                Index = 15,
                Status = Settings.ItemStatus15
            });

            return await Task.FromResult(Items);
        }
    }
}
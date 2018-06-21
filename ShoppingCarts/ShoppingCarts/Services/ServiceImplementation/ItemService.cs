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
                Image = "https://www.shareicon.net/data/128x128/2016/05/02/758874_package_512x512.png",
                Name = "Soft drinks",
                Index = 1,
                Status = Settings.ItemStatus1,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });

            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2017/01/16/871652_food_512x512.png",
                Name = "Ice cream",
                Index = 2,
                Status = Settings.ItemStatus2,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });

            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/04/759712_jar_512x512.png",
                Name = "Jar",
                Index = 3,
                Status = Settings.ItemStatus3,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });

            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/11/15/853021_jar_512x512.png",
                Name = "Jug",
                Index = 4,
                Status = Settings.ItemStatus4,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2017/01/23/874953_alcohol_512x512.png",
                Name = "Drinks",
                Index = 5,
                Status = Settings.ItemStatus5,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/04/759662_food_512x512.png",
                Name = "Fruits",
                Index = 6,
                Status = Settings.ItemStatus6,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/04/759686_food_512x512.png",
                Name = "Ice cream",
                Index = 7,
                Status = Settings.ItemStatus7,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/08/18/812988_food_512x512.png",
                Name = "Bouwl",
                Index = 8,
                Status = Settings.ItemStatus8,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/02/758874_package_512x512.png",
                Name = "Bottles",
                Index = 9,
                Status = Settings.ItemStatus9,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/04/759686_food_512x512.png",
                Name = "Ice cream",
                Index = 10,
                Status = Settings.ItemStatus10,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/03/759418_food_512x512.png",
                Name = "Fruits",
                Index = 11,
                Status = Settings.ItemStatus11,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/04/759662_food_512x512.png",
                Name = "Fruits",
                Index = 12,
                Status = Settings.ItemStatus12,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/11/15/853021_jar_512x512.png",
                Name = "Jar",
                Index = 13,
                Status = Settings.ItemStatus13,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2016/05/03/759418_food_512x512.png",
                Name = "Fruits",
                Index = 14,
                Status = Settings.ItemStatus14,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });
            Items.Add(new Item
            {
                Image = "https://www.shareicon.net/data/128x128/2017/04/19/884064_box_512x512.png",
                Name = "Sweet box",
                Index = 15,
                Status = Settings.ItemStatus15,
                Description = Constants.Description,
                ShortDescription = Constants.ShortDescription
            });

            return await Task.FromResult(Items);
        }
    }
}
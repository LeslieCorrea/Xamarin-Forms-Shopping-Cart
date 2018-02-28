using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmHelpers;
using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceImplementation;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> ShoppingItems { get; set; }

        public Command GetData { get; set; }

        public readonly IItemService _Service;

        public CartPageViewModel()
        {
            ShoppingItems = new ObservableRangeCollection<Item>();
            GetData = new Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IItemService>();
        }

        private async Task GetDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IEnumerable<Item> ItemsList = await _Service.GetItems();
                ShoppingItems.ReplaceRange(ItemsList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is : " + e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmHelpers;
using ShoppingCarts.Helpers;
using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceInterface;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> ShoppingItems { get; set; }

        public Command GetData { get; set; }

        public Command OnItemButtonClickedCommand { get; set; }

        public readonly IItemService _Service;

        public CartPageViewModel()
        {
            ShoppingItems = new ObservableRangeCollection<Item>();
            GetData = new Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IItemService>();
            OnItemButtonClickedCommand = new Command((e) => ExecuteButtonClick(e));
        }

        private void ExecuteButtonClick(Object e)
        {
            var selectedItem = (Item)e;
            selectedItem.Status = !selectedItem.Status;
            GenericMethods.CartCount();
        }

        private async Task GetDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                List<Item> ItemsList = await _Service.GetItems();

                for (int i = 0; i < ItemsList.Count; i++)
                {
                    if (ItemsList[i].Status)
                        ItemsList[i].ButtonText = "Remove from cart";
                    else
                        ItemsList[i].ButtonText = "Add to cart";
                }

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
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
        public ObservableRangeCollection<Item> ShoppingItems { get; } = new ObservableRangeCollection<Item>();

        public string cartCounter;

        public string CartCounter
        {
            get { return cartCounter; }
            set { SetProperty(ref cartCounter, value); }
        }

        public string buttonText;

        public string ButtonText
        {
            get { return buttonText; }
            set { SetProperty(ref buttonText, value); }
        }

        public Command GetData { get; set; }

        public Command OnItemButtonClickedCommand { get; set; }

        public readonly IItemService _Service;

        public CartPageViewModel()
        {
            GetData = new Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IItemService>();
            OnItemButtonClickedCommand = new Command((e) => ExecuteButtonClick(e));
        }

        private void ExecuteButtonClick(Object e)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var selectedItem = (Item)e;

                List<Item> ItemsList = new List<Item>(ShoppingItems);

                var index = selectedItem.Index;
                if (index == 1)
                    Settings.ItemStatus1 = !Settings.ItemStatus1;
                if (index == 2)
                    Settings.ItemStatus2 = !Settings.ItemStatus2;
                if (index == 3)
                    Settings.ItemStatus3 = !Settings.ItemStatus3;
                if (index == 4)
                    Settings.ItemStatus4 = !Settings.ItemStatus4;
                if (index == 5)
                    Settings.ItemStatus5 = !Settings.ItemStatus5;

                CartCounter = GenericMethods.CartCount().ToString();

                ShoppingItems.Clear();

                if (selectedItem.Status)
                    ItemsList[index - 1].ButtonText = "Add to cart";
                else
                    ItemsList[index - 1].ButtonText = "Remove from cart";

                selectedItem.Status = !selectedItem.Status;

                ShoppingItems.ReplaceRange(ItemsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is " + ex);
            }
            finally
            {
                IsBusy = false;
            }
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

                CartCounter = GenericMethods.CartCount().ToString();
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
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
        //public ObservableRangeCollection<Item> shoppingItems;
        //public ObservableRangeCollection<Item> ShoppingItems { get { return shoppingItems; } set { SetProperty(ref shoppingItems, value); } }

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
            // ShoppingItems = new ObservableRangeCollection<Item>();
            GetData = new Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IItemService>();
            OnItemButtonClickedCommand = new Command(async (e) => await ExecuteButtonClick(e));
        }

        private async Task ExecuteButtonClick(Object e)
        {
            var selectedItem = (Item)e;

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

            //  ShoppingItems.Clear();

            //selectedItem.Status = !selectedItem.Status;

            //if (!selectedItem.Status)
            //    selectedItem.ButtonText = "Add to cart";
            //else
            //    selectedItem.ButtonText = "Remove from cart";

            //  await GetDataCommand();

            CartCounter = GenericMethods.CartCount().ToString();

            // var list = new List<int>(obsCollection);
            List<Item> ItemsList = new List<Item>(ShoppingItems);

            ShoppingItems.Clear();

            if (selectedItem.Status)
                ItemsList[index - 1].ButtonText = "Add to cart";
            else
                ItemsList[index - 1].ButtonText = "Remove from cart";

            ShoppingItems.ReplaceRange(ItemsList);

            //for (int i = 0; i < ItemsList.Count; i++)
            //{
            //    if (ItemsList[i].Status)
            //        ItemsList[i].ButtonText = "Remove from cart";
            //    else
            //        ItemsList[i].ButtonText = "Add to cart";
            //}

            //ShoppingItems.ReplaceRange(ItemsList);

            // MessagingCenter.Send(this, "RefreshPage");

            var a = 1;
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

                var a = 1;
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
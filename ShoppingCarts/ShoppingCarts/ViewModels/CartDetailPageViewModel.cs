using Microsoft.AppCenter.Analytics;
using MvvmHelpers;
using ShoppingCarts.Helpers;
using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class CartDetailPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> ShoppingItems { get; } = new ObservableRangeCollection<Item>();

        public string buttonText;

        public string ButtonText
        {
            get { return buttonText; }
            set { SetProperty(ref buttonText, value); }
        }

        public bool itemsInCart;

        public bool ItemsInCart
        {
            get { return itemsInCart; }
            set { SetProperty(ref itemsInCart, value); }
        }

        public bool noItemsInCart;

        public bool NoItemsInCart
        {
            get { return noItemsInCart; }
            set { SetProperty(ref noItemsInCart, value); }
        }

        public Command GetData { get; set; }

        public Command OnItemButtonClickedCommand { get; set; }

        public Command RemoveAllButton { get; set; }

        public readonly IItemService _Service;

        public CartDetailPageViewModel()
        {
            GetData = new Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IItemService>();
            OnItemButtonClickedCommand = new Command((e) => ExecuteButtonClick(e));
            RemoveAllButton = new Command(() => RemoveAllItems());
        }

        private void RemoveAllItems()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                Settings.ItemStatus1 = false;
                Settings.ItemStatus2 = false;
                Settings.ItemStatus3 = false;
                Settings.ItemStatus4 = false;
                Settings.ItemStatus5 = false;
                Settings.ItemStatus6 = false;
                Settings.ItemStatus7 = false;
                Settings.ItemStatus8 = false;
                Settings.ItemStatus9 = false;
                Settings.ItemStatus10 = false;
                Settings.ItemStatus11 = false;
                Settings.ItemStatus12 = false;
                Settings.ItemStatus13 = false;
                Settings.ItemStatus14 = false;
                Settings.ItemStatus15 = false;

                ShoppingItems.Clear();

                ItemsInCart = false;
                NoItemsInCart = true;

                Analytics.TrackEvent("Remove all items from cart clicked");
            }
            catch (Exception e)
            {
                Console.Write("Exception is " + e);
            }
            finally
            {
                IsBusy = false;
            }
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
                if (index == 6)
                    Settings.ItemStatus6 = !Settings.ItemStatus6;
                if (index == 7)
                    Settings.ItemStatus7 = !Settings.ItemStatus7;
                if (index == 8)
                    Settings.ItemStatus8 = !Settings.ItemStatus8;
                if (index == 9)
                    Settings.ItemStatus9 = !Settings.ItemStatus9;
                if (index == 10)
                    Settings.ItemStatus10 = !Settings.ItemStatus10;
                if (index == 11)
                    Settings.ItemStatus11 = !Settings.ItemStatus11;
                if (index == 12)
                    Settings.ItemStatus12 = !Settings.ItemStatus12;
                if (index == 13)
                    Settings.ItemStatus13 = !Settings.ItemStatus13;
                if (index == 14)
                    Settings.ItemStatus14 = !Settings.ItemStatus14;
                if (index == 15)
                    Settings.ItemStatus15 = !Settings.ItemStatus15;

                ShoppingItems.Clear();

                selectedItem.Status = !selectedItem.Status;

                List<Item> UpdatedList = new List<Item>();

                UpdatedList = ItemsList.Where(item => item.Status).ToList<Item>();

                SetItems(UpdatedList);

                ShoppingItems.ReplaceRange(UpdatedList);
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
                        ItemsList[i].ButtonText = "Remove";
                    else
                        ItemsList[i].ButtonText = "Add to cart";
                }

                List<Item> UpdatedList = new List<Item>();

                UpdatedList = ItemsList.Where(item => item.Status).ToList<Item>();

                SetItems(UpdatedList);

                ShoppingItems.ReplaceRange(UpdatedList);
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

        public void SetItems(List<Item> ItemList)
        {
            if (ItemList.Count > 0)
            {
                ItemsInCart = true;
                NoItemsInCart = false;
            }
            else
            {
                ItemsInCart = false;
                NoItemsInCart = true;
            }
        }
    }
}
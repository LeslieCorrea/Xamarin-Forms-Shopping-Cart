using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmHelpers;
using ShoppingCarts.Helpers;
using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceInterface;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;

namespace ShoppingCarts.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> ShoppingItems { get; } = new ObservableRangeCollection<Item>();
        public ObservableRangeCollection<Grouping<string, Item>> ShoppingItemsGrouped { get; set; } = new ObservableRangeCollection<Grouping<string, Item>>();

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
            ShoppingItems = new ObservableRangeCollection<Item>();
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

                CartCounter = GenericMethods.CartCount().ToString();

                ShoppingItems.Clear();

                if (selectedItem.Status)
                    ItemsList[index - 1].ButtonText = "Add to cart";
                else
                    ItemsList[index - 1].ButtonText = "Remove";

                selectedItem.Status = !selectedItem.Status;

                ShoppingItems.ReplaceRange(ItemsList);

                ShoppingItemsGrouped = new ObservableRangeCollection<Grouping<string, Item>>(GroupItems(ShoppingItems));
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

                ShoppingItems.Clear();

                ShoppingItems.ReplaceRange(ItemsList);

                ShoppingItemsGrouped = new ObservableRangeCollection<Grouping<string, Item>>(GroupItems(ShoppingItems));

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

        private IEnumerable<Grouping<string, Item>> GroupItems(ObservableRangeCollection<Item> ShoppingItems)
        {
            var sorted = ShoppingItems.OrderBy(i => i.Name)
                .GroupBy(i => i.NameSort)
                .Select(i => new Grouping<string, Item>(i.Key, i));

            return sorted;
        }
    }
}
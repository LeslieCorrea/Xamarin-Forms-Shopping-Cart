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

        public Command GetData { get; set; }

        public Command OnItemButtonClickedCommand { get; set; }

        public readonly IItemService _Service;

        public CartDetailPageViewModel()
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

                ShoppingItems.Clear();

                selectedItem.Status = !selectedItem.Status;

                List<Item> UpdatedList = new List<Item>();

                UpdatedList = ItemsList.Where(item => item.Status).ToList<Item>();

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
                        ItemsList[i].ButtonText = "Remove from cart";
                    else
                        ItemsList[i].ButtonText = "Add to cart";
                }

                List<Item> UpdatedList = new List<Item>();

                UpdatedList = ItemsList.Where(item => item.Status).ToList<Item>();

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
    }
}
using System;
using System.Threading.Tasks;
using MvvmHelpers;
using ShoppingCarts.Helpers;
using ShoppingCarts.Model;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class ItemDetailPageViewModel : BaseViewModel
    {
        public string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }

        public string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { SetProperty(ref itemName, value); }
        }

        public string buttonName;

        public string ButtonName
        {
            get { return buttonName; }
            set { SetProperty(ref buttonName, value); }
        }

        public Command ButtonClicked { get; set; }

        public ItemDetailPageViewModel(Item ShoppingItem)
        {
            ImageSource = ShoppingItem.Image;
            ItemName = ShoppingItem.Name;
            ButtonName = ShoppingItem.ButtonText;

            ButtonClicked = new Command(() => GetDataCommand(ShoppingItem));
        }

        private void GetDataCommand(Item ShoppingItem)
        {
            if (!ShoppingItem.Status)
            {
                ButtonName = "Remove from cart";
            }
            else
            {
                ButtonName = "Add to cart";
            }

            var index = ShoppingItem.Index;
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

            ShoppingItem.Status = !ShoppingItem.Status;

            GenericMethods.CartCount();
        }
    }
}
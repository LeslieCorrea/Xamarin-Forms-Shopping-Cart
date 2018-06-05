using MvvmHelpers;
using ShoppingCarts.Helpers;
using ShoppingCarts.Model;
using System;
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

        public string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public Command ButtonClicked { get; set; }

        public ItemDetailPageViewModel(Item ShoppingItem)
        {
            ImageSource = ShoppingItem.Image;
            ItemName = ShoppingItem.Name;
            ButtonName = ShoppingItem.ButtonText;
            Description = ShoppingItem.Description;

            ButtonClicked = new Command(() => OnButtonClickedCommand(ShoppingItem));
        }

        private void OnButtonClickedCommand(Item ShoppingItem)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

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

                ShoppingItem.Status = !ShoppingItem.Status;

                GenericMethods.CartCount();
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
    }
}
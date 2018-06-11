using System;
using MvvmHelpers;
using ShoppingCarts.Model;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class ThirdDetailPageViewModel : BaseViewModel
    {
        private Product product;

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

        public string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public bool status;

        public bool Status
        {
            get { return status; }
            set { SetProperty(ref status, value); }
        }

        public Command ButtonClicked { get; set; }

        public ThirdDetailPageViewModel(Product product)
        {
            this.product = product;
            ButtonClicked = new Command(() => OnButtonClickedCommand(product));
            ImageSource = product.ProductImageUrl;
            ItemName = product.ProductName;
            Description = product.ProductDescription;
            Status = product.ProductStatus;
        }

        private void OnButtonClickedCommand(Product product)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                App.DAUtil.DeleteProduct(product);

                MessagingCenter.Send(this, "Deleted");
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

        public void SwitchToggled(bool toggled)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                product.ProductStatus = toggled;

                App.DAUtil.EditProduct(product);
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
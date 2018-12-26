using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;
using MvvmHelpers;
using ShoppingCarts.Model;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class AddProductPageViewModel : BaseViewModel
    {
        public Command OnSaveClicked { get; set; }

        public string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set { SetProperty(ref imageUrl, value); }
        }

        public string shortDescription;

        public string ShortDescription
        {
            get { return shortDescription; }
            set { SetProperty(ref shortDescription, value); }
        }

        public string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public AddProductPageViewModel()
        {
            OnSaveClicked = new Command(() => SaveDataCommand());
        }

        private void SaveDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                if (Name == null || ImageUrl == null || Description == null || ShortDescription == null)
                {
                    MessagingCenter.Send(this, "NoDataAlert");
                }
                else
                {
                    var vProduct = new Product()
                    {
                        ProductId = Guid.NewGuid(),
                        ProductName = Name,
                        ProductImageUrl = ImageUrl,
                        ProductShortDescription = ShortDescription,
                        ProductDescription = Description,
                        ProductStatus = false
                    };

                    App.DAUtil.SaveProduct(vProduct);

                    Analytics.TrackEvent("Add product clicked", new Dictionary<string, string> {
                       { "Product Name",vProduct.ProductName },
                       { "Product Image Url", vProduct.ProductImageUrl},
                       { "Product Status", vProduct.ProductStatus.ToString()}
                    });

                    MessagingCenter.Send(this, "Success");
                }
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
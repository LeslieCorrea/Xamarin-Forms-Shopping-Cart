using Microsoft.AppCenter.Analytics;
using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdPage : ContentPage
    {
        public ThirdPageViewModel _ViewModel;

        public ThirdPage()
        {
            InitializeComponent();

            BindingContext = _ViewModel = new ThirdPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.GetData.Execute(null);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = ((ListView)sender).SelectedItem as Product;

            if (product == null)
                return;

            Analytics.TrackEvent("Product detail clicked", new Dictionary<string, string> {
               { "ProductName Name",product.ProductName },
               { "Product Image Url", product.ProductImageUrl},
               { "Product Status", product.ProductStatus.ToString()}
            });

            await Navigation.PushAsync(new ThirdDetailPage(product));

            ((ListView)sender).SelectedItem = null;
        }

        private async void OnAddProductButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage());
        }

        private void SwitchToggled(object sender, ToggledEventArgs e)
        {
            var switchItem = (Switch)sender;
            var product = (Product)switchItem.BindingContext;
            _ViewModel.SwitchToggled(product);
        }
    }
}
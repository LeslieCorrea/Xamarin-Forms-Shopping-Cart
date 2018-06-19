using Microsoft.AppCenter.Analytics;
using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPageViewModel _ViewModel;

        public SecondPage()
        {
            InitializeComponent();

            BindingContext = _ViewModel = new SecondPageViewModel();

            MessagingCenter.Subscribe<SecondPageViewModel>(this, "NetworkAlert", async (sender) =>
             {
                 await DisplayAlert("Network Alert", "No network", "Ok");
             });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.GetData.Execute(null);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = ((ListView)sender).SelectedItem as ProductDetail;

            if (product == null)
                return;

            Analytics.TrackEvent("Product detail clicked", new Dictionary<string, string> {
               { "Product Name",product.Name },
               { "Product Image Url", product.ImageUrl}
            });

            await Navigation.PushAsync(new SecondDetailPage(product));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
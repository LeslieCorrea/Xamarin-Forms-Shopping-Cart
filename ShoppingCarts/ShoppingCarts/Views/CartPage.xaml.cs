using Microsoft.AppCenter.Analytics;
using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPageViewModel _ViewModel;

        private bool GotoCartDetailPage = false;

        public CartPage()
        {
            InitializeComponent();

            BindingContext = _ViewModel = new CartPageViewModel();

            NavigationBarView.FirstNameLabel.SetBinding(Label.TextProperty, "CartCounter");

            GotoCartDetailPage = false;
        }

        public CartPage(bool cartImage)
        {
            InitializeComponent();

            BindingContext = _ViewModel = new CartPageViewModel();

            NavigationBarView.FirstNameLabel.SetBinding(Label.TextProperty, "CartCounter");

            GotoCartDetailPage = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() =>
            {
                _ViewModel.GetData.Execute(null);
            });

            if (GotoCartDetailPage)
            {
                GotoCartDetailPage = false;
                await Navigation.PushAsync(new CartDetailPage());
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var shoppingItem = ((ListView)sender).SelectedItem as Item;

            if (shoppingItem == null)
                return;

            Analytics.TrackEvent("Item detail clicked", new Dictionary<string, string> {
               { "Item Name",shoppingItem.Name },
               { "Item Image Url", shoppingItem.Image}
            });

            await Navigation.PushAsync(new ItemDetailPage(shoppingItem));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
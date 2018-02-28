using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPageViewModel _ViewModel;

        public CartPage()
        {
            InitializeComponent();
            BindingContext = _ViewModel = new CartPageViewModel();
        }

        public double clicks = 0;

        //private void BtnIncrement_OnClicked(object sender, EventArgs e)
        //{
        //    clicks += 1;
        //    NavigationBarView.FirstNameLabel.Text = clicks.ToString();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.GetData.Execute(null);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var shoppingItem = ((ListView)sender).SelectedItem as Item;

            if (shoppingItem == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(shoppingItem));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
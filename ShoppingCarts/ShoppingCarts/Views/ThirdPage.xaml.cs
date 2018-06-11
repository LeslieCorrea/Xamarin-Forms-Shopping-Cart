using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
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

            await Navigation.PushAsync(new ThirdDetailPage(product));

            ((ListView)sender).SelectedItem = null;
        }

        private async void OnAddProductButtonClicked(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage());
        }
    }
}
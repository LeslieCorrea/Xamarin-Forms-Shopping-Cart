using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;

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

            MessagingCenter.Subscribe<SecondPageViewModel>(this, "NetworkAlert", (sender) =>
            {
                DisplayAlert("Network Alert", "No network", "Ok");
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

            await Navigation.PushAsync(new SecondDetailPage(product));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
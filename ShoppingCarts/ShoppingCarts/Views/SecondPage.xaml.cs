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

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
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

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private async void OnAddProductButtonClicked(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage());
        }
    }
}
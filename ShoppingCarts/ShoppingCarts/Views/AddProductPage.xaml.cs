using ShoppingCarts.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public AddProductPageViewModel _ViewModel;

        public AddProductPage()
        {
            InitializeComponent();

            BindingContext = _ViewModel = new AddProductPageViewModel();

            MessagingCenter.Subscribe<AddProductPageViewModel>(this, "NoDataAlert", async (sender) =>
            {
                await DisplayAlert("Enter Data Alert", "Please enter data", "Ok");
            });

            MessagingCenter.Subscribe<AddProductPageViewModel>(this, "Success", async (sender) =>
            {
                await DisplayAlert("Success", "Success", "Ok");

                await Navigation.PopAsync();
            });
        }
    }
}
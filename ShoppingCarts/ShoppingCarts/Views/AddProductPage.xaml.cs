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

            MessagingCenter.Subscribe<AddProductPageViewModel>(this, "NoDataAlert", (sender) =>
            {
                DisplayAlert("Enter Data Alert", "Please enter data", "Ok");
            });

            MessagingCenter.Subscribe<AddProductPageViewModel>(this, "Success", (sender) =>
            {
                DisplayAlert("Success", "Success", "Ok");

                Navigation.PopAsync();
            });
        }
    }
}
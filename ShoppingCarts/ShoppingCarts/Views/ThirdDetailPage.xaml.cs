using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdDetailPage : ContentPage
    {
        public ThirdDetailPageViewModel _ViewModel;

        public ThirdDetailPage(Product product)
        {
            InitializeComponent();

            BindingContext = _ViewModel = new ThirdDetailPageViewModel(product);

            MessagingCenter.Subscribe<ThirdDetailPageViewModel>(this, "Deleted", (sender) =>
            {
                Navigation.PopAsync();
            });
        }
    }
}
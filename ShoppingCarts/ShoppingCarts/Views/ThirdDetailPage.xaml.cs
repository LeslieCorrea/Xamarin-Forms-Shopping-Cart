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

            MessagingCenter.Subscribe<ThirdDetailPageViewModel>(this, "Deleted", async (sender) =>
            {
                await Navigation.PopAsync();
            });
        }

        private void SwitchToggled(object sender, ToggledEventArgs e)
        {
            var switchItem = (Switch)sender;
            var isSwitchToggled = switchItem.IsToggled;

            _ViewModel.SwitchToggled(isSwitchToggled);
        }
    }
}
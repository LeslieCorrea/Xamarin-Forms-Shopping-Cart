using Microsoft.AppCenter.Analytics;
using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using System.Collections.Generic;
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

            Analytics.TrackEvent("Switch Toggled", new Dictionary<string, string> {
               { "Is Switch Toggled",isSwitchToggled.ToString() }
            });

            _ViewModel.SwitchToggled(isSwitchToggled);
        }
    }
}
using ShoppingCarts.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;

            MessagingCenter.Subscribe<ContentView.CustomNavigationBar>(this, "presentMenu", (sender) => { IsPresented = !IsPresented; });

            MessagingCenter.Subscribe<CartPageViewModel>(this, "RefreshPage", (sender) =>
            {
                GoToCartPage();
            });

            MessagingCenter.Subscribe<MasterPage>(this, "GoToCartDetailPage", (sender) =>
            {
                GoToCartPage();
            });
        }

        private void GoToCartPage()
        {
            Detail = new NavigationPage(new CartPage(true));
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
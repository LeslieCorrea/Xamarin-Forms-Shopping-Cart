using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();
        }

        private void OnCartImageTapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "GoToCartDetailPage");

            ((MasterDetailPage)Parent).IsPresented = false;
        }
    }
}
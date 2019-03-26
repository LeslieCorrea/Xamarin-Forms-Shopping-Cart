using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowAlert();
        }

        public void ShowAlert()
        {
            Application.Current.MainPage.DisplayAlert("Note:", "Chat with customer care executive here", "OK");
        }
    }
}
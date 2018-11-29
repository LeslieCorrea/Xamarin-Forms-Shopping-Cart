using ShoppingCarts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        public GalleryPageViewModel _ViewModel;

        public GalleryPage()
        {
            InitializeComponent();

            BindingContext = _ViewModel = new GalleryPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _ViewModel.GetData.Execute(null);
        }
    }
}
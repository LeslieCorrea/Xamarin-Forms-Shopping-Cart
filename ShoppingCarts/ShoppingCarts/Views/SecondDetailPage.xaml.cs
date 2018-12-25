using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondDetailPage : ContentPage
    {
        private SecondDetailPageViewModel _ViewModel;

        public SecondDetailPage(ProductDetail productDetail)
        {
            InitializeComponent();

            BindingContext = _ViewModel = new SecondDetailPageViewModel(productDetail);
        }

        public SecondDetailPage(ProductDetail productDetail, string title)
        {
            InitializeComponent();

            BindingContext = _ViewModel = new SecondDetailPageViewModel(productDetail);

            Title = title;
        }
    }
}
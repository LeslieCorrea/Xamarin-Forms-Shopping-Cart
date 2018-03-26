using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailPageViewModel _viewModel;

        public ItemDetailPage(Item ShoppingItem)
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemDetailPageViewModel(ShoppingItem);
        }
    }
}
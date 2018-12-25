using ShoppingCarts.Model;
using ShoppingCarts.ViewModels;
using System;
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

        private void OnFlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var grourp = e.Group;

            Console.WriteLine("Group is " + grourp);

            var item = e.Item as Item;
            var detailPageTitle = "Gallery Item Details";

            var product = new ProductDetail()
            {
                Name = item.Name,
                Description = item.Description,
                ImageUrl = item.Image,
                ShortDescription = item.ShortDescription
            };

            Navigation.PushAsync(new SecondDetailPage(product, detailPageTitle));
        }
    }
}
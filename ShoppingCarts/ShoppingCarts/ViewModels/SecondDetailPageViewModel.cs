using MvvmHelpers;
using ShoppingCarts.Model;

namespace ShoppingCarts.ViewModels
{
    public class SecondDetailPageViewModel : BaseViewModel
    {
        public string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }

        public string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { SetProperty(ref itemName, value); }
        }

        public string description;

        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public SecondDetailPageViewModel(ProductDetail productDetail)
        {
            ImageSource = productDetail.ImageUrl;
            ItemName = productDetail.Name;
            Description = productDetail.Description;
        }
    }
}
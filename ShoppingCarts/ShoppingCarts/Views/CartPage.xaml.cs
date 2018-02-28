using ShoppingCarts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPageViewModel _ViewModel;

        public CartPage()
        {
            InitializeComponent();
            BindingContext = _ViewModel = new CartPageViewModel();
        }

        public double clicks = 0;

        //private void BtnIncrement_OnClicked(object sender, EventArgs e)
        //{
        //    clicks += 1;
        //    NavigationBarView.FirstNameLabel.Text = clicks.ToString();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ViewModel.GetData.Execute(null);
        }
    }
}
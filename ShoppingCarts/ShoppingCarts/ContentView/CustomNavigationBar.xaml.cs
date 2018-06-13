using ShoppingCarts.Views;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingCarts.ContentView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavigationBar : Xamarin.Forms.ContentView
    {
        public CustomNavigationBar()
        {
            InitializeComponent();
        }

        public Label FirstNameLabel
        {
            get
            {
                return labelText;
            }
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "presentMenu");
        }

        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(
        "Title",
        typeof(string),
        typeof(CustomNavigationBar),
        "this is Title",
        propertyChanged: OnTitlePropertyChanged
        );

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var thisView = bindable as CustomNavigationBar;
            var title = newValue.ToString();
            //thisView.lblTitle.Text = title;
        }

        private void Tapcart_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartDetailPage());
        }
    }
}
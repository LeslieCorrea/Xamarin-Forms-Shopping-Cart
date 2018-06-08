using ShoppingCarts.Helpers;
using Xamarin.Forms;

namespace ShoppingCarts
{
    public partial class App : Application
    {
        private static DataAccess dbUtils;

        public App()
        {
            InitializeComponent();

            MainPage = new Views.MainPage();
        }

        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
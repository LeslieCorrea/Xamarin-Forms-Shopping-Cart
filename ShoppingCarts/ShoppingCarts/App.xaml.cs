using DLToolkit.Forms.Controls;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using ShoppingCarts.Helpers;
using Xamarin.Forms;

namespace ShoppingCarts
{
    public partial class App : Application
    {
        public static string User = "UserOne";
        private static DataAccess dbUtils;

        public App()
        {
            InitializeComponent();

            FlowListView.Init();

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

            // App center analytices and crashes
            AppCenter.Start(ApiKeys.AndroidAppCenterKey + ApiKeys.iOSAppCenterKey, typeof(Analytics), typeof(Crashes));
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
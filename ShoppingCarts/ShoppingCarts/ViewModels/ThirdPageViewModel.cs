using System;
using System.Threading.Tasks;
using MvvmHelpers;
using ShoppingCarts.Model;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class ThirdPageViewModel : BaseViewModel
    {
        public Command GetData { get; set; }

        public Command OnItemButtonClickedCommand { get; set; }

        public ObservableRangeCollection<Product> Products { get; } = new ObservableRangeCollection<Product>();

        public ThirdPageViewModel()
        {
            GetData = new Command(() => GetDataCommand());
            OnItemButtonClickedCommand = new Command((e) => ExecuteButtonClick(e));
        }

        private void ExecuteButtonClick(object e)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                var selectedItem = (Product)e;
                App.DAUtil.DeleteProduct(selectedItem);

                var vList = App.DAUtil.GetAllProducts();
                Products.Clear();
                Products.ReplaceRange(vList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is " + ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void GetDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                var vList = App.DAUtil.GetAllProducts();
                Products.Clear();
                Products.ReplaceRange(vList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is : " + e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
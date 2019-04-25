using System;
using MvvmHelpers;
using ShoppingCarts.Model;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingCarts.ViewModels
{
    public class ThirdPageViewModel : BaseViewModel
    {
        public Command GetData { get; set; }

        public Command OnItemButtonClickedCommand { get; set; }

        public ObservableRangeCollection<Product> Products { get; } = new ObservableRangeCollection<Product>();
        public ObservableRangeCollection<Grouping<string, Product>> ProductsGrouped { get; set; } = new ObservableRangeCollection<Grouping<string, Product>>();

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

                ProductsGrouped = new ObservableRangeCollection<Grouping<string, Product>>(GroupItems(Products));
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

                ProductsGrouped = new ObservableRangeCollection<Grouping<string, Product>>(GroupItems(Products));
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

        public void SwitchToggled(Product product)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                App.DAUtil.EditProduct(product);
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

        private IEnumerable<Grouping<string, Product>> GroupItems(ObservableRangeCollection<Product> Products)
        {
            var sorted = Products.OrderBy(p => p.ProductName)
                .GroupBy(p => p.ProductName[0].ToString().ToUpper())
                .Select(p => new Grouping<string, Product>(p.Key, p));

            return sorted;
        }
    }
}
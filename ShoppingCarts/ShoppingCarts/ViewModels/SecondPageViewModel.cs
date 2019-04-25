using MvvmHelpers;
using ShoppingCarts.Helpers;
using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace ShoppingCarts.ViewModels
{
    public class SecondPageViewModel : BaseViewModel
    {
        public Command GetData { get; set; }
        public readonly IProductDetailService _Service;
        private List<ProductDetail> ItemsList;
        public ObservableRangeCollection<ProductDetail> Products { get; } = new ObservableRangeCollection<ProductDetail>();
        public ObservableRangeCollection<Grouping<string, ProductDetail>> ProductsGrouped { get; set; } = new ObservableRangeCollection<Grouping<string, ProductDetail>>();

        public SecondPageViewModel()
        {
            _Service = DependencyService.Get<IProductDetailService>();
            ItemsList = new List<ProductDetail>();
            GetData = new Command(async () => await GetDataCommand());
        }

        private async Task GetDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                if (NetworkCheck.IsInternet())
                {
                    ItemsList = await _Service.GetProducts();
                    Products.Clear();
                    Products.ReplaceRange(ItemsList);

                    var sorted = Products.OrderBy(p => p.Name)
                   .GroupBy(p => p.NameSort)
                   .Select(p => new Grouping<string, ProductDetail>(p.Key, p));

                    ProductsGrouped = new ObservableRangeCollection<Grouping<string, ProductDetail>>(sorted);
                }
                else
                {
                    MessagingCenter.Send(this, "NetworkAlert");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception is : " + ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
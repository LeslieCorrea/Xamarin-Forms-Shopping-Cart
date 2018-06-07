using ShoppingCarts.Helpers;
using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ShoppingCarts.Services.ServiceImplementation.ProdectDetailService))]

namespace ShoppingCarts.Services.ServiceImplementation
{
    public class ProdectDetailService : IProductDetailService
    {
        public List<ProductDetail> ProductDetails;
        public HttpManager httpManager;

        public ProdectDetailService()
        {
            ProductDetails = new List<ProductDetail>();
            httpManager = new HttpManager();
        }

        public async Task<List<ProductDetail>> GetProducts()
        {
            var response = await httpManager.GetAsync<ProductDetail>(Constants.URL);

            return response;
        }
    }
}
using ShoppingCarts.Helpers.Interface;
using ShoppingCarts.Model;
using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingCarts.Helpers
{
    public class DataAccess
    {
        private SQLiteConnection dbConn;

        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<Product>();
        }

        public List<Product> GetAllProducts()
        {
            return dbConn.Query<Product>("Select * From [Product]");
        }

        public int SaveEmployee(Product aProduct)
        {
            return dbConn.Insert(aProduct);
        }

        public int DeleteEmployee(Product aProduct)
        {
            return dbConn.Delete(aProduct);
        }

        public int EditEmployee(Product aProduct)
        {
            return dbConn.Update(aProduct);
        }
    }
}
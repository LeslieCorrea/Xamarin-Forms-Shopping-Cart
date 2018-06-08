using SQLite.Net;

namespace ShoppingCarts.Helpers.Interface
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
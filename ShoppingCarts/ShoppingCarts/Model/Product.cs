using SQLite.Net.Attributes;

namespace ShoppingCarts.Model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public long ProductId
        { get; set; }

        [NotNull]
        public string ProductName
        { get; set; }

        public string ImageUrl
        { get; set; }

        public string ShortDescription
        { get; set; }

        public string Description
        { get; set; }

        public bool Status
        { get; set; }
    }
}
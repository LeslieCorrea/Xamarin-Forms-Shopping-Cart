using SQLite.Net.Attributes;
using System;

namespace ShoppingCarts.Model
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public Guid ProductId
        { get; set; }

        [NotNull]
        public string ProductName
        { get; set; }

        public string ProductImageUrl
        { get; set; }

        public string ProductShortDescription
        { get; set; }

        public string ProductDescription
        { get; set; }

        public bool ProductStatus
        { get; set; }
    }
}
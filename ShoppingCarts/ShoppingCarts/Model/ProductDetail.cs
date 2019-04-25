namespace ShoppingCarts.Model
{
    public class ProductDetail
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name) || Name.Length == 0)
                    return "?";

                return Name[0].ToString().ToUpper();
            }
        }
    }
}
namespace ShoppingCarts.Helpers
{
    public static class GenericMethods
    {
        public static int CartCount()
        {
            return Calculate();
        }

        public static int Calculate()
        {
            int count = 0;

            if (Settings.ItemStatus1)
                count = count + 1;
            if (Settings.ItemStatus2)
                count = count + 1;
            if (Settings.ItemStatus3)
                count = count + 1;
            if (Settings.ItemStatus4)
                count = count + 1;
            if (Settings.ItemStatus5)
                count = count + 1;
            if (Settings.ItemStatus6)
                count = count + 1;
            if (Settings.ItemStatus7)
                count = count + 1;
            if (Settings.ItemStatus8)
                count = count + 1;
            if (Settings.ItemStatus9)
                count = count + 1;
            if (Settings.ItemStatus10)
                count = count + 1;
            if (Settings.ItemStatus11)
                count = count + 1;
            if (Settings.ItemStatus12)
                count = count + 1;
            if (Settings.ItemStatus13)
                count = count + 1;
            if (Settings.ItemStatus14)
                count = count + 1;
            if (Settings.ItemStatus15)
                count = count + 1;

            return count;
        }
    }
}
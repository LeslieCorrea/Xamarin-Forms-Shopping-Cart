using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ShoppingCarts.Helpers
{
    public static class Settings
    {
        private static ISettings Setting
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static bool ItemStatus1
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus1", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus1", value);
            }
        }

        public static bool ItemStatus2
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus2", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus2", value);
            }
        }

        public static bool ItemStatus3
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus3", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus3", value);
            }
        }

        public static bool ItemStatus4
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus4", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus4", value);
            }
        }

        public static bool ItemStatus5
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus5", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus5", value);
            }
        }
    }
}
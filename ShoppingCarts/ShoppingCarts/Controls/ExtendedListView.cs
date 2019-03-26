using System;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingCarts.Controls
{
    public class ExtendedListView : ListView
    {
        public ExtendedListView() : this(ListViewCachingStrategy.RecycleElement)
        {
        }

        public ExtendedListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            this.ItemSelected += OnItemSelected;
            this.ItemTapped += OnItemTapped;
            this.ItemAppearing += OnItemAppearing;
            this.ItemDisappearing += OnItemDisappering;
        }

        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create(nameof(TappedCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        public static readonly BindableProperty ItemAppearingCommandProperty =
            BindableProperty.Create(nameof(ItemAppearingCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

        public ICommand ItemAppearingCommand
        {
            get { return (ICommand)GetValue(ItemAppearingCommandProperty); }
            set { SetValue(ItemAppearingCommandProperty, value); }
        }

        public static readonly BindableProperty ItemDisappearingCommandProperty =
         BindableProperty.Create(nameof(ItemDisappearingCommand), typeof(ICommand), typeof(ExtendedListView), default(ICommand));

        public ICommand ItemDisappearingCommand
        {
            get { return (ICommand)GetValue(ItemDisappearingCommandProperty); }
            set { SetValue(ItemDisappearingCommandProperty, value); }
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ExtendedListView)sender;
            if (e == null) return;
            listView.SelectedItem = null;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (TappedCommand != null)
            {
                TappedCommand?.Execute(e.Item);
            }
            SelectedItem = null;
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (ItemAppearingCommand != null)
            {
                ItemAppearingCommand?.Execute(e.Item);
            }
        }

        private void OnItemDisappering(object sender, ItemVisibilityEventArgs e)
        {
            ItemDisappearingCommand?.Execute(e.Item);
        }

        public void ScrollToFirst()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (ItemsSource != null && ItemsSource.Cast<object>().Count() > 0)
                    {
                        var msg = ItemsSource.Cast<object>().FirstOrDefault();
                        if (msg != null)
                        {
                            ScrollTo(msg, ScrollToPosition.Start, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            });
        }

        public void ScrollToLast()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    if (ItemsSource != null && ItemsSource.Cast<object>().Count() > 0)
                    {
                        var msg = ItemsSource.Cast<object>().LastOrDefault();
                        if (msg != null)
                        {
                            ScrollTo(msg, ScrollToPosition.End, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            });
        }
    }
}
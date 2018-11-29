using MvvmHelpers;
using ShoppingCarts.Model;
using ShoppingCarts.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingCarts.ViewModels
{
    public class GalleryPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> ItemsGallery { get; } = new ObservableRangeCollection<Item>();

        public Command GetData { get; set; }

        public readonly IItemService _Service;

        public GalleryPageViewModel()
        {
            GetData = new Command(async () => await GetDataCommand());
            _Service = DependencyService.Get<IItemService>();
        }

        private async System.Threading.Tasks.Task GetDataCommand()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                List<Item> ItemsList = await _Service.GetItems();

                ItemsGallery.Clear();
                ItemsGallery.ReplaceRange(ItemsList);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is : " + e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
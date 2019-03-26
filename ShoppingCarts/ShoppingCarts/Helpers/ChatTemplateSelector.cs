using ShoppingCarts.Model;
using ShoppingCarts.Views;
using Xamarin.Forms;

namespace ShoppingCarts.Helpers
{
    internal class ChatTemplateSelector : DataTemplateSelector
    {
        private DataTemplate incomingDataTemplate;
        private DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingMessageViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingMessageViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
                return null;

            return (messageVm.User == App.User) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
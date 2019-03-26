using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using ShoppingCarts.Controls;
using ShoppingCarts.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEditorControl), typeof(CustomEditorRenderer))]

namespace ShoppingCarts.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        private bool initial = true;
        private Drawable originalBackground;

        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (initial)
                {
                    originalBackground = Control.Background;
                    initial = false;
                }
                Control.SetMaxLines(5);
            }

            if (e.NewElement != null)
            {
                var customControl = (ExtendedEditorControl)Element;
                if (customControl.HasRoundedCorner)
                {
                    ApplyBorder();
                }

                if (!string.IsNullOrEmpty(customControl.Placeholder))
                {
                    Control.Hint = customControl.Placeholder;
                    Control.SetHintTextColor(customControl.PlaceholderColor.ToAndroid());
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var customControl = (ExtendedEditorControl)Element;

            if (ExtendedEditorControl.PlaceholderProperty.PropertyName == e.PropertyName)
            {
                Control.Hint = customControl.Placeholder;
            }
            else if (ExtendedEditorControl.PlaceholderColorProperty.PropertyName == e.PropertyName)
            {
                Control.SetHintTextColor(customControl.PlaceholderColor.ToAndroid());
            }
            else if (ExtendedEditorControl.HasRoundedCornerProperty.PropertyName == e.PropertyName)
            {
                if (customControl.HasRoundedCorner)
                {
                    ApplyBorder();
                }
                else
                {
                    this.Control.Background = originalBackground;
                }
            }
        }

        private void ApplyBorder()
        {
            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(10);
            gd.SetStroke(2, Color.Black.ToAndroid());
            this.Control.Background = gd;
        }
    }
}
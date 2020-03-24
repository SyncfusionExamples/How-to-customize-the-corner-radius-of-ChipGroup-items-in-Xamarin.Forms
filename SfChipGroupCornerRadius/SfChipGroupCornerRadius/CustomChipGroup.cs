using Syncfusion.XForms.Buttons;
using Xamarin.Forms;

namespace SfChipGroupCornerRadius
{
    public class CustomChipGroup : SfChipGroup
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(Thickness), typeof(CustomChipGroup), GetDefaultCornerRadius(), BindingMode.TwoWay, null, null);

        public Thickness CornerRadius
        {
            get { return (Thickness)GetValue(CornerRadiusProperty); }
            set { this.SetValue(CornerRadiusProperty, value); }
        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            child.ChildAdded += Child_ChildAdded;
        }

        private void Child_ChildAdded(object sender, ElementEventArgs e)
        {
            var sfChip = e.Element as SfChip;
            if (sfChip != null)
            {
                sfChip.SetBinding(SfChip.CornerRadiusProperty, new Binding() { Path = "CornerRadius", Source = this, Mode = BindingMode.TwoWay });
            }
        }

        protected override void OnChildRemoved(Element child)
        {
            child.ChildAdded -= Child_ChildAdded;
            base.OnChildRemoved(child);
        }

        private static Thickness GetDefaultCornerRadius()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                return 40d;
            }

            return 15d;
        }
    }
}

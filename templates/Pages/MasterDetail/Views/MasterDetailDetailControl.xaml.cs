using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

using Param_ItemNamespace.Models;

namespace Param_ItemNamespace.Views
{
    public sealed partial class MasterDetailDetailControl : UserControl
    {
        public Order MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Order; }
            set
            {
                SetValue(MasterMenuItemProperty, value);
                ConnectedAnimation heroAnim = ConnectedAnimationService.GetForCurrentView().GetAnimation("hero");
                ConnectedAnimation titleAnim = ConnectedAnimationService.GetForCurrentView().GetAnimation("title");
                if (!(heroAnim == null) && !(titleAnim == null))
                {
                    heroAnim.TryStart(destIcon);
                    titleAnim.TryStart(destTitle);
                }
            }
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem",typeof(Order),typeof(MasterDetailDetailControl),new PropertyMetadata(null));

        public MasterDetailDetailControl()
        {
            InitializeComponent();
        }
    }
}

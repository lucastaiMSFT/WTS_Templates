using Param_ItemNamespace.Services;
using Param_ItemNamespace.ViewModels;
using Param_ItemNamespace.Models;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

using System.Collections.Generic;


namespace Param_ItemNamespace.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        public MasterDetailPage()
        {
            InitializeComponent();
        }

         private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e?.ClickedItem as Order;
            if (item != null)
            {

                foreach (var fonticon in GetAllVisualChildrenOfType<FontIcon>(MasterListView))
                {
                    var element = (UIElement)fonticon;
                    bool gotCorrect = (item.HashIdentIcon == (string)fonticon.Tag);
                    if (gotCorrect)
                    {
                        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("hero", element);
                    }
                }

                foreach (var textblock in GetAllVisualChildrenOfType<TextBlock>(MasterListView))
                {
                    var element = (UIElement)textblock;
                    bool gotCorrect = (item.HashIdentTitle == (string)textblock.Tag);
                    if (gotCorrect)
                    {
                        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("title", element);
                    }
                }
            }
        }
        private IEnumerable<T> GetAllVisualChildrenOfType<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    yield return (T)child;
                else
                {
                    for (int j = 0; j < VisualTreeHelper.GetChildrenCount(child); j++)
                    {
                        IEnumerable<T> childrenOfChild = GetAllVisualChildrenOfType<T>(child);
                        foreach (T subChild in childrenOfChild)
                        {
                            yield return subChild;
                        }
                    }
                }
            }
        }
    }
}

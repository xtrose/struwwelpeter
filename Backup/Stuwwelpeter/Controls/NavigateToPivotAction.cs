using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interactivity;
using System.Windows.Navigation;

namespace Struwwelpeter
{
    //
    // If you want your Action to target elements other than its parent, extend your class
    // from TargetedTriggerAction instead of from TriggerAction
    //
    public class NavigateToPivotAction : TriggerAction<DependencyObject>
    {
        public NavigateToPivotAction()
        {
            // Insert code required on object creation below this point.
        }

        protected override void Invoke(object o)
        {
            // Insert code that defines what the Action will do when triggered/invoked.
            (Application.Current.RootVisual as INavigate).Navigate(new Uri(this.TargetPage.OriginalString + "?PivotIndex=" + this.PivotIndex, UriKind.Relative));
        }

        public static readonly DependencyProperty TargetPageProperty = DependencyProperty.Register("TargetPage", typeof(Uri), typeof(NavigateToPivotAction), null);

        [System.ComponentModel.CategoryAttribute("Common Properties")]
        /// <summary>
        /// Gets or sets the XAML file to navigate to. This is a dependency property.
        /// </summary>
        public Uri TargetPage
        {
            get
            {
                return (Uri)base.GetValue(TargetPageProperty);
            }
            set
            {
                base.SetValue(TargetPageProperty, value);
            }
        }

        public static readonly DependencyProperty PivotIndexProperty = DependencyProperty.Register("PivotIndex", typeof(int), typeof(NavigateToPivotAction), null);

        [System.ComponentModel.CategoryAttribute("Common Properties")]
        /// <summary>
        /// Gets or sets the XAML file to navigate to. This is a dependency property.
        /// </summary>
        public int PivotIndex
        {
            get
            {
                return (int)base.GetValue(PivotIndexProperty);
            }
            set
            {
                base.SetValue(PivotIndexProperty, value);
            }
        }
    }
}
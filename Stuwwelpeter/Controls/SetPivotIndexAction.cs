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
using Microsoft.Phone.Controls;

namespace Struwwelpeter
{
    //
    // If you want your Action to target elements other than its parent, extend your class
    // from TargetedTriggerAction instead of from TriggerAction
    //
    public class SetPivotIndexAction : TargetedTriggerAction<DependencyObject>
    {
        public SetPivotIndexAction()
        {
            // Insert code required on object creation below this point.
        }

        protected override void Invoke(object o)
        {
            // Insert code that defines what the Action will do when triggered/invoked.

            PhoneApplicationPage page = null;
            FrameworkElement p = this.Target as FrameworkElement;
            while (p != null)
            {
                if (typeof(PhoneApplicationPage).IsAssignableFrom(p.GetType()))
                {
                    page = (PhoneApplicationPage)p;
                    break;
                }
                p = p.Parent as FrameworkElement;
            }

            if (page != null)
            {
                Pivot pivot = this.Target as Pivot;
                if (pivot != null)
                {
                    string pivotIndex = "";
                    if (page.NavigationContext.QueryString.TryGetValue("PivotIndex", out pivotIndex))
                    {
                        pivot.SelectedIndex = int.Parse(pivotIndex);
                    }
                }
            }
        }
    }
}
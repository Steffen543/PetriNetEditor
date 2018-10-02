using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petri.Editor.Helper
{
    public class PetriNetCoordinates
    {
        private ItemsControl itemsControl;

        public double X => GetPosition().X;
        public double Y => GetPosition().Y;

        public PetriNetCoordinates(ItemsControl control)
        {
            itemsControl = control;
        }

        private Point GetPosition()
        {
            var canvas = VisualTreeHelper.GetChild(itemsControl, 0) as UIElement;
            var pos = Mouse.GetPosition(canvas);
            double size = (double)Application.Current.FindResource("TransitionSize");
           

            var realCanvas = itemsControl.GetVisualChild<Canvas>();
            var transform = realCanvas.LayoutTransform as ScaleTransform;

            var halfSizeX = size / 2 * transform.ScaleX;
            var halfSizeY = size / 2 * transform.ScaleY;

            pos.X = (pos.X - halfSizeX) / transform.ScaleX;
            pos.Y = (pos.Y - halfSizeY) / transform.ScaleY;

            return pos;
        }


    }

    public static class Test
    {
        public static T GetVisualChild<T>(this Visual referenceVisual) where T : Visual
        {
            Visual child = null;
            for (Int32 i = 0; i < VisualTreeHelper.GetChildrenCount(referenceVisual); i++)
            {
                child = VisualTreeHelper.GetChild(referenceVisual, i) as Visual;
                if (child != null && (child.GetType() == typeof(T)))
                {
                    break;
                }
                else if (child != null)
                {
                    child = GetVisualChild<T>(child);
                    if (child != null && (child.GetType() == typeof(T)))
                    {
                        break;
                    }
                }
            }
            return child as T;
        }
    }

   
}

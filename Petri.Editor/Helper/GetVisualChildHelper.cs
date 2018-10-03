using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Petri.Editor.Helper
{
    public static class GetVisualChildHelper
    {
        public static IEnumerable<DependencyObject> fetChilds(this DependencyObject parent)
        {
            if (parent == null) yield break;

            //use the logical tree for content / framework elements
            foreach (object obj in LogicalTreeHelper.GetChildren(parent))
            {
                var depObj = obj as DependencyObject;
                if (depObj != null)
                    yield return depObj;
            }

            //use the visual tree for Visual / Visual3D elements
            if (parent is Visual || parent is Visual3D)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    yield return VisualTreeHelper.GetChild(parent, i);
                }
            }
        }

        public static T GetVisualChildExtension<T>(this Visual referenceVisual) where T : Visual
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
                    child = GetVisualChildExtension<T>(child);
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


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
            var pos = Mouse.GetPosition(itemsControl);
            double size = (double)Application.Current.FindResource("NetObjectSize");

            var halfSizeX = size / 2;
            var halfSizeY = size / 2;
            pos.X = (pos.X - halfSizeX);
            pos.Y = (pos.Y - halfSizeY);

            return pos;
        }


    }

  

}

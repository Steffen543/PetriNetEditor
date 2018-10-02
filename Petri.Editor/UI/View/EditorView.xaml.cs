using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Petri.Editor.UI.View
{
    /// <summary>
    /// Interaktionslogik für EditorView.xaml
    /// </summary>
    public partial class EditorView : UserControl
    {
        public EditorView()
        {
            InitializeComponent();
        }

        private void Arrow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //e.Handled = true;
        }


        private bool isMoving = false;                  //False - ignore mouse movements and don't scroll
        private bool isDeferredMovingStarted = false;   //True - Mouse down -> Mouse up without moving -> Move; False - Mouse down -> Move
        private Point? startPosition = null;
        private double slowdown = 200;                  //The number 200 is found from experiments, it should be corrected



        private void ScrollViewer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.isMoving == true) //Moving with a released wheel and pressing a button
                this.CancelScrolling();
            else if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
            {
                if (this.isMoving == false) //Pressing a wheel the first time
                {
                    this.isMoving = true;
                    this.startPosition = e.GetPosition(sender as IInputElement);
                    this.isDeferredMovingStarted = true; //the default value is true until the opposite value is set

                    //this.AddScrollSign(e.GetPosition(this.topLayer).X, e.GetPosition(this.topLayer).Y);
                }
            }
        }

        private void ScrollViewer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Released && this.isDeferredMovingStarted != true)
                this.CancelScrolling();
        }

        private void CancelScrolling()
        {
            this.isMoving = false;
            this.startPosition = null;
            this.isDeferredMovingStarted = false;
            //this.RemoveScrollSign();
        }

        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            var sv = sender as ScrollViewer;

            if (this.isMoving && sv != null)
            {
                this.isDeferredMovingStarted = false; //standard scrolling (Mouse down -> Move)

                var currentPosition = e.GetPosition(sv);
                var offset = currentPosition - startPosition.Value;
                offset.Y /= slowdown;
                offset.X /= slowdown;

                //if(Math.Abs(offset.Y) > 25.0/slowdown)  //Some kind of a dead space, uncomment if it is neccessary
                sv.ScrollToVerticalOffset(sv.VerticalOffset - offset.Y);
                sv.ScrollToHorizontalOffset(sv.HorizontalOffset - offset.X);
            }
        }



    }
}

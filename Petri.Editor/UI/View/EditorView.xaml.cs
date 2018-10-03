using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Petri.Editor.Helper;

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


            MainScrollViewer.ScrollChanged += OnScrollViewerScrollChanged;
            MainScrollViewer.MouseRightButtonUp += OnMouseRightButtonUp;
            MainScrollViewer.PreviewMouseRightButtonUp += OnMouseRightButtonUp;
            MainScrollViewer.PreviewMouseWheel += OnPreviewMouseWheel;
            MainScrollViewer.PreviewMouseRightButtonDown += OnMouseRightButtonDown;
            MainScrollViewer.MouseMove += OnMouseMove;

            ZoomSlider.ValueChanged += OnSliderValueChanged;
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(MainScrollViewer);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                MainScrollViewer.ScrollToHorizontalOffset(MainScrollViewer.HorizontalOffset - dX);
                MainScrollViewer.ScrollToVerticalOffset(MainScrollViewer.VerticalOffset - dY);
            }
        }

        void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(MainScrollViewer);
            if (mousePos.X <= MainScrollViewer.ViewportWidth && mousePos.Y < MainScrollViewer.ViewportHeight)
            {
                MainScrollViewer.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(MainScrollViewer);
            }
        }

        void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(MainScrollViewer);

            if (e.Delta > 0)
            {
                ZoomSlider.Value += 0.1;
            }
            if (e.Delta < 0)
            {
                ZoomSlider.Value -= 0.1;
            }

            e.Handled = true;
        }

        void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainScrollViewer.Cursor = Cursors.Arrow;
            MainScrollViewer.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var realCanvas = MainItemsControl.GetVisualChildExtension<Canvas>();
            var transform = realCanvas.LayoutTransform as ScaleTransform;

        
            transform.ScaleX = e.NewValue;
            transform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(MainScrollViewer.ViewportWidth / 2, MainScrollViewer.ViewportHeight / 2);
            lastCenterPositionOnTarget = MainScrollViewer.TranslatePoint(centerOfViewport, MainItemsControl);
        }

        void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
       
                        var centerOfViewport = new Point(MainScrollViewer.ViewportWidth / 2, MainScrollViewer.ViewportHeight / 2);
                        Point centerOfTargetNow = MainScrollViewer.TranslatePoint(centerOfViewport, MainItemsControl);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(MainItemsControl);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / MainItemsControl.Width;
                    double multiplicatorY = e.ExtentHeight / MainItemsControl.Height;

                    double newOffsetX = MainScrollViewer.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = MainScrollViewer.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    MainScrollViewer.ScrollToHorizontalOffset(newOffsetX);
                    MainScrollViewer.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }


        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;

    }

}

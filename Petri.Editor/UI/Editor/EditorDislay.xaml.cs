using Petri.Editor.Dialogs;
using Petri.Editor.Helper;
using Petri.Logic.Components;
using Petri.Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Petri.Editor.UI.Editor
{
    /// <summary>
    /// Interaktionslogik für EditorDislay.xaml
    /// </summary>
    public partial class EditorDislay : UserControl
    {
        public AddConnectionHelper AddConnectionHelper;

   
        public string CommandText
        {
            set { SetValue(CommandTextProperty, value); }
            get { return (string)GetValue(CommandTextProperty); }
        }

        /// <summary>
        ///     Identifies the Y1 dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandTextProperty =
            DependencyProperty.Register("CommandText",
                typeof(string), typeof(EditorDislay),
                new FrameworkPropertyMetadata(String.Empty,
                        FrameworkPropertyMetadataOptions.AffectsMeasure));

        public EditorDislay()
        {
            CommandText = "Alo";
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
            if (!(sender is ItemsControl))
                return;

            var itemsControl = sender as ItemsControl;
            var canvas = VisualTreeHelper.GetChild(itemsControl, 0) as Canvas;
            var pos = Mouse.GetPosition(canvas);
            double size = (double)Application.Current.FindResource("TransitionSize");

            var x = pos.X - size / 2;
            var y = pos.Y - size / 2;

            Console.WriteLine($"X: {x}, Y: {y}");
            switch(((EditorViewModel)DataContext).EditorMode)
            {
                case EditorMode.AddStelle:
                    ((EditorViewModel)DataContext).AddStelle(x, y, "neu");
                    break;
                case EditorMode.AddTransition:
                    ((EditorViewModel)DataContext).AddTransition(x, y, "neu");
                    break;
            }
         
        }

        private void Arrow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Component_CLick(object sender, RoutedEventArgs e)
        {
            var clickedComp = (sender as Button).DataContext as IConnectable;
            var viewModel = ((EditorViewModel)DataContext);
            var editMode = ((EditorViewModel)DataContext).EditorMode;

            switch (editMode)
            {
                case EditorMode.AddConnection:

                    if(AddConnectionHelper == null)
                    {
                        AddConnectionHelper = new AddConnectionHelper();
                        AddConnectionHelper.Source = clickedComp;
                    }
                    else if(AddConnectionHelper.Destination == null)
                    {
                        AddConnectionHelper.Destination = clickedComp;
                        ConnectionWindow connWindow = new ConnectionWindow();
                        connWindow.DataContext = AddConnectionHelper;
                        connWindow.ShowDialog();
                     
                        viewModel.AddConnection(AddConnectionHelper.Source, AddConnectionHelper.Destination, AddConnectionHelper.Value, AddConnectionHelper.Description);
                        AddConnectionHelper = null;
                        viewModel.EditorMode = EditorMode.Nothing;
                    }
                    break;
                case EditorMode.Nothing:
                    if(clickedComp is Transition transition)
                    {
                        transition.Execute();
                    }
                    break;
            }


        }
    }
}

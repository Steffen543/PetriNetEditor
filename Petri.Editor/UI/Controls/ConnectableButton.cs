using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Petri.Editor.UI.ViewModel;
using Petzold.Media2D;

namespace Petri.Editor.Controls
{
    public class ConnectableButton : Button
    {
        public static readonly DependencyProperty EditorModeProperty =
            DependencyProperty.Register("EditorMode",
                typeof(EditorMode), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(UI.ViewModel.EditorMode.Execute,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public EditorMode EditorMode
        {
            set => SetValue(EditorModeProperty, value);
            get => (EditorMode)GetValue(EditorModeProperty);
        }


        public static readonly DependencyProperty IsMarkedAsSourceProperty =
            DependencyProperty.Register("IsMarkedAsSource",
                typeof(bool), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public bool IsMarkedAsSource
        {
            set => SetValue(IsMarkedAsSourceProperty, value);
            get => (bool)GetValue(IsMarkedAsSourceProperty);
        }


        public static readonly DependencyProperty IsMarkedAsDestinationProperty =
            DependencyProperty.Register("IsMarkedAsDestination",
                typeof(bool), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public bool IsMarkedAsDestination
        {
            set => SetValue(IsMarkedAsDestinationProperty, value);
            get => (bool)GetValue(IsMarkedAsDestinationProperty);
        }


        public static readonly DependencyProperty IsExecutableProperty =
            DependencyProperty.Register("IsExecutable",
                typeof(bool), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));



        public bool IsExecutable
        {
            set => SetValue(IsExecutableProperty, value);
            get => (bool)GetValue(IsExecutableProperty);
        }

        public static readonly DependencyProperty IsNotExecutableProperty =
            DependencyProperty.Register("IsNotExecutable",
                typeof(bool), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public bool IsNotExecutable
        {
            set => SetValue(IsNotExecutableProperty, value);
            get => (bool)GetValue(IsNotExecutableProperty);
        }

        public static readonly DependencyProperty IsShowInformationProperty =
            DependencyProperty.Register("IsShowInformation",
                typeof(bool), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public bool IsShowInformation
        {
            set => SetValue(IsShowInformationProperty, value);
            get => (bool)GetValue(IsShowInformationProperty);
        }

        public static readonly DependencyProperty IsMarkedAsDeleteProperty =
            DependencyProperty.Register("IsMarkedAsDelete",
                typeof(bool), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public bool IsMarkedAsDelete
        {
            set => SetValue(IsMarkedAsDeleteProperty, value);
            get => (bool)GetValue(IsMarkedAsDeleteProperty);
        }


        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius",
                typeof(CornerRadius), typeof(ConnectableButton),
                new FrameworkPropertyMetadata(new CornerRadius(0),
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        public CornerRadius CornerRadius
        {
            set => SetValue(CornerRadiusProperty, value);
            get => (CornerRadius)GetValue(CornerRadiusProperty);
        }

        public ConnectableButton()
        {
            
        }
    }
}

﻿#pragma checksum "..\..\..\..\UI\Editor\EditorDislay.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF2E964D0C9AEDFE86DB72F75A0FF860756BC58C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Petri.Editor.Controls;
using Petri.Editor.Converter;
using Petri.Editor.Converter.Conn;
using Petri.Editor.UI.Editor;
using Petri.Logic.Components;
using Petri.Logic.ViewModel;
using Petzold.Media2D;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Petri.Editor.UI.Editor {
    
    
    /// <summary>
    /// EditorDislay
    /// </summary>
    public partial class EditorDislay : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 15 "..\..\..\..\UI\Editor\EditorDislay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Petri.Editor.UI.Editor.EditorDislay self;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\UI\Editor\EditorDislay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LabelCurrentCommand;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Petri.Editor;component/ui/editor/editordislay.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Editor\EditorDislay.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.self = ((Petri.Editor.UI.Editor.EditorDislay)(target));
            return;
            case 2:
            
            #line 53 "..\..\..\..\UI\Editor\EditorDislay.xaml"
            ((System.Windows.Controls.ItemsControl)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LabelCurrentCommand = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 57 "..\..\..\..\UI\Editor\EditorDislay.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseLeftButtonUp);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 105 "..\..\..\..\UI\Editor\EditorDislay.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Component_CLick);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 119 "..\..\..\..\UI\Editor\EditorDislay.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Component_CLick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


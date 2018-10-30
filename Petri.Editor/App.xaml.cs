﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Petri.Logic.Components;

namespace Petri.Editor
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
           
            base.OnStartup(e);
            ConnectableBase.SIZE = (double)Application.Current.FindResource("NetObjectSize");
        }
    }
}

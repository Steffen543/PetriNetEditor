using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace Petri.Editor.Helper
{
    public class AddConnectionHelper : ViewModelBase
    {


        public ConnectableBase Source
        {
            get { return GetProperty(() => Source); }
            set { SetProperty(() => Source, value); }
        }

        public ConnectableBase Destination
        {
            get { return GetProperty(() => Destination); }
            set { SetProperty(() => Destination, value); }
        }

        public int Value
        {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value); }
        }

        public string Description
        {
            get { return GetProperty(() => Description); }
            set { SetProperty(() => Description, value); }
        }

      
    }
}

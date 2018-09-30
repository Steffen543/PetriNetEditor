using Petri.Logic.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri.Editor.Helper
{
    public class AddConnectionHelper
    {
        public IConnectable Source { get; set; }
        public IConnectable Destination { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}

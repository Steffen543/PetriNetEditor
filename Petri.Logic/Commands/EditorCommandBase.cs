using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri.Logic.Commands
{
    public abstract class EditorCommandBase
    {
        public string CommandText { get; set; }

        public abstract void Execute();
    }
}

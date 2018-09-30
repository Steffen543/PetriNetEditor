using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri.Logic.Commands
{
    public class AddTransitionCommand : EditorCommandBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Description { get; set; }
        
        public AddTransitionCommand()
        {
            Description = "Transition hinzufügen";
        }


        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

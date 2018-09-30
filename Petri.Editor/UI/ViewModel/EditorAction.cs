using Petri.Logic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri.Editor.UI.ViewModel
{
    public class EditorAction
    {
        public List<EditorCommandBase> Commands { get; set; }

        public string CommandText
        {
            get
            {
                return Commands.FirstOrDefault()?.CommandText;
            }
        }

        public void Next()
        {
            if (Commands.Count > 0)
                Commands.Remove(Commands.First());
        }

        public void ExecuteNextCommand()
        {
            if (Commands.Count > 0)
                Commands.First().Execute();
        }
    }
}

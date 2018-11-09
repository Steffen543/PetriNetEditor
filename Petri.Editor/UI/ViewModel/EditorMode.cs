using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri.Editor.UI.ViewModel
{
    public enum EditorMode
    {
        [Description("Bearbeiten")]
        Edit,
        [Description("Aktivieren")]
        Execute,
        [Description("Transition hinzufügen")]
        AddTransition,
        [Description("Stelle hinzufügen")]
        AddPlace,
        [Description("Verbindung hinzufügen")]
        AddConnection,
        [Description("Löschen")]
        Delete
      
    }
}

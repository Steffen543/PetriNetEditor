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
        [Description("Auswählen")]
        Nothing,
        [Description("Transition hinzufügen")]
        AddTransition,
        [Description("Stelle hinzufügen")]
        AddStelle,
        [Description("Verbindung hinzufügen")]
        AddConnection,
        [Description("Löschen")]
        Delete,
        [Description("Informationen")]
        Info
    }
}

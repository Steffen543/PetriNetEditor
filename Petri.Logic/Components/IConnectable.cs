using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petri.Logic.Pnml;

namespace Petri.Logic.Components
{
    public interface IConnectable
    {
        string Id { get; set; }
        Position Position { get; set; }
        bool SelectedAsSource { get; set; }
    }
}

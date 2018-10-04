using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petri.Logic.Components
{
    public interface IConnectable
    {
        int Id { get; set; }
        double X { get; set; }
        double Y { get; set; }
        bool SelectedAsSource { get; set; }
    }
}

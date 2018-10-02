using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Petri.Logic.Components
{
    [XmlType("Transition")]
    public class Transition : ConnectableBase, IConnectable
    {
        public bool IsExecutable
        {
            get
            {
                bool returnValue = true;
                foreach (var inputConnection in Input)
                {
                    var currentValue = ((Stelle)inputConnection.Source).Value;
                    
                    if (currentValue < inputConnection.Value)
                        returnValue = false;
                }
                return returnValue;
            }
        }
      
        public Transition()
        {
           
        }

        public Transition(int id, double x, double y, string name, string description) : base(id, x, y, description, name)
        {

        }

        public void Execute()
        {
            foreach(var inputConnection in Input)
            {
                var source = ((Stelle)inputConnection.Source);
                source.Value -= inputConnection.Value;
                //source.Value = 0;
            }
            foreach (var outputConnection in Output)
            {
                var destination = ((Stelle)outputConnection.Destination);
               destination.Value += outputConnection.Value;
            }


        }

        public override string ToString()
        {
            return $"Transition: [Id: {Id.ToString()}, Description: {Description}";
        }
    }
}

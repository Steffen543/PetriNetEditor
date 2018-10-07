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
        [XmlAttribute("IsExecutable")]
        public bool IsExecutable
        {
            get { return GetProperty(() => IsExecutable); }
            set { SetProperty(() => IsExecutable, value); }
        }

        public void CalcIsExecutable()
        {
            bool returnValue = true;
            foreach (var inputConnection in Input)
            {
                var currentValue = ((Stelle)inputConnection.Source).Value;

                if (currentValue < inputConnection.Value)
                    returnValue = false;
            }
            IsExecutable = returnValue;
            foreach (var outputConnection in Output)
            {
                outputConnection.CalcIsExecutable();
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
            }
            foreach (var outputConnection in Output)
            {
                var destination = ((Stelle)outputConnection.Destination);
                destination.Value += outputConnection.Value;
            }
            CalcIsExecutable();

        }

        public override string ToString()
        {
            return $"Transition: [Id: {Id.ToString()}, Description: {Description}";
        }
    }
}

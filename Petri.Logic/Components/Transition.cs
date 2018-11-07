using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Pnml;

namespace Petri.Logic.Components
{
    [XmlType("transition")]
    public class Transition : ConnectableBase
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
                var currentValue = ((Place)inputConnection.Source).Value;

                if (currentValue.Text < inputConnection.Value.Text)
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

        public Transition(string id, double x, double y, string name, string description) : base(id, x, y, name, description)
        {
            
        }

        public void Execute()
        {
            foreach(var inputConnection in Input)
            {
                var source = ((Place)inputConnection.Source);
                source.Value = new PlaceInitialMarking(source.Value.Text - inputConnection.Value.Text);
            }
            foreach (var outputConnection in Output)
            {
                var destination = ((Place)outputConnection.Destination);
                destination.Value = new PlaceInitialMarking(destination.Value.Text + outputConnection.Value.Text);
                //foreach (var connection in destination.Output)
                //{
                //    if(connection.Destination is Transition trans)
                //        trans.CalcIsExecutable();
                //}
            }
            CalcIsExecutable();

        }

        public override string ToString()
        {
            return $"Transition: [Id: {Id.ToString()}, Description: {Description}";
        }
    }
}

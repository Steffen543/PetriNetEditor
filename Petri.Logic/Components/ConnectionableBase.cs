using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Petri.Logic.Helper;
using Petri.Logic.Pnml;
using Petri.Logic.Xml;

namespace Petri.Logic.Components
{
    public class ConnectableBase : UIPlaceable
    {
        public static double SIZE;

        /// <summary>
        /// Only for binding
        /// </summary>
        [XmlIgnore()]
        public string NameBind
        {
            get { return GetProperty(() => NameBind); }
            set
            {
                SetProperty(() => NameBind, value);
                SetProperty(() => Name, new Name(value));
            }
        }

        [XmlElement("name")]
        public Name Name
        {
            get { return GetProperty(() => Name); }
            set
            {
                SetProperty(() => Name, value);
                SetProperty(() => NameBind, value.Text);
                RaisePropertiesChanged("NameBind");
            }
        }

        [XmlIgnore()]
        public ObservableCollection<Connection> Input { get; set; }

        [XmlIgnore()]
        public ObservableCollection<Connection> Output { get; set; }

        [XmlIgnore()]
        public bool SelectedAsSource
        {
            get { return GetProperty(() => SelectedAsSource); }
            set { SetProperty(() => SelectedAsSource, value); }
        }

        public ConnectableBase(string id, double x, double y, string name, string description) : base(id, x, y, description)
        {
            Input = new ObservableCollection<Connection>();
            Output = new ObservableCollection<Connection>();
            Name = new Name(name);
        }

        public ConnectableBase()
        {
            Input = new ObservableCollection<Connection>();
            Output = new ObservableCollection<Connection>();
        }

        /// <summary>
        /// if the position of a connectable base item changed, all the arrows from
        /// the input and the output have to be updated to the right position
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        internal void PositionChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            foreach (var connection in Output)
            {
                ArrowManagement.Remove(connection.Source, connection.Destination);
            }
            foreach (var connection in Input)
            {
                ArrowManagement.Remove(connection.Source, connection.Destination);
            }
            foreach (var connection in Output)
            {
                connection.UpdateArrows();
            }
            foreach (var connection in Input)
            {
                connection.UpdateArrows();
            }
        }

       
    }
}

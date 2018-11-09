using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petri.Logic.Components;

namespace Petri.Logic.Helper
{
    public class ArrowManagement
    {
        private static List<ArrowItem> items = new List<ArrowItem>();
        public static ObjectList ObjectList;

        public static void Clear()
        {
            items.Clear();
        }

        public static void Add(ConnectableBase item1, ConnectableBase item2, double position)
        {
            items.Add(new ArrowItem(item1, item2) {Position =  position});
        }

        internal static ArrowItem AlreadyContainsConnection(ConnectableBase item1, ConnectableBase item2)
        {
            var connectionAlreadyDrawn = items.FirstOrDefault(p => p.Contains(item1, item2));
            return connectionAlreadyDrawn;
        }

        public static void Remove(ConnectableBase item1, ConnectableBase item2)
        {
            List<ArrowItem> removeList = new List<ArrowItem>();
            foreach (var arrowItem in items)
            {
                if(arrowItem.Contains(item1, item2))
                    removeList.Add(arrowItem);
            }
            foreach (var arrowItem in removeList)
            {
                items.Remove(arrowItem);
            }
        }


        internal static void Remove(ArrowItem arrowitem)
        {
            items.Remove(arrowitem);
        }

        public static int CountConnectionsInArrowManagement(ConnectableBase component1, ConnectableBase component2)
        {

            int counter = 0;
            //foreach (var conn in ObjectList.GetConnections())
            foreach (var conn in items)
            {
                //var comp1Found = conn.Source == component1 || conn.Destination == component1;
                //var comp2Found = conn.Source == component2 || conn.Destination == component2;
                //if (comp1Found && comp2Found) counter++;
                var comp1Found = component1 == conn.Component1 || component1 == conn.Component2;
                var comp2Found = component2 == conn.Component1 || component2 == conn.Component2;
                if (comp1Found && comp2Found) counter++;
            }
            return counter;
           
          
        }

        public static int CountAllConnections(ConnectableBase component1, ConnectableBase component2)
        {

            int counter = 0;
            foreach (var conn in ObjectList.GetConnections())
            {
                var comp1Found = component1 == conn.Source || component1 == conn.Destination;
                var comp2Found = component2 == conn.Source || component2 == conn.Destination;
                if (comp1Found && comp2Found) counter++;
            }
            return counter;


        }
    }

    internal class ArrowItem
    {
        public ConnectableBase Component1 { get; set; }
        public ConnectableBase Component2 { get; set; }
        public double Position { get; set; }

        public ArrowItem(ConnectableBase component1, ConnectableBase component2)
        {
            Component1 = component1;
            Component2 = component2;
        }

        public bool Contains(ConnectableBase component1, ConnectableBase component2)
        {
            bool oneFound = false;
            bool twoFound = false;
            oneFound = component1 == Component1 || component1 == Component2;
            twoFound = component2 == Component1 || component2 == Component2;
            return oneFound && twoFound;
        }
    }
}

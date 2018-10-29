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

        public static void Add(IConnectable item1, IConnectable item2)
        {
            items.Add(new ArrowItem(item1, item2));
        }

        public static bool AlreadyCalculated(IConnectable item1, IConnectable item2)
        {
            var connectionAlreadyDrawn = items.FirstOrDefault(p => p.Contains(item1, item2));
            if (connectionAlreadyDrawn == null) return false;
            return true;
        }

        public static void Remove(IConnectable item1, IConnectable item2)
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
    }

    internal class ArrowItem
    {
        public IConnectable Component1 { get; set; }
        public IConnectable Component2 { get; set; }
       

        public ArrowItem(IConnectable component1, IConnectable component2)
        {
            Component1 = component1;
            Component2 = component2;
        }

        public bool Contains(IConnectable component1, IConnectable component2)
        {
            bool oneFound = false;
            bool twoFound = false;
            oneFound = component1 == Component1 || component1 == Component2;
            twoFound = component2 == Component1 || component2 == Component2;
            return oneFound && twoFound;
        }
    }
}

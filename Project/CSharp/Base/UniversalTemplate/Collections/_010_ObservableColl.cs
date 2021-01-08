using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _010_ObservableColl
    {
        public _010_ObservableColl()
        {
            ObservableCollection<int> ts = new ObservableCollection<int>();
            ts.CollectionChanged += Ts_CollectionChanged;

            ts.Add(1);
            ts[0] = 2;
        }

        private void Ts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Console.WriteLine("add {0}", (int)e.NewItems[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    int v1 = (int)e.OldItems[0];
                    int v2 = (int)e.NewItems[0];
                    Console.WriteLine($"{v1} Replace on {v2}");
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CSharp.Base.Collections
{
    class Collections5
    {
        public Collections5()
        {
            ObservableCollection<int> coll = new ObservableCollection<int>();
            coll.CollectionChanged += Fd_CollectionChanged;
            coll.Add(1);
            coll.Add(2);
            coll.Add(3);
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }

            coll[0] = 123;

            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private void Fd_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    int item = (int)e.NewItems[0];
                    Console.WriteLine($"Add : {item} ");
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulation.BLL.Models
{
    public class VegetableCollection : ICollection<Vegetable>
    {

        public IEnumerator<Vegetable> GetEnumerator()
        {
            return new VegetableEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new VegetableEnumerator(this);
        }

        private List<Vegetable> innerCol;

        public VegetableCollection()
        {
            innerCol = new List<Vegetable>();
        }

        public Vegetable this[int index]
        {
            get { return (Vegetable)innerCol[index]; }
            set { innerCol[index] = value; }
        }

        public void Sort(IComparer<Vegetable> comparer)
        {
            innerCol.Sort(comparer);
        }

        // Determines if an item is in the 
        // collection by using a specified equality comparer.
        public bool Contains(Vegetable item, EqualityComparer<Vegetable> comp)
        {
            bool found = false;
            foreach (Vegetable bx in innerCol)
            {
                if (comp.Equals(bx, item))
                {
                    found = true;
                }
            }

            return found;
        }

        // Determines if an item is in the collection
        // by using the VegetableSameName equality comparer.
        public bool Contains(Vegetable item)
        {
            return Contains(item, new VegetableSameName());
        }

        // Adds an item if it is not already in the collection
        // if it exist just add wright to item.
        public void Add(Vegetable item)
        {

            if (!Contains(item, new VegetableSameName()))
            {
                innerCol.Add(item);
            }
            else
            {
                innerCol.Where(foo => foo.Name == foo.Name).Select(u => { u.Weight += item.Weight; return u; }).ToList();
            }
        }

        public void Clear()
        {
            innerCol.Clear();
        }

        public void CopyTo(Vegetable[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < innerCol.Count; i++)
            {
                array[i + arrayIndex] = innerCol[i];
            }
        }

        public int Count
        {
            get
            {
                return innerCol.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Vegetable item)
        {
            bool result = false;

            // Iterate the inner collection to 
            // find the box to be removed.
            for (int i = 0; i < innerCol.Count; i++)
            {

                Vegetable curBox = (Vegetable)innerCol[i];

                if (new VegetableSameName().Equals(curBox, item))
                {
                    innerCol.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }
        
    }

    public class VegetableEnumerator : IEnumerator<Vegetable>
    {
        private VegetableCollection _collection;
        private int curIndex;
        private Vegetable curVegetable;


        public VegetableEnumerator(VegetableCollection collection)
        {
            _collection = collection;
            curIndex = -1;
            curVegetable = default(Vegetable);

        }

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                curVegetable = _collection[curIndex];
            }
            return true;
        }

        public void Reset() { curIndex = -1; }

        void IDisposable.Dispose() { }

        public Vegetable Current
        {
            get { return curVegetable; }
        }


        object IEnumerator.Current
        {
            get { return Current; }
        }

    }

    public class VegetableSameName: EqualityComparer<Vegetable>
    {
        public override bool Equals(Vegetable b1, Vegetable b2)
        {
            if (b1.Name == b2.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode(Vegetable obj)
        {
            throw new NotImplementedException();
        }
    }

    // Defines comparator for sort by calories
    public class CaloriesComparator<T> : IComparer<T> where T : Vegetable
    {
        public int Compare(T x, T y)
        {
            if (x.Calories < y.Calories)
                return 1;
            if (x.Calories > y.Calories)
                return -1;
            else return 0;
        }
    }

}

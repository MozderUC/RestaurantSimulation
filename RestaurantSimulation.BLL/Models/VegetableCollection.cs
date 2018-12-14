using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        private readonly List<Vegetable> _innerCol;

        public VegetableCollection()
        {
            _innerCol = new List<Vegetable>();
        }

        public Vegetable this[int index]
        {
            get => _innerCol[index];
            set => _innerCol[index] = value;
        }

        public void Sort(IComparer<Vegetable> comparer)
        {
            _innerCol.Sort(comparer);
        }

        // Determines if an item is in the 
        // collection by using a specified equality comparer.
        public bool Contains(Vegetable item, EqualityComparer<Vegetable> comp)
        {
            var found = false;
            foreach (var bx in _innerCol)
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
                _innerCol.Add(item);
            }
            else
            {
                _innerCol.Where(foo => foo.Name == item?.Name).Select(u =>
                {
                    if (item != null) u.Weight += item.Weight;
                    return u;
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                }).ToList();
            }
        }

        public void Clear()
        {
            _innerCol.Clear();
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void CopyTo(Vegetable[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (var i = 0; i < _innerCol.Count; i++)
            {
                array[i + arrayIndex] = _innerCol[i];
            }
        }

        public int Count => _innerCol.Count;

        public bool IsReadOnly => false;

        public bool Remove(Vegetable item)
        {
            var result = false;

            // Iterate the inner collection to 
            // find the box to be removed.
            for (var i = 0; i < _innerCol.Count; i++)
            {

                var curBox = _innerCol[i];

                if (!new VegetableSameName().Equals(curBox, item)) continue;
                _innerCol.RemoveAt(i);
                result = true;
                break;
            }
            return result;
        }
        
    }

    public class VegetableEnumerator : IEnumerator<Vegetable>
    {
        private readonly VegetableCollection _collection;
        private int _curIndex;


        public VegetableEnumerator(VegetableCollection collection)
        {
            _collection = collection;
            _curIndex = -1;
            Current = default(Vegetable);

        }

        public bool MoveNext()
        {
            //Avoids going beyond the end of the collection.
            if (++_curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                Current = _collection[_curIndex];
            }
            return true;
        }

        public void Reset() { _curIndex = -1; }

        void IDisposable.Dispose() { }

        public Vegetable Current { get; private set; }


        object IEnumerator.Current
        {
            get { return Current; }
        }

    }

    public class VegetableSameName: EqualityComparer<Vegetable>
    {
        public override bool Equals(Vegetable b1, Vegetable b2)
        {
            return b2 != null && (b1 != null && b1.Name == b2.Name);
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
            if (y != null && (x != null && x.Calories < y.Calories))
                return 1;
            if (y != null && (x != null && x.Calories > y.Calories))
                return -1;
            else return 0;
        }
    }

}

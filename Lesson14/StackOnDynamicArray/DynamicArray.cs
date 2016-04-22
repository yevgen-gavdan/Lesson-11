using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnDynamicArray
{
    public class DynamicArray<T>
    {
        //### DATA ####
        T[] data = null;

        //### DEFAULTS ####
        const int DefaultCapacity = 2;
        const int DefaultGrowthFactor = 2;
        const int DefaultSize = 10;

        //### PROPERTIES ###
        public int Capacity { get { return data.Length; } } //N
        public int Size { get { return size; } } //N
        public int GrowthFactor
        {
            get { return growthFactor; }
            private set { growthFactor = value; }
        }
        public int MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }

        //### FIELDS ####
        private int maxSize;
        private int growthFactor = 0;
        private int size = 0;

        //### METHODS ###
        public DynamicArray(int initialCapacity = DefaultCapacity, int growthFactor = DefaultGrowthFactor, int maxSize = DefaultSize)
        {
            if (initialCapacity <= 0 || initialCapacity > int.MaxValue)
            {
                initialCapacity = DefaultCapacity;
            }
            if (growthFactor <= 0 || growthFactor > int.MaxValue)
            {
                growthFactor = DefaultGrowthFactor;
            }
            if (maxSize <= 0 || maxSize > int.MaxValue)
            {
                maxSize = DefaultSize;
            }

            GrowthFactor = growthFactor;
            MaxSize = maxSize;
            data = new T[initialCapacity];
        }
        private void ArrayGrow()
        {
            T[] biggerArray = new T[Capacity * GrowthFactor];
            data.CopyTo(biggerArray, 0);
            data = biggerArray;
        }
        private void ArrayCut()
        {
            T[] smallerArray = new T[Capacity / GrowthFactor];
            Array.Copy(data, smallerArray, Size);
            data = smallerArray;
        }
        private bool IsPossitionAccurateToAdd(int possition)
        {
            return (possition >= 0 && possition <= size);
        }
        private bool IsPossitionAccurateToRemove(int possition)
        {
            return (possition >= 0 && possition < size);
        }
        private bool ManageMemory()
        {
            if (Size == Capacity)
            {
                ArrayGrow();
            }
            else if ((Size < (Capacity / GrowthFactor) && Size > GrowthFactor))
            {
                ArrayCut();
            }
            return true;
        }
        private void InsertByPossition(T newData, int possition)
        {
            if (Size == MaxSize) //Array full?
            {
                return;
            }
            data[possition] = newData;
            if (possition >= Size) //Adding new element or updating existing?
            {
                size++;
            }
        }
        private void RemoveByPossition(int possition)
        {
            data[possition] = default(T);
            size--;
        }
        private T Get(int possition)
        {
            if (IsPossitionAccurateToRemove(possition))
            {
                return data[possition];
            }
            return default(T);
        }

        //### INTERFACE ####
        public void SetElement(T element, int possition)
        {
            if (IsPossitionAccurateToAdd(possition))
            {
                if (ManageMemory())
                {
                    InsertByPossition(element, possition);
                }
            }
        }
        public void Remove(int possition)
        {
            if (IsPossitionAccurateToRemove(possition))
            {
                RemoveByPossition(possition);
                ManageMemory();
            }
        }
        public T this[int index]
        {
            get
            {
                return Get(index);
            }
            set
            {
                SetElement(value, index);
            }
        }
    }

}

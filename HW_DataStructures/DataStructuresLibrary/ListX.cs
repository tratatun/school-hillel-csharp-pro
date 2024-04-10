using DataStructuresLibrary.Interfaces;
using System;

namespace DataStructuresLibrary
{
    public class ListX<T> : IListX<T>, ICollectionX<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public int Count => count;

        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        public ListX()
        {
            items = new T[4];
            capacity = 4;
            count = 0;
        }

        public ListX(int capacity)
        {
            items = new T[capacity];
            this.capacity = capacity;
            count = 0;
        }

        public void Add(T item)
        {
            if (count == capacity)
            {
                capacity *= 2;
                T[] newItems = new T[capacity];
                for (int i = 0; i < count; i++)
                {
                    newItems[i] = this[i];
                }
                items = newItems;
            }
            this[count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }

            if (count == capacity)
            {
                capacity *= 2;
                T[] newItems = new T[capacity];
            }

            for (int i = count; i > index; i--)
            {
                this[i] = this[i - 1];
            }

            this[index] = item;
        }

        public int Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (this[i].Equals(item))
                {
                    RemoveAt(i);
                    return i;
                }
            }
            return -1;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            T item = this[index];
            for (int i = index; i < count - 1; i++)
            {
                this[i] = this[i + 1];
            }
            count--;
            return item;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (this[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (this[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public T[] ToArray()
        {
            return items;
        }

        public void Reverse()
        {
            for (int i = 0; i < count / 2; i++)
            {
                T temp = this[i];
                this[i] = this[count - i - 1];
                this[count - i - 1] = temp;
            }
        }
    }
}

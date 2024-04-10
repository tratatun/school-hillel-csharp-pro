using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary.Interfaces
{
    public interface ITree<T>: ICollectionX<T>
    {
        public T Value { get; set; }
        public ITree<T>? Left { get; set; }
        public ITree<T>? Right { get; set; }
    }

    public interface IListX<T>
    {
        public T this[int index] { get; set; }

        public T RemoveAt(int index);

        public int IndexOf(T value);

        public void Reverse();
    }

    public interface ICollectionX<T>
    {
        public int Count { get; }

        public void Add(T value);

        public bool Contains(T value);

        public void Clear();

        public T[] ToArray();
    }
}

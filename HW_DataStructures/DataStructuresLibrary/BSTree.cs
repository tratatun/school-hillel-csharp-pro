using DataStructuresLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLibrary
{
    public class BSTree<T> : ITree<T>, ICollectionX<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public ITree<T>? Left { get; set; }
        public ITree<T>? Right { get; set; }

        private int count;

        public int Count => count;

        public BSTree(T value)
        {
            count = 1;
            Value = value;
        }

        public void Add(T value)
        {
            count++;
            if (Value.CompareTo(value) <= 0)
            {
                if (Right == null)
                {
                    Right = new BSTree<T>(value);
                }
                else
                {
                    Right.Add(value);
                }
            }
            else
            {
                if (Left == null)
                {
                    Left = new BSTree<T>(value);
                }
                else
                {
                    Left.Add(value);
                }
            }
        }

        public bool Contains(T value)
        {
            if (Value.CompareTo(value) == 0)
            {
                return true;
            }
            if (Value.CompareTo(value) < 0)
            {
                return Right?.Contains(value) ?? false;
            }
            return Left?.Contains(value) ?? false;
        }

        public void Clear()
        {
            count = 0;
            Left = null;
            Right = null;
        }

        public T[] ToArray()
        {
            T[] array = new T[count];

            array[0] = Value;

            if (Left != null)
            {
                var leftArr = Left.ToArray();

                for (int i = 0; i < leftArr.Length; i++)
                {
                    array[i + 1] = leftArr[i];
                }
            }

            if (Right != null)
            {
                var rightArr = Right.ToArray();

                for (int i = 0; i < rightArr.Length; i++)
                {
                    array[(Left?.Count ?? 0) + 1 + i] = rightArr[i];
                }
            }

            return array;
        }
    }
}

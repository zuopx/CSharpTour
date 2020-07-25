using System;
using System.Collections.Generic;
using System.Text;

namespace ClassMembers
{
    public class MyList<T>
    {
        // Constant
        const int defaultCapacity = 4;

        // Fields
        T[] items;
        int count;

        // Constructor
        public MyList(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }

        // Properties
        public int Count => count;

        public int Capacity
        {
            get { return items.Length; }
            set
            {
                if (value < count) value = count;
                if (value != items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(items, 0, newItems, 0, count);
                    items = newItems;
                }
            }
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
                OnChanged();
            }
        }

        // Methods
        public void Add(T item)
        {
            if (count == Capacity) Capacity = count * 2;
            items[count] = item;
            count++;
            OnChanged();
        }

        protected virtual void OnChanged() =>
            Changed?.Invoke(this, EventArgs.Empty);

        public override bool Equals(object other) =>
            Equals(this, other as MyList<T>);

        static bool Equals(MyList<T> a, MyList<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
            if (Object.ReferenceEquals(b, null) || a.count != b.count)
                return false;
            for (int i = 0; i < a.count; i++)
            {
                if (!object.Equals(a.items[i], b.items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Event
        public event EventHandler Changed;

        // Operators
        public static bool operator ==(MyList<T> a, MyList<T> b) =>
            Equals(a, b);

        public static bool operator !=(MyList<T> a, MyList<T> b) =>
            !Equals(a, b);
    }
}

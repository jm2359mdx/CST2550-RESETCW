using System;

using System;

namespace LibraryManagementSystem.DataStructures
{
    public class CustomList<T>
    {
        private T[] items;
        private int count;

        public CustomList()
        {
            items = new T[4]; // initial capacity
            count = 0;
        }

        public int Count => count;

        public void Add(T item)
        {
            if (count == items.Length)
                Resize();

            items[count++] = item;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range");

            return items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range");

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[--count] = default(T); // optional: reset last item
        }

        private void Resize()
        {
            T[] newItems = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }

            items = newItems;
        }
    }
}

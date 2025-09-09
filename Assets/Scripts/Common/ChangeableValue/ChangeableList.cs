namespace Common.ChangeableValue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ChangeableList<T> : IChangeableValue, IEnumerable<T>
    {
        private readonly List<T> _list = new();
        
        public event Action Changed;

        public int Count => _list.Count;

        public void Add(T item)
        {
            _list.Add(item);
            Changed?.Invoke();
        }

        public void Remove(T item)
        {
            _list.Remove(item);
            Changed?.Invoke();
        }

        public IEnumerator<T> GetEnumerator() =>
            _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
namespace Common.ChangeableValue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ChangeableQueue<T> : IChangeableValue, IEnumerable<T>
    {
        private readonly Queue<T> _queue = new();
        
        public event Action Changed;

        public int Count => _queue.Count;

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
            Changed?.Invoke();
        }

        public T Dequeue()
        {
            T item = _queue.Dequeue();
            Changed?.Invoke();
            return item;
        }

        public IEnumerator<T> GetEnumerator() =>
            _queue.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
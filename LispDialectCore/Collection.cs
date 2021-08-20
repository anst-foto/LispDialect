using System.Collections;

namespace LispDialectCore
{
    public class Collection : IEnumerable
    {
        private Item _head;
        private Item _tail;
        private int _count;

        public Collection()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        
        public int Count => _count;

        public void Add(Lexeme value)
        {
            var item = new Item(value);
            if(_head == null)
            {
                _head = item;
            }
            else
            {
                _tail.Next = item;
            }

            _tail = item;
            _count++;
        }
        
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            var current = _head;
            while(current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
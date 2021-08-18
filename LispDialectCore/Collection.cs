

using System;

namespace LispDialectCore
{
    public class Collection
    {
        public Val Value { get; set; }
        public Collection Next { get; set; }

        public Collection()
        {
            Value = new Val
            {
                Value = null,
                Type = TypeVal.Null
            };

            Next = this;
        }

        public void Push(Val val)
        {
            if (Value.Type == TypeVal.Null)
            {
                Value = val;
            }
            else
            {
                Next = new Collection
                {
                    Value = val
                };
            }
        }

        public void ForEach(Action<string> action)
        {
            var val = Value;
            action?.Invoke(val.ToString());
            
            val = Next.Value;
            while (val.Type != TypeVal.Null)
            {
                action?.Invoke(val.ToString());
            }
        }
    }
}
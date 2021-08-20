using System;

namespace LispDialectCore
{
    public class Item
    {
        public Lexeme Value;
        public Item Next;

        public Item()
        {
            Value = new Lexeme(Value = null, TypeLexeme.Null);
            Next = null;
        }

        public Item(Lexeme value)
        {
            Value = value;
            Next = null;
        }
    }
}
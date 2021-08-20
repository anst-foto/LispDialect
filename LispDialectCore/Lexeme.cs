namespace LispDialectCore
{
    public class Lexeme
    {
        public readonly object Value;
        public readonly TypeLexeme Type;

        public Lexeme(object value, TypeLexeme type)
        {
            Value = value;
            Type = type;
        }
    }
}
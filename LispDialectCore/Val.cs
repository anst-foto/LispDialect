namespace LispDialectCore
{
    public class Val
    {
        public object Value { get; set; }
        public TypeVal Type { get; set; }

        public new string ToString()
        {
            return Type switch
            {
                TypeVal.Null => "NULL",
                TypeVal.Integer => $"INTEGER: {Value}",
                TypeVal.Double => $"DOUBLE: {Value}",
                TypeVal.String => $"STRING: {Value}"
            };
        }
    }
}
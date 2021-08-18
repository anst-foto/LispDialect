namespace LispDialectCore
{
    public static class Parser
    {
        public static Collection Lexer(string input)
        {
            var strings = input.Split(' ');
            var res = new Collection();
            
            foreach (var str in strings)
            {
                var isInt = IsInt(str, out var @int);
                if (isInt)
                {
                    res.Push(new Val {Value = @int, Type = TypeVal.Integer});
                }

                var isDouble = IsDouble(str, out var @double);
                if (isDouble)
                {
                    res.Push(new Val {Value = @double, Type = TypeVal.Double});
                }

                res.Push(new Val {Value = str, Type = TypeVal.String});
            }

            return res;
        }

        private static bool IsInt(string input, out int @int)
        {
            return int.TryParse(input, out @int);
        }

        private static bool IsDouble(string input, out double @double)
        {
            return double.TryParse(input, out @double);
        }
    }
}
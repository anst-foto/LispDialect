namespace LispDialectCore
{
    public static class Parser
    {
        public static Val Lexer(string input)
        {
            var isInt = IsInt(input, out var @int);
            if (isInt)
            {
                return new Val {Value = @int, Type = TypeVal.Integer};
            }

            var isDouble = IsDouble(input, out var @double);
            if (isDouble)
            {
                return new Val {Value = @double, Type = TypeVal.Double};
            }

            return new Val {Value = input, Type = TypeVal.String};
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
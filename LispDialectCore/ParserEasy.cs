using System.Collections.Generic;
using System.Linq;

namespace LispDialectCore
{
    public static class ParserEasy
    {
        private static List<string> Operators = new List<string> { "+", "-", "*", "/" };

        public static Stack<Lexeme> Analysis(string script)
        {
            var result = new Stack<Lexeme>();
            var list_str = script.Split(' ');

            foreach (var s in list_str)
            {
                var trim = s.Trim();
                var is_int = int.TryParse(trim, out var @int);
                var is_real = double.TryParse(trim, out var real);

                if (is_int)
                {
                    result.Push(new Lexeme(@int, TypeLexeme.Integer));
                } else if (is_real)
                {
                    result.Push(new Lexeme(real, TypeLexeme.Real));
                }
                else
                {
                    switch (s)
                    {
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                            result.Push(new Lexeme(s, TypeLexeme.Operator));
                            break;
                        default:
                            result.Push(new Lexeme(s, TypeLexeme.String));
                            break;
                    }
                }
            }

            return result;
        }

        public static Collection AnalysisCollection(string script)
        {
            var result = new Collection();
            var list_str = script.Split(' ');

            foreach (var s in list_str)
            {
                var trim = s.Trim();
                var is_int = int.TryParse(trim, out var @int);
                var is_real = double.TryParse(trim, out var real);

                if (is_int)
                {
                    result.Add(new Lexeme(@int, TypeLexeme.Integer));
                } else if (is_real)
                {
                    result.Add(new Lexeme(real, TypeLexeme.Real));
                }
                else
                {
                    switch (s)
                    {
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                            result.Add(new Lexeme(s, TypeLexeme.Operator));
                            break;
                        default:
                            result.Add(new Lexeme(s, TypeLexeme.String));
                            break;
                    }
                }
            }

            return result;
        }
    }
}
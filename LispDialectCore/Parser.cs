using System.Collections.Generic;

namespace LispDialectCore
{
    public static class Parser
    {
        private static List<string> Operators = new List<string> { "+", "-", "*", "/" };
        private static (bool is_str, int start, int end) IsString(string parsed_string)
        {
            var start_str = false;
            var start_index_str = 0;
            var end_index_str = 0;
            for (var i = 0; i < parsed_string.Length; i++)
            {
                if (parsed_string[i] == '"' && !start_str)
                {
                    start_str = true;
                    start_index_str = i;
                }
                else if (parsed_string[i] == '"' && start_str)
                {
                    //start_str = false;
                    end_index_str = i;
                    break;
                }
            }

            return end_index_str == 0 ? (false, 0, 0) : (true, start_index_str, end_index_str);
        }

        private static (bool is_not_str, int start, int end) IsNotString(string parsed_string)
        {
            var start_not_str = false;
            var start_index_not_str = 0;
            var end_index_not_str = 0;

            for (var i = 0; i < parsed_string.Length; i++)
            {
                if (!start_not_str)
                {
                    if (char.IsLetterOrDigit(parsed_string[i]))
                    {
                        start_not_str = true;
                        start_index_not_str = i;
                    }
                    else
                    {
                        return (false, 0, 0);
                    }
                }
                else
                {
                    if (!char.IsWhiteSpace(parsed_string[i]) && parsed_string[i] != '\n') continue;
                    end_index_not_str = i - 1;
                    break;
                }
            }
            
            return end_index_not_str == 0 ? (false, 0, 0) : (true, start_index_int: start_index_not_str, end_index_int: end_index_not_str);
        }

        /*private static (bool is_int, int start, int end) IsInt(string parsed_string)
        {
            var start_int = false;
            var start_index_int = 0;
            var end_index_int = 0;

            for (var i = 0; i < parsed_string.Length; i++)
            {
                if (char.IsDigit(parsed_string[i]) && !start_int)
                {
                    start_int = true;
                    start_index_int = i;
                }
                else if (char.IsWhiteSpace(parsed_string[i]) && start_int)
                {
                    start_int = false;
                    end_index_int = i - 1;
                    break;
                }
            }
            
            return end_index_int == 0 ? (false, 0, 0) : (true, start_index_int, end_index_int);
        }

        private static (bool is_real, int start, int end) IsReal(string parsed_string)
        {
            var start_real = false;
            var start_index_real = 0;
            var end_index_real = 0;

            for (var i = 0; i < parsed_string.Length; i++)
            {
                if (char.IsDigit(parsed_string[i]) && !start_real)
                {
                    start_real = true;
                    start_index_real = i;
                }
                else if (char.IsWhiteSpace(parsed_string[i]) && start_real)
                {
                    start_real = false;
                    end_index_real = i - 1;
                }
            }
            
            return end_index_real == 0 ? (false, 0, 0) : (true, start_index_real, end_index_real);
        }
        
        private static (bool is_operator, int start, int end) IsOperator(string parsed_string)
        {
            var start_operator = false;
            var start_index_operator = 0;
            var end_index_operator = 0;
            for (var i = 0; i < parsed_string.Length; i++)
            {
                if (char.IsLetter(parsed_string[i]) && !start_operator)
                {
                    start_operator = true;
                    start_index_operator = i;
                }
                else if (char.IsWhiteSpace(parsed_string[i]) && start_operator)
                {
                    start_operator = false;
                    end_index_operator = i - 1;
                    break;
                }
            }
            
            return end_index_operator == 0 ? (false, 0, 0) : (true, start_index_operator, end_index_operator);
        }*/

        public static Stack<Lexeme> Analysis(string script)
        {
            var result = new Stack<Lexeme>();
            
            var parsed_string = script.Trim();
            var temp_parsed_string = string.Empty;
            var temp_length = parsed_string.Length;

            var fin = false; 
            
            while (!fin)
            {
                parsed_string = parsed_string.Trim();
                var (isStr, start_str, end_str) = IsString(parsed_string);
                if (isStr)
                {
                    var length = end_str + 1 - start_str;
                    temp_parsed_string = parsed_string.Substring(start_str, length);
                    result.Push(new Lexeme(temp_parsed_string, TypeLexeme.String));

                    temp_length -= length;
                    if (temp_length <= 0)
                    {
                        fin = true;
                    }
                    
                    parsed_string = parsed_string.Substring(end_str + 1);
                }
                else
                {
                    var (isNotStr, start, end) = IsNotString(parsed_string);
                    if (isNotStr)
                    {
                        var length = end + 1 - start;
                        temp_parsed_string = parsed_string.Substring(start, length);

                        var isInt = int.TryParse(temp_parsed_string, out var @int);
                        var isReal = double.TryParse(temp_parsed_string, out var @double);
                        var isOperator = IsOperator(temp_parsed_string, out var @operator);
                    
                        if (isInt)
                        {
                            result.Push(new Lexeme(@int, TypeLexeme.Integer));
                        } else if (isReal)
                        {
                            result.Push(new Lexeme(@double, TypeLexeme.Real));
                        } else if (isOperator)
                        {
                            result.Push(new Lexeme(@operator, TypeLexeme.Operator));
                        }

                        temp_length -= length;
                        if (temp_length <= 0)
                        {
                            fin = true;
                        }
                    
                        parsed_string = parsed_string.Substring(end + 1);
                    }
                    else
                    {
                        temp_parsed_string = parsed_string.Substring(temp_length);
                        result.Push(new Lexeme(temp_parsed_string, TypeLexeme.Unknown));
                        fin = true;
                    }
                }

                /*var isInt = IsInt(parsed_string);
                if (isInt.is_int)
                {
                    var length = isInt.end + 1 - isInt.start;
                    temp_parsed_string = parsed_string.Substring(isInt.start, length);
                    var int32 = int.Parse(temp_parsed_string);
                    result.Push(new Lexeme(int32, TypeLexeme.Integer));
                    
                    temp_length -= length;
                    if (temp_length <= 0)
                    {
                        fin = true;
                    }
                    
                    parsed_string = parsed_string.Substring(isInt.end + 1);
                }
                
                var isReal = IsReal(parsed_string);
                if (isReal.is_real)
                {
                    var length = isReal.end + 1 - isReal.start;
                    temp_parsed_string = parsed_string.Substring(isReal.start, length);
                    var real = double.Parse(temp_parsed_string, new NumberFormatInfo { NumberDecimalSeparator = "." });
                    result.Push(new Lexeme(real, TypeLexeme.Real));
                    
                    temp_length -= length;
                    if (temp_length <= 0)
                    {
                        fin = true;
                    }
                    
                    parsed_string = parsed_string.Substring(isReal.end + 1);
                }

                var isOperator = IsOperator(parsed_string);
                if (isOperator.is_operator)
                {
                    var length = isReal.end + 1 - isReal.start;
                    temp_parsed_string = parsed_string.Substring(isReal.start, length);
                    result.Push(new Lexeme(temp_parsed_string, TypeLexeme.Operator));
                    
                    temp_length -= length;
                    if (temp_length <= 0)
                    {
                        fin = true;
                    }
                    
                    parsed_string = parsed_string.Substring(isReal.end + 1);
                }*/
            }

            return result;
        }

        private static bool IsOperator(string parsed_string, out string o)
        {
            foreach (var @operator in Operators)
            {
                if (parsed_string != @operator) continue;
                o = @operator;
                return true;
            }

            o = string.Empty;
            return false;
        }
    }
}
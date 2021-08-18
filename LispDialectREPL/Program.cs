using System;
using Core = LispDialectCore;

namespace LispDialectREPL
{
    internal static class Program
    {
        private static void Main()
        {
            var exit = false;
            do
            {
                var input = Console.WaitLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                { 
                    Console.Error("Пустая строка. Повторите ввод");
                    continue;
                }

                switch (input)
                {
                    case "exit":
                        exit = true;
                        break;
                    case "help":
                        Console.Info("Разработка собственного языка программирования");
                        //TODO Написать вывод команд
                        break;
                    default:
                        var res = Core.Parser.Lexer(input);
                        Console.PrintCollection(res);
                        break;
                }
            } while (!exit);
            
            Console.Info("До свидания...");
        }
    }
}
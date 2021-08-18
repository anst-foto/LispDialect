using System;

namespace LispDialectREPL
{
    public static class Console
    {
        public static string? WaitLine()
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write($"{DateTime.Now:u} >>>");
            var input = System.Console.ReadLine();
            System.Console.ResetColor();

            return input;
        }

        public static void Info(string? message)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine($"{DateTime.Now:u} [INFO] : {message}");
            System.Console.ResetColor();
        }
        
        public static void Error(string message)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine($"{DateTime.Now:u} [ERROR] : {message}");
            System.Console.ResetColor();
        }
    }
}
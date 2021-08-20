using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LispDialectCore;

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

        public static void PrintLexeme(Lexeme lexeme)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.Write($"{lexeme.Type} : {lexeme.Value}\t");
            System.Console.ResetColor();
        }

        public static void PrintCollectionLexeme(Stack<Lexeme> lexemes)
        {
            foreach (var lexeme in lexemes)
            {
                PrintLexeme(lexeme);
            }
        }
    }
}
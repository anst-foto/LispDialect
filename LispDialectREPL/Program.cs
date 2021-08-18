using System;

namespace LispDialectREPL
{
    internal static class Program
    {
        private static void Main()
        {
            do
            {
                Console.Write(">>>");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                if (input == "exit")
                {
                    break;
                }
            } while (true);
        }
    }
}
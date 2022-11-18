using System;

namespace DirMimeTypeParser
{
    static class ColoredOutput
    {
        public static void WriteLine(string text, ConsoleColor colorOfText)
        {
            Console.ForegroundColor = colorOfText;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void Write(string text, ConsoleColor colorOfText)
        {
            Console.ForegroundColor = colorOfText;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void WriteLineHiglighted(string text, ConsoleColor colorOfTextBackground)
        {
            Console.BackgroundColor = colorOfTextBackground;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WriteHiglighted(string text, ConsoleColor colorOfTextBackground)
        {
            Console.BackgroundColor = colorOfTextBackground;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}

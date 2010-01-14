using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS3.Executable
{
    public class Logger
    {
        public static void Error(string message, params object[] format)
        {

            PrintColoredLineToConsole(ConsoleColor.Red, String.Format(message, format));
        }

        public static void Warn(string message, params object[] format)
        {

            PrintColoredLineToConsole(ConsoleColor.Yellow, String.Format(message, format));
        }

        public static void Log(string message, params object[] format)
        {

            PrintColoredLineToConsole(ConsoleColor.White, String.Format(message, format));
        }

        public static void Warn(Exception e, string note)
        {
            Warn(note);
            Warn("-------------------------------------------------");
            Warn(e.StackTrace);
        }

        public static void Error(Exception e, string note)
        {
            Error(note);
            Error("-------------------------------------------------");
            Error(e.ToString());
        }
   
        private static void PrintColoredLineToConsole(ConsoleColor color, string line)
        {
            ConsoleColor initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ForegroundColor = initialColor;
        }
        
    }
}

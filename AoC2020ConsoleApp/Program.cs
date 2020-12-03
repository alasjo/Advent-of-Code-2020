using System;

namespace AoC2020ConsoleApp
{
    public class Program
    {
        private static int nrDays = 25;

        public static void Main(string[] args)
        {
            Menu menu = new Menu(nrDays);

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.Write(menu.ToString());
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        menu.Skip(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        menu.Skip(1);
                        break;
                    case ConsoleKey.PageUp:
                        menu.Skip(-5);
                        break;
                    case ConsoleKey.PageDown:
                        menu.Skip(5);
                        break;
                    case ConsoleKey.Enter:
                        menu.Handle();
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}

using System;
using System.Security.Cryptography;
using jinek.X11;

namespace X11ClipboardTest;

internal static class Program {
    private static void Main() {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("<P> Set primary selection text");
        Console.WriteLine("<C> Set clipboard text");
        Console.WriteLine("<V> Show current clipboard");
        Console.ResetColor();
        Console.WriteLine();

        while (true) {
            var key = Console.ReadKey(true);
            switch (key.Key) {
                case ConsoleKey.Escape:
                case ConsoleKey.Q: return;

                case ConsoleKey.P:
                    X11Clipboard.Primary.SetText("P-" + RandomNumberGenerator.GetHexString(6) + "-P");
                    Console.WriteLine("Set primary selection text:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(X11Clipboard.Primary.GetText());
                    Console.ResetColor();
                    Console.WriteLine();
                    break;

                case ConsoleKey.C:
                    X11Clipboard.Clipboard.SetText("C-" + RandomNumberGenerator.GetHexString(6) + "-C");
                    Console.WriteLine("Set clipboard text:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(X11Clipboard.Clipboard.GetText());
                    Console.ResetColor();
                    Console.WriteLine();
                    break;

                case ConsoleKey.V:
                    Console.WriteLine("Primary selection text:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(X11Clipboard.Primary.GetText());
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Clipboard text:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(X11Clipboard.Clipboard.GetText());
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
            }
        }
    }
}

using System;

namespace PasswordGenerator
{
    class Program
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        [STAThread]
        static void Main( string[] args )
        {
            Loop();
        }

        static void Loop()
        {
            Console.Clear();

            Generate();

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Spacebar) Loop();
        }

        static void Generate()
        {
            Random r = new Random();

            Console.WriteLine("Generated password: \n");

            string password = "";

            for (int i = 0; i < 20; i++)
            {
                char c = ' ';

                if (r.NextDouble() < .5f) c = alphabet[(int)(r.NextDouble() * alphabet.Length)];
                else c = ((int)(r.NextDouble() * 10)).ToString()[0];

                password += c;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(password);
            Console.ForegroundColor = ConsoleColor.Gray;

            System.Windows.Forms.Clipboard.SetText(password);

            Console.WriteLine("\nThe password has been copied to the clipboard. \n\nPress SPACE to regenerate.");
        }
    }
}

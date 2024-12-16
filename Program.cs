using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string imagePath = "5364139374037560681_99.jpg";
        Bitmap bitmap = new Bitmap(imagePath);

        for (int y = 0; y < bitmap.Height; y += 6)
        {
            for (int x = 0; x < bitmap.Width; x += 3)
            {
                Color pixelColor = bitmap.GetPixel(x, y);
                char asciiChar = GetAsciiChar(pixelColor);
                SetConsoleColor(pixelColor);
                Console.Write(asciiChar);
            }
            Console.WriteLine();
        }

        Console.ResetColor();
    }

    static char GetAsciiChar(Color color)
    {
        int brightness = (int)(0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B);

        string chars = "@%#*+=-:. ";
        int index = (brightness * (chars.Length - 1)) / 255;
        return chars[chars.Length - 1 - index];
    }

    static void SetConsoleColor(Color color)
    {
        string ansiColor = $"\x1b[38;2;{color.R};{color.G};{color.B}m";
        Console.Write(ansiColor);
    }
}

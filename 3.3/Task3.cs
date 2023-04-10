using System;
using System.Drawing;
using System.IO;

namespace _3._3
{
    class Task3
    {
        static void Main(string[] args)
        {
            string imagesPath = @"./images/";

            Func<Bitmap, Bitmap> grayscaleFunc = Grayscale;
            Func<Bitmap, Bitmap> rotate90Func = Rotate90;

            Func<Bitmap, Bitmap> processingFunc = grayscaleFunc;
            processingFunc += rotate90Func;

            Action<Bitmap> displayAction = Display;

            string[] imageFiles = Directory.GetFiles(imagesPath);
            foreach (string imageFile in imageFiles)
            {
                Bitmap originalImage = new Bitmap(imageFile);
                Bitmap processedImage = processingFunc(originalImage);
                displayAction(processedImage);
            }
        }
        static Bitmap Grayscale(Bitmap originalImage)
        {
            Bitmap processedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixel = originalImage.GetPixel(x, y);
                    int grayScale = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    Color grayColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    processedImage.SetPixel(x, y, grayColor);
                }
            }

            return processedImage;
        }

        static Bitmap Rotate90(Bitmap originalImage)
        {
            Bitmap processedImage = new Bitmap(originalImage.Height, originalImage.Width);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color pixel = originalImage.GetPixel(x, y);
                    processedImage.SetPixel(y, originalImage.Width - x - 1, pixel);
                }
            }

            return processedImage;
        }

        static void Display(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    if (pixelColor.GetBrightness() < 0.5)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

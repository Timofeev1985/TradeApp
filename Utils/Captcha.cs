using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SkiaSharp;

namespace TradeApp.Utils
{
    public class Captcha
    {
        /// <summary>
        /// Генерирует картинку, содержащую текст капчи
        /// </summary>
        /// <param name="width">ширина изображения</param>
        /// <param name="height">высота изображения</param>
        /// <param name="symbolCount">длина капчи</param>
        /// <returns>возвращает картинку и текст капчи</returns>
        public static (Avalonia.Media.Imaging.Bitmap image, string captcha) CreateImage(int width, int height, int symbolCount)
        {
            Random rnd = new Random();
            //Создадим изображение
            var bmp = new SKBitmap(width, height);
            //Укажем где рисовать
            using SKCanvas canvas = new(bmp);
            //фон картинки
            canvas.Clear(SKColor.Parse("#808080"));
            //Сгенерируем текст
            char symbol;
            // нбор допустимых символов
            string alphabet = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            // текст капчи
            string captcha = "";
            // размер поля для одного символа
            int h = width / symbolCount;
            for (int i = 0; i < symbolCount; ++i)
            {
                // генерируем размер буквы
                int size = rnd.Next(20, h);
                // выбираем любой символ из допустимого набора
                symbol = alphabet[rnd.Next(alphabet.Length)];
                // текст капчи
                captcha += symbol;
                // генерируем позиции рисования символа
                float Ypos = rnd.Next(10, height - size - 15);
                float Xpos = rnd.Next(i * h, (i + 1) * h - size);
                //Нарисуем сгенерированный символ
                using (var paint = new SKPaint())
                {
                    paint.TextSize = 20.0f;
                    paint.IsAntialias = true;
                    paint.Color = new SKColor((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255));
                    paint.TextEncoding = SKTextEncoding.Utf32;
                    canvas.DrawText(symbol.ToString(), Xpos, Ypos, paint);
                    canvas.DrawLine(Xpos + 5, Ypos + 5, rnd.Next(0, width), rnd.Next(0, height), paint);
                }
            }
            for (int j = 0; j < 100; ++j)
                {
                using (var paint = new SKPaint())
                {
                    paint.Style = SKPaintStyle.Fill;
                    paint.IsAntialias = true;
                    paint.Color = SKColors.Blue;
                    paint.StrokeWidth = 1;
                    canvas.DrawCircle(rnd.Next(0, width), rnd.Next(0, height), 1, paint);
                }
            }
            return (SKBitmapToAvaloniaBitmap(bmp), captcha);
        }



        public static Avalonia.Media.Imaging.Bitmap SKBitmapToAvaloniaBitmap(SKBitmap skBitmap)
        {
            SKData data = skBitmap.Encode(SKEncodedImageFormat.Png, 100);
            using (Stream stream = data.AsStream())
            {
                return new Avalonia.Media.Imaging.Bitmap(stream);
            }
        }
    }
}
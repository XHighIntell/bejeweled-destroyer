using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Intell.Win32;

namespace Bejeweled.Kernel {
    public class Game {


        public IntPtr Handle { get; set; }

        public Rectangle CaptureRectangle { get; set; }

        public int JewelSize { get; set; } = 40;

        public Jewel[,] Jewels { get; set; }

        public Game() {

            Jewels = new Jewel[8, 8];
            for (var x = 0; x <= 7; x++) {
                for (var y = 0; y <= 7; y++) {
                    Jewels[x, y] = new Jewel();
                }
            }
        }

        public Bitmap UpdateJewels() {
            var hdc = User32.GetDC(IntPtr.Zero);
            var bitmap = ScreenCapturer.CaptureWindow(Handle, CaptureRectangle, true);
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            

            for (var x = 0; x <= 7; x++) {
                for (var y = 0; y <= 7; y++) {
                    //var color = GetAverageColor(data, new Point(JewelSize / 2 + x * JewelSize, JewelSize / 2 + y * JewelSize), (int)(JewelSize * .3));
                    //var jewel = Jewels[x, y];
                    //jewel.Color = GetJewelColor(color.R, color.G, color.B);

                    var jewel = Jewels[x, y];
                    jewel.Color = GetJewelColor(data, new Point(JewelSize / 2 + x * JewelSize, JewelSize / 2 + y * JewelSize), (int)(JewelSize * .3));
                }
            }




            bitmap.UnlockBits(data);
            User32.ReleaseDC(IntPtr.Zero, hdc);

            return bitmap;
        }


        public static unsafe JewelColors GetJewelColor(BitmapData data, Point point, int sampleSize = 5) {
            var x = point.X - sampleSize / 2;
            var y = point.Y - sampleSize / 2;

            // None = 0, 
            // White = 1, // H = [0; 10]
            // Orange = 2, // H = [25; 40]
            // Yellow = 3, // H = [45; 60]
            // Green = 4, // H = [120; 140]
            // Blue = 5, // H = [190; 220]
            // Purple = 6, // H = [290; 310]
            // Red = 7, // H = [345; 360]

            var record = new ColorScoreRecord();


            for (var i = x; i < x + sampleSize; i++) {
                for (var j = y; j < y + sampleSize; j++) {
                    var p = (int*)(data.Scan0 + i * 3 + j * data.Stride);
                    var color = *p;

                    var b = color & 0xFF;
                    var g = (color >> 8) & 0xFF;
                    var r = (color >> 16) & 0xFF;

                    var hsl = ColorHSL.FromRGB((byte)r, (byte)g, (byte)b);

                    var heu = hsl.H;
                    var value = hsl.B;

                    // ignore all dark color
                    if (value <= .50) continue;

                    if (0 <= heu && heu <= 5) record.Add(JewelColors.White, 1);
                    if (16 <= heu && heu <= 45) {
                        record.Add(JewelColors.Orange, 1);
                        record.Add(JewelColors.Yellow, -1);
                    }
                    if (40 <= heu && heu <= 60) record.Add(JewelColors.Yellow, 1);
                    if (105 <= heu && heu <= 145) {
                        record.Add(JewelColors.Green, 1);
                        record.Add(JewelColors.Red, -1);
                    }
                    if (190 <= heu && heu <= 220) record.Add(JewelColors.Blue, 1);
                    if (290 <= heu && heu <= 310) record.Add(JewelColors.Purple, 1);
                    if (345 <= heu && heu <= 360) record.Add(JewelColors.Red, 1);
                    


                }
            }

            return record.GetHighest(out int score);
        }



    }




}

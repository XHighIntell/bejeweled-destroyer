using Bejeweled.Kernel;
using Intell.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled.Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            button1.MouseUp += Button1_MouseUp;
        }

        private void Button1_MouseUp(object sender, MouseEventArgs e) {

            User32.GetCursorPos(out Point point);
            var hWnd = User32.WindowFromPoint(point.X, point.Y);
            User32.ScreenToClient(hWnd, ref point);

            var game = new Game();
            game.Handle = hWnd;
            game.CaptureRectangle = new Rectangle(point.X, point.Y, game.JewelSize * 8, game.JewelSize * 8);


            ///Game.FirstJewel = new Point(20, 20);
            var bitmap = game.UpdateJewels();

            using (var graphic = Graphics.FromImage(bitmap)) {

                for (var x = 0; x <= 7; x++) {
                    for (var y = 0; y <= 7; y++) {
                        var jewel = game.Jewels[x, y];
                        var brush = Brushes.Black;

                        if (jewel.Color == JewelColors.White) brush = Brushes.White;
                        else if (jewel.Color == JewelColors.Orange) brush = Brushes.Orange;
                        else if (jewel.Color == JewelColors.Yellow) brush = Brushes.Yellow;
                        else if (jewel.Color == JewelColors.Green) brush = Brushes.Green;
                        else if (jewel.Color == JewelColors.Blue) brush = Brushes.Blue;
                        else if (jewel.Color == JewelColors.Purple) brush = Brushes.Purple;
                        else if (jewel.Color == JewelColors.Red) brush = Brushes.Red;


                        graphic.FillRectangle(brush, x * game.JewelSize, y * game.JewelSize, game.JewelSize, game.JewelSize);

                    }
                }
                
                

            }


            this.BackgroundImage = bitmap;


            game.UpdateJewels();

        }
    }
}

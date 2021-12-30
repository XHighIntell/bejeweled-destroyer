using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Intell.Win32;

using Bejeweled.Kernel;


namespace Bejeweled.Forms {
    public partial class EntryForm : Form {
        public EntryForm() {
            InitializeComponent();

            User32.RegisterHotKey(this.Handle, 0, 2, (int)Keys.F1);
            User32.RegisterHotKey(this.Handle, 1, 2, (int)Keys.F2);


            _prioritizeColor.Items.AddRange(Enum.GetNames(typeof(JewelColors)));

            _timer.Tick += timer_Tick;
            _sizeNumeric.ValueChanged += (sender, e) => {
                Game.JewelSize = (int)_sizeNumeric.Value;
            };
            _speedNumeric.ValueChanged += (sender, e) => {
                _timer.Interval = (int)_speedNumeric.Value;
            };
            _prioritizeColor.SelectedIndexChanged += (sender, e) => {
                prioritizeColor = (JewelColors)Enum.Parse(typeof(JewelColors), (string)_prioritizeColor.Items[_prioritizeColor.SelectedIndex]);
            };
            
        }



        Game Game = new Game();
        JewelColors prioritizeColor = JewelColors.None;

        async void button1_Click(object sender, EventArgs e) {
            //var dc = User32.GetWindowDC(new IntPtr(0));

            await Task.Delay(2000);
            
            User32.PostMessageA(new IntPtr(21302322), WindowsMessages.WM_LBUTTONDOWN, 1, 661 + 645 * 256 * 256);
            User32.PostMessageA(new IntPtr(21302322), 514, 0, 661 + 645 * 256 * 256);

            //this.BackgroundImage = Capturer.Capture(dc, 0, 0, 100, 100);
            //Gdi32.BitBlt()
        }

        void droplabel_MouseUp(object sender, MouseEventArgs e) {

            User32.GetCursorPos(out Point point);
            var hWnd = User32.WindowFromPoint(point.X, point.Y);
            User32.ScreenToClient(hWnd, ref point);

            this._handleLabel.Text = hWnd.ToString();
            Game.Handle = hWnd;
            Game.CaptureRectangle = new Rectangle(point.X, point.Y, Game.JewelSize * 8, Game.JewelSize * 8);

            var sw = new Stopwatch();
            sw.Start();
            ///Game.FirstJewel = new Point(20, 20);
            var bitmap = Game.UpdateJewels();


            pictureBox1.BackgroundImage = bitmap;


            var solutions = MoveSolution.Find(Game.Jewels);
            var xx = MoveSolution.FilterMoveCanInOneTime(Game.Jewels, solutions);


            sw.Stop();

            this.Text = solutions.Length.ToString() + " " + sw.ElapsedMilliseconds;

            //Game.FirstJewel =
        }



        void timer_Tick(object sender, EventArgs e) {
            Game.UpdateJewels().Dispose();

            

            var solutions = MoveSolution.Find(Game.Jewels).OrderBy((a) => {

                var score = a.Score;

                if (prioritizeColor == JewelColors.White) score += 256 * a.DestroyedWhite;
                else if (prioritizeColor == JewelColors.Orange) score += 256 * a.DestroyedOrange;
                else if (prioritizeColor == JewelColors.Yellow) score += 256 * a.DestroyedYellow;
                else if (prioritizeColor == JewelColors.Green) score += 256 * a.DestroyedGreen;
                else if (prioritizeColor == JewelColors.Blue) score += 256 * a.DestroyedBlue;
                else if (prioritizeColor == JewelColors.Purple) score += 256 * a.DestroyedPurple;
                else if (prioritizeColor == JewelColors.Red) score += 256 * a.DestroyedRed;

                return -score;
            }).ToArray();

            this.Text = solutions.Length.ToString();

            solutions = MoveSolution.FilterMoveCanInOneTime(Game.Jewels, solutions).Take(5).ToArray();

            foreach (var solution in solutions) MoveJewel(solution);
        }

        void MoveJewel(MoveSolution solution) {
            var x1 = Game.CaptureRectangle.Left + Game.JewelSize / 2 + solution.From.X * Game.JewelSize;
            var y1 = Game.CaptureRectangle.Top + Game.JewelSize / 2 + solution.From.Y * Game.JewelSize;

            var x2 = Game.CaptureRectangle.Left + Game.JewelSize / 2 + solution.To.X * Game.JewelSize;
            var y2 = Game.CaptureRectangle.Top + Game.JewelSize / 2 + solution.To.Y * Game.JewelSize;



            User32.SendMessageA(Game.Handle, WindowsMessages.WM_LBUTTONDOWN, 1, x1 + y1 * 256 * 256);
            User32.SendMessageA(Game.Handle, 514, 0, x1 + y1 * 256 * 256);

            User32.SendMessageA(Game.Handle, WindowsMessages.WM_LBUTTONDOWN, 1, x2 + y2 * 256 * 256);
            User32.SendMessageA(Game.Handle, 514, 0, x2 + y2 * 256 * 256);
        }


        protected override void WndProc(ref Message m) {

            if (m.Msg == WindowsMessages.WM_HOTKEY) {
                if (m.WParam.ToInt32() == 0) {
                    _timer.Enabled = false;
                }
                else if (m.WParam.ToInt32() == 1) {
                    _timer.Enabled = true;
                    timer_Tick(null, null);
                }
            }

            base.WndProc(ref m);
        }


    }



}

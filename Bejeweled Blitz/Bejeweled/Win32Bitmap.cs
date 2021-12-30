using System;
using Intell.Win32;

namespace Bejeweled {
    ///<summary>Native Bitmap.</summary>
    public class Win32Bitmap {

        public Win32Bitmap() { }
        public Win32Bitmap(int width, int height) {
            var screen_hdc = User32.GetWindowDC(IntPtr.Zero);
            var hdc = Gdi32.CreateCompatibleDC(screen_hdc);
            var hBitmap = Gdi32.CreateCompatibleBitmap(screen_hdc, width, height);

            Gdi32.SelectObject(hdc, hBitmap);
            User32.ReleaseDC(IntPtr.Zero, screen_hdc);

            this.Hdc = hdc;
            this.Handle = hBitmap;
        }

        public IntPtr Hdc { get; set; }
        public IntPtr Handle { get; set; }

    }

}

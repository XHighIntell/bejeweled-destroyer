using System;
using System.Collections.Generic;
using System.Drawing;
using Intell.Win32;

namespace Bejeweled {

    ///<summary>Utility that helps capturing screen to bitmap.</summary>
    public static class ScreenCapturer {

        static Dictionary<string, Win32Bitmap> cache = new Dictionary<string, Win32Bitmap>();


        public static Bitmap CaptureHdc(IntPtr hdc, int left, int top, int width, int height) {

            var win32bitmap = CreateOrReuseWin32Bitmap(width, height);

            //User32.GetClientRect(_handle, out Rectangle clientRect);
            //MapWindowPoints(_handle, IntPtr.Zero, ref clientRect, 2);

            Gdi32.BitBlt(win32bitmap.Hdc, 0, 0, width, height, hdc, left, top, 13369376);

            //User32.ReleaseDC(IntPtr.Zero, hdc);

            return Image.FromHbitmap(win32bitmap.Handle);
        }

        ///<summary>Capture a window to bitmap.</summary>
        ///<param name="hwnd">The handle of window.</param>
        ///<param name="rectangle">Relative to hWnd.</param>
        ///<param name="useScreenCapture">If true, use screen's DC for capture.</param>
        public static Bitmap CaptureWindow(IntPtr hwnd, Rectangle rectangle, bool useScreenCapture) {

            var win32bitmap = CreateOrReuseWin32Bitmap(rectangle.Width, rectangle.Height);
            

            if (useScreenCapture == true) {
                var hdc = User32.GetDC(IntPtr.Zero);

                User32.GetWindowRect(hwnd, out Rectangle windowRect);
                Gdi32.BitBlt(win32bitmap.Hdc, 0, 0, rectangle.Width, rectangle.Height, hdc, windowRect.Left + rectangle.Left, windowRect.Top + rectangle.Top, 13369376);
                User32.ReleaseDC(IntPtr.Zero, hdc);

                return Image.FromHbitmap(win32bitmap.Handle);
            }
            else {
                
                var hdc = User32.GetDC(IntPtr.Zero);

                Gdi32.BitBlt(win32bitmap.Hdc, 0, 0, rectangle.Width, rectangle.Height, hdc, rectangle.Left, rectangle.Top, 13369376);

                User32.ReleaseDC(IntPtr.Zero, hdc);

                return Image.FromHbitmap(win32bitmap.Handle);

            }
        }


        

        static Win32Bitmap CreateOrReuseWin32Bitmap(int width, int height) {
            var key = width + "x" + height;
            Win32Bitmap win32bitmap = null;

            if (cache.ContainsKey(key) == true) win32bitmap = cache[key];

            if (win32bitmap == null) {
                win32bitmap = new Win32Bitmap(width, height);

                cache.Add(key, win32bitmap);
            }

            return win32bitmap;
        }

    }



}

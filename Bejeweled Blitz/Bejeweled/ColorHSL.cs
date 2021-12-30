using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejeweled {

    public struct ColorHSL {
        public ColorHSL(float h, float s, float l, float b) {
            H = h;
            S = s;
            L = l;
            B = b;
        }

        public float H;
        public float S;
        public float L;
        public float B;

        public static ColorHSL FromRGB(byte red, byte green, byte blue) {
            float _R = (red / 255f);
            float _G = (green / 255f);
            float _B = (blue / 255f);

            float _Min = Math.Min(Math.Min(_R, _G), _B);
            float _Max = Math.Max(Math.Max(_R, _G), _B);
            float _Delta = _Max - _Min;

            float H = 0;
            float S = 0;
            float L = (float)((_Max + _Min) / 2.0f);
            float B = 0;

            if (_Delta != 0) {
                if (L < 0.5f) {
                    S = (float)(_Delta / (_Max + _Min));
                }
                else {
                    S = (float)(_Delta / (2.0f - _Max - _Min));
                }


                if (_R == _Max) { H = (_G - _B) / _Delta; }
                else if (_G == _Max) { H = 2f + (_B - _R) / _Delta; }
                else if (_B == _Max) { H = 4f + (_R - _G) / _Delta; }
            }

            H *= 60;

            if (H < 0) H += 360;
            B = _Max;

            return new ColorHSL(H, S, L, B);
        }


    }
}

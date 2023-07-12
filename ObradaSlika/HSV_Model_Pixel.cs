using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika
{
    public static class HSV_Model_Pixel
    {   
        public static void RGB2HSV(Color c, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(c.R, Math.Max(c.G, c.B));
            int min = Math.Min(c.R, Math.Min(c.G, c.B));

            hue = c.GetHue();
            if(max == 0)
            {
                saturation = 0;
            }
            else
            {
                saturation = 1.0 - (1.0 * min / max);
            }
            value = max / 255.0;
        }
        public static Color HSV2RGB(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(v, t, p);
            else if (hi == 1)
                return Color.FromArgb(q, v, p);
            else if (hi == 2)
                return Color.FromArgb(p, v, t);
            else if (hi == 3)
                return Color.FromArgb(p, q, v);
            else if (hi == 4)
                return Color.FromArgb(t, p, v);
            else
                return Color.FromArgb(v, p, q);
        }
    }
}

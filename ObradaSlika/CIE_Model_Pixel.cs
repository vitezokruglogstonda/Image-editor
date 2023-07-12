using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika
{
    public class CIE_Model_Pixel 
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public CIE_Model_Pixel()
        {
            this.X = 0.0;
            this.Y = 0.0;
            this.Z = 0.0;
        }
           
        private void LinearToSRgb(ref int[] sRgb, double[] linearRgb, int c)
        {
            double tmp;
            for (int i = 0; i < c; i++) 
            {
                tmp = 0;
                if (Math.Abs(linearRgb[i]) < 0.0031308)
                {
                    tmp = linearRgb[i] * 12.92;
                }
                else
                {
                    tmp = 1.055 * Math.Pow(linearRgb[i], (1.0 / 2.4)) - 0.055;
                }
                //sRgb[i] = Convert.ToInt32(tmp*255);
                sRgb[i] = (int)(tmp * 255);
            }
        }
        public void SRgbToLinear(ref double[] linearRgb, int[] sRgb, int c)
        {
            for(int i=0; i<c; i++)
            {
                linearRgb[i] = (double)(sRgb[i] / 255.0);
            }
            for (int i = 0; i < c; i++)
            {
                if(linearRgb[i] > 0.04045)
                {
                    linearRgb[i] = Math.Pow((linearRgb[i] + 0.055) / (1 + 0.055), 2.2);
                }
                else
                {
                    linearRgb[i] = linearRgb[i] / 12.92;
                }
            }
        }
        public void XyzToRgb_Negative()
        {
            int c = 3;
            double[,] constants = new double[3, 3] { { 3.2410, -1.5374, -0.4986 }, { -0.9692, 1.8760, 0.0416 }, { 0.0556, -0.2040, 1.0570 } };
            double[] xyz = new double[3] { this.X, this.Y, this.Z };
            double[] linearRgb = new double[3];
            int[] sRgb = new int[3];
            for (int i = 0; i < c; i++)
            {
                double acc = 0;
                for (int j = 0; j < c; j++)
                {
                    acc += constants[i, j] * xyz[j];
                }
                linearRgb[i] = acc;
            }
            this.LinearToSRgb(ref sRgb, linearRgb, c);
            for (int i = 0; i < c; i++)
            {
                if (sRgb[i] > 255)
                {
                    sRgb[i] = 255;
                }
                else if (sRgb[i] < -255)
                {
                    sRgb[i] = -255;
                }
            }
            this.R = sRgb[0];
            this.G = sRgb[1];
            this.B = sRgb[2];
        }
        public void XyzToRgb()
        {
            int c = 3;
            double[,] constants = new double[3, 3] { { 3.2410, -1.5374, -0.4986 }, { -0.9692, 1.8760, 0.0416 }, { 0.0556, -0.2040, 1.0570 } };
            double[] xyz = new double[3] { this.X, this.Y, this.Z };
            double[] linearRgb = new double[3];
            int[] sRgb = new int[3];
            for (int i = 0; i < c; i++)
            {
                double acc = 0;
                for (int j = 0; j < c; j++)
                {
                    acc += constants[i, j] * xyz[j];
                }
                linearRgb[i] = acc;
            }
            this.LinearToSRgb(ref sRgb, linearRgb, c);
            for (int i = 0; i < c; i++)
            {
                if (sRgb[i] > 255)
                {
                    sRgb[i] = 255;
                }
                else if (sRgb[i] < 0)
                {
                    sRgb[i] = 0;
                }
            }
            this.R = sRgb[0];
            this.G = sRgb[1];
            this.B = sRgb[2];
        }
        public void RgbToXyz()
        {
            int c = 3;
            double[,] constants = new double[3, 3] { { 0.4124, 0.3576, 0.1805 }, { 0.2126, 0.7152, 0.0722 }, { 0.0193, 0.1192, 0.9505 } };
            double[] xyz = new double[3];
            double[] linearRgb = new double[3];
            int[] sRgb = new int[3] { this.R, this.G, this.B };
            this.SRgbToLinear(ref linearRgb, sRgb, c);
            for(int i=0; i<c; i++)
            {
                double acc = 0;
                for (int j = 0; j < c; j++)
                {
                    acc += constants[i, j] * linearRgb[j];
                }
                xyz[i] = acc;
            }
            this.X = xyz[0];
            this.Y = xyz[1];
            this.Z = xyz[2];
        }
        public int[] Extract(Color c, int skip)
        {
            this.R = (int)c.R;
            this.G = (int)c.G;
            this.B = (int)c.B;
            this.RgbToXyz();
            double[] xyz = new double[3] { this.X, this.Y, this.Z };
            for (int i = 0; i < 3; i++)
            {
                if (i != skip)
                {
                    xyz[i] = 0;
                }
            }
            this.X = xyz[0];
            this.Y = xyz[1];
            this.Z = xyz[2];
            this.XyzToRgb();
            int[] new_color = new int[3] { this.R, this.G, this.B };
            return new_color;
        }
        public int AverageRGB()
        {
            int result;
            result = Convert.ToInt32((this.R + this.G + this.B) / 3);
            if (result > 255)
            {
                result = 255;
            }
            return result;
        }
    }
}

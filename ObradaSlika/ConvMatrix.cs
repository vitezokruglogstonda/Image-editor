using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObradaSlika
{
    public class ConvMatrix
	{
		public int Dim;
		private int OutValue;
		private int CenterVelue;
		private int[,] Matrix;
		private int Factor;
		private int Offset;
		//public ConvMatrix(int factor, int offset, int outValue, int dim = 3)
		public ConvMatrix(int outValue, int center, int offset, int dim = 3)
		{
			this.OutValue = outValue;
			this.CenterVelue = center;
			if (dim % 2 == 1)
			{
				this.Dim = dim;
			}
			else
			{
				this.Dim = 3;
			}
			this.Matrix = new int[this.Dim, this.Dim];
			for (int i = 0; i < dim; i++)
			{
				for (int j = 0; j < dim; j++)
				{
					this.Matrix[i, j] = this.OutValue;
				}
			}
			this.Factor = this.CalculateFactor();
			this.SetCentralPixel(this.CenterVelue);
			this.Offset = offset;
		}
		private int CalculateFactor()
        {
			int sum = 0;
			int times = (this.Dim * this.Dim) - 1;
			for (int i = 0; i<times; i++)
            {
				sum += this.OutValue;
            }
			return this.CenterVelue + sum;
        }
		private void SetCentralPixel(int nVal)
		{
			int index = (this.Dim - 1) / 2;
			this.Matrix[index, index] = nVal;
		}
		public int[] Calclulate(Color[,] subPicture)
		{
			//izracunaj krajnju RGB vrednost rezultujuceg piksela
			int[] new_pixel = new int[3];
			int kR, kG, kB, sR = 0, sG = 0, sB = 0;
			for (int i = 0; i < this.Dim; i++)
			{
				for (int j = 0; j < this.Dim; j++)
				{
					sR += subPicture[i, j].R * this.Matrix[i, j];
					sG += subPicture[i, j].G * this.Matrix[i, j];
					sB += subPicture[i, j].B * this.Matrix[i, j];
				}
			}
			kR = (sR / this.Factor) + this.Offset;
			kG = (sG / this.Factor) + this.Offset;
			kB = (sB / this.Factor) + this.Offset;

			if (kR < 0)
			{
				kR = 0;
			}
			else if (kR > 255)
			{
				kR = 255;
			}
			if (kG < 0)
			{
				kG = 0;
			}
			else if (kG > 255)
			{
				kG = 255;
			}
			if (kB < 0)
			{
				kB = 0;
			}
			else if (kB > 255)
			{
				kB = 255;
			}

			new_pixel[0] = kR;
			new_pixel[1] = kG;
			new_pixel[2] = kB;

			return new_pixel;
		}
		public void Calclulate_Unsafe(ref Bitmap b)
		{

			Bitmap bSrc = (Bitmap)b.Clone();
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			int stride2 = stride * 2;
			System.IntPtr Scan0 = bmData.Scan0;
			System.IntPtr SrcScan0 = bmSrc.Scan0;

			unsafe
			{
				int topLeft = this.Matrix[0, 0];
				int topMid = this.Matrix[0, 1];
				int topRight = this.Matrix[0, 2];
				int midLeft = this.Matrix[1, 0];
				int pixel = this.Matrix[1, 1];
				int midRight = this.Matrix[1, 2];
				int bottomLeft = this.Matrix[2, 0];
				int bottomMid = this.Matrix[2, 1];
				int bottomRight = this.Matrix[2, 2];

				byte* p = (byte*)(void*)Scan0;
				byte* pSrc = (byte*)(void*)SrcScan0;

				int nOffset = stride - b.Width * 3;
				int nWidth = b.Width - 2;
				int nHeight = b.Height - 2;

				int nPixel;

				int sum;
				int next = 3;
				int index;
				int tmpStride;
					//((dim*3 - 1) / 2) - 1
					//((dim-1) / 2) * 3
				int centerIndex = ((this.Dim - 1) * 3) / 2;
				int blue = 0;
				int green = 1;
				int red = 2;

				for (int y = 0; y < nHeight; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						//Red
						sum = 0;
						tmpStride = 0;
						for(int i = 0; i<this.Dim; i++)
                        {
							index = 0;
							for (int j = 0; j < this.Dim; j++)
							{
								sum += this.Matrix[i,j]*pSrc[index+red+tmpStride];
								index += next;
							}
							tmpStride += stride;
						}
						
						nPixel = (sum / this.Factor) + this.Offset;

						if (nPixel < 0) nPixel = 0;
						if (nPixel > 255) nPixel = 255;
						
						p[centerIndex + red + stride] = (byte)nPixel;

						//Green
						sum = 0;
						tmpStride = 0;
						for (int i = 0; i < this.Dim; i++)
						{
							index = 0;
							for (int j = 0; j < this.Dim; j++)
							{
								sum += this.Matrix[i, j] * pSrc[index + green + tmpStride];
								index += next;
							}
							tmpStride += stride;
						}

						nPixel = (( sum / this.Factor) + this.Offset);

						if (nPixel < 0) nPixel = 0;
						if (nPixel > 255) nPixel = 255;

						p[centerIndex + green + stride] = (byte)nPixel;

						//Blue
						sum = 0;
						tmpStride = 0;
						for (int i = 0; i < this.Dim; i++)
						{
							index = 0;
							for (int j = 0; j < this.Dim; j++)
							{
								sum += this.Matrix[i, j] * pSrc[index + blue + tmpStride];
								index += next;
							}
							tmpStride += stride;
						}

						nPixel = ( sum / this.Factor) + this.Offset;

						if (nPixel < 0) nPixel = 0;
						if (nPixel > 255) nPixel = 255;

						p[centerIndex + blue + stride] = (byte)nPixel;

						p += 3;
						pSrc += 3;
					}
					p += nOffset;
					pSrc += nOffset;
				}
			}

			b.UnlockBits(bmData);
			bSrc.UnlockBits(bmSrc);
		}
	}
}

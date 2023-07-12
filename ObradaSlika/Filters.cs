using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ObradaSlika
{	
	public class Filters
    {
		public struct FloatPoint
		{
			public double X;
			public double Y;
		}
		private static int[,] OrderDitheringMatrix = null;
		private static int[,] SimpleColorize_Matrix_Default = null;
		private static int[,] SimpleColorize_Matrix_Custom = null;
		private static int[] SimpleColorize_Range = null;
		public Filters()
        {
			
        }
		public static void GenerateMapping(Bitmap image)
        {
			SimpleColorize_Populate();
			if (SimpleColorize_Matrix_Custom == null)
			{
				SimpleColorize_Matrix_Custom = new int[4, 3];
			}
			int gray;
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					Color c = image.GetPixel(x, y);
					gray = (c.R + c.G + c.B) / 3;
					for (int i = 1; i < SimpleColorize_Range.Length; i++)
					{
						if (gray < SimpleColorize_Range[i])
						{
							SimpleColorize_Matrix_Custom[i, 0] = c.R;
							SimpleColorize_Matrix_Custom[i, 1] = c.G;
							SimpleColorize_Matrix_Custom[i, 2] = c.B;
							break;
						}
					}
				}
			}
		}
		private static void SimpleColorize_Populate()
        {
            if (SimpleColorize_Matrix_Default == null)
            {
				SimpleColorize_Matrix_Default = new int[4,3] { { 0, 0, 0 }, { 101, 67, 33 }, { 255, 105, 180 }, { 255, 255, 255 } };
            }
			if(SimpleColorize_Range == null)
            {
				SimpleColorize_Range = new int[4] { 50, 120, 160, 255};
            }
        }
		private static void PopulateOrderDitherMatrix()
        {
			if(OrderDitheringMatrix == null)
			{
				OrderDitheringMatrix = new int[3, 3] { { 8, 3, 4 }, { 6, 1, 2 }, { 7, 5, 9 } };
			}
		}
		private static int ScaleDown(int num)
        {
			int res = 0, tmp = 0;

			for (int i = 0; i < 10; i++)
			{
				tmp += 255 / 9;
				if (tmp > num)
				{
					res = i;
					break;
				}
			}
			return res;
		}
		private static int ScaleUp(int num)
		{
			return Convert.ToInt32(255 / 9)*num;
		}
		public static void SeparateChannels(ref List<Bitmap> channels)//za sve 3 slike treba da vrati: 1.bez YZ ; 2.bez XZ ; 3. bez XY
        {
			CIE_Model_Pixel cie = new CIE_Model_Pixel();
			for(int i=0; i<3; i++)
            {
				for (int x = 0; x < channels[i].Width; x++)
				{
					for (int y = 0; y < channels[i].Height; y++)
					{
						Color c = channels[i].GetPixel(x, y);
						int[] new_color = cie.Extract(c, i);
						channels[i].SetPixel(x, y, Color.FromArgb(new_color[0], new_color[1], new_color[2]));
					}
				}
			}
        }
		public static void DownsampleChannels(ref List<Bitmap> channels)
		{
			CIE_Model_Pixel cie = new CIE_Model_Pixel();
			Color?[,] subPicture = new Color?[2,2];
			for (int i = 0; i < 3; i++)
			{
				for (int x = 0; x < channels[i].Width; x++)
				{
					for (int y = 0; y < channels[i].Height; y++)
					{
                        if (i == 0)
                        {
							Color c = channels[i].GetPixel(x, y);
							int[] new_color = cie.Extract(c, i);
							channels[i].SetPixel(x, y, Color.FromArgb(new_color[0], new_color[1], new_color[2]));
                        }
                        else if (x % 2 == 0 && y % 2 == 0)
						{
							int[] topLeft = null, bottomLeft = null, newValue = null;
							for  (int q = 0; q < 2; q++)
                            {
								for (int p = 0; p < 2; p++)
								{
									if(x+q < channels[i].Width && y+p < channels[i].Height)
                                    {
										if (p == 0 && q == 0)
										{
											Color c = channels[i].GetPixel(x + q, y + p);
											topLeft = cie.Extract(c, i);
											newValue = topLeft.ToArray();
										}
										else if (p == 1 && q == 0)
										{
											Color c = channels[i].GetPixel(x + q, y + p);
											bottomLeft = cie.Extract(c, i);
											for (int r = 0; r < 3; r++)
											{
												newValue[r] = (topLeft[r] + bottomLeft[r]) / 2;
											}
										}
										channels[i].SetPixel(x + q, y + p, Color.FromArgb(newValue[0], newValue[1], newValue[2]));
									}
								}
							}
							channels[i].SetPixel(x, y, Color.FromArgb(newValue[0], newValue[1], newValue[2]));
						}
					}
				}
			}
		}
		public static void SeparateGrayscale(ref List<Bitmap> grayscale, int numberOfShades)
        {
			Arithmetic(grayscale[0]);
			Max(grayscale[1]);
			Custom(grayscale[2], numberOfShades);
        }
		private static void Arithmetic(Bitmap image)
        {
			Bitmap copy = (Bitmap)image.Clone();
			int gray;
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					Color c = copy.GetPixel(x, y);
					gray = (c.R+c.G+c.B) / 3;
					image.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
				}
			}
		}
		private static void Max(Bitmap image)
		{
			Bitmap copy = (Bitmap)image.Clone();
			int gray;
			int[] tmp = new int[3];
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					Color c = copy.GetPixel(x, y);
					tmp[0] = c.R;
					tmp[1] = c.G;
					tmp[2] = c.B;
					gray = tmp.Max();
					image.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
				}
			}
		}
		private static void Custom(Bitmap image, int numberOfShades = 3)
		{
			Bitmap copy = (Bitmap)image.Clone();
			decimal ConversionFactor = 255 / (numberOfShades - 1);			
			decimal avg;
			int gray;
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					Color c = copy.GetPixel(x, y);
					avg = (c.R + c.G + c.B) / 3;
					gray = Convert.ToInt32(((avg/ConversionFactor)+(decimal)0.5)*ConversionFactor);
                    if (gray>255)
                    {
						gray = 255;
                    }
					image.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
				}
			}
		}
		public static void Color_Standard(Bitmap image, int red, int green, int blue)
		{
			for (int x = 0; x < image.Width; x++)
            {
				for (int y = 0; y < image.Height; y++)
				{
					Color c = image.GetPixel(x, y);
					int newRed = c.R + red;
					int newGreen = c.G + green;
					int newBlue = c.B + blue;
					if (newRed < 0)
					{
						newRed = 0;
					}
					else if (newRed > 255)
					{
						newRed = 255;
					}
					if (newGreen < 0)
					{
						newGreen = 0;
					}
					else if (newGreen > 255)
					{
						newGreen = 255;
					}
					if (newBlue < 0)
					{
						newBlue = 0;
					}
					else if (newBlue > 255)
					{
						newBlue = 255;
					}
					image.SetPixel(x,y,Color.FromArgb(newRed, newGreen, newBlue));
				}
			}
		}
		public static bool Color_Unsafe(Bitmap image, int red, int green, int blue)
		{
			if (red < -255 || red > 255) return false;
			if (green < -255 || green > 255) return false;
			if (blue < -255 || blue > 255) return false;

			BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				int nOffset = stride - image.Width * 3;
				int nPixel;

				for (int y = 0; y < image.Height; ++y)
				{
					for (int x = 0; x < image.Width; ++x)
					{
						nPixel = p[2] + red;
						nPixel = Math.Max(nPixel, 0);
						p[2] = (byte)Math.Min(255, nPixel);

						nPixel = p[1] + green;
						nPixel = Math.Max(nPixel, 0);
						p[1] = (byte)Math.Min(255, nPixel);

						nPixel = p[0] + blue;
						nPixel = Math.Max(nPixel, 0);
						p[0] = (byte)Math.Min(255, nPixel);

						p += 3;
					}
					p += nOffset;
				}
			}

			image.UnlockBits(bmData);

			return true;
		}
		public static void MeanRemoval_Standard(Bitmap image, int centerValue, int kernelSize)
        {
			Bitmap copy = (Bitmap)image.Clone();

			int offset;
            switch (kernelSize)
            {
				case 5:
					offset = (int)Math.Pow(2, 5);
					break;
				case 7:
					offset = (int)Math.Pow(2, 7);
					break;
				default:
					offset = 0;
					break;
			}
			ConvMatrix kernel = new ConvMatrix(-1, centerValue, offset, kernelSize);

			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					//izvuci podsliku (u zavisnosti od velicine konvolucione matrice)
					Color[,] tmpSubPicture = new Color[kernel.Dim, kernel.Dim];
					int center_index = (kernel.Dim-1)/2;
					int start_x = x - center_index;
					int start_y = y - center_index;
					//int end_x = x + center_index;
					//int end_y = y + center_index;
					//for(int i=start_x; i<end_x; i++)
					for (int i = 0; i < kernel.Dim; i++)
					{
						//for(int j = start_y; j < end_y; j++)
						for (int j = 0; j < kernel.Dim; j++)
						{
							if((start_x + i) >= 0 && (start_x + i) < image.Width && (start_y+j)>=0 && (start_y + j) < image.Height)
                            {
								tmpSubPicture[j, i] = copy.GetPixel((start_x + i), (start_y + j));
							}
                            else
                            {
								tmpSubPicture[j, i] = Color.FromArgb(127, 127, 127);
							}
						}
					}
					int[] new_color = kernel.Calclulate(tmpSubPicture);
					image.SetPixel(x, y, Color.FromArgb(new_color[0], new_color[1], new_color[2]));
				}
			}
		}
		public static void MeanRemoval_Unsafe(Bitmap image, int centerValue, int kernelSize)
        {
			int offset;
			switch (kernelSize)
			{
				case 5:
					offset = (int)Math.Pow(2, 5);
					break;
				case 7:
					offset = (int)Math.Pow(2, 7);
					break;
				default:
					offset = 0;
					break;
			}
			ConvMatrix kernel = new ConvMatrix(-1, centerValue, offset, kernelSize);
			kernel.Calclulate_Unsafe(ref image);
		}
		public static void Invert_Standard(Bitmap image)
        {
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					Color c = image.GetPixel(x, y);
					int newRed = 255 - c.R;
					int newGreen = 255 - c.G;
					int newBlue = 255 - c.B;
					image.SetPixel(x, y, Color.FromArgb(newRed, newGreen, newBlue));
				}
			}
		}
		public static void Invert_Unsafe(Bitmap image)
		{
			BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				int nOffset = stride - image.Width * 3;
				int nWidth = image.Width * 3;

				for (int y = 0; y < image.Height; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						p[0] = (byte)(255 - p[0]);
						++p;
					}
					p += nOffset;
				}
			}

			image.UnlockBits(bmData);
		}
		private static int[] EdgeDetectHomogenity_Calculate(Color[,] tmpSubPicture, int threshold)
        {
			int[] new_pixel = new int[3];
			Color s = tmpSubPicture[1, 1];
			int sR = s.R;
			int sG = s.G;
			int sB = s.B;
			int maxR = 0;
			int maxG = 0;
			int maxB = 0;
			int difR, difG, difB;
			for (int i = 0; i < 3; i++)
            {
				for (int j = 0; j < 3; j++)
				{
					if(i != 1 && j != 1)
                    {
						difR = Math.Abs(tmpSubPicture[i,j].R - sR);
						if(difR > maxR)
                        {
							maxR = difR;
                        }
						difG = Math.Abs(tmpSubPicture[i, j].G - sG);
						if (difG > maxG)
						{
							maxG = difG;
						}
						difB = Math.Abs(tmpSubPicture[i, j].B - sB);
						if (difB > maxB)
						{
							maxB = difB;
						}
					}
				}
			}
			if(maxR < threshold)
            {
				maxR = 0;
            }
			if (maxG < threshold)
			{
				maxG = 0;
			}
			if (maxB < threshold)
			{
				maxB = 0;
			}
			new_pixel[0] = maxR;
			new_pixel[1] = maxG;
			new_pixel[2] = maxB;
			return new_pixel;
		}
		public static void EdgeDetectHomogenity_Standard(Bitmap image, int threshold)
        {
			Bitmap copy = (Bitmap)image.Clone();
			Color[,] tmpSubPicture;
			for (int x = 0; x < image.Width-2; x++)
			{
				for (int y = 0; y < image.Height-2; y++)
				{
					tmpSubPicture = new Color[3, 3];
					for (int i = 0; i < 3; i++)
					{
						for (int j = 0; j < 3; j++)
						{
							tmpSubPicture[j, i] = copy.GetPixel((x + i), (y + j));
						}
					}
					int[] new_color = EdgeDetectHomogenity_Calculate(tmpSubPicture, threshold);
					image.SetPixel(x+1, y+1, Color.FromArgb(new_color[0], new_color[1], new_color[2]));					
				}
			}
		}
		public static void EdgeDetectHomogenity_Unsafe(Bitmap b, byte threshold)
		{
			Bitmap b2 = (Bitmap)b.Clone();

			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bmData2 = b2.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;
			System.IntPtr Scan02 = bmData2.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;
				byte* p2 = (byte*)(void*)Scan02;

				int nOffset = stride - b.Width * 3;
				int nWidth = b.Width * 3;

				int nPixel = 0, nPixelMax = 0;

				p += stride;
				p2 += stride;

				for (int y = 1; y < b.Height - 1; ++y)
				{
					p += 3;
					p2 += 3;

					for (int x = 3; x < nWidth - 3; ++x)
					{
						nPixelMax = Math.Abs(p2[0] - (p2 + stride - 3)[0]);
						nPixel = Math.Abs(p2[0] - (p2 + stride)[0]);
						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs(p2[0] - (p2 + stride + 3)[0]);
						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs(p2[0] - (p2 - stride)[0]);
						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs(p2[0] - (p2 + stride)[0]);
						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs(p2[0] - (p2 - stride - 3)[0]);
						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs(p2[0] - (p2 - stride)[0]);
						if (nPixel > nPixelMax) nPixelMax = nPixel;

						nPixel = Math.Abs(p2[0] - (p2 - stride + 3)[0]);
						if (nPixel > nPixelMax) nPixelMax = nPixel;

						if (nPixelMax < threshold) nPixelMax = 0;

						p[0] = (byte)nPixelMax;

						++p;
						++p2;
					}

					p += 3 + nOffset;
					p2 += 3 + nOffset;
				}
			}

			b.UnlockBits(bmData);
			b2.UnlockBits(bmData2);
		}
		private static Point[,] TimeWrap_Mechanism(int nWidth, int nHeight, Byte factor)
        {
			FloatPoint[,] fp = new FloatPoint[nWidth, nHeight];
			Point[,] pt = new Point[nWidth, nHeight];

			Point mid = new Point();
			mid.X = nWidth / 2;
			mid.Y = nHeight / 2;

			double theta, radius;
			double newX, newY;

			for (int x = 0; x < nWidth; ++x)
			{
				for (int y = 0; y < nHeight; ++y)
				{
					int trueX = x - mid.X;
					int trueY = y - mid.Y;
					theta = Math.Atan2((trueY), (trueX));

					radius = Math.Sqrt(trueX * trueX + trueY * trueY);

					double newRadius = Math.Sqrt(radius) * factor;

					newX = mid.X + (newRadius * Math.Cos(theta));
					if (newX > 0 && newX < nWidth)
					{
						fp[x, y].X = newX;
						pt[x, y].X = (int)newX;
					}
					else
					{
						fp[x, y].X = 0.0;
						pt[x, y].X = 0;
					}

					newY = mid.Y + (newRadius * Math.Sin(theta));
					if (newY > 0 && newY < nHeight)
					{
						fp[x, y].Y = newY;
						pt[x, y].Y = (int)newY;
					}
					else
					{
						fp[x, y].Y = 0.0;
						pt[x, y].Y = 0;
					}
				}
			}
			return pt;
		}
		public static void TimeWarp_Standard(Bitmap image, Byte factor)
        {
			Point[,] pt = TimeWrap_Mechanism(image.Width, image.Height, factor);
			OffsetFilter_Standard(image, pt);
		}
		public static void TimeWarp_Unsafe(Bitmap image, Byte factor)
		{
			Point[,] pt = TimeWrap_Mechanism(image.Width, image.Height, factor);
			OffsetFilter_Unsafe(image, pt);
		}
		public static void OffsetFilter_Standard(Bitmap image, Point[,] offset)
        {
			Bitmap copy = (Bitmap)image.Clone();

			int xOffset, yOffset;
			for (int y = 0; y < image.Height; ++y)
			{
				for (int x = 0; x < image.Width; ++x)
				{
					xOffset = offset[x, y].X;
					yOffset = offset[x, y].Y;
					if (yOffset >= 0 && yOffset < image.Height && xOffset >= 0 && xOffset < image.Width)
					{
						Color c = copy.GetPixel(xOffset, yOffset);
						image.SetPixel(x, y, Color.FromArgb(c.R, c.G, c.B));
					}
				}
			}
		}
		public static void OffsetFilter_Unsafe(Bitmap image, Point[,] offset)
		{
			Bitmap copy = (Bitmap)image.Clone();

			BitmapData bmData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bmSrc = copy.LockBits(new Rectangle(0, 0, copy.Width, copy.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int scanline = bmData.Stride;

			System.IntPtr Scan0 = bmData.Scan0;
			System.IntPtr SrcScan0 = bmSrc.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;
				byte* pSrc = (byte*)(void*)SrcScan0;

				int nOffset = bmData.Stride - image.Width * 3;
				int nWidth = image.Width;
				int nHeight = image.Height;

				int xOffset, yOffset;

				for (int y = 0; y < nHeight; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						xOffset = offset[x, y].X;
						yOffset = offset[x, y].Y;

						if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
						{
							p[0] = pSrc[(yOffset * scanline) + (xOffset * 3)];
							p[1] = pSrc[(yOffset * scanline) + (xOffset * 3) + 1];
							p[2] = pSrc[(yOffset * scanline) + (xOffset * 3) + 2];
						}

						p += 3;
					}
					p += nOffset;
				}
			}
			image.UnlockBits(bmData);
			copy.UnlockBits(bmSrc);
		}
		public static void Histogram_Cutting(Bitmap image, int threshold, int constant)
        {
			Bitmap copy = (Bitmap)image.Clone();

			int[] rgb_old = new int[3];
			int[] rgb_new = new int[3];
			for (int y = 0; y < image.Height; ++y)
			{
				for (int x = 0; x < image.Width; ++x)
				{	
					Color c = copy.GetPixel(x, y);
					rgb_old[0] = c.R;
					rgb_old[1] = c.G;
					rgb_old[2] = c.B;
					for(int i = 0; i < 3; i++)
                    {
                        if (rgb_old[i] < threshold)
                        {
							rgb_new[i] = 0;
                        }
                        else
                        {
							rgb_new[i] = rgb_old[i] - constant;
                        }
                    }
					image.SetPixel(x, y, Color.FromArgb(rgb_new[0], rgb_new[1], rgb_new[2]));					
				}
			}
		}
		public static void OrderedDithering(Bitmap image)
        {
			Bitmap copy = (Bitmap)image.Clone();
			PopulateOrderDitherMatrix();
			Color?[,] tmpSubPicture = new Color?[3,3];
			for (int y = 0; y < image.Height; y+=3)
			{
				for (int x = 0; x < image.Width; x+=3)
				{
					for(int i = 0; i < 3; i++)
                    {
						for(int j = 0; j<3; j++)
                        {
                            if ((x+j)<image.Width && (y+i)<image.Height)
                            {
								tmpSubPicture[i, j] = copy.GetPixel((x + j), (y + i));
                            }
                            else
                            {
								tmpSubPicture[i, j] = null;
                            }
                        }
                    }
					OrderedDithering_Calculate(ref tmpSubPicture);
					for (int i = 0; i < 3; i++)
					{
						for (int j = 0; j < 3; j++)
						{
							if ((x + j) < image.Width && (y + i) < image.Height)
							{
								image.SetPixel((x + j), (y + i), Color.FromArgb(tmpSubPicture[i,j].Value.R, tmpSubPicture[i, j].Value.G, tmpSubPicture[i, j].Value.B));
							}
						}
					}
				}
			}
		}
		private static void OrderedDithering_Calculate(ref Color?[,] subPicture)
        {
			int[] rgb = new int[3];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
                    if (subPicture[i, j] != null)
                    {
						rgb[0] = ScaleDown(subPicture[i, j].Value.R);
						rgb[1] = ScaleDown(subPicture[i, j].Value.G);
						rgb[2] = ScaleDown(subPicture[i, j].Value.B);
						for(int z = 0; z < 3; z++)
                        {
                            if (OrderDitheringMatrix[i,j] > rgb[z])
                            {
								rgb[z] = 0;
                            }
                        }
						subPicture[i, j] = Color.FromArgb(ScaleUp(rgb[0]), ScaleUp(rgb[1]), ScaleUp(rgb[2]));
					}
				}
			}
		}
		private static void ClosestPaletteColor(Color c, int factor, ref int[] rgb)
        {
			rgb[0] = (factor * c.R / 255) * (255 / factor);
			rgb[1] = (factor * c.G / 255) * (255 / factor);
			rgb[2] = (factor * c.B / 255) * (255 / factor);
		}
		private static void CalculateError(Color c, int[] rgb, ref int[] error)
		{
			error[0] = c.R - rgb[0];
			error[1] = c.R - rgb[1];
			error[2] = c.R - rgb[2];
		}
		public static void BurkesDithering(Bitmap image)
        {
			Color tmpPixel, nextPixel;
			int[] newColor = new int[3];
			int[] error = new int[3];
			int nextX, nextY;
			for (int y = 0; y < image.Height; y++)
			{
				for (int x = 0; x < image.Width; x++)				
				{
					tmpPixel = image.GetPixel(x, y);
					ClosestPaletteColor(tmpPixel,4, ref newColor);
					image.SetPixel(x,y,Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					CalculateError(tmpPixel, newColor, ref error);
					
					nextX = x + 1;
					nextY = y;
					if(nextX < image.Width)
                    {
						nextPixel = image.GetPixel(nextX, nextY);
						newColor[0] = nextPixel.R + (error[0] * 8 / 32);
                        if (newColor[0] > 255)
                        {
							newColor[0] = 255;

						}
						newColor[1] = nextPixel.G + (error[1] * 8 / 32);
						if (newColor[1] > 255)
						{
							newColor[1] = 255;

						}
						newColor[2] = nextPixel.B + (error[2] * 8 / 32);
						if (newColor[2] > 255)
						{
							newColor[2] = 255;

						}
						image.SetPixel(nextX, nextY, Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					}
					nextX++;
					if (nextX < image.Width)
					{
						nextPixel = image.GetPixel(nextX, nextY);
						newColor[0] = nextPixel.R + (error[0] * 4 / 32);
						if (newColor[0] > 255)
						{
							newColor[0] = 255;

						}
						newColor[1] = nextPixel.G + (error[1] * 4 / 32);
						if (newColor[1] > 255)
						{
							newColor[1] = 255;

						}
						newColor[2] = nextPixel.B + (error[2] * 4 / 32);
						if (newColor[2] > 255)
						{
							newColor[2] = 255;

						}
						image.SetPixel(nextX, nextY, Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					}
					nextX = x - 2;
					nextY = y + 1;
					if (nextX > 0 && nextY < image.Height)
					{
						nextPixel = image.GetPixel(nextX, nextY);
						newColor[0] = nextPixel.R + (error[0] * 2 / 32);
						if (newColor[0] > 255)
						{
							newColor[0] = 255;

						}
						newColor[1] = nextPixel.G + (error[1] * 2 / 32);
						if (newColor[1] > 255)
						{
							newColor[1] = 255;

						}
						newColor[2] = nextPixel.B + (error[2] * 2 / 32);
						if (newColor[2] > 255)
						{
							newColor[2] = 255;

						}
						image.SetPixel(nextX, nextY, Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					}
					nextX++;
					if (nextX > 0 && nextY < image.Height)
					{
						nextPixel = image.GetPixel(nextX, nextY);
						newColor[0] = nextPixel.R + (error[0] * 4 / 32);
						if (newColor[0] > 255)
						{
							newColor[0] = 255;

						}
						newColor[1] = nextPixel.G + (error[1] * 4 / 32);
						if (newColor[1] > 255)
						{
							newColor[1] = 255;

						}
						newColor[2] = nextPixel.B + (error[2] * 4 / 32);
						if (newColor[2] > 255)
						{
							newColor[2] = 255;

						}
						image.SetPixel(nextX, nextY, Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					}
					nextX++;
					if (nextY < image.Height)
					{
						nextPixel = image.GetPixel(nextX, nextY);
						newColor[0] = nextPixel.R + (error[0] * 8 / 32);
						if (newColor[0] > 255)
						{
							newColor[0] = 255;

						}
						newColor[1] = nextPixel.G + (error[1] * 8 / 32);
						if (newColor[1] > 255)
						{
							newColor[1] = 255;

						}
						newColor[2] = nextPixel.B + (error[2] * 8 / 32);
						if (newColor[2] > 255)
						{
							newColor[2] = 255;

						}
						image.SetPixel(nextX, nextY, Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					}
					nextX++;
					if (nextX < image.Width && nextY < image.Height)
					{
						nextPixel = image.GetPixel(nextX, nextY);
						newColor[0] = nextPixel.R + (error[0] * 4 / 32);
						if (newColor[0] > 255)
						{
							newColor[0] = 255;

						}
						newColor[1] = nextPixel.G + (error[1] * 4 / 32);
						if (newColor[1] > 255)
						{
							newColor[1] = 255;

						}
						newColor[2] = nextPixel.B + (error[2] * 4 / 32);
						if (newColor[2] > 255)
						{
							newColor[2] = 255;

						}
						image.SetPixel(nextX, nextY, Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					}
					nextX++;
					if (nextX < image.Width && nextY < image.Height)
					{
						nextPixel = image.GetPixel(nextX, nextY);
						newColor[0] = nextPixel.R + (error[0] * 2 / 32);
						if (newColor[0] > 255)
						{
							newColor[0] = 255;

						}
						newColor[1] = nextPixel.G + (error[1] * 2 / 32);
						if (newColor[1] > 255)
						{
							newColor[1] = 255;

						}
						newColor[2] = nextPixel.B + (error[2] * 2 / 32);
						if (newColor[2] > 255)
						{
							newColor[2] = 255;

						}
						image.SetPixel(nextX, nextY, Color.FromArgb(newColor[0], newColor[1], newColor[2]));
					}
				}
			}
		}
		private static void ColorizePixel(int gray, ref int[] rgb, int[,] map_matrix)
        {
			for(int i = 0; i < SimpleColorize_Range.Length; i++)
            {
                if (gray<=SimpleColorize_Range[i])
                {
					for(int j = 0; j < 3; j++)
                    {
						rgb[j] = map_matrix[i, j];
					}					
					break;
                }
            }
        }
		public static void SimpleColorize_Default(Bitmap image)
        {
			SimpleColorize_Populate();
			Bitmap copy = (Bitmap)image.Clone();
			Color tmpPixel;
			int[] rgb = new int[3];
			for (int x = 0; x < image.Width; x++)
			{
				for (int y = 0; y < image.Height; y++)
				{
					tmpPixel = copy.GetPixel(x,y);
					ColorizePixel(tmpPixel.R, ref rgb, SimpleColorize_Matrix_Default);
					image.SetPixel(x,y, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
				}
			}
		}
		public static void SimpleColorize_Custom(Bitmap image)
		{
            if (SimpleColorize_Matrix_Custom != null)
            {
				Bitmap copy = (Bitmap)image.Clone();
				Color tmpPixel;
				int[] rgb = new int[3];
				for (int x = 0; x < image.Width; x++)
				{
					for (int y = 0; y < image.Height; y++)
					{
						tmpPixel = copy.GetPixel(x, y);
						ColorizePixel(tmpPixel.R, ref rgb, SimpleColorize_Matrix_Custom);
						image.SetPixel(x, y, Color.FromArgb(rgb[0], rgb[1], rgb[2]));
					}
				}
			}
		}
		public static void CrossDomainColorize(Bitmap image, double newHue, double? newSaturation)
        {
			Bitmap copy = (Bitmap)image.Clone();
			double newScaledHue = ScaleHue(newHue);
			int quickX, tmpQuickX, tmpR, tmpG, tmpB;
			Color tmpColor;
			for (int x = 0; x < image.Width; x++)
			{
				quickX = x * 3;
                while(quickX > image.Width - 1)
                {
					quickX = quickX - image.Width; 
                }
				for (int y = 0; y < image.Height; y++)
				{

					tmpQuickX = quickX + 2;
					if(tmpQuickX > image.Width - 1)
					{
						tmpQuickX = tmpQuickX - image.Width;
					}
					tmpR = copy.GetPixel(tmpQuickX, y).R;

					tmpQuickX = quickX + 1;
					if (tmpQuickX > image.Width - 1)
					{
						tmpQuickX = tmpQuickX - image.Width;
					}
					tmpG = copy.GetPixel(tmpQuickX, y).G;

					tmpB = copy.GetPixel(quickX, y).B;

					tmpColor = CrossDomainColorize_Calculate(Color.FromArgb(tmpR, tmpG, tmpB), newScaledHue, newSaturation);
					image.SetPixel(x, y, Color.FromArgb(tmpColor.R, tmpColor.G, tmpColor.B));
				}
			}
		}

		public static Color CrossDomainColorize_Calculate(Color color, double newHue, double? newSaturation)
        {
			double tmpHue, tmpSaturation, tmpValue;
			HSV_Model_Pixel.RGB2HSV(color, out tmpHue, out tmpSaturation, out tmpValue);
            if (newSaturation == null)
            {
				newSaturation = tmpSaturation;
            }
			Color newColor = HSV_Model_Pixel.HSV2RGB(newHue, (double)newSaturation, tmpValue);
			return newColor;
        }
		private static double ScaleHue(double oldHue)
        {
			double newHue;
            switch (oldHue)
            {
				case 1:
					newHue = 72;
					break;
				case 2:
					newHue = 144;
					break;
				case 3:
					newHue = 216;
					break;
				case 4:
					newHue = 288;
					break;				
				default:
					newHue = 0;
					break;
			}
			return newHue;
        }
		public static void Flip(Bitmap b, bool bHorz = false, bool bVert = true)
		{
			Point[,] ptFlip = new Point[b.Width, b.Height];

			int nWidth = b.Width;
			int nHeight = b.Height;

			for (int x = 0; x < nWidth; ++x)
				for (int y = 0; y < nHeight; ++y)
				{
					ptFlip[x, y].X = (bHorz) ? nWidth - (x + 1) : x;
					ptFlip[x, y].Y = (bVert) ? nHeight - (y + 1) : y;
				}

			OffsetFilterAbs(b, ptFlip);
		}
		public static void OffsetFilterAbs(Bitmap b, Point[,] offset)
		{
			Bitmap bSrc = (Bitmap)b.Clone();

			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int scanline = bmData.Stride;

			System.IntPtr Scan0 = bmData.Scan0;
			System.IntPtr SrcScan0 = bmSrc.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;
				byte* pSrc = (byte*)(void*)SrcScan0;

				int nOffset = bmData.Stride - b.Width * 3;
				int nWidth = b.Width;
				int nHeight = b.Height;

				int xOffset, yOffset;

				for (int y = 0; y < nHeight; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						xOffset = offset[x, y].X;
						yOffset = offset[x, y].Y;

						if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
						{
							p[0] = pSrc[(yOffset * scanline) + (xOffset * 3)];
							p[1] = pSrc[(yOffset * scanline) + (xOffset * 3) + 1];
							p[2] = pSrc[(yOffset * scanline) + (xOffset * 3) + 2];
						}

						p += 3;
					}
					p += nOffset;
				}
			}

			b.UnlockBits(bmData);
			bSrc.UnlockBits(bmSrc);
		}
		public static void KuwaharaBlur(ref Bitmap image, int Size = 2)
		{
			Bitmap copy = (Bitmap)image.Clone();
			Graphics NewGraphics = Graphics.FromImage(copy);
			NewGraphics.DrawImage(copy, new Rectangle(0, 0, copy.Width, copy.Height), new System.Drawing.Rectangle(0, 0, copy.Width, copy.Height), System.Drawing.GraphicsUnit.Pixel);
			NewGraphics.Dispose();
			Random TempRandom = new Random();
			int[] ApetureMinX = { -(Size / 2), 0, -(Size / 2), 0 };
			int[] ApetureMaxX = { 0, (Size / 2), 0, (Size / 2) };
			int[] ApetureMinY = { -(Size / 2), -(Size / 2), 0, 0 };
			int[] ApetureMaxY = { 0, 0, (Size / 2), (Size / 2) };
			for (int x = 0; x < copy.Width; ++x)
			{
				for (int y = 0; y < copy.Height; ++y)
				{
					int[] RValues = { 0, 0, 0, 0 };
					int[] GValues = { 0, 0, 0, 0 };
					int[] BValues = { 0, 0, 0, 0 };
					int[] NumPixels = { 0, 0, 0, 0 };
					int[] MaxRValue = { 0, 0, 0, 0 };
					int[] MaxGValue = { 0, 0, 0, 0 };
					int[] MaxBValue = { 0, 0, 0, 0 };
					int[] MinRValue = { 255, 255, 255, 255 };
					int[] MinGValue = { 255, 255, 255, 255 };
					int[] MinBValue = { 255, 255, 255, 255 };
					for (int i = 0; i < 4; ++i)
					{
						for (int x2 = ApetureMinX[i]; x2 < ApetureMaxX[i]; ++x2)
						{
							int TempX = x + x2;
							if (TempX >= 0 && TempX < copy.Width)
							{
								for (int y2 = ApetureMinY[i]; y2 < ApetureMaxY[i]; ++y2)
								{
									int TempY = y + y2;
									if (TempY >= 0 && TempY < copy.Height)
									{
										Color TempColor = copy.GetPixel(TempX, TempY);
										RValues[i] += TempColor.R;
										GValues[i] += TempColor.G;
										BValues[i] += TempColor.B;
										if (TempColor.R > MaxRValue[i])
										{
											MaxRValue[i] = TempColor.R;
										}
										else if (TempColor.R < MinRValue[i])
										{
											MinRValue[i] = TempColor.R;
										}

										if (TempColor.G > MaxGValue[i])
										{
											MaxGValue[i] = TempColor.G;
										}
										else if (TempColor.G < MinGValue[i])
										{
											MinGValue[i] = TempColor.G;
										}

										if (TempColor.B > MaxBValue[i])
										{
											MaxBValue[i] = TempColor.B;
										}
										else if (TempColor.B < MinBValue[i])
										{
											MinBValue[i] = TempColor.B;
										}
										++NumPixels[i];
									}
								}
							}
						}
					}
					int j = 0;
					int MinDifference = 10000;
					for (int i = 0; i < 4; ++i)
					{
						int CurrentDifference = (MaxRValue[i] - MinRValue[i]) + (MaxGValue[i] - MinGValue[i]) + (MaxBValue[i] - MinBValue[i]);
						if (CurrentDifference < MinDifference && NumPixels[i] > 0)
						{
							j = i;
							MinDifference = CurrentDifference;
						}
					}

					Color MeanPixel = Color.FromArgb(RValues[j] / NumPixels[j],
						GValues[j] / NumPixels[j],
						BValues[j] / NumPixels[j]);
					image.SetPixel(x, y, MeanPixel);
				}
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ObradaSlika
{
    public partial class Form1 : Form
    {
        private enum Views
        {
            First,
            Second_Channels,
            Second_Grayscale,
            Second_Downsample,
            Histo_XYZ,
            Histo_RGB
        }
        public Bitmap BitmapImage;
        public Bitmap OG_Image;
        public List<Bitmap> Channels;
        public List<Bitmap> Grayscale;
        public Buffer<Bitmap> UndoBuffer;
        public Buffer<Bitmap> RedoBuffer;
        private Views TmpView;
        private double Zoom = 1.0;
        private int BufferSize;
        private int KernelSize;
        private bool UseOriginalImage;
        private bool UseUnsafe;
        private bool FilterChannels;
        private bool SimpleColorize;
        private int Histogram_Threshold;
        private int Histogram_Constant;

        public Form1()
        {
            InitializeComponent();
            this.BitmapImage = new Bitmap(2, 2);
            this.Channels = new List<Bitmap>(3);
            this.Grayscale = new List<Bitmap>(3);
            this.TmpView = Views.First;
            this.UseOriginalImage = true;
            this.UseUnsafe = false;
            this.FilterChannels = false;
            this.SimpleColorize = false;
            this.BufferSize = 1;
            this.KernelSize = 3;
            this.UndoBuffer = new Buffer<Bitmap>(this.BufferSize);
            this.RedoBuffer = new Buffer<Bitmap>(this.BufferSize);
            this.Histogram_Constant = 0;
            this.Histogram_Threshold = 0;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(this.BitmapImage != null)
            {
                if(String.Equals(this.TmpView.ToString(), Views.First.ToString()))
                {
                    Point point = new Point();
                    point.X = this.AutoScrollPosition.X;
                    point.Y = this.AutoScrollPosition.Y + this.menuStrip1.Size.Height;
                    g.DrawImage(this.BitmapImage, new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                }
                else if (String.Equals(this.TmpView.ToString(), Views.Second_Channels.ToString()))
                {
                    Point point = new Point();
                    point.X = this.AutoScrollPosition.X;
                    point.Y = this.AutoScrollPosition.Y + this.menuStrip1.Size.Height;

                    g.DrawImage(this.BitmapImage, new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;

                    g.DrawImage(this.Channels[0], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X = this.AutoScrollPosition.X;
                    point.Y += Convert.ToInt32(this.BitmapImage.Height * Zoom) + 2; 

                    g.DrawImage(this.Channels[1], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;

                    g.DrawImage(this.Channels[2], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                }
                else if (String.Equals(this.TmpView.ToString(), Views.Second_Downsample.ToString()))
                {
                    Point point = new Point();
                    point.X = this.AutoScrollPosition.X;
                    point.Y = this.AutoScrollPosition.Y + this.menuStrip1.Size.Height;

                    g.DrawImage(this.BitmapImage, new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;

                    g.DrawImage(this.Channels[0], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X = this.AutoScrollPosition.X;
                    point.Y += Convert.ToInt32(this.BitmapImage.Height * Zoom) + 2;

                    g.DrawImage(this.Channels[1], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;

                    g.DrawImage(this.Channels[2], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                }
                else if (String.Equals(this.TmpView.ToString(), Views.Second_Grayscale.ToString()))
                {
                    Point point = new Point();
                    point.X = this.AutoScrollPosition.X;
                    point.Y = this.AutoScrollPosition.Y + this.menuStrip1.Size.Height;

                    g.DrawImage(this.BitmapImage, new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;

                    g.DrawImage(this.Grayscale[0], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X = this.AutoScrollPosition.X;
                    point.Y += Convert.ToInt32(this.BitmapImage.Height * Zoom) + 2;

                    g.DrawImage(this.Grayscale[1], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                    point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;

                    g.DrawImage(this.Grayscale[2], new Rectangle(point.X, point.Y, (int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom)));
                }
                else
                {
                    Point point = new Point();
                    point.X = this.AutoScrollPosition.X;
                    point.Y = this.AutoScrollPosition.Y + this.menuStrip1.Size.Height;
                    int height = (int)(this.BitmapImage.Height * Zoom);
                    int width = (int)(this.BitmapImage.Width * Zoom);

                    g.DrawImage(this.BitmapImage, new Rectangle(point.X, point.Y, width, height));
                    point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;
                    if (width > 400)
                    {
                        width = 400;
                    }
                    if (height > 200)
                    {
                        height = 200;
                    }
                    if (String.Equals(this.TmpView.ToString(), Views.Histo_XYZ.ToString()))
                    {
                        //this.Draw_Histogram_XYZ(this.Channels[0], 'X', this.X_channel_histogram, point.X, point.Y, width, height);
                        this.Draw_Histogram_XYZ(this.BitmapImage, 'X', this.X_channel_histogram, point.X, point.Y, width, height);                        
                        point.X = this.AutoScrollPosition.X;
                        point.Y += Convert.ToInt32(this.BitmapImage.Height * Zoom) + 2;

                        //this.Draw_Histogram_XYZ(this.Channels[1], 'Y', this.Y_channel_histogram, point.X, point.Y, width, height);
                        this.Draw_Histogram_XYZ(this.BitmapImage, 'Y', this.Y_channel_histogram, point.X, point.Y, width, height);                        
                        point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;

                        //this.Draw_Histogram_XYZ(this.Channels[2], 'Z', this.Z_channel_histogram, point.X, point.Y, width, height);
                        this.Draw_Histogram_XYZ(this.BitmapImage, 'Z', this.Z_channel_histogram, point.X, point.Y, width, height);
                    }
                    else
                    {
                        List<Chart> charts = new List<Chart>();
                        charts.Add(this.X_channel_histogram);
                        charts.Add(this.Y_channel_histogram);
                        charts.Add(this.Z_channel_histogram);

                        this.Create_Histograms_RGB(this.BitmapImage, charts, width, height);

                        charts[0].Location = new Point(point.X, point.Y);
                        point.X = this.AutoScrollPosition.X;
                        point.Y += Convert.ToInt32(this.BitmapImage.Height * Zoom) + 2;
                        charts[1].Location = new Point(point.X, point.Y);
                        point.X += Convert.ToInt32(this.BitmapImage.Width * Zoom) + 2;
                        charts[2].Location = new Point(point.X, point.Y);

                        foreach(Chart c in charts)
                        {
                            this.Controls.Add(c);
                        }
                    }                    
                }
            }
        }
        private void CustomComponentGenerator()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.X_channel_histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Y_channel_histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Z_channel_histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.X_channel_histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y_channel_histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Z_channel_histogram)).BeginInit();
            //
            //
            //
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.X_channel_histogram.ChartAreas.Add(chartArea1);
            //this.X_channel_histogram.Location = new System.Drawing.Point(104, 93);
            this.X_channel_histogram.Name = "X_channel_histogram";
            //this.X_channel_histogram.Size = new System.Drawing.Size(300, 300);
            this.X_channel_histogram.TabIndex = 0;
            this.X_channel_histogram.Text = "X_channel_histogram";
            this.X_channel_histogram.Titles.Add("X channel");
            this.X_channel_histogram.ChartAreas[0].AxisX.Minimum = 0;
            this.X_channel_histogram.ChartAreas[0].AxisX.Maximum = 255;
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea2";
            this.Y_channel_histogram.ChartAreas.Add(chartArea2);
            //this.Y_channel_histogram.Location = new System.Drawing.Point(104, 93);
            this.Y_channel_histogram.Name = "Y_channel_histogram";
            //this.Y_channel_histogram.Size = new System.Drawing.Size(300, 300);
            this.Y_channel_histogram.TabIndex = 0;
            this.Y_channel_histogram.Text = "Y_channel_histogram";
            this.Y_channel_histogram.Titles.Add("Y channel");
            this.Y_channel_histogram.ChartAreas[0].AxisX.Minimum = 0;
            this.Y_channel_histogram.ChartAreas[0].AxisX.Maximum = 255;
            // 
            // chart3
            // 
            chartArea1.Name = "ChartArea3";
            this.Z_channel_histogram.ChartAreas.Add(chartArea3);
            //this.Z_channel_histogram.Location = new System.Drawing.Point(104, 93);
            this.Z_channel_histogram.Name = "Z_channel_histogram";
            //this.Z_channel_histogram.Size = new System.Drawing.Size(300, 300);
            this.Z_channel_histogram.TabIndex = 0;
            this.Z_channel_histogram.Text = "Z_channel_histogram";
            this.Z_channel_histogram.Titles.Add("Z channel");
            this.Z_channel_histogram.ChartAreas[0].AxisX.Minimum = 0;
            this.Z_channel_histogram.ChartAreas[0].AxisX.Maximum = 255;
        }
        private void UpdateBuffer(int size)
        {
            this.UndoBuffer.Size = size;
            this.RedoBuffer.Size = size;
        }
        private void Open_Settings(object sender, EventArgs e)
        {
            SettingsDialog settings = new SettingsDialog(this.BufferSize, this.KernelSize, this.UseUnsafe, !this.UseOriginalImage, this.FilterChannels, this.SimpleColorize);
            if(DialogResult.OK == settings.ShowDialog())
            {
                this.KernelSize = settings.Kernel_Size;
                this.BufferSize = settings.Buffer_Size;
                this.UpdateBuffer(this.BufferSize);
                this.UseUnsafe = settings.UnsafeMode;
                this.UseOriginalImage = !settings.NewImage;
                this.FilterChannels = settings.FilterChannels;
                this.SimpleColorize = settings.SimpleColorize;
            }
        }

        #region File

        
        private void FileLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|Custom files (*.cust)|*.cust|All valid files|*.bmp/*.jpg/*.gif/*.png/*.cust";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                string extension = Path.GetExtension(openFileDialog.FileName).ToLower();
                if (String.Equals(extension, ".cust"))
                {
                    CustomImageFormat custom = new CustomImageFormat(System.IO.File.ReadAllBytes(openFileDialog.FileName));
                    this.BitmapImage = (Bitmap)custom.Image.Clone();
                }
                else
                {
                    this.BitmapImage = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
                }                
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size((int)(this.BitmapImage.Width * Zoom), (int)(this.BitmapImage.Height * Zoom));
                this.OG_Image = (Bitmap)this.BitmapImage.Clone();
                this.Invalidate();
            }
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            Bitmap bitmapToSave = (Bitmap)this.BitmapImage.Clone();
            if (String.Equals(this.TmpView.ToString(), Views.Second_Downsample.ToString()))
            {
                SelectChannel_Dialog dlg = new SelectChannel_Dialog();
                if(DialogResult.OK == dlg.ShowDialog())
                {
                    bitmapToSave = (Bitmap)this.Channels[dlg.ChannelIndex].Clone();
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|Custom files (*.cust)|*.cust|All valid files (*.bmp/*.jpg/*.cust)|*.bmp/*.jpg/*.cust";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                if (String.Equals(extension, ".cust"))
                {
                    HuffmanCoding_Dialog huff = new HuffmanCoding_Dialog();
                    if (DialogResult.OK == huff.ShowDialog())
                    {
                        CustomImageFormat custom = new CustomImageFormat(bitmapToSave, huff.Coding);
                        System.IO.File.WriteAllBytes(saveFileDialog.FileName, custom.Data);
                    }                        
                }
                else
                {
                    bitmapToSave.Save(saveFileDialog.FileName);
                }
            }
        }
        private void ExitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Views
        private void View_1_Click(object sender, EventArgs e)
        {
            if (!String.Equals(this.TmpView.ToString(), Views.First.ToString()))
            {
                if(String.Equals(this.TmpView.ToString(), Views.Histo_XYZ.ToString())|| String.Equals(this.TmpView.ToString(), Views.Histo_RGB.ToString()))
                {
                    this.Remove_Histograms();
                }
                this.TmpView = Views.First;
                this.UpdateFormTitle(this.TmpView);
                this.Invalidate();
            }            
        }

        private void View_2_Channels_Click(object sender, EventArgs e)
        {
            if (!String.Equals(this.TmpView.ToString(), Views.Second_Channels.ToString()))
            {
                if (String.Equals(this.TmpView.ToString(), Views.Histo_XYZ.ToString()) || String.Equals(this.TmpView.ToString(), Views.Histo_RGB.ToString()))
                {
                    this.Remove_Histograms();
                }
                this.TmpView = Views.Second_Channels;
                this.UpdateFormTitle(this.TmpView);
                this.SeparateChannels();
                this.Invalidate();
            }
        }
        private void View_2_Grayscale_Click(object sender, EventArgs e)
        {
            if (!String.Equals(this.TmpView.ToString(), Views.Second_Grayscale.ToString()))
            {
                if (String.Equals(this.TmpView.ToString(), Views.Histo_XYZ.ToString()) || String.Equals(this.TmpView.ToString(), Views.Histo_RGB.ToString()))
                {
                    this.Remove_Histograms();
                }
                this.TmpView = Views.Second_Grayscale;
                this.UpdateFormTitle(this.TmpView);
                this.GenerateGrayscale();
                this.Invalidate();
            }
        }
        private void View_2_Histo_XYZ_Click(object sender, EventArgs e)
        {
            if (!String.Equals(this.TmpView.ToString(), Views.Histo_XYZ.ToString()))
            {
                this.TmpView = Views.Histo_XYZ;
                this.UpdateFormTitle(this.TmpView);
                this.SeparateChannels();
                this.Invalidate();
            }
        }
        private void View_2_Histo_RGB_Click(object sender, EventArgs e)
        {
            if (!String.Equals(this.TmpView.ToString(), Views.Histo_RGB.ToString()))
            {
                this.TmpView = Views.Histo_RGB;
                this.UpdateFormTitle(this.TmpView);
                this.SeparateChannels();
                this.Invalidate();
            }
        }
        private void View_2_Downsample_Click(object sender, EventArgs e)
        {
            if (!String.Equals(this.TmpView.ToString(), Views.Second_Downsample.ToString()))
            {
                if (String.Equals(this.TmpView.ToString(), Views.Histo_XYZ.ToString()) || String.Equals(this.TmpView.ToString(), Views.Histo_RGB.ToString()))
                {
                    this.Remove_Histograms();
                }
                this.TmpView = Views.Second_Downsample;
                this.UpdateFormTitle(this.TmpView);
                this.SeparateChannels();
                this.Invalidate();
            }
        }
        private void Create_Histograms_RGB(Bitmap image, List<Chart> charts, int width, int height)
        {
            foreach(Chart c in charts)
            {
                c.Series.Clear();
                c.Size = new Size(width, height);
                c.ChartAreas[0].AxisX.Minimum = 0;
                c.ChartAreas[0].AxisX.Maximum = 255;
            }
            charts[0].Titles[0].Text = "R";
            charts[1].Titles[0].Text = "G";
            charts[2].Titles[0].Text = "B";
            Series seriesR = new Series();
            Series seriesG = new Series();
            Series seriesB = new Series();
            DataPoint p;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);
                    //zbog ovog if-a se ne prikazuju vrednosti 0 na histogramu, jer remeti y-osu prilikom koriscenja filtera za odsecanje histograma (posto onda ima najvise pixela sa vrednoscu 0 da se ostale vrednosti jedva vide)
                    if (c.R > 0)
                    {
                        if ((p = seriesR.Points.SingleOrDefault(p => p.XValue == c.R)) != null)
                        {
                            p.YValues[0]++;
                        }
                        else
                        {
                            seriesR.Points.Add(new DataPoint(c.R, 1));
                        }
                    }
                    if (c.G > 0)
                    {
                        if ((p = seriesG.Points.SingleOrDefault(p => p.XValue == c.G)) != null)
                        {
                            p.YValues[0]++;
                        }
                        else
                        {
                            seriesG.Points.Add(new DataPoint(c.G, 1));
                        }
                    }
                    if (c.B > 0)
                    {
                        if ((p = seriesB.Points.SingleOrDefault(p => p.XValue == c.B)) != null)
                        {
                            p.YValues[0]++;
                        }
                        else
                        {
                            seriesB.Points.Add(new DataPoint(c.B, 1));
                        }
                    }
                }
            }
            charts[0].Series.Add(seriesR);
            charts[1].Series.Add(seriesG);
            charts[2].Series.Add(seriesB);
            foreach (Chart c in charts)
            {
                foreach (Series s in c.Series)
                {
                    foreach (DataPoint point in s.Points)
                    {
                        point.LabelBackColor = Color.Black;
                    }
                }
            }
        }
        
        private void Draw_Histogram_RGB(Bitmap image, char channel, Chart chart, int x, int y, int width, int height)
        {
            chart.Series.Clear();
            chart.Location = new Point(x, y);
            chart.Size = new Size(width, height);
            chart.Titles[0].Text = channel.ToString();
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 255;
            Series series = new Series();
            DataPoint p;
            int tmpPixelValue;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);
                    switch (channel)
                    {
                        case 'R':
                            tmpPixelValue = c.R;
                            break;
                        case 'G':
                            tmpPixelValue = c.G;
                            break;
                        case 'B':
                            tmpPixelValue = c.B;
                            break;
                        default:
                            tmpPixelValue = 0;
                            break;
                    }
                    if (tmpPixelValue > 0)
                    {
                        if ((p = series.Points.SingleOrDefault(p => p.XValue == tmpPixelValue)) != null)
                        {
                            p.YValues[0]++;
                        }
                        else
                        {
                            series.Points.Add(new DataPoint(tmpPixelValue, 1));
                        }
                    }                    
                }
            }
            chart.Series.Add(series);
            foreach (Series s in chart.Series)
            {
                foreach (DataPoint point in s.Points)
                {
                    point.LabelBackColor = Color.Black;
                }
            }
            this.Controls.Add(chart);
        }
        private void Draw_Histogram_XYZ(Bitmap image, char channel,Chart chart, int x, int y, int width, int height)
        {
            chart.Series.Clear();
            chart.Location = new Point(x, y);
            chart.Size = new Size(width, height);
            chart.Titles[0].Text = channel.ToString()+" channel";
            chart.ChartAreas[0].AxisX.Minimum = 0;
            switch (channel)
            {
                case 'X':
                    chart.ChartAreas[0].AxisX.Maximum = 0.9505;
                    break;
                case 'Y':
                    chart.ChartAreas[0].AxisX.Maximum = 1.0;
                    break;
                case 'Z':
                    chart.ChartAreas[0].AxisX.Maximum = 0.8252;
                    break;
                default:                    
                    break;
            }
            Series series = new Series();
            DataPoint p;
            double tmpPixelValue;
            CIE_Model_Pixel cie = new CIE_Model_Pixel(); 
            for(int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i,j);
                    cie.R = c.R;
                    cie.G = c.G;
                    cie.B = c.B;
                    cie.RgbToXyz();
                    switch (channel)
                    {
                        case 'X':
                            tmpPixelValue = Math.Round(cie.X, 2);
                            break;
                        case 'Y':
                            tmpPixelValue = Math.Round(cie.Y, 2);
                            break;
                        case 'Z':
                            tmpPixelValue = Math.Round(cie.Z, 2);
                            break;
                        default:
                            tmpPixelValue = 0;
                            break;
                    }
                    if (tmpPixelValue>0)
                    {
                        if ((p = series.Points.SingleOrDefault(p => p.XValue == tmpPixelValue)) != null)
                        {
                            p.YValues[0]++;
                        }
                        else
                        {
                            series.Points.Add(new DataPoint(tmpPixelValue, 1));
                        }
                    }                    
                }
            }
            chart.Series.Add(series);
            this.Controls.Add(chart);
        }
        private void Remove_Histograms()
        {
            this.Controls.Remove(this.X_channel_histogram);
            this.Controls.Remove(this.Y_channel_histogram);
            this.Controls.Remove(this.Z_channel_histogram);
        }
        private void UpdateFormTitle(Views v)
        {
            String title = "Obrada slika";
            String type = "";
            switch (v)
            {
                case Views.First:
                    type += " - View 1";
                    break;
                case Views.Second_Channels:
                    type += " - View 2 (Channels)";
                    break;
                case Views.Second_Grayscale:
                    type += " - View 2 (Grayscale)";
                    break;
                case Views.Second_Downsample:
                    type += " - View 2 (Downsampled Channels)";
                    break;
                case Views.Histo_XYZ:
                    type += " - View 2 (Histogram)";
                    break;
                case Views.Histo_RGB:
                    type += " - View 2 (Histogram)";
                    break;
                default:
                    break;
            }
            this.Text = title + type;
        }
        private void SeparateChannels()
        {
            if(this.Channels.Count > 0)
            {
                this.Channels.Clear();
            }
            Bitmap tmp;
            for (int i = 0; i < 3; i++)
            {
                tmp = (Bitmap)this.BitmapImage.Clone();
                this.Channels.Add(tmp);
            }
            if(String.Equals(this.TmpView.ToString(), Views.Second_Channels.ToString()))
            {
                Filters.SeparateChannels(ref this.Channels);
            }
            else if (String.Equals(this.TmpView.ToString(), Views.Second_Downsample.ToString()))
            {
                Filters.DownsampleChannels(ref this.Channels);
            }
        }
        
        private void GenerateGrayscale()
        {
            if (this.Grayscale.Count > 0)
            {
                this.Grayscale.Clear();
            }
            Bitmap tmp;
            for (int i = 0; i < 3; i++)
            {
                tmp = (Bitmap)this.BitmapImage.Clone();
                this.Grayscale.Add(tmp);
            }
            Filters.SeparateGrayscale(ref this.Grayscale, 11);
        }
        #endregion

        #region Edit

        public void Undo(object sender, EventArgs e)
        {
            Command cmd = new UndoCommand(this);
            cmd.Execute();
            this.Invalidate();
        }
        public void Redo(object sender, EventArgs e)
        {
            Command cmd = new RedoCommand(this);
            cmd.Execute();
            this.Invalidate();
        }
        private void Buffer(Bitmap image)
        {
            this.UndoBuffer.Push(image);
            this.RedoBuffer.Clear();
        }

        #endregion

        #region Filters
        private void Filter_Color(object sender, EventArgs e)
        {
            CIE_Model_Pixel cie = new CIE_Model_Pixel();
            ColorInputDialog ColorInput = new ColorInputDialog(cie);

            if (DialogResult.OK == ColorInput.ShowDialog())
            {
                this.Buffer(this.BitmapImage);
                if (this.UseOriginalImage)
                {
                    this.BitmapImage = (Bitmap)this.OG_Image.Clone();
                }
                if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
                {
                    if (this.UseUnsafe)
                    {
                        Filters.Color_Unsafe(this.BitmapImage, cie.R, cie.G, cie.B);
                    }
                    else
                    {
                        Filters.Color_Standard(this.BitmapImage, cie.R, cie.G, cie.B);
                    }
                }
                else if(!this.FilterChannels)
                {
                    if (this.UseUnsafe)
                    {
                        Filters.Color_Unsafe(this.BitmapImage, cie.R, cie.G, cie.B);
                    }
                    else
                    {
                        Filters.Color_Standard(this.BitmapImage, cie.R, cie.G, cie.B);
                    }
                    this.SeparateChannels();
                }
                else
                {
                    this.SeparateChannels();
                    if (this.UseUnsafe)
                    {
                        Filters.Color_Unsafe(this.BitmapImage, cie.R, cie.G, cie.B);
                    }
                    else
                    {
                        Filters.Color_Standard(this.BitmapImage, cie.R, cie.G, cie.B);
                    }
                    foreach (Bitmap img in this.Channels)
                    {
                        if (this.UseUnsafe)
                        {
                            Filters.Color_Unsafe(img, cie.R, cie.G, cie.B);
                        }
                        else
                        {
                            Filters.Color_Standard(img, cie.R, cie.G, cie.B);
                        }
                    }
                }
                this.Invalidate();
            }
        }
        private void Filter_MeanRemoval(object sender, EventArgs e)
        {
            MeanRemovalDialog mean_removal_dialog = new MeanRemovalDialog(this.KernelSize);
            if (DialogResult.OK == mean_removal_dialog.ShowDialog())
            {
                this.Buffer(this.BitmapImage);
                if (this.UseOriginalImage)
                {
                    this.BitmapImage = (Bitmap)this.OG_Image.Clone();
                }
                if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
                {
                    if (this.UseUnsafe)
                    {
                        Filters.MeanRemoval_Unsafe(this.BitmapImage, mean_removal_dialog.N, this.KernelSize);
                    }
                    else
                    {
                        Filters.MeanRemoval_Standard(this.BitmapImage, mean_removal_dialog.N, this.KernelSize);
                    }
                }
                else if (!this.FilterChannels)
                {
                    if (this.UseUnsafe)
                    {
                        Filters.MeanRemoval_Unsafe(this.BitmapImage, mean_removal_dialog.N, this.KernelSize);
                    }
                    else
                    {
                        Filters.MeanRemoval_Standard(this.BitmapImage, mean_removal_dialog.N, this.KernelSize);
                    }
                    this.SeparateChannels();
                }
                else
                {
                    this.SeparateChannels();
                    if (this.UseUnsafe)
                    {
                        Filters.MeanRemoval_Unsafe(this.BitmapImage, mean_removal_dialog.N, this.KernelSize);
                    }
                    else
                    {
                        Filters.MeanRemoval_Standard(this.BitmapImage, mean_removal_dialog.N, this.KernelSize);
                    }
                    foreach (Bitmap img in this.Channels)
                    {
                        if (this.UseUnsafe)
                        {
                            Filters.MeanRemoval_Unsafe(img, mean_removal_dialog.N, this.KernelSize);
                        }
                        else
                        {
                            Filters.MeanRemoval_Standard(img, mean_removal_dialog.N, this.KernelSize);
                        }
                    }
                }
                this.Invalidate();
            }
        }
        private void Filter_Invert(object sender, EventArgs e)
        {
            this.Buffer(this.BitmapImage);
            if (this.UseOriginalImage)
            {
                this.BitmapImage = (Bitmap)this.OG_Image.Clone();
            }
            if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
            {
                if (this.UseUnsafe)
                {
                    Filters.Invert_Unsafe(this.BitmapImage);
                }
                else
                {
                    Filters.Invert_Standard(this.BitmapImage);
                }
            }
            else if (!this.FilterChannels)
            {
                if (this.UseUnsafe)
                {
                    Filters.Invert_Unsafe(this.BitmapImage);
                }
                else
                {
                    Filters.Invert_Standard(this.BitmapImage);
                }
                this.SeparateChannels();
            }
            else
            {
                this.SeparateChannels();
                if (this.UseUnsafe)
                {
                    Filters.Invert_Unsafe(this.BitmapImage);
                }
                else
                {
                    Filters.Invert_Standard(this.BitmapImage);
                }
                foreach (Bitmap img in this.Channels)
                {
                    if (this.UseUnsafe)
                    {
                        Filters.Invert_Unsafe(img);
                    }
                    else
                    {
                        Filters.Invert_Standard(img);
                    }
                }
            }
            this.Invalidate();
        }
        private void Filter_EdgeDetectHomogenity(object sender, EventArgs e)
        {
            EdgeDetectHomogenityDialog dialog = new EdgeDetectHomogenityDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                this.Buffer(this.BitmapImage);
                if (this.UseOriginalImage)
                {
                    this.BitmapImage = (Bitmap)this.OG_Image.Clone();
                }
                if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
                {
                    if (this.UseUnsafe)
                    {
                        Filters.EdgeDetectHomogenity_Unsafe(this.BitmapImage, (byte)dialog.Threshold);
                    }
                    else
                    {
                        Filters.EdgeDetectHomogenity_Standard(this.BitmapImage, dialog.Threshold);
                    }
                }
                else if (!this.FilterChannels)
                {
                    if (this.UseUnsafe)
                    {
                        Filters.EdgeDetectHomogenity_Unsafe(this.BitmapImage, (byte)dialog.Threshold);
                    }
                    else
                    {
                        Filters.EdgeDetectHomogenity_Standard(this.BitmapImage, dialog.Threshold);
                    }
                    this.SeparateChannels();
                }
                else
                {
                    this.SeparateChannels();
                    if (this.UseUnsafe)
                    {
                        Filters.EdgeDetectHomogenity_Unsafe(this.BitmapImage, (byte)dialog.Threshold);
                    }
                    else
                    {
                        Filters.EdgeDetectHomogenity_Standard(this.BitmapImage, dialog.Threshold);
                    }
                    foreach (Bitmap img in this.Channels)
                    {
                        if (this.UseUnsafe)
                        {
                            Filters.EdgeDetectHomogenity_Unsafe(img, (byte)dialog.Threshold);
                        }
                        else
                        {
                            Filters.EdgeDetectHomogenity_Standard(img, dialog.Threshold);
                        }
                    }
                }
                this.Invalidate();
            }
        }
        private void Filter_TimeWrap(object sender, EventArgs e)
        {
            this.Buffer(this.BitmapImage);
            if (this.UseOriginalImage)
            {
                this.BitmapImage = (Bitmap)this.OG_Image.Clone();
            }
            if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
            {
                if (this.UseUnsafe)
                {
                    Filters.TimeWarp_Unsafe(this.BitmapImage, 15);
                }
                else
                {
                    Filters.TimeWarp_Standard(this.BitmapImage, 15);
                }
            }
            else if (!this.FilterChannels)
            {
                if (this.UseUnsafe)
                {
                    Filters.TimeWarp_Unsafe(this.BitmapImage, 15);
                }
                else
                {
                    Filters.TimeWarp_Standard(this.BitmapImage, 15);
                }
                this.SeparateChannels();
            }
            else
            {
                this.SeparateChannels();
                if (this.UseUnsafe)
                {
                    Filters.TimeWarp_Unsafe(this.BitmapImage, 15);
                }
                else
                {
                    Filters.TimeWarp_Standard(this.BitmapImage, 15);
                }
                foreach (Bitmap img in this.Channels)
                {
                    if (this.UseUnsafe)
                    {
                        Filters.TimeWarp_Unsafe(this.BitmapImage, 15);
                    }
                    else
                    {
                        Filters.TimeWarp_Standard(this.BitmapImage, 15);
                    }
                }
            }
            this.Invalidate();            
        }
        private void Filter_HistogramCutting(object sender, EventArgs e)
        {
            HistogramCutting_Dialog dialog = new HistogramCutting_Dialog(this.Histogram_Constant, this.TmpView.ToString());
            if (DialogResult.OK == dialog.ShowDialog())
            {
                double threshold = dialog.T;
                if (String.Equals(this.TmpView.ToString(), Views.Histo_XYZ.ToString()))
                {
                    CIE_Model_Pixel cie = new CIE_Model_Pixel();
                    cie.X = threshold;
                    cie.Y = threshold;
                    cie.Z = threshold;
                    cie.XyzToRgb();
                    threshold = cie.AverageRGB(); 
                }
                this.Histogram_Threshold = Convert.ToInt32(threshold);
                this.Buffer(this.BitmapImage);
                if (this.UseOriginalImage)
                {
                    this.BitmapImage = (Bitmap)this.OG_Image.Clone();
                }
                if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
                {
                    Filters.Histogram_Cutting(this.BitmapImage, this.Histogram_Threshold, this.Histogram_Constant);
                }
                else if (!this.FilterChannels)
                {
                    Filters.Histogram_Cutting(this.BitmapImage, this.Histogram_Threshold, this.Histogram_Constant);
                    this.SeparateChannels();
                }
                else
                {
                    this.SeparateChannels();
                    Filters.Histogram_Cutting(this.BitmapImage, this.Histogram_Threshold, this.Histogram_Constant);
                    foreach (Bitmap img in this.Channels)
                    {
                        Filters.Histogram_Cutting(img, this.Histogram_Threshold, this.Histogram_Constant);
                    }
                }
                this.Invalidate();
            }            
        }
        private void Filter_OrderedDithering_Click(object sender, EventArgs e)
        {
            this.Buffer(this.BitmapImage);
            if (this.UseOriginalImage)
            {
                this.BitmapImage = (Bitmap)this.OG_Image.Clone();
            }
            if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
            {
                Filters.OrderedDithering(this.BitmapImage);
            }
            else if (!this.FilterChannels)
            {
                Filters.OrderedDithering(this.BitmapImage);
                this.SeparateChannels();
            }
            else
            {
                this.SeparateChannels();
                Filters.OrderedDithering(this.BitmapImage);
                foreach (Bitmap img in this.Channels)
                {
                    Filters.OrderedDithering(img);
                }
            }
            this.Invalidate();
        }
        private void Filter_BurkesDithering_Click(object sender, EventArgs e)
        {
            this.Buffer(this.BitmapImage);
            if (this.UseOriginalImage)
            {
                this.BitmapImage = (Bitmap)this.OG_Image.Clone();
            }
            if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
            {
                Filters.BurkesDithering(this.BitmapImage);
            }
            else if (!this.FilterChannels)
            {
                Filters.BurkesDithering(this.BitmapImage);
                this.SeparateChannels();
            }
            else
            {
                this.SeparateChannels();
                Filters.BurkesDithering(this.BitmapImage);
                foreach (Bitmap img in this.Channels)
                {
                    Filters.BurkesDithering(img);
                }
            }
            this.Invalidate();
        }
        private void Filter_SimpleColorize_Click(object sender, EventArgs e)
        {
            this.Buffer(this.BitmapImage);
            if (this.UseOriginalImage)
            {
                this.BitmapImage = (Bitmap)this.OG_Image.Clone();
            }
            if (!this.SimpleColorize)
            {
                Filters.SimpleColorize_Default(this.BitmapImage);
            }
            else
            {
                Filters.SimpleColorize_Custom(this.BitmapImage);
            }            
            this.Invalidate();
        }
        private void Filter_Colorize_GenerateMapping_Click(object sender, EventArgs e)
        {
            Filters.GenerateMapping(this.BitmapImage);
        }

        private void Filter_Colorize_CrossDomainColorize_Click(object sender, EventArgs e)
        {
            CrossDomainColorize_Dialog dialog = new CrossDomainColorize_Dialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                this.Buffer(this.BitmapImage);
                if (this.UseOriginalImage)
                {
                    this.BitmapImage = (Bitmap)this.OG_Image.Clone();
                }
                if (String.Equals(this.TmpView.ToString(), Views.First.ToString()))
                {

                    Filters.CrossDomainColorize(this.BitmapImage, dialog.Hue, dialog.Saturation);
                }
                else if (!this.FilterChannels)
                {
                    Filters.CrossDomainColorize(this.BitmapImage, dialog.Hue, dialog.Saturation);
                    this.SeparateChannels();
                }
                else
                {
                    this.SeparateChannels();
                    Filters.CrossDomainColorize(this.BitmapImage, dialog.Hue, dialog.Saturation);
                    foreach (Bitmap img in this.Channels)
                    {
                        Filters.CrossDomainColorize(img, dialog.Hue, dialog.Saturation);
                    }
                }
                this.Invalidate();
            }
        }
        private void Filter_KuwaharaBlur_Click(object sender, EventArgs e)
        {
            this.Buffer(this.BitmapImage);
            if (this.UseOriginalImage)
            {
                this.BitmapImage = (Bitmap)this.OG_Image.Clone();
            }
            Filters.KuwaharaBlur(ref this.BitmapImage);
            this.Invalidate();
        }

        #endregion


    }
}

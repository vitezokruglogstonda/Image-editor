
using System.Windows.Forms.DataVisualization.Charting;

namespace ObradaSlika
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.FileLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterColor = new System.Windows.Forms.ToolStripMenuItem();
            this.convolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanRemovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectHomogenityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuttingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ditheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderedDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burkesDitheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorizeGrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleColorizeDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossDomainColorizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.View_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.View_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramCIEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downsampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kuwaharaBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomComponentGenerator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.editToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileLoad,
            this.FileSave,
            this.ExitApp});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // FileLoad
            // 
            this.FileLoad.Name = "FileLoad";
            this.FileLoad.Size = new System.Drawing.Size(100, 22);
            this.FileLoad.Text = "Load";
            this.FileLoad.Click += new System.EventHandler(this.FileLoad_Click);
            // 
            // FileSave
            // 
            this.FileSave.Name = "FileSave";
            this.FileSave.Size = new System.Drawing.Size(100, 22);
            this.FileSave.Text = "Save";
            this.FileSave.Click += new System.EventHandler(this.FileSave_Click);
            // 
            // ExitApp
            // 
            this.ExitApp.Name = "ExitApp";
            this.ExitApp.Size = new System.Drawing.Size(100, 22);
            this.ExitApp.Text = "Exit";
            this.ExitApp.Click += new System.EventHandler(this.ExitApp_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.Undo);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.Redo);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterColor,
            this.convolutionToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.edgeDetectHomogenityToolStripMenuItem,
            this.displacementToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.ditheringToolStripMenuItem,
            this.colorizeGrayscaleToolStripMenuItem,
            this.kuwaharaBlurToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // FilterColor
            // 
            this.FilterColor.Name = "FilterColor";
            this.FilterColor.Size = new System.Drawing.Size(201, 22);
            this.FilterColor.Text = "Color";
            this.FilterColor.Click += new System.EventHandler(this.Filter_Color);
            // 
            // convolutionToolStripMenuItem
            // 
            this.convolutionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanRemovalToolStripMenuItem});
            this.convolutionToolStripMenuItem.Name = "convolutionToolStripMenuItem";
            this.convolutionToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.convolutionToolStripMenuItem.Text = "Convolution";
            // 
            // meanRemovalToolStripMenuItem
            // 
            this.meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            this.meanRemovalToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.meanRemovalToolStripMenuItem.Text = "Mean Removal";
            this.meanRemovalToolStripMenuItem.Click += new System.EventHandler(this.Filter_MeanRemoval);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.Filter_Invert);
            // 
            // edgeDetectHomogenityToolStripMenuItem
            // 
            this.edgeDetectHomogenityToolStripMenuItem.Name = "edgeDetectHomogenityToolStripMenuItem";
            this.edgeDetectHomogenityToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.edgeDetectHomogenityToolStripMenuItem.Text = "EdgeDetectHomogenity";
            this.edgeDetectHomogenityToolStripMenuItem.Click += new System.EventHandler(this.Filter_EdgeDetectHomogenity);
            // 
            // displacementToolStripMenuItem
            // 
            this.displacementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeWrapToolStripMenuItem});
            this.displacementToolStripMenuItem.Name = "displacementToolStripMenuItem";
            this.displacementToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.displacementToolStripMenuItem.Text = "Displacement";
            // 
            // timeWrapToolStripMenuItem
            // 
            this.timeWrapToolStripMenuItem.Name = "timeWrapToolStripMenuItem";
            this.timeWrapToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.timeWrapToolStripMenuItem.Text = "TimeWrap";
            this.timeWrapToolStripMenuItem.Click += new System.EventHandler(this.Filter_TimeWrap);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuttingToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // cuttingToolStripMenuItem
            // 
            this.cuttingToolStripMenuItem.Name = "cuttingToolStripMenuItem";
            this.cuttingToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.cuttingToolStripMenuItem.Text = "Cutting";
            this.cuttingToolStripMenuItem.Click += new System.EventHandler(this.Filter_HistogramCutting);
            // 
            // ditheringToolStripMenuItem
            // 
            this.ditheringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderedDitheringToolStripMenuItem,
            this.burkesDitheringToolStripMenuItem});
            this.ditheringToolStripMenuItem.Name = "ditheringToolStripMenuItem";
            this.ditheringToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.ditheringToolStripMenuItem.Text = "Dithering";
            // 
            // orderedDitheringToolStripMenuItem
            // 
            this.orderedDitheringToolStripMenuItem.Name = "orderedDitheringToolStripMenuItem";
            this.orderedDitheringToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.orderedDitheringToolStripMenuItem.Text = "Ordered dithering";
            this.orderedDitheringToolStripMenuItem.Click += new System.EventHandler(this.Filter_OrderedDithering_Click);
            // 
            // burkesDitheringToolStripMenuItem
            // 
            this.burkesDitheringToolStripMenuItem.Name = "burkesDitheringToolStripMenuItem";
            this.burkesDitheringToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.burkesDitheringToolStripMenuItem.Text = "Burkes Dithering";
            this.burkesDitheringToolStripMenuItem.Click += new System.EventHandler(this.Filter_BurkesDithering_Click);
            // 
            // colorizeGrayscaleToolStripMenuItem
            // 
            this.colorizeGrayscaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleColorizeDefaultToolStripMenuItem,
            this.generateMappingToolStripMenuItem,
            this.crossDomainColorizeToolStripMenuItem});
            this.colorizeGrayscaleToolStripMenuItem.Name = "colorizeGrayscaleToolStripMenuItem";
            this.colorizeGrayscaleToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.colorizeGrayscaleToolStripMenuItem.Text = "Colorize ";
            // 
            // simpleColorizeDefaultToolStripMenuItem
            // 
            this.simpleColorizeDefaultToolStripMenuItem.Name = "simpleColorizeDefaultToolStripMenuItem";
            this.simpleColorizeDefaultToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.simpleColorizeDefaultToolStripMenuItem.Text = "Simple Colorize (grayscale)";
            this.simpleColorizeDefaultToolStripMenuItem.Click += new System.EventHandler(this.Filter_SimpleColorize_Click);
            // 
            // generateMappingToolStripMenuItem
            // 
            this.generateMappingToolStripMenuItem.Name = "generateMappingToolStripMenuItem";
            this.generateMappingToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.generateMappingToolStripMenuItem.Text = "Generate Mapping";
            this.generateMappingToolStripMenuItem.Click += new System.EventHandler(this.Filter_Colorize_GenerateMapping_Click);
            // 
            // crossDomainColorizeToolStripMenuItem
            // 
            this.crossDomainColorizeToolStripMenuItem.Name = "crossDomainColorizeToolStripMenuItem";
            this.crossDomainColorizeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.crossDomainColorizeToolStripMenuItem.Text = "Cross-Domain Colorize";
            this.crossDomainColorizeToolStripMenuItem.Click += new System.EventHandler(this.Filter_Colorize_CrossDomainColorize_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.View_1,
            this.View_2});
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.viewsToolStripMenuItem.Text = "Views";
            // 
            // View_1
            // 
            this.View_1.Name = "View_1";
            this.View_1.Size = new System.Drawing.Size(108, 22);
            this.View_1.Text = "View 1";
            this.View_1.Click += new System.EventHandler(this.View_1_Click);
            // 
            // View_2
            // 
            this.View_2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelsToolStripMenuItem,
            this.histogramsToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.downsampleToolStripMenuItem});
            this.View_2.Name = "View_2";
            this.View_2.Size = new System.Drawing.Size(108, 22);
            this.View_2.Text = "View 2";
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.channelsToolStripMenuItem.Text = "Channels";
            this.channelsToolStripMenuItem.Click += new System.EventHandler(this.View_2_Channels_Click);
            // 
            // histogramsToolStripMenuItem
            // 
            this.histogramsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramRGBToolStripMenuItem,
            this.histogramCIEToolStripMenuItem});
            this.histogramsToolStripMenuItem.Name = "histogramsToolStripMenuItem";
            this.histogramsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.histogramsToolStripMenuItem.Text = "Histograms";
            // 
            // histogramRGBToolStripMenuItem
            // 
            this.histogramRGBToolStripMenuItem.Name = "histogramRGBToolStripMenuItem";
            this.histogramRGBToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.histogramRGBToolStripMenuItem.Text = "Histogram (RGB)";
            this.histogramRGBToolStripMenuItem.Click += new System.EventHandler(this.View_2_Histo_RGB_Click);
            // 
            // histogramCIEToolStripMenuItem
            // 
            this.histogramCIEToolStripMenuItem.Name = "histogramCIEToolStripMenuItem";
            this.histogramCIEToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.histogramCIEToolStripMenuItem.Text = "Histogram (CIE)";
            this.histogramCIEToolStripMenuItem.Click += new System.EventHandler(this.View_2_Histo_XYZ_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.View_2_Grayscale_Click);
            // 
            // downsampleToolStripMenuItem
            // 
            this.downsampleToolStripMenuItem.Name = "downsampleToolStripMenuItem";
            this.downsampleToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.downsampleToolStripMenuItem.Text = "Downsample";
            this.downsampleToolStripMenuItem.Click += new System.EventHandler(this.View_2_Downsample_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Options";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.Open_Settings);
            // 
            // kuwaharaBlurToolStripMenuItem
            // 
            this.kuwaharaBlurToolStripMenuItem.Name = "kuwaharaBlurToolStripMenuItem";
            this.kuwaharaBlurToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.kuwaharaBlurToolStripMenuItem.Text = "KuwaharaBlur";
            this.kuwaharaBlurToolStripMenuItem.Click += new System.EventHandler(this.Filter_KuwaharaBlur_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Obrada slika";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem FileLoad;
        private System.Windows.Forms.ToolStripMenuItem FileSave;
        private System.Windows.Forms.ToolStripMenuItem ExitApp;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FilterColor;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem View_1;
        private System.Windows.Forms.ToolStripMenuItem View_2;
        private System.Windows.Forms.ToolStripMenuItem convolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanRemovalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectHomogenityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displacementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramsToolStripMenuItem;
        //chart
        private System.Windows.Forms.DataVisualization.Charting.Chart X_channel_histogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart Y_channel_histogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart Z_channel_histogram;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuttingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramCIEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ditheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderedDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burkesDitheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorizeGrayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleColorizeDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossDomainColorizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downsampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kuwaharaBlurToolStripMenuItem;
    }
}


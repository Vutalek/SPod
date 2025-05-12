namespace SPod
{
    partial class SPod
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            Choosing = new OpenFileDialog();
            fileButton = new Button();
            fileName = new TextBox();
            playButton = new Button();
            stopButton = new Button();
            restartButton = new Button();
            volume = new TrackBar();
            volumeLevel = new Label();
            IIR = new RadioButton();
            FIR = new RadioButton();
            gain1 = new TrackBar();
            gain2 = new TrackBar();
            gain3 = new TrackBar();
            gain4 = new TrackBar();
            gain5 = new TrackBar();
            gain6 = new TrackBar();
            band1 = new Label();
            band2 = new Label();
            band3 = new Label();
            band4 = new Label();
            band5 = new Label();
            band6 = new Label();
            InputViz = new System.Windows.Forms.DataVisualization.Charting.Chart();
            OutputViz = new System.Windows.Forms.DataVisualization.Charting.Chart();
            mainBox = new GroupBox();
            equalizerBox = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            delayBox = new GroupBox();
            delayLevelLabel = new Label();
            delayDepthLabel = new Label();
            delayLevel = new TrackBar();
            delayDepth = new TrackBar();
            delayCheck = new CheckBox();
            envelopBox = new GroupBox();
            envelopRectLabel = new Label();
            envelopSinusLabel = new Label();
            envelopTriangleLabel = new Label();
            envelopSizeLabel = new Label();
            envelopRect = new TrackBar();
            envelopSinus = new TrackBar();
            envelopSize = new TrackBar();
            envelopCheck = new CheckBox();
            envelopTriangle = new TrackBar();
            spectrumBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InputViz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OutputViz).BeginInit();
            mainBox.SuspendLayout();
            equalizerBox.SuspendLayout();
            delayBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)delayLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)delayDepth).BeginInit();
            envelopBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)envelopRect).BeginInit();
            ((System.ComponentModel.ISupportInitialize)envelopSinus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)envelopSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)envelopTriangle).BeginInit();
            spectrumBox.SuspendLayout();
            SuspendLayout();
            // 
            // Choosing
            // 
            Choosing.FileName = "Choosing";
            Choosing.Filter = "Wav files (*.wav)|*.wav";
            // 
            // fileButton
            // 
            fileButton.Location = new Point(6, 13);
            fileButton.Name = "fileButton";
            fileButton.Size = new Size(66, 29);
            fileButton.TabIndex = 0;
            fileButton.Text = "File";
            fileButton.UseVisualStyleBackColor = true;
            fileButton.Click += ChooseFile;
            // 
            // fileName
            // 
            fileName.Location = new Point(78, 13);
            fileName.Name = "fileName";
            fileName.ReadOnly = true;
            fileName.Size = new Size(246, 27);
            fileName.TabIndex = 1;
            // 
            // playButton
            // 
            playButton.Location = new Point(6, 48);
            playButton.Name = "playButton";
            playButton.Size = new Size(104, 57);
            playButton.TabIndex = 2;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += PlayButton;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(116, 48);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(101, 57);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton;
            // 
            // restartButton
            // 
            restartButton.Location = new Point(223, 48);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(101, 57);
            restartButton.TabIndex = 4;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += RestartButton;
            // 
            // volume
            // 
            volume.Location = new Point(6, 111);
            volume.Maximum = 100;
            volume.Name = "volume";
            volume.Size = new Size(211, 56);
            volume.TabIndex = 5;
            volume.Tag = "";
            volume.TickStyle = TickStyle.Both;
            volume.Value = 100;
            volume.ValueChanged += VolumeChanged;
            // 
            // volumeLevel
            // 
            volumeLevel.AutoSize = true;
            volumeLevel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            volumeLevel.Location = new Point(223, 108);
            volumeLevel.Name = "volumeLevel";
            volumeLevel.Size = new Size(91, 41);
            volumeLevel.TabIndex = 6;
            volumeLevel.Text = "100%";
            // 
            // IIR
            // 
            IIR.AutoSize = true;
            IIR.Location = new Point(6, 63);
            IIR.Name = "IIR";
            IIR.Size = new Size(47, 24);
            IIR.TabIndex = 8;
            IIR.TabStop = true;
            IIR.Text = "IIR";
            IIR.UseVisualStyleBackColor = true;
            IIR.CheckedChanged += FilterChanged;
            // 
            // FIR
            // 
            FIR.AutoSize = true;
            FIR.Checked = true;
            FIR.Location = new Point(6, 33);
            FIR.Name = "FIR";
            FIR.Size = new Size(50, 24);
            FIR.TabIndex = 9;
            FIR.TabStop = true;
            FIR.Text = "FIR";
            FIR.UseVisualStyleBackColor = true;
            FIR.CheckedChanged += FilterChanged;
            // 
            // gain1
            // 
            gain1.Location = new Point(62, 33);
            gain1.Maximum = 0;
            gain1.Minimum = -60;
            gain1.Name = "gain1";
            gain1.Orientation = Orientation.Vertical;
            gain1.RightToLeft = RightToLeft.No;
            gain1.Size = new Size(56, 189);
            gain1.TabIndex = 10;
            gain1.TickStyle = TickStyle.Both;
            gain1.ValueChanged += gainChanged;
            // 
            // gain2
            // 
            gain2.Location = new Point(198, 33);
            gain2.Maximum = 0;
            gain2.Minimum = -60;
            gain2.Name = "gain2";
            gain2.Orientation = Orientation.Vertical;
            gain2.RightToLeft = RightToLeft.No;
            gain2.Size = new Size(56, 189);
            gain2.TabIndex = 14;
            gain2.TickStyle = TickStyle.Both;
            gain2.ValueChanged += gainChanged;
            // 
            // gain3
            // 
            gain3.Location = new Point(334, 33);
            gain3.Maximum = 0;
            gain3.Minimum = -60;
            gain3.Name = "gain3";
            gain3.Orientation = Orientation.Vertical;
            gain3.RightToLeft = RightToLeft.No;
            gain3.Size = new Size(56, 189);
            gain3.TabIndex = 17;
            gain3.TickStyle = TickStyle.Both;
            gain3.ValueChanged += gainChanged;
            // 
            // gain4
            // 
            gain4.Location = new Point(470, 33);
            gain4.Maximum = 0;
            gain4.Minimum = -60;
            gain4.Name = "gain4";
            gain4.Orientation = Orientation.Vertical;
            gain4.RightToLeft = RightToLeft.No;
            gain4.Size = new Size(56, 189);
            gain4.TabIndex = 20;
            gain4.TickStyle = TickStyle.Both;
            gain4.ValueChanged += gainChanged;
            // 
            // gain5
            // 
            gain5.Location = new Point(606, 33);
            gain5.Maximum = 0;
            gain5.Minimum = -60;
            gain5.Name = "gain5";
            gain5.Orientation = Orientation.Vertical;
            gain5.RightToLeft = RightToLeft.No;
            gain5.Size = new Size(56, 189);
            gain5.TabIndex = 23;
            gain5.TickStyle = TickStyle.Both;
            gain5.ValueChanged += gainChanged;
            // 
            // gain6
            // 
            gain6.Location = new Point(742, 33);
            gain6.Maximum = 0;
            gain6.Minimum = -60;
            gain6.Name = "gain6";
            gain6.Orientation = Orientation.Vertical;
            gain6.RightToLeft = RightToLeft.No;
            gain6.Size = new Size(56, 189);
            gain6.TabIndex = 26;
            gain6.TickStyle = TickStyle.Both;
            gain6.ValueChanged += gainChanged;
            // 
            // band1
            // 
            band1.AutoSize = true;
            band1.Location = new Point(62, 229);
            band1.Name = "band1";
            band1.Size = new Size(47, 20);
            band1.TabIndex = 29;
            band1.Text = "0-100";
            // 
            // band2
            // 
            band2.AutoSize = true;
            band2.Location = new Point(191, 229);
            band2.Name = "band2";
            band2.Size = new Size(63, 20);
            band2.TabIndex = 30;
            band2.Text = "100-954";
            // 
            // band3
            // 
            band3.AutoSize = true;
            band3.Location = new Point(334, 229);
            band3.Name = "band3";
            band3.Size = new Size(71, 20);
            band3.TabIndex = 31;
            band3.Text = "954-2226";
            // 
            // band4
            // 
            band4.AutoSize = true;
            band4.Location = new Point(456, 229);
            band4.Name = "band4";
            band4.Size = new Size(79, 20);
            band4.TabIndex = 32;
            band4.Text = "2226-4770";
            // 
            // band5
            // 
            band5.AutoSize = true;
            band5.Location = new Point(593, 229);
            band5.Name = "band5";
            band5.Size = new Size(79, 20);
            band5.TabIndex = 33;
            band5.Text = "4770-9858";
            // 
            // band6
            // 
            band6.AutoSize = true;
            band6.Location = new Point(727, 229);
            band6.Name = "band6";
            band6.Size = new Size(87, 20);
            band6.TabIndex = 34;
            band6.Text = "9858-22000";
            // 
            // InputViz
            // 
            InputViz.BackColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            InputViz.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            InputViz.Legends.Add(legend1);
            InputViz.Location = new Point(15, 26);
            InputViz.Name = "InputViz";
            InputViz.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            InputViz.Series.Add(series1);
            InputViz.Size = new Size(412, 502);
            InputViz.TabIndex = 35;
            InputViz.Text = "Input";
            title1.Name = "Title1";
            title1.Text = "Input";
            InputViz.Titles.Add(title1);
            // 
            // OutputViz
            // 
            OutputViz.BackColor = Color.Transparent;
            chartArea2.Name = "ChartArea1";
            OutputViz.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            OutputViz.Legends.Add(legend2);
            OutputViz.Location = new Point(416, 26);
            OutputViz.Name = "OutputViz";
            OutputViz.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            OutputViz.Series.Add(series2);
            OutputViz.Size = new Size(412, 502);
            OutputViz.TabIndex = 36;
            OutputViz.Text = "Output";
            title2.Name = "Title1";
            title2.Text = "Output";
            OutputViz.Titles.Add(title2);
            // 
            // mainBox
            // 
            mainBox.Controls.Add(fileButton);
            mainBox.Controls.Add(fileName);
            mainBox.Controls.Add(playButton);
            mainBox.Controls.Add(stopButton);
            mainBox.Controls.Add(restartButton);
            mainBox.Controls.Add(volume);
            mainBox.Controls.Add(volumeLevel);
            mainBox.Location = new Point(4, -1);
            mainBox.Name = "mainBox";
            mainBox.Size = new Size(338, 179);
            mainBox.TabIndex = 37;
            mainBox.TabStop = false;
            // 
            // equalizerBox
            // 
            equalizerBox.Controls.Add(label2);
            equalizerBox.Controls.Add(FIR);
            equalizerBox.Controls.Add(label1);
            equalizerBox.Controls.Add(IIR);
            equalizerBox.Controls.Add(band6);
            equalizerBox.Controls.Add(gain6);
            equalizerBox.Controls.Add(band5);
            equalizerBox.Controls.Add(gain5);
            equalizerBox.Controls.Add(band4);
            equalizerBox.Controls.Add(gain4);
            equalizerBox.Controls.Add(band3);
            equalizerBox.Controls.Add(gain3);
            equalizerBox.Controls.Add(band2);
            equalizerBox.Controls.Add(gain2);
            equalizerBox.Controls.Add(band1);
            equalizerBox.Controls.Add(gain1);
            equalizerBox.Location = new Point(362, -1);
            equalizerBox.Name = "equalizerBox";
            equalizerBox.Size = new Size(834, 265);
            equalizerBox.TabIndex = 38;
            equalizerBox.TabStop = false;
            equalizerBox.Text = "Equalizer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(797, 37);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 40;
            label2.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(797, 202);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 39;
            label1.Text = "-60";
            // 
            // delayBox
            // 
            delayBox.Controls.Add(delayLevelLabel);
            delayBox.Controls.Add(delayDepthLabel);
            delayBox.Controls.Add(delayLevel);
            delayBox.Controls.Add(delayDepth);
            delayBox.Controls.Add(delayCheck);
            delayBox.Location = new Point(4, 184);
            delayBox.Name = "delayBox";
            delayBox.Size = new Size(338, 233);
            delayBox.TabIndex = 39;
            delayBox.TabStop = false;
            delayBox.Text = "Delay";
            // 
            // delayLevelLabel
            // 
            delayLevelLabel.AutoSize = true;
            delayLevelLabel.Location = new Point(12, 142);
            delayLevelLabel.Name = "delayLevelLabel";
            delayLevelLabel.Size = new Size(43, 20);
            delayLevelLabel.TabIndex = 42;
            delayLevelLabel.Text = "Level";
            // 
            // delayDepthLabel
            // 
            delayDepthLabel.AutoSize = true;
            delayDepthLabel.Location = new Point(12, 60);
            delayDepthLabel.Name = "delayDepthLabel";
            delayDepthLabel.Size = new Size(50, 20);
            delayDepthLabel.TabIndex = 41;
            delayDepthLabel.Text = "Depth";
            // 
            // delayLevel
            // 
            delayLevel.Location = new Point(12, 165);
            delayLevel.Maximum = 100;
            delayLevel.Name = "delayLevel";
            delayLevel.Size = new Size(312, 56);
            delayLevel.TabIndex = 40;
            delayLevel.Tag = "";
            delayLevel.TickStyle = TickStyle.Both;
            delayLevel.Value = 80;
            delayLevel.ValueChanged += DelayLevelChanged;
            // 
            // delayDepth
            // 
            delayDepth.Location = new Point(12, 83);
            delayDepth.Maximum = 8192;
            delayDepth.Minimum = 10;
            delayDepth.Name = "delayDepth";
            delayDepth.Size = new Size(312, 56);
            delayDepth.TabIndex = 40;
            delayDepth.Tag = "";
            delayDepth.TickStyle = TickStyle.Both;
            delayDepth.Value = 1024;
            delayDepth.ValueChanged += DelayDepthChanged;
            // 
            // delayCheck
            // 
            delayCheck.AutoSize = true;
            delayCheck.Location = new Point(12, 31);
            delayCheck.Name = "delayCheck";
            delayCheck.Size = new Size(85, 24);
            delayCheck.TabIndex = 0;
            delayCheck.Text = "Enabled";
            delayCheck.UseVisualStyleBackColor = true;
            delayCheck.CheckedChanged += DelayChecked;
            // 
            // envelopBox
            // 
            envelopBox.Controls.Add(envelopRectLabel);
            envelopBox.Controls.Add(envelopSinusLabel);
            envelopBox.Controls.Add(envelopTriangleLabel);
            envelopBox.Controls.Add(envelopSizeLabel);
            envelopBox.Controls.Add(envelopRect);
            envelopBox.Controls.Add(envelopSinus);
            envelopBox.Controls.Add(envelopSize);
            envelopBox.Controls.Add(envelopCheck);
            envelopBox.Controls.Add(envelopTriangle);
            envelopBox.Location = new Point(4, 423);
            envelopBox.Name = "envelopBox";
            envelopBox.Size = new Size(338, 399);
            envelopBox.TabIndex = 40;
            envelopBox.TabStop = false;
            envelopBox.Text = "Envelop";
            // 
            // envelopRectLabel
            // 
            envelopRectLabel.AutoSize = true;
            envelopRectLabel.Location = new Point(12, 306);
            envelopRectLabel.Name = "envelopRectLabel";
            envelopRectLabel.Size = new Size(75, 20);
            envelopRectLabel.TabIndex = 46;
            envelopRectLabel.Text = "Rectangle";
            // 
            // envelopSinusLabel
            // 
            envelopSinusLabel.AutoSize = true;
            envelopSinusLabel.Location = new Point(12, 142);
            envelopSinusLabel.Name = "envelopSinusLabel";
            envelopSinusLabel.Size = new Size(43, 20);
            envelopSinusLabel.TabIndex = 42;
            envelopSinusLabel.Text = "Sinus";
            // 
            // envelopTriangleLabel
            // 
            envelopTriangleLabel.AutoSize = true;
            envelopTriangleLabel.Location = new Point(12, 224);
            envelopTriangleLabel.Name = "envelopTriangleLabel";
            envelopTriangleLabel.Size = new Size(62, 20);
            envelopTriangleLabel.TabIndex = 45;
            envelopTriangleLabel.Text = "Trinagle";
            // 
            // envelopSizeLabel
            // 
            envelopSizeLabel.AutoSize = true;
            envelopSizeLabel.Location = new Point(12, 60);
            envelopSizeLabel.Name = "envelopSizeLabel";
            envelopSizeLabel.Size = new Size(36, 20);
            envelopSizeLabel.TabIndex = 41;
            envelopSizeLabel.Text = "Size";
            // 
            // envelopRect
            // 
            envelopRect.Location = new Point(12, 329);
            envelopRect.Maximum = 100;
            envelopRect.Name = "envelopRect";
            envelopRect.Size = new Size(312, 56);
            envelopRect.TabIndex = 43;
            envelopRect.Tag = "";
            envelopRect.TickStyle = TickStyle.Both;
            envelopRect.ValueChanged += EnvelopRectDepthChanged;
            // 
            // envelopSinus
            // 
            envelopSinus.Location = new Point(12, 165);
            envelopSinus.Maximum = 100;
            envelopSinus.Name = "envelopSinus";
            envelopSinus.Size = new Size(312, 56);
            envelopSinus.TabIndex = 40;
            envelopSinus.Tag = "";
            envelopSinus.TickStyle = TickStyle.Both;
            envelopSinus.Value = 100;
            envelopSinus.ValueChanged += EnvelopSinDepthChanged;
            // 
            // envelopSize
            // 
            envelopSize.Location = new Point(12, 83);
            envelopSize.Maximum = 41000;
            envelopSize.Minimum = 10;
            envelopSize.Name = "envelopSize";
            envelopSize.Size = new Size(312, 56);
            envelopSize.TabIndex = 40;
            envelopSize.Tag = "";
            envelopSize.TickStyle = TickStyle.Both;
            envelopSize.Value = 4096;
            envelopSize.ValueChanged += EnvelopSizeChanged;
            // 
            // envelopCheck
            // 
            envelopCheck.AutoSize = true;
            envelopCheck.Location = new Point(12, 31);
            envelopCheck.Name = "envelopCheck";
            envelopCheck.Size = new Size(85, 24);
            envelopCheck.TabIndex = 0;
            envelopCheck.Text = "Enabled";
            envelopCheck.UseVisualStyleBackColor = true;
            envelopCheck.CheckedChanged += EnvelopChecked;
            // 
            // envelopTriangle
            // 
            envelopTriangle.Location = new Point(12, 247);
            envelopTriangle.Maximum = 100;
            envelopTriangle.Name = "envelopTriangle";
            envelopTriangle.Size = new Size(312, 56);
            envelopTriangle.TabIndex = 44;
            envelopTriangle.Tag = "";
            envelopTriangle.TickStyle = TickStyle.Both;
            envelopTriangle.ValueChanged += EnvelopTriagDepthChanged;
            // 
            // spectrumBox
            // 
            spectrumBox.Controls.Add(InputViz);
            spectrumBox.Controls.Add(OutputViz);
            spectrumBox.Location = new Point(362, 280);
            spectrumBox.Name = "spectrumBox";
            spectrumBox.Size = new Size(834, 542);
            spectrumBox.TabIndex = 41;
            spectrumBox.TabStop = false;
            spectrumBox.Text = "Spectrum";
            // 
            // SPod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 840);
            Controls.Add(envelopBox);
            Controls.Add(delayBox);
            Controls.Add(mainBox);
            Controls.Add(equalizerBox);
            Controls.Add(spectrumBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "SPod";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SPod";
            FormClosing += SaveSettings;
            ((System.ComponentModel.ISupportInitialize)volume).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain3).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain4).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain5).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain6).EndInit();
            ((System.ComponentModel.ISupportInitialize)InputViz).EndInit();
            ((System.ComponentModel.ISupportInitialize)OutputViz).EndInit();
            mainBox.ResumeLayout(false);
            mainBox.PerformLayout();
            equalizerBox.ResumeLayout(false);
            equalizerBox.PerformLayout();
            delayBox.ResumeLayout(false);
            delayBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)delayLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)delayDepth).EndInit();
            envelopBox.ResumeLayout(false);
            envelopBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)envelopRect).EndInit();
            ((System.ComponentModel.ISupportInitialize)envelopSinus).EndInit();
            ((System.ComponentModel.ISupportInitialize)envelopSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)envelopTriangle).EndInit();
            spectrumBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog Choosing;
        private Button fileButton;
        private TextBox fileName;
        private Button playButton;
        private Button stopButton;
        private Button restartButton;
        private TrackBar volume;
        private Label volumeLevel;
        private RadioButton IIR;
        private RadioButton FIR;
        private TrackBar gain1;
        private TrackBar gain2;
        private TrackBar gain3;
        private TrackBar gain4;
        private TrackBar gain5;
        private TrackBar gain6;
        private Label band1;
        private Label band2;
        private Label band3;
        private Label band4;
        private Label band5;
        private Label band6;
        private System.Windows.Forms.DataVisualization.Charting.Chart InputViz;
        private System.Windows.Forms.DataVisualization.Charting.Chart OutputViz;
        private GroupBox mainBox;
        private GroupBox equalizerBox;
        private Label label2;
        private Label label1;
        private GroupBox delayBox;
        private Label delayLevelLabel;
        private Label delayDepthLabel;
        private TrackBar delayLevel;
        private TrackBar delayDepth;
        private CheckBox delayCheck;
        private GroupBox envelopBox;
        private Label envelopSinusLabel;
        private Label envelopSizeLabel;
        private TrackBar envelopSinus;
        private TrackBar envelopSize;
        private CheckBox envelopCheck;
        private Label envelopRectLabel;
        private Label envelopTriangleLabel;
        private TrackBar envelopRect;
        private TrackBar envelopTriangle;
        private GroupBox spectrumBox;
    }
}

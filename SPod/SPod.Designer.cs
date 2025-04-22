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
            Choosing = new OpenFileDialog();
            fileButton = new Button();
            fileName = new TextBox();
            playButton = new Button();
            stopButton = new Button();
            restartButton = new Button();
            volume = new TrackBar();
            volumeLevel = new Label();
            Filter = new CheckBox();
            IIR = new RadioButton();
            FIR = new RadioButton();
            gain1 = new TrackBar();
            gain1_60 = new Label();
            gain1_0 = new Label();
            ((System.ComponentModel.ISupportInitialize)volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain1).BeginInit();
            SuspendLayout();
            // 
            // Choosing
            // 
            Choosing.FileName = "Choosing";
            Choosing.Filter = "Wav files (*.wav)|*.wav";
            // 
            // fileButton
            // 
            fileButton.Location = new Point(12, 12);
            fileButton.Name = "fileButton";
            fileButton.Size = new Size(66, 29);
            fileButton.TabIndex = 0;
            fileButton.Text = "File";
            fileButton.UseVisualStyleBackColor = true;
            fileButton.Click += ChooseFile;
            // 
            // fileName
            // 
            fileName.Location = new Point(84, 12);
            fileName.Name = "fileName";
            fileName.ReadOnly = true;
            fileName.Size = new Size(246, 27);
            fileName.TabIndex = 1;
            // 
            // playButton
            // 
            playButton.Location = new Point(12, 47);
            playButton.Name = "playButton";
            playButton.Size = new Size(104, 57);
            playButton.TabIndex = 2;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += PlayButton;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(122, 47);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(101, 57);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += StopButton;
            // 
            // restartButton
            // 
            restartButton.Location = new Point(229, 47);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(101, 57);
            restartButton.TabIndex = 4;
            restartButton.Text = "Restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Click += RestartButton;
            // 
            // volume
            // 
            volume.Location = new Point(12, 110);
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
            volumeLevel.Location = new Point(239, 110);
            volumeLevel.Name = "volumeLevel";
            volumeLevel.Size = new Size(91, 41);
            volumeLevel.TabIndex = 6;
            volumeLevel.Text = "100%";
            // 
            // Filter
            // 
            Filter.AutoSize = true;
            Filter.CausesValidation = false;
            Filter.Location = new Point(336, 47);
            Filter.Name = "Filter";
            Filter.Size = new Size(64, 24);
            Filter.TabIndex = 7;
            Filter.Text = "Filter";
            Filter.UseVisualStyleBackColor = true;
            Filter.CheckedChanged += FilterChanged;
            // 
            // IIR
            // 
            IIR.AutoSize = true;
            IIR.Location = new Point(336, 107);
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
            FIR.Location = new Point(336, 77);
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
            gain1.Location = new Point(395, 21);
            gain1.Maximum = 0;
            gain1.Minimum = -60;
            gain1.Name = "gain1";
            gain1.Orientation = Orientation.Vertical;
            gain1.RightToLeft = RightToLeft.No;
            gain1.Size = new Size(56, 130);
            gain1.TabIndex = 10;
            gain1.TickStyle = TickStyle.Both;
            gain1.ValueChanged += gain1Changed;
            // 
            // gain1_60
            // 
            gain1_60.AutoSize = true;
            gain1_60.Location = new Point(440, 127);
            gain1_60.Name = "gain1_60";
            gain1_60.Size = new Size(31, 20);
            gain1_60.TabIndex = 11;
            gain1_60.Text = "-60";
            // 
            // gain1_0
            // 
            gain1_0.AutoSize = true;
            gain1_0.Location = new Point(440, 21);
            gain1_0.Name = "gain1_0";
            gain1_0.Size = new Size(17, 20);
            gain1_0.TabIndex = 12;
            gain1_0.Text = "0";
            // 
            // PassBand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 179);
            Controls.Add(gain1_0);
            Controls.Add(gain1_60);
            Controls.Add(gain1);
            Controls.Add(FIR);
            Controls.Add(IIR);
            Controls.Add(Filter);
            Controls.Add(volumeLevel);
            Controls.Add(volume);
            Controls.Add(restartButton);
            Controls.Add(stopButton);
            Controls.Add(playButton);
            Controls.Add(fileName);
            Controls.Add(fileButton);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "SPod";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SPod";
            ((System.ComponentModel.ISupportInitialize)volume).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private CheckBox Filter;
        private RadioButton IIR;
        private RadioButton FIR;
        private TrackBar gain1;
        private Label gain1_60;
        private Label gain1_0;
    }
}

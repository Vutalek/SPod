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
            IIR = new RadioButton();
            FIR = new RadioButton();
            gain1 = new TrackBar();
            gain1_60 = new Label();
            gain1_0 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            gain2 = new TrackBar();
            label4 = new Label();
            label5 = new Label();
            gain3 = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            gain4 = new TrackBar();
            label8 = new Label();
            label9 = new Label();
            gain5 = new TrackBar();
            label10 = new Label();
            label11 = new Label();
            gain6 = new TrackBar();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            ((System.ComponentModel.ISupportInitialize)volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gain6).BeginInit();
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
            gain1.Location = new Point(391, 32);
            gain1.Maximum = 0;
            gain1.Minimum = -60;
            gain1.Name = "gain1";
            gain1.Orientation = Orientation.Vertical;
            gain1.RightToLeft = RightToLeft.No;
            gain1.Size = new Size(56, 130);
            gain1.TabIndex = 10;
            gain1.TickStyle = TickStyle.Both;
            gain1.ValueChanged += gainChanged;
            // 
            // gain1_60
            // 
            gain1_60.AutoSize = true;
            gain1_60.Location = new Point(436, 138);
            gain1_60.Name = "gain1_60";
            gain1_60.Size = new Size(31, 20);
            gain1_60.TabIndex = 11;
            gain1_60.Text = "-60";
            // 
            // gain1_0
            // 
            gain1_0.AutoSize = true;
            gain1_0.Location = new Point(436, 32);
            gain1_0.Name = "gain1_0";
            gain1_0.Size = new Size(17, 20);
            gain1_0.TabIndex = 12;
            gain1_0.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(391, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 13;
            label1.Text = "Эквалайзер";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(518, 32);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 16;
            label2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 138);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 15;
            label3.Text = "-60";
            // 
            // gain2
            // 
            gain2.Location = new Point(473, 32);
            gain2.Maximum = 0;
            gain2.Minimum = -60;
            gain2.Name = "gain2";
            gain2.Orientation = Orientation.Vertical;
            gain2.RightToLeft = RightToLeft.No;
            gain2.Size = new Size(56, 130);
            gain2.TabIndex = 14;
            gain2.TickStyle = TickStyle.Both;
            gain2.ValueChanged += gainChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 32);
            label4.Name = "label4";
            label4.Size = new Size(17, 20);
            label4.TabIndex = 19;
            label4.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(600, 138);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 18;
            label5.Text = "-60";
            // 
            // gain3
            // 
            gain3.Location = new Point(555, 32);
            gain3.Maximum = 0;
            gain3.Minimum = -60;
            gain3.Name = "gain3";
            gain3.Orientation = Orientation.Vertical;
            gain3.RightToLeft = RightToLeft.No;
            gain3.Size = new Size(56, 130);
            gain3.TabIndex = 17;
            gain3.TickStyle = TickStyle.Both;
            gain3.ValueChanged += gainChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(682, 32);
            label6.Name = "label6";
            label6.Size = new Size(17, 20);
            label6.TabIndex = 22;
            label6.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(682, 138);
            label7.Name = "label7";
            label7.Size = new Size(31, 20);
            label7.TabIndex = 21;
            label7.Text = "-60";
            // 
            // gain4
            // 
            gain4.Location = new Point(637, 32);
            gain4.Maximum = 0;
            gain4.Minimum = -60;
            gain4.Name = "gain4";
            gain4.Orientation = Orientation.Vertical;
            gain4.RightToLeft = RightToLeft.No;
            gain4.Size = new Size(56, 130);
            gain4.TabIndex = 20;
            gain4.TickStyle = TickStyle.Both;
            gain4.ValueChanged += gainChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(764, 32);
            label8.Name = "label8";
            label8.Size = new Size(17, 20);
            label8.TabIndex = 25;
            label8.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(764, 138);
            label9.Name = "label9";
            label9.Size = new Size(31, 20);
            label9.TabIndex = 24;
            label9.Text = "-60";
            // 
            // gain5
            // 
            gain5.Location = new Point(719, 32);
            gain5.Maximum = 0;
            gain5.Minimum = -60;
            gain5.Name = "gain5";
            gain5.Orientation = Orientation.Vertical;
            gain5.RightToLeft = RightToLeft.No;
            gain5.Size = new Size(56, 130);
            gain5.TabIndex = 23;
            gain5.TickStyle = TickStyle.Both;
            gain5.ValueChanged += gainChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(846, 28);
            label10.Name = "label10";
            label10.Size = new Size(17, 20);
            label10.TabIndex = 28;
            label10.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(846, 134);
            label11.Name = "label11";
            label11.Size = new Size(31, 20);
            label11.TabIndex = 27;
            label11.Text = "-60";
            // 
            // gain6
            // 
            gain6.Location = new Point(801, 28);
            gain6.Maximum = 0;
            gain6.Minimum = -60;
            gain6.Name = "gain6";
            gain6.Orientation = Orientation.Vertical;
            gain6.RightToLeft = RightToLeft.No;
            gain6.Size = new Size(56, 130);
            gain6.TabIndex = 26;
            gain6.TickStyle = TickStyle.Both;
            gain6.ValueChanged += gainChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(391, 165);
            label12.Name = "label12";
            label12.Size = new Size(47, 20);
            label12.TabIndex = 29;
            label12.Text = "0-100";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(466, 165);
            label13.Name = "label13";
            label13.Size = new Size(63, 20);
            label13.TabIndex = 30;
            label13.Text = "100-954";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(546, 165);
            label14.Name = "label14";
            label14.Size = new Size(71, 20);
            label14.TabIndex = 31;
            label14.Text = "954-2226";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(623, 165);
            label15.Name = "label15";
            label15.Size = new Size(79, 20);
            label15.TabIndex = 32;
            label15.Text = "2226-4770";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(702, 165);
            label16.Name = "label16";
            label16.Size = new Size(79, 20);
            label16.TabIndex = 33;
            label16.Text = "4770-9858";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(787, 165);
            label17.Name = "label17";
            label17.Size = new Size(87, 20);
            label17.TabIndex = 34;
            label17.Text = "9858-22000";
            // 
            // SPod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 203);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(gain6);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(gain5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(gain4);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(gain3);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(gain2);
            Controls.Add(label1);
            Controls.Add(gain1_0);
            Controls.Add(gain1_60);
            Controls.Add(gain1);
            Controls.Add(FIR);
            Controls.Add(IIR);
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
            ((System.ComponentModel.ISupportInitialize)gain2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain3).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain4).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain5).EndInit();
            ((System.ComponentModel.ISupportInitialize)gain6).EndInit();
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
        private RadioButton IIR;
        private RadioButton FIR;
        private TrackBar gain1;
        private Label gain1_60;
        private Label gain1_0;
        private Label label1;
        private Label label2;
        private Label label3;
        private TrackBar gain2;
        private Label label4;
        private Label label5;
        private TrackBar gain3;
        private Label label6;
        private Label label7;
        private TrackBar gain4;
        private Label label8;
        private Label label9;
        private TrackBar gain5;
        private Label label10;
        private Label label11;
        private TrackBar gain6;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
    }
}

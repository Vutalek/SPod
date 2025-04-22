namespace PlayTest
{
    partial class Play
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
            // Play
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 110);
            Controls.Add(restartButton);
            Controls.Add(stopButton);
            Controls.Add(playButton);
            Controls.Add(fileName);
            Controls.Add(fileButton);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Play";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Play";
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
    }
}

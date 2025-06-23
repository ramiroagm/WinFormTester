namespace WinFormTester
{
    partial class Spotify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            groupBox1 = new GroupBox();
            rbSpotifyData = new RichTextBox();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(218, 21);
            button1.Name = "button1";
            button1.Size = new Size(142, 23);
            button1.TabIndex = 0;
            button1.Text = "Connect Info";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbSpotifyData);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 260);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tester data";
            // 
            // rbSpotifyData
            // 
            rbSpotifyData.Location = new Point(6, 22);
            rbSpotifyData.Name = "rbSpotifyData";
            rbSpotifyData.Size = new Size(188, 232);
            rbSpotifyData.TabIndex = 0;
            rbSpotifyData.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(218, 50);
            button2.Name = "button2";
            button2.Size = new Size(142, 23);
            button2.TabIndex = 2;
            button2.Text = "Connect Playback";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Spotify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Name = "Spotify";
            Text = "Spotify";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private GroupBox groupBox1;
        private RichTextBox rbSpotifyData;
        private Button button2;
    }
}
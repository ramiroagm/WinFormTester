namespace WinFormTester
{
    partial class TelegramBot
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
            btnConnect = new Button();
            txtMessage = new TextBox();
            rtxtResult = new RichTextBox();
            btnSendMsg = new Button();
            groupBox1 = new GroupBox();
            btnClean = new Button();
            groupBox2 = new GroupBox();
            rtxtLog = new RichTextBox();
            groupBox3 = new GroupBox();
            btnClean2 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(6, 22);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(109, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(121, 52);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(189, 23);
            txtMessage.TabIndex = 1;
            // 
            // rtxtResult
            // 
            rtxtResult.Location = new Point(6, 22);
            rtxtResult.Name = "rtxtResult";
            rtxtResult.Size = new Size(354, 185);
            rtxtResult.TabIndex = 2;
            rtxtResult.Text = "";
            // 
            // btnSendMsg
            // 
            btnSendMsg.Location = new Point(6, 51);
            btnSendMsg.Name = "btnSendMsg";
            btnSendMsg.Size = new Size(109, 23);
            btnSendMsg.TabIndex = 3;
            btnSendMsg.Text = "Enviar mensaje";
            btnSendMsg.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClean);
            groupBox1.Controls.Add(rtxtResult);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 242);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ventana de resultado";
            // 
            // btnClean
            // 
            btnClean.Location = new Point(6, 213);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(75, 23);
            btnClean.TabIndex = 3;
            btnClean.Text = "Limpiar";
            btnClean.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnConnect);
            groupBox2.Controls.Add(btnSendMsg);
            groupBox2.Controls.Add(txtMessage);
            groupBox2.Location = new Point(384, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 421);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Conexión";
            // 
            // rtxtLog
            // 
            rtxtLog.Location = new Point(6, 22);
            rtxtLog.Name = "rtxtLog";
            rtxtLog.Size = new Size(354, 123);
            rtxtLog.TabIndex = 4;
            rtxtLog.Text = "";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnClean2);
            groupBox3.Controls.Add(rtxtLog);
            groupBox3.Location = new Point(12, 260);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(366, 182);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Logs y excepciones";
            // 
            // btnClean2
            // 
            btnClean2.Location = new Point(6, 151);
            btnClean2.Name = "btnClean2";
            btnClean2.Size = new Size(75, 23);
            btnClean2.TabIndex = 4;
            btnClean2.Text = "Limpiar";
            btnClean2.UseVisualStyleBackColor = true;
            // 
            // TelegramBot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 454);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "TelegramBot";
            Text = "TelegramBot";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnConnect;
        private TextBox txtMessage;
        private RichTextBox rtxtResult;
        private Button btnSendMsg;
        private GroupBox groupBox1;
        private Button btnClean;
        private GroupBox groupBox2;
        private RichTextBox rtxtLog;
        private GroupBox groupBox3;
        private Button btnClean2;
    }
}
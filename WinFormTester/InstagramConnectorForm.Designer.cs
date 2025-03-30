namespace WinFormTester
{
    partial class InstagramConnectorForm
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
            groupBox1 = new GroupBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            rtxtLog = new RichTextBox();
            groupBox3 = new GroupBox();
            btnSend = new Button();
            label4 = new Label();
            txtMessage = new TextBox();
            txtUserToSend = new TextBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            txtCantMsg = new TextBox();
            label5 = new Label();
            btnGetMsg = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(135, 81);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 117);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Conexión a Instagram";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(95, 52);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(156, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(95, 21);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(156, 23);
            txtUserName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 55);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 24);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtxtLog);
            groupBox2.Location = new Point(293, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(388, 419);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log";
            // 
            // rtxtLog
            // 
            rtxtLog.Location = new Point(6, 21);
            rtxtLog.Name = "rtxtLog";
            rtxtLog.Size = new Size(371, 392);
            rtxtLog.TabIndex = 0;
            rtxtLog.Text = "";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnSend);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(txtMessage);
            groupBox3.Controls.Add(txtUserToSend);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(12, 135);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(275, 130);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Enviar mensaje";
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(123, 93);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(104, 23);
            btnSend.TabIndex = 4;
            btnSend.Text = "Enviar mensaje";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 67);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 3;
            label4.Text = "Mensaje:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(105, 64);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(146, 23);
            txtMessage.TabIndex = 2;
            // 
            // txtUserToSend
            // 
            txtUserToSend.Location = new Point(106, 29);
            txtUserToSend.Name = "txtUserToSend";
            txtUserToSend.Size = new Size(145, 23);
            txtUserToSend.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 32);
            label3.Name = "label3";
            label3.Size = new Size(94, 15);
            label3.TabIndex = 0;
            label3.Text = "Usuario a enviar:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtCantMsg);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(btnGetMsg);
            groupBox4.Location = new Point(12, 271);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(275, 160);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Obtener mensajes";
            // 
            // txtCantMsg
            // 
            txtCantMsg.Location = new Point(198, 16);
            txtCantMsg.Name = "txtCantMsg";
            txtCantMsg.Size = new Size(33, 23);
            txtCantMsg.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 19);
            label5.Name = "label5";
            label5.Size = new Size(173, 15);
            label5.TabIndex = 1;
            label5.Text = "Cantidad de mensajes por chat:";
            // 
            // btnGetMsg
            // 
            btnGetMsg.Location = new Point(86, 37);
            btnGetMsg.Name = "btnGetMsg";
            btnGetMsg.Size = new Size(75, 23);
            btnGetMsg.TabIndex = 0;
            btnGetMsg.Text = "Obtener";
            btnGetMsg.UseVisualStyleBackColor = true;
            btnGetMsg.Click += btnGetMsg_Click;
            // 
            // InstagramConnector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 444);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "InstagramConnector";
            Text = "InstagramConnector";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnConnect;
        private GroupBox groupBox1;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private RichTextBox rtxtLog;
        private GroupBox groupBox3;
        private Button btnSend;
        private Label label4;
        private TextBox txtMessage;
        private TextBox txtUserToSend;
        private Label label3;
        private GroupBox groupBox4;
        private TextBox txtCantMsg;
        private Label label5;
        private Button btnGetMsg;
    }
}
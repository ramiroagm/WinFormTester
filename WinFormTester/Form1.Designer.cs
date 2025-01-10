namespace WinFormTester
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
            components = new System.ComponentModel.Container();
            btnInyection = new Button();
            testing1 = new GroupBox();
            rtResult = new RichTextBox();
            groupBox1 = new GroupBox();
            buttonSend = new Button();
            listBoxMessages = new ListBox();
            label2 = new Label();
            label1 = new Label();
            txtVal2 = new TextBox();
            txtVal1 = new TextBox();
            btnDelegate = new Button();
            txtTester = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            textBoxMessage = new TextBox();
            testing1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnInyection
            // 
            btnInyection.Location = new Point(6, 22);
            btnInyection.Name = "btnInyection";
            btnInyection.Size = new Size(75, 23);
            btnInyection.TabIndex = 0;
            btnInyection.Text = "Inyección";
            btnInyection.UseVisualStyleBackColor = true;
            btnInyection.Click += btnInyection_Click;
            // 
            // testing1
            // 
            testing1.Controls.Add(rtResult);
            testing1.Controls.Add(listBoxMessages);
            testing1.Location = new Point(12, 12);
            testing1.Name = "testing1";
            testing1.Size = new Size(436, 536);
            testing1.TabIndex = 1;
            testing1.TabStop = false;
            testing1.Text = "Resultados";
            // 
            // rtResult
            // 
            rtResult.Location = new Point(6, 22);
            rtResult.Name = "rtResult";
            rtResult.Size = new Size(429, 277);
            rtResult.TabIndex = 0;
            rtResult.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxMessage);
            groupBox1.Controls.Add(buttonSend);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtVal2);
            groupBox1.Controls.Add(txtVal1);
            groupBox1.Controls.Add(btnDelegate);
            groupBox1.Controls.Add(txtTester);
            groupBox1.Controls.Add(btnInyection);
            groupBox1.Location = new Point(472, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(302, 305);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acciones";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(6, 80);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(75, 23);
            buttonSend.TabIndex = 8;
            buttonSend.Text = "SignalIR";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_ClickAsync;
            // 
            // listBoxMessages
            // 
            listBoxMessages.FormattingEnabled = true;
            listBoxMessages.Location = new Point(6, 305);
            listBoxMessages.Name = "listBoxMessages";
            listBoxMessages.Size = new Size(424, 229);
            listBoxMessages.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 55);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 6;
            label2.Text = "Valor 1:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(180, 55);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Valor 2:";
            // 
            // txtVal2
            // 
            txtVal2.Location = new Point(231, 52);
            txtVal2.Name = "txtVal2";
            txtVal2.Size = new Size(53, 23);
            txtVal2.TabIndex = 4;
            // 
            // txtVal1
            // 
            txtVal1.Location = new Point(131, 51);
            txtVal1.Name = "txtVal1";
            txtVal1.Size = new Size(46, 23);
            txtVal1.TabIndex = 3;
            // 
            // btnDelegate
            // 
            btnDelegate.Location = new Point(6, 51);
            btnDelegate.Name = "btnDelegate";
            btnDelegate.Size = new Size(75, 23);
            btnDelegate.TabIndex = 2;
            btnDelegate.Text = "Delegado";
            btnDelegate.UseVisualStyleBackColor = true;
            btnDelegate.Click += btnDelegate_Click;
            // 
            // txtTester
            // 
            txtTester.Location = new Point(87, 22);
            txtTester.Name = "txtTester";
            txtTester.Size = new Size(197, 23);
            txtTester.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(87, 80);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(197, 23);
            textBoxMessage.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 589);
            Controls.Add(groupBox1);
            Controls.Add(testing1);
            Name = "Form1";
            Text = "Form1";
            testing1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnInyection;
        private GroupBox testing1;
        private GroupBox groupBox1;
        private RichTextBox rtResult;
        private TextBox txtTester;
        private Button btnDelegate;
        private Label label2;
        private Label label1;
        private TextBox txtVal2;
        private TextBox txtVal1;
        private ErrorProvider errorProvider1;
        private ListBox listBoxMessages;
        private Button buttonSend;
        private TextBox textBoxMessage;
    }
}

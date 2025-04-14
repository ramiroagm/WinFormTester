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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnInyection = new Button();
            testing1 = new GroupBox();
            rtResult = new RichTextBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            txtVal2 = new TextBox();
            txtVal1 = new TextBox();
            btnDelegate = new Button();
            txtTester = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            menuStrip1 = new MenuStrip();
            consultasABaseDirectoToolStripMenuItem = new ToolStripMenuItem();
            menúPrincipalToolStripMenuItem = new ToolStripMenuItem();
            consultasPorServicioToolStripMenuItem = new ToolStripMenuItem();
            menúPrincipalToolStripMenuItem1 = new ToolStripMenuItem();
            botTelegramToolStripMenuItem = new ToolStripMenuItem();
            instagramToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            sdfaToolStripMenuItem = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            label3 = new Label();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            testing1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            testing1.Location = new Point(12, 52);
            testing1.Name = "testing1";
            testing1.Size = new Size(454, 305);
            testing1.TabIndex = 1;
            testing1.TabStop = false;
            testing1.Text = "Resultados";
            // 
            // rtResult
            // 
            rtResult.Location = new Point(6, 22);
            rtResult.Name = "rtResult";
            rtResult.Size = new Size(442, 277);
            rtResult.TabIndex = 0;
            rtResult.Text = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtVal2);
            groupBox1.Controls.Add(txtVal1);
            groupBox1.Controls.Add(btnDelegate);
            groupBox1.Controls.Add(txtTester);
            groupBox1.Controls.Add(btnInyection);
            groupBox1.Location = new Point(18, 363);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(448, 104);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acciones básicas";
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
            txtTester.Size = new Size(355, 23);
            txtTester.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { consultasABaseDirectoToolStripMenuItem, consultasPorServicioToolStripMenuItem, botTelegramToolStripMenuItem, instagramToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(971, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // consultasABaseDirectoToolStripMenuItem
            // 
            consultasABaseDirectoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menúPrincipalToolStripMenuItem });
            consultasABaseDirectoToolStripMenuItem.Name = "consultasABaseDirectoToolStripMenuItem";
            consultasABaseDirectoToolStripMenuItem.Size = new Size(147, 20);
            consultasABaseDirectoToolStripMenuItem.Text = "Consultas a base directo";
            // 
            // menúPrincipalToolStripMenuItem
            // 
            menúPrincipalToolStripMenuItem.Name = "menúPrincipalToolStripMenuItem";
            menúPrincipalToolStripMenuItem.Size = new Size(154, 22);
            menúPrincipalToolStripMenuItem.Text = "Menú principal";
            // 
            // consultasPorServicioToolStripMenuItem
            // 
            consultasPorServicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menúPrincipalToolStripMenuItem1 });
            consultasPorServicioToolStripMenuItem.Name = "consultasPorServicioToolStripMenuItem";
            consultasPorServicioToolStripMenuItem.Size = new Size(135, 20);
            consultasPorServicioToolStripMenuItem.Text = "Consultas por servicio";
            // 
            // menúPrincipalToolStripMenuItem1
            // 
            menúPrincipalToolStripMenuItem1.Name = "menúPrincipalToolStripMenuItem1";
            menúPrincipalToolStripMenuItem1.Size = new Size(154, 22);
            menúPrincipalToolStripMenuItem1.Text = "Menú principal";
            menúPrincipalToolStripMenuItem1.Click += menúPrincipalToolStripMenuItem1_Click;
            // 
            // botTelegramToolStripMenuItem
            // 
            botTelegramToolStripMenuItem.Name = "botTelegramToolStripMenuItem";
            botTelegramToolStripMenuItem.Size = new Size(89, 20);
            botTelegramToolStripMenuItem.Text = "Bot Telegram";
            botTelegramToolStripMenuItem.Click += botTelegramToolStripMenuItem_Click;
            // 
            // instagramToolStripMenuItem
            // 
            instagramToolStripMenuItem.Name = "instagramToolStripMenuItem";
            instagramToolStripMenuItem.Size = new Size(72, 20);
            instagramToolStripMenuItem.Text = "Instagram";
            instagramToolStripMenuItem.Click += instagramToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sdfaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(97, 26);
            // 
            // sdfaToolStripMenuItem
            // 
            sdfaToolStripMenuItem.Name = "sdfaToolStripMenuItem";
            sdfaToolStripMenuItem.Size = new Size(96, 22);
            sdfaToolStripMenuItem.Text = "sdfa";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(linkLabel2);
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Location = new Point(472, 52);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(487, 415);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Información general";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 22);
            label3.Name = "label3";
            label3.Size = new Size(417, 15);
            label3.TabIndex = 2;
            label3.Text = "A continuación, queda información general sobre mi persona y este proyecto:\r\n";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(97, 57);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(67, 15);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "URL Github";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked_1;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(15, 57);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(76, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "URL LinkedIn";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(971, 492);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(testing1);
            Controls.Add(menuStrip1);
            Cursor = Cursors.Arrow;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form1";
            Text = "Menú principal";
            TransparencyKey = Color.Red;
            Load += Form1_Load;
            testing1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private MenuStrip menuStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sdfaToolStripMenuItem;
        private ToolStripMenuItem consultasABaseDirectoToolStripMenuItem;
        private ToolStripMenuItem menúPrincipalToolStripMenuItem;
        private ToolStripMenuItem consultasPorServicioToolStripMenuItem;
        private ToolStripMenuItem menúPrincipalToolStripMenuItem1;
        private ToolStripMenuItem botTelegramToolStripMenuItem;
        private ToolStripMenuItem instagramToolStripMenuItem;
        private GroupBox groupBox2;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Label label3;
    }
}

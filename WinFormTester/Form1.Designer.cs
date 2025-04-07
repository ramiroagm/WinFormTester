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
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
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
            resources.ApplyResources(btnInyection, "btnInyection");
            btnInyection.Name = "btnInyection";
            btnInyection.UseVisualStyleBackColor = true;
            btnInyection.Click += btnInyection_Click;
            // 
            // testing1
            // 
            testing1.Controls.Add(rtResult);
            resources.ApplyResources(testing1, "testing1");
            testing1.Name = "testing1";
            testing1.TabStop = false;
            // 
            // rtResult
            // 
            resources.ApplyResources(rtResult, "rtResult");
            rtResult.Name = "rtResult";
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
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // txtVal2
            // 
            resources.ApplyResources(txtVal2, "txtVal2");
            txtVal2.Name = "txtVal2";
            // 
            // txtVal1
            // 
            resources.ApplyResources(txtVal1, "txtVal1");
            txtVal1.Name = "txtVal1";
            // 
            // btnDelegate
            // 
            resources.ApplyResources(btnDelegate, "btnDelegate");
            btnDelegate.Name = "btnDelegate";
            btnDelegate.UseVisualStyleBackColor = true;
            btnDelegate.Click += btnDelegate_Click;
            // 
            // txtTester
            // 
            resources.ApplyResources(txtTester, "txtTester");
            txtTester.Name = "txtTester";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { consultasABaseDirectoToolStripMenuItem, consultasPorServicioToolStripMenuItem, botTelegramToolStripMenuItem, instagramToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // consultasABaseDirectoToolStripMenuItem
            // 
            consultasABaseDirectoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menúPrincipalToolStripMenuItem });
            consultasABaseDirectoToolStripMenuItem.Name = "consultasABaseDirectoToolStripMenuItem";
            resources.ApplyResources(consultasABaseDirectoToolStripMenuItem, "consultasABaseDirectoToolStripMenuItem");
            // 
            // menúPrincipalToolStripMenuItem
            // 
            menúPrincipalToolStripMenuItem.Name = "menúPrincipalToolStripMenuItem";
            resources.ApplyResources(menúPrincipalToolStripMenuItem, "menúPrincipalToolStripMenuItem");
            // 
            // consultasPorServicioToolStripMenuItem
            // 
            consultasPorServicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menúPrincipalToolStripMenuItem1 });
            consultasPorServicioToolStripMenuItem.Name = "consultasPorServicioToolStripMenuItem";
            resources.ApplyResources(consultasPorServicioToolStripMenuItem, "consultasPorServicioToolStripMenuItem");
            // 
            // menúPrincipalToolStripMenuItem1
            // 
            menúPrincipalToolStripMenuItem1.Name = "menúPrincipalToolStripMenuItem1";
            resources.ApplyResources(menúPrincipalToolStripMenuItem1, "menúPrincipalToolStripMenuItem1");
            menúPrincipalToolStripMenuItem1.Click += menúPrincipalToolStripMenuItem1_Click;
            // 
            // botTelegramToolStripMenuItem
            // 
            botTelegramToolStripMenuItem.Name = "botTelegramToolStripMenuItem";
            resources.ApplyResources(botTelegramToolStripMenuItem, "botTelegramToolStripMenuItem");
            botTelegramToolStripMenuItem.Click += botTelegramToolStripMenuItem_Click;
            // 
            // instagramToolStripMenuItem
            // 
            instagramToolStripMenuItem.Name = "instagramToolStripMenuItem";
            resources.ApplyResources(instagramToolStripMenuItem, "instagramToolStripMenuItem");
            instagramToolStripMenuItem.Click += instagramToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sdfaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            // 
            // sdfaToolStripMenuItem
            // 
            sdfaToolStripMenuItem.Name = "sdfaToolStripMenuItem";
            resources.ApplyResources(sdfaToolStripMenuItem, "sdfaToolStripMenuItem");
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(linkLabel2);
            groupBox2.Controls.Add(linkLabel1);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // linkLabel2
            // 
            resources.ApplyResources(linkLabel2, "linkLabel2");
            linkLabel2.Name = "linkLabel2";
            linkLabel2.TabStop = true;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked_1;
            // 
            // linkLabel1
            // 
            resources.ApplyResources(linkLabel1, "linkLabel1");
            linkLabel1.Name = "linkLabel1";
            linkLabel1.TabStop = true;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked_1;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(testing1);
            Controls.Add(menuStrip1);
            Cursor = Cursors.Cross;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            HelpButton = true;
            KeyPreview = true;
            Name = "Form1";
            TopMost = true;
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

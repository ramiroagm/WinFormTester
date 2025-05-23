﻿namespace WinFormTester
{
    partial class LoginForm
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
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnFgtPwd = new Button();
            btnCreateAcc = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(79, 112);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(79, 46);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(330, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(79, 83);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(330, 23);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 49);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 3;
            label1.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 83);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // btnFgtPwd
            // 
            btnFgtPwd.Location = new Point(160, 112);
            btnFgtPwd.Name = "btnFgtPwd";
            btnFgtPwd.Size = new Size(128, 23);
            btnFgtPwd.TabIndex = 5;
            btnFgtPwd.Text = "Forgot Password";
            btnFgtPwd.UseVisualStyleBackColor = true;
            // 
            // btnCreateAcc
            // 
            btnCreateAcc.Location = new Point(294, 112);
            btnCreateAcc.Name = "btnCreateAcc";
            btnCreateAcc.Size = new Size(115, 23);
            btnCreateAcc.TabIndex = 6;
            btnCreateAcc.Text = "Create account";
            btnCreateAcc.UseVisualStyleBackColor = true;
            btnCreateAcc.Click += btnCreateAcc_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(119, 18);
            label3.Name = "label3";
            label3.Size = new Size(220, 15);
            label3.TabIndex = 7;
            label3.Text = "Inicio de sesión para ventanas de prueba";
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 178);
            Controls.Add(label3);
            Controls.Add(btnCreateAcc);
            Controls.Add(btnFgtPwd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Button btnFgtPwd;
        private Button btnCreateAcc;
        private Label label3;
    }
}

namespace computerScienceNEA
{
    partial class FormAccountLogin
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDatabaseLoginUsername = new System.Windows.Forms.TextBox();
            this.textBoxDatabaseLoginPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(222, 25);
            this.label10.TabIndex = 53;
            this.label10.Text = "Login to an Account";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(259, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Please enter your details below to register an account";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 56;
            this.label3.Text = "Username :";
            // 
            // textBoxDatabaseLoginUsername
            // 
            this.textBoxDatabaseLoginUsername.Location = new System.Drawing.Point(84, 87);
            this.textBoxDatabaseLoginUsername.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseLoginUsername.Name = "textBoxDatabaseLoginUsername";
            this.textBoxDatabaseLoginUsername.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabaseLoginUsername.TabIndex = 55;
            // 
            // textBoxDatabaseLoginPassword
            // 
            this.textBoxDatabaseLoginPassword.Location = new System.Drawing.Point(84, 122);
            this.textBoxDatabaseLoginPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseLoginPassword.Name = "textBoxDatabaseLoginPassword";
            this.textBoxDatabaseLoginPassword.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabaseLoginPassword.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Not got an account? Press \"Register\" below.\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(56, 279);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(159, 28);
            this.buttonRegister.TabIndex = 59;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 150);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(252, 28);
            this.buttonLogin.TabIndex = 60;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // FormAccountLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 326);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDatabaseLoginUsername);
            this.Controls.Add(this.textBoxDatabaseLoginPassword);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Name = "FormAccountLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormAccountLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDatabaseLoginUsername;
        private System.Windows.Forms.TextBox textBoxDatabaseLoginPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonLogin;
    }
}
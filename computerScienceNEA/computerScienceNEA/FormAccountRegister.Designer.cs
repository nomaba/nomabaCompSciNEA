
namespace computerScienceNEA
{
    partial class FormAccountRegister
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
            this.textBoxDatabasePassword = new System.Windows.Forms.TextBox();
            this.textBoxDatabaseLastName = new System.Windows.Forms.TextBox();
            this.textBoxDatabaseFirstName = new System.Windows.Forms.TextBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.textBoxDatabaseUsername = new System.Windows.Forms.TextBox();
            this.textBoxDatabaseBirthDay = new System.Windows.Forms.TextBox();
            this.textBoxDatabaseBirthMonth = new System.Windows.Forms.TextBox();
            this.textBoxDatabaseBirthYear = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxDatabasePassword
            // 
            this.textBoxDatabasePassword.Location = new System.Drawing.Point(300, 249);
            this.textBoxDatabasePassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabasePassword.Name = "textBoxDatabasePassword";
            this.textBoxDatabasePassword.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabasePassword.TabIndex = 31;
            this.textBoxDatabasePassword.Text = "Password";
            // 
            // textBoxDatabaseLastName
            // 
            this.textBoxDatabaseLastName.Location = new System.Drawing.Point(300, 114);
            this.textBoxDatabaseLastName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseLastName.Name = "textBoxDatabaseLastName";
            this.textBoxDatabaseLastName.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabaseLastName.TabIndex = 30;
            this.textBoxDatabaseLastName.Text = "Last Name";
            // 
            // textBoxDatabaseFirstName
            // 
            this.textBoxDatabaseFirstName.Location = new System.Drawing.Point(300, 86);
            this.textBoxDatabaseFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseFirstName.Name = "textBoxDatabaseFirstName";
            this.textBoxDatabaseFirstName.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabaseFirstName.TabIndex = 29;
            this.textBoxDatabaseFirstName.Text = "First Name";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(300, 287);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(159, 28);
            this.buttonInsert.TabIndex = 28;
            this.buttonInsert.Text = "Inert into database";
            this.buttonInsert.UseVisualStyleBackColor = true;
            // 
            // textBoxDatabaseUsername
            // 
            this.textBoxDatabaseUsername.Location = new System.Drawing.Point(300, 163);
            this.textBoxDatabaseUsername.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseUsername.Name = "textBoxDatabaseUsername";
            this.textBoxDatabaseUsername.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabaseUsername.TabIndex = 32;
            this.textBoxDatabaseUsername.Text = "Username";
            // 
            // textBoxDatabaseBirthDay
            // 
            this.textBoxDatabaseBirthDay.Location = new System.Drawing.Point(300, 191);
            this.textBoxDatabaseBirthDay.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseBirthDay.Name = "textBoxDatabaseBirthDay";
            this.textBoxDatabaseBirthDay.Size = new System.Drawing.Size(47, 20);
            this.textBoxDatabaseBirthDay.TabIndex = 33;
            this.textBoxDatabaseBirthDay.Text = "Day";
            // 
            // textBoxDatabaseBirthMonth
            // 
            this.textBoxDatabaseBirthMonth.Location = new System.Drawing.Point(355, 191);
            this.textBoxDatabaseBirthMonth.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseBirthMonth.Name = "textBoxDatabaseBirthMonth";
            this.textBoxDatabaseBirthMonth.Size = new System.Drawing.Size(47, 20);
            this.textBoxDatabaseBirthMonth.TabIndex = 34;
            this.textBoxDatabaseBirthMonth.Text = "Month";
            // 
            // textBoxDatabaseBirthYear
            // 
            this.textBoxDatabaseBirthYear.Location = new System.Drawing.Point(412, 191);
            this.textBoxDatabaseBirthYear.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseBirthYear.Name = "textBoxDatabaseBirthYear";
            this.textBoxDatabaseBirthYear.Size = new System.Drawing.Size(47, 20);
            this.textBoxDatabaseBirthYear.TabIndex = 35;
            this.textBoxDatabaseBirthYear.Text = "Year";
            // 
            // FormAccountRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxDatabaseBirthYear);
            this.Controls.Add(this.textBoxDatabaseBirthMonth);
            this.Controls.Add(this.textBoxDatabaseBirthDay);
            this.Controls.Add(this.textBoxDatabaseUsername);
            this.Controls.Add(this.textBoxDatabasePassword);
            this.Controls.Add(this.textBoxDatabaseLastName);
            this.Controls.Add(this.textBoxDatabaseFirstName);
            this.Controls.Add(this.buttonInsert);
            this.Name = "FormAccountRegister";
            this.Text = "FormRegisterAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDatabasePassword;
        private System.Windows.Forms.TextBox textBoxDatabaseLastName;
        private System.Windows.Forms.TextBox textBoxDatabaseFirstName;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.TextBox textBoxDatabaseUsername;
        private System.Windows.Forms.TextBox textBoxDatabaseBirthDay;
        private System.Windows.Forms.TextBox textBoxDatabaseBirthMonth;
        private System.Windows.Forms.TextBox textBoxDatabaseBirthYear;
    }
}
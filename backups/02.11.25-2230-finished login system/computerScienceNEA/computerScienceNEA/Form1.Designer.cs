
namespace computerScienceNEA
{
    partial class RobotControls
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
            this.buttonStartRobot = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.lightOff = new System.Windows.Forms.Button();
            this.lightOn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonForwards = new System.Windows.Forms.Button();
            this.buttonBackwards = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonSQLSearch = new System.Windows.Forms.Button();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.textBoxDatabaseFirstName = new System.Windows.Forms.TextBox();
            this.textBoxDatabaseLastName = new System.Windows.Forms.TextBox();
            this.textBoxDatabasePassword = new System.Windows.Forms.TextBox();
            this.textBoxDataLoginPassword = new System.Windows.Forms.TextBox();
            this.textBoxDataLoginAccountID = new System.Windows.Forms.TextBox();
            this.buttonDataLogin = new System.Windows.Forms.Button();
            this.textBoxDataLoginOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStartRobot
            // 
            this.buttonStartRobot.Location = new System.Drawing.Point(12, 81);
            this.buttonStartRobot.Name = "buttonStartRobot";
            this.buttonStartRobot.Size = new System.Drawing.Size(293, 86);
            this.buttonStartRobot.TabIndex = 14;
            this.buttonStartRobot.Text = "Start The Robot";
            this.buttonStartRobot.UseVisualStyleBackColor = true;
            this.buttonStartRobot.Click += new System.EventHandler(this.buttonStartRobot_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(13, 52);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(293, 23);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(12, 25);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(293, 21);
            this.comboBoxPorts.TabIndex = 10;
            this.comboBoxPorts.Text = "COM port";
            // 
            // lightOff
            // 
            this.lightOff.Location = new System.Drawing.Point(419, 81);
            this.lightOff.Name = "lightOff";
            this.lightOff.Size = new System.Drawing.Size(117, 45);
            this.lightOff.TabIndex = 9;
            this.lightOff.Text = "Light Off";
            this.lightOff.UseVisualStyleBackColor = true;
            this.lightOff.Click += new System.EventHandler(this.lightOff_Click);
            // 
            // lightOn
            // 
            this.lightOn.Location = new System.Drawing.Point(542, 81);
            this.lightOn.Name = "lightOn";
            this.lightOn.Size = new System.Drawing.Size(117, 49);
            this.lightOn.TabIndex = 8;
            this.lightOn.Text = "Light On";
            this.lightOn.UseVisualStyleBackColor = true;
            this.lightOn.Click += new System.EventHandler(this.lightOn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Please select your COM Port";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(366, 55);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(293, 20);
            this.textBoxOutput.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "test section (remove this befroe finishing)";
            // 
            // buttonForwards
            // 
            this.buttonForwards.Location = new System.Drawing.Point(256, 239);
            this.buttonForwards.Name = "buttonForwards";
            this.buttonForwards.Size = new System.Drawing.Size(117, 49);
            this.buttonForwards.TabIndex = 17;
            this.buttonForwards.Text = "Forwards";
            this.buttonForwards.UseVisualStyleBackColor = true;
            this.buttonForwards.Click += new System.EventHandler(this.buttonForwards_Click);
            // 
            // buttonBackwards
            // 
            this.buttonBackwards.Location = new System.Drawing.Point(256, 294);
            this.buttonBackwards.Name = "buttonBackwards";
            this.buttonBackwards.Size = new System.Drawing.Size(117, 49);
            this.buttonBackwards.TabIndex = 18;
            this.buttonBackwards.Text = "Backwards";
            this.buttonBackwards.UseVisualStyleBackColor = true;
            this.buttonBackwards.Click += new System.EventHandler(this.buttonBackwards_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(379, 294);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(117, 49);
            this.buttonRight.TabIndex = 19;
            this.buttonRight.Text = "Right";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(133, 294);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(117, 49);
            this.buttonLeft.TabIndex = 20;
            this.buttonLeft.Text = "Left";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(256, 349);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(117, 49);
            this.buttonStop.TabIndex = 21;
            this.buttonStop.Text = "stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(805, 13);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(159, 28);
            this.buttonRegister.TabIndex = 22;
            this.buttonRegister.Text = "Inert into database";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonSQLSearch
            // 
            this.buttonSQLSearch.Location = new System.Drawing.Point(805, 130);
            this.buttonSQLSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSQLSearch.Name = "buttonSQLSearch";
            this.buttonSQLSearch.Size = new System.Drawing.Size(159, 28);
            this.buttonSQLSearch.TabIndex = 23;
            this.buttonSQLSearch.Text = "run SQL search";
            this.buttonSQLSearch.UseVisualStyleBackColor = true;
            this.buttonSQLSearch.Click += new System.EventHandler(this.buttonSQLSearch_Click);
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.Location = new System.Drawing.Point(805, 166);
            this.listBoxOutput.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(159, 238);
            this.listBoxOutput.TabIndex = 24;
            // 
            // textBoxDatabaseFirstName
            // 
            this.textBoxDatabaseFirstName.Location = new System.Drawing.Point(805, 49);
            this.textBoxDatabaseFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseFirstName.Name = "textBoxDatabaseFirstName";
            this.textBoxDatabaseFirstName.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabaseFirstName.TabIndex = 25;
            // 
            // textBoxDatabaseLastName
            // 
            this.textBoxDatabaseLastName.Location = new System.Drawing.Point(805, 77);
            this.textBoxDatabaseLastName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabaseLastName.Name = "textBoxDatabaseLastName";
            this.textBoxDatabaseLastName.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabaseLastName.TabIndex = 26;
            // 
            // textBoxDatabasePassword
            // 
            this.textBoxDatabasePassword.Location = new System.Drawing.Point(805, 105);
            this.textBoxDatabasePassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDatabasePassword.Name = "textBoxDatabasePassword";
            this.textBoxDatabasePassword.Size = new System.Drawing.Size(159, 20);
            this.textBoxDatabasePassword.TabIndex = 27;
            // 
            // textBoxDataLoginPassword
            // 
            this.textBoxDataLoginPassword.Location = new System.Drawing.Point(983, 77);
            this.textBoxDataLoginPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDataLoginPassword.Name = "textBoxDataLoginPassword";
            this.textBoxDataLoginPassword.Size = new System.Drawing.Size(159, 20);
            this.textBoxDataLoginPassword.TabIndex = 30;
            // 
            // textBoxDataLoginAccountID
            // 
            this.textBoxDataLoginAccountID.Location = new System.Drawing.Point(983, 49);
            this.textBoxDataLoginAccountID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDataLoginAccountID.Name = "textBoxDataLoginAccountID";
            this.textBoxDataLoginAccountID.Size = new System.Drawing.Size(159, 20);
            this.textBoxDataLoginAccountID.TabIndex = 29;
            // 
            // buttonDataLogin
            // 
            this.buttonDataLogin.Location = new System.Drawing.Point(983, 13);
            this.buttonDataLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDataLogin.Name = "buttonDataLogin";
            this.buttonDataLogin.Size = new System.Drawing.Size(159, 28);
            this.buttonDataLogin.TabIndex = 28;
            this.buttonDataLogin.Text = "Login";
            this.buttonDataLogin.UseVisualStyleBackColor = true;
            this.buttonDataLogin.Click += new System.EventHandler(this.buttonDataLogin_Click);
            // 
            // textBoxDataLoginOutput
            // 
            this.textBoxDataLoginOutput.Location = new System.Drawing.Point(983, 135);
            this.textBoxDataLoginOutput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDataLoginOutput.Name = "textBoxDataLoginOutput";
            this.textBoxDataLoginOutput.Size = new System.Drawing.Size(159, 20);
            this.textBoxDataLoginOutput.TabIndex = 31;
            // 
            // RobotControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 417);
            this.Controls.Add(this.textBoxDataLoginOutput);
            this.Controls.Add(this.textBoxDataLoginPassword);
            this.Controls.Add(this.textBoxDataLoginAccountID);
            this.Controls.Add(this.buttonDataLogin);
            this.Controls.Add(this.textBoxDatabasePassword);
            this.Controls.Add(this.textBoxDatabaseLastName);
            this.Controls.Add(this.textBoxDatabaseFirstName);
            this.Controls.Add(this.listBoxOutput);
            this.Controls.Add(this.buttonSQLSearch);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonBackwards);
            this.Controls.Add(this.buttonForwards);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStartRobot);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.lightOff);
            this.Controls.Add(this.lightOn);
            this.Name = "RobotControls";
            this.Text = "RobotControls";
            this.Load += new System.EventHandler(this.RobotControls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartRobot;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button lightOff;
        private System.Windows.Forms.Button lightOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonForwards;
        private System.Windows.Forms.Button buttonBackwards;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonSQLSearch;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.TextBox textBoxDatabaseFirstName;
        private System.Windows.Forms.TextBox textBoxDatabaseLastName;
        private System.Windows.Forms.TextBox textBoxDatabasePassword;
        private System.Windows.Forms.TextBox textBoxDataLoginPassword;
        private System.Windows.Forms.TextBox textBoxDataLoginAccountID;
        private System.Windows.Forms.Button buttonDataLogin;
        private System.Windows.Forms.TextBox textBoxDataLoginOutput;
    }
}


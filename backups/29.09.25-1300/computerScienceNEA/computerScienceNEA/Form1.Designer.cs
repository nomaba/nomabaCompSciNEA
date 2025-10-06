
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
            // 
            // lightOff
            // 
            this.lightOff.Location = new System.Drawing.Point(449, 81);
            this.lightOff.Name = "lightOff";
            this.lightOff.Size = new System.Drawing.Size(117, 45);
            this.lightOff.TabIndex = 9;
            this.lightOff.Text = "Light Off";
            this.lightOff.UseVisualStyleBackColor = true;
            this.lightOff.Click += new System.EventHandler(this.lightOff_Click);
            // 
            // lightOn
            // 
            this.lightOn.Location = new System.Drawing.Point(572, 81);
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
            this.textBoxOutput.Location = new System.Drawing.Point(396, 55);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(293, 20);
            this.textBoxOutput.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 33);
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
            // RobotControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 427);
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
    }
}


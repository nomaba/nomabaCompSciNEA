
namespace ArduinoFormsTest
{
    partial class ArduinoControls
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
            this.lightOn = new System.Windows.Forms.Button();
            this.lightOff = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonStartRobot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lightOn
            // 
            this.lightOn.Location = new System.Drawing.Point(12, 12);
            this.lightOn.Name = "lightOn";
            this.lightOn.Size = new System.Drawing.Size(293, 86);
            this.lightOn.TabIndex = 0;
            this.lightOn.Text = "Light On";
            this.lightOn.UseVisualStyleBackColor = true;
            this.lightOn.Click += new System.EventHandler(this.lightOn_Click);
            // 
            // lightOff
            // 
            this.lightOff.Location = new System.Drawing.Point(12, 104);
            this.lightOff.Name = "lightOff";
            this.lightOff.Size = new System.Drawing.Size(293, 86);
            this.lightOff.TabIndex = 1;
            this.lightOff.Text = "Light Off";
            this.lightOff.UseVisualStyleBackColor = true;
            this.lightOff.Click += new System.EventHandler(this.lightOff_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(12, 202);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPorts.TabIndex = 2;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 229);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(119, 23);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 258);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(293, 20);
            this.textBoxOutput.TabIndex = 5;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(14, 284);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(119, 23);
            this.buttonQuit.TabIndex = 6;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonStartRobot
            // 
            this.buttonStartRobot.Location = new System.Drawing.Point(12, 313);
            this.buttonStartRobot.Name = "buttonStartRobot";
            this.buttonStartRobot.Size = new System.Drawing.Size(293, 86);
            this.buttonStartRobot.TabIndex = 7;
            this.buttonStartRobot.Text = "Start The Robot";
            this.buttonStartRobot.UseVisualStyleBackColor = true;
            // 
            // ArduinoControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 422);
            this.Controls.Add(this.buttonStartRobot);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.lightOff);
            this.Controls.Add(this.lightOn);
            this.Name = "ArduinoControls";
            this.Text = "Arduino Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lightOn;
        private System.Windows.Forms.Button lightOff;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonStartRobot;
    }
}


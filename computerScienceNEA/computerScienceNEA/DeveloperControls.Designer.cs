
namespace computerScienceNEA
{
    partial class DeveloperControls
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSendCommand = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPreviousCommand = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 32);
            this.label1.TabIndex = 22;
            this.label1.Text = "Developer Controls";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(12, 131);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(403, 20);
            this.textBoxCommand.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Send a command to the robot (e.g. \"moveForward\")";
            // 
            // buttonSendCommand
            // 
            this.buttonSendCommand.Location = new System.Drawing.Point(194, 157);
            this.buttonSendCommand.Name = "buttonSendCommand";
            this.buttonSendCommand.Size = new System.Drawing.Size(221, 23);
            this.buttonSendCommand.TabIndex = 25;
            this.buttonSendCommand.Text = "Send Command";
            this.buttonSendCommand.UseVisualStyleBackColor = true;
            this.buttonSendCommand.Click += new System.EventHandler(this.buttonSendCommand_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Note: This developer menu can only be used after the home page has been opened";
            // 
            // labelPreviousCommand
            // 
            this.labelPreviousCommand.AutoSize = true;
            this.labelPreviousCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreviousCommand.Location = new System.Drawing.Point(12, 196);
            this.labelPreviousCommand.Name = "labelPreviousCommand";
            this.labelPreviousCommand.Size = new System.Drawing.Size(181, 16);
            this.labelPreviousCommand.TabIndex = 27;
            this.labelPreviousCommand.Text = "Previous command sent : null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(392, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Note : The command must exactly match a command in the listofcommands.txt file";
            // 
            // DeveloperControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 281);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPreviousCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSendCommand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.label1);
            this.Name = "DeveloperControls";
            this.Text = "Developer Contrtols";
            this.Load += new System.EventHandler(this.RobotControls_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSendCommand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPreviousCommand;
        private System.Windows.Forms.Label label5;
    }
}


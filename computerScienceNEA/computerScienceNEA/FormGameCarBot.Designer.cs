
namespace computerScienceNEA
{
    partial class FormGameCarBot
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
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonBackwards = new System.Windows.Forms.Button();
            this.buttonForwards = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGoHome = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(136, 195);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(117, 49);
            this.buttonStop.TabIndex = 26;
            this.buttonStop.Text = "stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(13, 195);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(117, 49);
            this.buttonLeft.TabIndex = 25;
            this.buttonLeft.Text = "Left";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(259, 195);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(117, 49);
            this.buttonRight.TabIndex = 24;
            this.buttonRight.Text = "Right";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonBackwards
            // 
            this.buttonBackwards.Location = new System.Drawing.Point(136, 250);
            this.buttonBackwards.Name = "buttonBackwards";
            this.buttonBackwards.Size = new System.Drawing.Size(117, 49);
            this.buttonBackwards.TabIndex = 23;
            this.buttonBackwards.Text = "Backwards";
            this.buttonBackwards.UseVisualStyleBackColor = true;
            this.buttonBackwards.Click += new System.EventHandler(this.buttonBackwards_Click);
            // 
            // buttonForwards
            // 
            this.buttonForwards.Location = new System.Drawing.Point(136, 140);
            this.buttonForwards.Name = "buttonForwards";
            this.buttonForwards.Size = new System.Drawing.Size(117, 49);
            this.buttonForwards.TabIndex = 22;
            this.buttonForwards.Text = "Forwards";
            this.buttonForwards.UseVisualStyleBackColor = true;
            this.buttonForwards.Click += new System.EventHandler(this.buttonForwards_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 32);
            this.label1.TabIndex = 27;
            this.label1.Text = "Welcome to Car Bot";
            // 
            // buttonGoHome
            // 
            this.buttonGoHome.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoHome.Location = new System.Drawing.Point(221, 329);
            this.buttonGoHome.Name = "buttonGoHome";
            this.buttonGoHome.Size = new System.Drawing.Size(158, 37);
            this.buttonGoHome.TabIndex = 28;
            this.buttonGoHome.Text = "Go back to home page";
            this.buttonGoHome.UseVisualStyleBackColor = true;
            this.buttonGoHome.Click += new System.EventHandler(this.buttonGoHome_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 86);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(341, 24);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = "Tell the robot which direction to move in by pressing the buttons below\r\n";
            // 
            // FormGameCarBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 377);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonGoHome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonBackwards);
            this.Controls.Add(this.buttonForwards);
            this.Name = "FormGameCarBot";
            this.Text = "FormGameCarBot";
            this.Load += new System.EventHandler(this.FormGameCarBot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonBackwards;
        private System.Windows.Forms.Button buttonForwards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGoHome;
        private System.Windows.Forms.TextBox textBox1;
    }
}
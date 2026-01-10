
namespace computerScienceNEA
{
    partial class FormGameRR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameRR));
            this.buttonShoot = new System.Windows.Forms.Button();
            this.buttonGoHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHighScore = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonShoot
            // 
            this.buttonShoot.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShoot.Location = new System.Drawing.Point(110, 268);
            this.buttonShoot.Name = "buttonShoot";
            this.buttonShoot.Size = new System.Drawing.Size(158, 37);
            this.buttonShoot.TabIndex = 11;
            this.buttonShoot.Text = "Shoot The Gun";
            this.buttonShoot.UseVisualStyleBackColor = true;
            this.buttonShoot.Click += new System.EventHandler(this.buttonShoot_Click);
            // 
            // buttonGoHome
            // 
            this.buttonGoHome.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoHome.Location = new System.Drawing.Point(225, 408);
            this.buttonGoHome.Name = "buttonGoHome";
            this.buttonGoHome.Size = new System.Drawing.Size(158, 37);
            this.buttonGoHome.TabIndex = 14;
            this.buttonGoHome.Text = "Go back to home";
            this.buttonGoHome.UseVisualStyleBackColor = true;
            this.buttonGoHome.Click += new System.EventHandler(this.buttonGoHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Welcome to Russian Roulette";
            // 
            // labelHighScore
            // 
            this.labelHighScore.AutoSize = true;
            this.labelHighScore.Location = new System.Drawing.Point(147, 239);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(78, 13);
            this.labelHighScore.TabIndex = 26;
            this.labelHighScore.Text = "High Score: 00";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 53);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(377, 147);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(165, 330);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(50, 13);
            this.labelScore.TabIndex = 23;
            this.labelScore.Text = "Score: 0 ";
            // 
            // FormGameRR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 455);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGoHome);
            this.Controls.Add(this.buttonShoot);
            this.Name = "FormGameRR";
            this.Text = "FormGameRR";
            this.Load += new System.EventHandler(this.FormGameRR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShoot;
        private System.Windows.Forms.Button buttonGoHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHighScore;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelScore;
    }
}

namespace computerScienceNEA
{
    partial class FormGameBowling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameBowling));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGoHome = new System.Windows.Forms.Button();
            this.buttonRoll = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelLives = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelHighScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Welcome to Bowling";
            // 
            // buttonGoHome
            // 
            this.buttonGoHome.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoHome.Location = new System.Drawing.Point(228, 433);
            this.buttonGoHome.Name = "buttonGoHome";
            this.buttonGoHome.Size = new System.Drawing.Size(158, 37);
            this.buttonGoHome.TabIndex = 17;
            this.buttonGoHome.Text = "Go back to home page";
            this.buttonGoHome.UseVisualStyleBackColor = true;
            this.buttonGoHome.Click += new System.EventHandler(this.buttonGoHome_Click);
            // 
            // buttonRoll
            // 
            this.buttonRoll.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRoll.Location = new System.Drawing.Point(113, 285);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(158, 37);
            this.buttonRoll.TabIndex = 16;
            this.buttonRoll.Text = "Roll the ball";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.buttonRoll_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(81, 384);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(47, 13);
            this.labelScore.TabIndex = 19;
            this.labelScore.Text = "Score: 0";
            // 
            // labelLives
            // 
            this.labelLives.AutoSize = true;
            this.labelLives.Location = new System.Drawing.Point(228, 384);
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(97, 13);
            this.labelLives.TabIndex = 20;
            this.labelLives.Text = "Lives Remaining: 2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 79);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(377, 119);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // labelHighScore
            // 
            this.labelHighScore.AutoSize = true;
            this.labelHighScore.Location = new System.Drawing.Point(149, 232);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(78, 13);
            this.labelHighScore.TabIndex = 22;
            this.labelHighScore.Text = "High Score: 00";
            // 
            // FormGameBowling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 480);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelLives);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGoHome);
            this.Controls.Add(this.buttonRoll);
            this.Name = "FormGameBowling";
            this.Text = "FormGameBowling";
            this.Load += new System.EventHandler(this.FormGameBowling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGoHome;
        private System.Windows.Forms.Button buttonRoll;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelLives;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelHighScore;
    }
}
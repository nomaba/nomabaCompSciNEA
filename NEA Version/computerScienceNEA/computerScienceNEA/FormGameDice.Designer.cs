
namespace computerScienceNEA
{
    partial class FormGameDice
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
            this.buttonRollOneDice = new System.Windows.Forms.Button();
            this.buttonRollTwoDice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGoHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRollOneDice
            // 
            this.buttonRollOneDice.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRollOneDice.Location = new System.Drawing.Point(146, 69);
            this.buttonRollOneDice.Name = "buttonRollOneDice";
            this.buttonRollOneDice.Size = new System.Drawing.Size(158, 37);
            this.buttonRollOneDice.TabIndex = 10;
            this.buttonRollOneDice.Text = "One Dice";
            this.buttonRollOneDice.UseVisualStyleBackColor = true;
            this.buttonRollOneDice.Click += new System.EventHandler(this.buttonRollOneDice_Click);
            // 
            // buttonRollTwoDice
            // 
            this.buttonRollTwoDice.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRollTwoDice.Location = new System.Drawing.Point(146, 112);
            this.buttonRollTwoDice.Name = "buttonRollTwoDice";
            this.buttonRollTwoDice.Size = new System.Drawing.Size(158, 37);
            this.buttonRollTwoDice.TabIndex = 11;
            this.buttonRollTwoDice.Text = "Two Dice";
            this.buttonRollTwoDice.UseVisualStyleBackColor = true;
            this.buttonRollTwoDice.Click += new System.EventHandler(this.buttonRollTwoDice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "How many dice do you want to roll";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonGoHome
            // 
            this.buttonGoHome.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoHome.Location = new System.Drawing.Point(285, 252);
            this.buttonGoHome.Name = "buttonGoHome";
            this.buttonGoHome.Size = new System.Drawing.Size(158, 37);
            this.buttonGoHome.TabIndex = 13;
            this.buttonGoHome.Text = "Go back to home page";
            this.buttonGoHome.UseVisualStyleBackColor = true;
            this.buttonGoHome.Click += new System.EventHandler(this.buttonGoHome_Click);
            // 
            // FormGameDice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 301);
            this.Controls.Add(this.buttonGoHome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRollTwoDice);
            this.Controls.Add(this.buttonRollOneDice);
            this.Name = "FormGameDice";
            this.Text = "FormGameDice";
            this.Load += new System.EventHandler(this.FormGameDice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRollOneDice;
        private System.Windows.Forms.Button buttonRollTwoDice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGoHome;
    }
}
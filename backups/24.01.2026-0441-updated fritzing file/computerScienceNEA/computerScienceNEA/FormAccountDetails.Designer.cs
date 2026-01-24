
namespace computerScienceNEA
{
    partial class FormAccountDetails
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
            this.buttonGoHome = new System.Windows.Forms.Button();
            this.labelNameFirst = new System.Windows.Forms.Label();
            this.labelNameLast = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelDOB = new System.Windows.Forms.Label();
            this.labelFavColour = new System.Windows.Forms.Label();
            this.labelFavFood = new System.Windows.Forms.Label();
            this.labelFavGame = new System.Windows.Forms.Label();
            this.labelLV = new System.Windows.Forms.Label();
            this.labelHighScoreRR = new System.Windows.Forms.Label();
            this.labelHighScoreBowling = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGoHome
            // 
            this.buttonGoHome.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoHome.Location = new System.Drawing.Point(12, 401);
            this.buttonGoHome.Name = "buttonGoHome";
            this.buttonGoHome.Size = new System.Drawing.Size(158, 37);
            this.buttonGoHome.TabIndex = 30;
            this.buttonGoHome.Text = "Go back to home page";
            this.buttonGoHome.UseVisualStyleBackColor = true;
            this.buttonGoHome.Click += new System.EventHandler(this.buttonGoHome_Click);
            // 
            // labelNameFirst
            // 
            this.labelNameFirst.AutoSize = true;
            this.labelNameFirst.Location = new System.Drawing.Point(37, 74);
            this.labelNameFirst.Name = "labelNameFirst";
            this.labelNameFirst.Size = new System.Drawing.Size(63, 13);
            this.labelNameFirst.TabIndex = 31;
            this.labelNameFirst.Text = "First Name: ";
            // 
            // labelNameLast
            // 
            this.labelNameLast.AutoSize = true;
            this.labelNameLast.Location = new System.Drawing.Point(36, 99);
            this.labelNameLast.Name = "labelNameLast";
            this.labelNameLast.Size = new System.Drawing.Size(64, 13);
            this.labelNameLast.TabIndex = 32;
            this.labelNameLast.Text = "Last Name: ";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(37, 127);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(61, 13);
            this.labelUsername.TabIndex = 33;
            this.labelUsername.Text = "Username: ";
            // 
            // labelDOB
            // 
            this.labelDOB.AutoSize = true;
            this.labelDOB.Location = new System.Drawing.Point(36, 156);
            this.labelDOB.Name = "labelDOB";
            this.labelDOB.Size = new System.Drawing.Size(71, 13);
            this.labelDOB.TabIndex = 34;
            this.labelDOB.Text = "Date of birth: ";
            // 
            // labelFavColour
            // 
            this.labelFavColour.AutoSize = true;
            this.labelFavColour.Location = new System.Drawing.Point(36, 207);
            this.labelFavColour.Name = "labelFavColour";
            this.labelFavColour.Size = new System.Drawing.Size(89, 13);
            this.labelFavColour.TabIndex = 35;
            this.labelFavColour.Text = "Favourite colour: ";
            // 
            // labelFavFood
            // 
            this.labelFavFood.AutoSize = true;
            this.labelFavFood.Location = new System.Drawing.Point(36, 234);
            this.labelFavFood.Name = "labelFavFood";
            this.labelFavFood.Size = new System.Drawing.Size(84, 13);
            this.labelFavFood.TabIndex = 36;
            this.labelFavFood.Text = "Favourite Food: ";
            // 
            // labelFavGame
            // 
            this.labelFavGame.AutoSize = true;
            this.labelFavGame.Location = new System.Drawing.Point(37, 263);
            this.labelFavGame.Name = "labelFavGame";
            this.labelFavGame.Size = new System.Drawing.Size(86, 13);
            this.labelFavGame.TabIndex = 37;
            this.labelFavGame.Text = "Favourite game: ";
            // 
            // labelLV
            // 
            this.labelLV.AutoSize = true;
            this.labelLV.Location = new System.Drawing.Point(37, 180);
            this.labelLV.Name = "labelLV";
            this.labelLV.Size = new System.Drawing.Size(26, 13);
            this.labelLV.TabIndex = 38;
            this.labelLV.Text = "LV: ";
            // 
            // labelHighScoreRR
            // 
            this.labelHighScoreRR.AutoSize = true;
            this.labelHighScoreRR.Location = new System.Drawing.Point(34, 306);
            this.labelHighScoreRR.Name = "labelHighScoreRR";
            this.labelHighScoreRR.Size = new System.Drawing.Size(173, 13);
            this.labelHighScoreRR.TabIndex = 39;
            this.labelHighScoreRR.Text = "Highest score in Russian Roulette: \r\n";
            // 
            // labelHighScoreBowling
            // 
            this.labelHighScoreBowling.AutoSize = true;
            this.labelHighScoreBowling.Location = new System.Drawing.Point(34, 333);
            this.labelHighScoreBowling.Name = "labelHighScoreBowling";
            this.labelHighScoreBowling.Size = new System.Drawing.Size(158, 13);
            this.labelHighScoreBowling.TabIndex = 40;
            this.labelHighScoreBowling.Text = "Highest score in Bowling game: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 32);
            this.label11.TabIndex = 41;
            this.label11.Text = "Account Details";
            // 
            // FormAccountDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelHighScoreBowling);
            this.Controls.Add(this.labelHighScoreRR);
            this.Controls.Add(this.labelLV);
            this.Controls.Add(this.labelFavGame);
            this.Controls.Add(this.labelFavFood);
            this.Controls.Add(this.labelFavColour);
            this.Controls.Add(this.labelDOB);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelNameLast);
            this.Controls.Add(this.labelNameFirst);
            this.Controls.Add(this.buttonGoHome);
            this.Name = "FormAccountDetails";
            this.Text = "FormAccountDetails";
            this.Load += new System.EventHandler(this.FormAccountDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGoHome;
        private System.Windows.Forms.Label labelNameFirst;
        private System.Windows.Forms.Label labelNameLast;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelDOB;
        private System.Windows.Forms.Label labelFavColour;
        private System.Windows.Forms.Label labelFavFood;
        private System.Windows.Forms.Label labelFavGame;
        private System.Windows.Forms.Label labelLV;
        private System.Windows.Forms.Label labelHighScoreRR;
        private System.Windows.Forms.Label labelHighScoreBowling;
        private System.Windows.Forms.Label label11;
    }
}
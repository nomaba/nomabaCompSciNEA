
namespace computerScienceNEA
{
    partial class FormGamePet
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGamePet));
            this.buttonGoHome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLV = new System.Windows.Forms.Label();
            this.timer1Second = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGoHome
            // 
            this.buttonGoHome.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoHome.Location = new System.Drawing.Point(118, 327);
            this.buttonGoHome.Name = "buttonGoHome";
            this.buttonGoHome.Size = new System.Drawing.Size(158, 37);
            this.buttonGoHome.TabIndex = 32;
            this.buttonGoHome.Text = "Go back to home page";
            this.buttonGoHome.UseVisualStyleBackColor = true;
            this.buttonGoHome.Click += new System.EventHandler(this.buttonGoHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 32);
            this.label1.TabIndex = 30;
            this.label1.Text = "Welcome to Pet ";
            // 
            // labelLV
            // 
            this.labelLV.AutoSize = true;
            this.labelLV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLV.Location = new System.Drawing.Point(173, 253);
            this.labelLV.Name = "labelLV";
            this.labelLV.Size = new System.Drawing.Size(34, 18);
            this.labelLV.TabIndex = 33;
            this.labelLV.Text = "LV: ";
            // 
            // timer1Second
            // 
            this.timer1Second.Interval = 1000;
            this.timer1Second.Tick += new System.EventHandler(this.timer1Second_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 105);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(377, 105);
            this.textBox1.TabIndex = 34;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // FormGamePet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 417);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelLV);
            this.Controls.Add(this.buttonGoHome);
            this.Controls.Add(this.label1);
            this.Name = "FormGamePet";
            this.Text = "FormGamePet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGamePet_FormClosing);
            this.Load += new System.EventHandler(this.FormGamePet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGoHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLV;
        private System.Windows.Forms.Timer timer1Second;
        private System.Windows.Forms.TextBox textBox1;
    }
}
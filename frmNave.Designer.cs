namespace pryLab3
{
    partial class frmNave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNave));
            this.pctBala = new System.Windows.Forms.PictureBox();
            this.pctEnemigos = new System.Windows.Forms.PictureBox();
            this.pctNave = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEnemigos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNave)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBala
            // 
            this.pctBala.Image = global::pryLab3.Properties.Resources.bala;
            this.pctBala.Location = new System.Drawing.Point(302, 116);
            this.pctBala.Name = "pctBala";
            this.pctBala.Size = new System.Drawing.Size(100, 49);
            this.pctBala.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBala.TabIndex = 2;
            this.pctBala.TabStop = false;
            this.pctBala.Visible = false;
            // 
            // pctEnemigos
            // 
            this.pctEnemigos.Image = global::pryLab3.Properties.Resources.enemigo;
            this.pctEnemigos.Location = new System.Drawing.Point(318, 46);
            this.pctEnemigos.Name = "pctEnemigos";
            this.pctEnemigos.Size = new System.Drawing.Size(63, 32);
            this.pctEnemigos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctEnemigos.TabIndex = 1;
            this.pctEnemigos.TabStop = false;
            this.pctEnemigos.Visible = false;
            // 
            // pctNave
            // 
            this.pctNave.Image = ((System.Drawing.Image)(resources.GetObject("pctNave.Image")));
            this.pctNave.Location = new System.Drawing.Point(273, 327);
            this.pctNave.Name = "pctNave";
            this.pctNave.Size = new System.Drawing.Size(140, 93);
            this.pctNave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctNave.TabIndex = 0;
            this.pctNave.TabStop = false;
            this.pctNave.Visible = false;
            this.pctNave.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmNave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pctBala);
            this.Controls.Add(this.pctEnemigos);
            this.Controls.Add(this.pctNave);
            this.Name = "frmNave";
            this.Text = "frmNave";
            ((System.ComponentModel.ISupportInitialize)(this.pctBala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctEnemigos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctNave;
        private System.Windows.Forms.PictureBox pctEnemigos;
        private System.Windows.Forms.PictureBox pctBala;
    }
}
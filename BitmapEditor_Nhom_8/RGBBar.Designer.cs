namespace BitmapEditor_Nhom_8
{
    partial class RGBBar
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
            this.trkBarR = new System.Windows.Forms.TrackBar();
            this.trkBarG = new System.Windows.Forms.TrackBar();
            this.trkBarB = new System.Windows.Forms.TrackBar();
            this.lblR = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarB)).BeginInit();
            this.SuspendLayout();
            // 
            // trkBarR
            // 
            this.trkBarR.Location = new System.Drawing.Point(97, 18);
            this.trkBarR.Maximum = 20;
            this.trkBarR.Name = "trkBarR";
            this.trkBarR.Size = new System.Drawing.Size(235, 45);
            this.trkBarR.TabIndex = 0;
            this.trkBarR.Value = 10;
            this.trkBarR.Scroll += new System.EventHandler(this.trkBarR_Scroll);
            // 
            // trkBarG
            // 
            this.trkBarG.Location = new System.Drawing.Point(97, 72);
            this.trkBarG.Maximum = 20;
            this.trkBarG.Name = "trkBarG";
            this.trkBarG.Size = new System.Drawing.Size(235, 45);
            this.trkBarG.TabIndex = 1;
            this.trkBarG.Value = 10;
            this.trkBarG.Scroll += new System.EventHandler(this.trkBarG_Scroll);
            // 
            // trkBarB
            // 
            this.trkBarB.Location = new System.Drawing.Point(97, 123);
            this.trkBarB.Maximum = 20;
            this.trkBarB.Name = "trkBarB";
            this.trkBarB.Size = new System.Drawing.Size(235, 45);
            this.trkBarB.TabIndex = 2;
            this.trkBarB.Value = 10;
            this.trkBarB.Scroll += new System.EventHandler(this.trkBarB_Scroll);
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.ForeColor = System.Drawing.Color.Red;
            this.lblR.Location = new System.Drawing.Point(12, 18);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(57, 20);
            this.lblR.TabIndex = 3;
            this.lblR.Text = "R: 0%";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblG.Location = new System.Drawing.Point(12, 72);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(58, 20);
            this.lblG.TabIndex = 4;
            this.lblG.Text = "G: 0%";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB.ForeColor = System.Drawing.Color.Blue;
            this.lblB.Location = new System.Drawing.Point(12, 123);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(56, 20);
            this.lblB.TabIndex = 5;
            this.lblB.Text = "B: 0%";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(337, 40);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(338, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RGBBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 178);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblG);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.trkBarB);
            this.Controls.Add(this.trkBarG);
            this.Controls.Add(this.trkBarR);
            this.Name = "RGBBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RBGBar";
            ((System.ComponentModel.ISupportInitialize)(this.trkBarR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkBarB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trkBarR;
        private System.Windows.Forms.TrackBar trkBarG;
        private System.Windows.Forms.TrackBar trkBarB;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
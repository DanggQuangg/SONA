namespace SONA
{
    partial class PlaylistChoice
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPlaylistName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbPlaylistName
            // 
            this.lbPlaylistName.BackColor = System.Drawing.Color.Transparent;
            this.lbPlaylistName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlaylistName.ForeColor = System.Drawing.Color.White;
            this.lbPlaylistName.Location = new System.Drawing.Point(55, 14);
            this.lbPlaylistName.Name = "lbPlaylistName";
            this.lbPlaylistName.Size = new System.Drawing.Size(75, 25);
            this.lbPlaylistName.TabIndex = 4;
            this.lbPlaylistName.Text = "Attention";
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::SONA.Properties.Resources.add_circle;
            this.btnAdd.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAdd.Location = new System.Drawing.Point(9, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 34);
            this.btnAdd.TabIndex = 1;
            // 
            // PlaylistChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.Controls.Add(this.lbPlaylistName);
            this.Controls.Add(this.btnAdd);
            this.Name = "PlaylistChoice";
            this.Size = new System.Drawing.Size(260, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbPlaylistName;
    }
}

namespace NetsphereScnTool.Forms
{
    partial class TextureChangeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureChangeView));
            this.textureNameLabel = new System.Windows.Forms.Label();
            this.applyTexture = new System.Windows.Forms.Button();
            this.txts = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textureNameLabel
            // 
            this.textureNameLabel.AutoSize = true;
            this.textureNameLabel.Location = new System.Drawing.Point(12, 31);
            this.textureNameLabel.Name = "textureNameLabel";
            this.textureNameLabel.Size = new System.Drawing.Size(129, 21);
            this.textureNameLabel.TabIndex = 0;
            this.textureNameLabel.Text = "Texture Name(s): ";
            // 
            // applyTexture
            // 
            this.applyTexture.Location = new System.Drawing.Point(16, 141);
            this.applyTexture.Name = "applyTexture";
            this.applyTexture.Size = new System.Drawing.Size(88, 37);
            this.applyTexture.TabIndex = 1;
            this.applyTexture.Text = "Apply";
            this.applyTexture.UseVisualStyleBackColor = true;
            this.applyTexture.Click += new System.EventHandler(this.ApplyTexture_Click);
            // 
            // txts
            // 
            this.txts.Location = new System.Drawing.Point(147, 28);
            this.txts.Name = "txts";
            this.txts.Size = new System.Drawing.Size(134, 150);
            this.txts.TabIndex = 3;
            this.txts.Text = "";
            // 
            // TextureChangeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 219);
            this.Controls.Add(this.txts);
            this.Controls.Add(this.applyTexture);
            this.Controls.Add(this.textureNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TextureChangeView";
            this.Text = "TextureChangeView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textureNameLabel;
        private System.Windows.Forms.Button applyTexture;
        private System.Windows.Forms.RichTextBox txts;
    }
}
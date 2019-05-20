namespace NetsphereScnTool.Forms
{
    partial class AnimationEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationEditView));
            this.txt = new System.Windows.Forms.RichTextBox();
            this.applyAnimation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(12, 12);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(550, 200);
            this.txt.TabIndex = 0;
            this.txt.Text = "";
            // 
            // applyAnimation
            // 
            this.applyAnimation.Location = new System.Drawing.Point(250, 223);
            this.applyAnimation.Name = "applyAnimation";
            this.applyAnimation.Size = new System.Drawing.Size(90, 30);
            this.applyAnimation.TabIndex = 1;
            this.applyAnimation.Text = "Apply";
            this.applyAnimation.UseVisualStyleBackColor = true;
            this.applyAnimation.Click += new System.EventHandler(this.ApplyAnimation_Click);
            // 
            // AnimationEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(575, 265);
            this.Controls.Add(this.applyAnimation);
            this.Controls.Add(this.txt);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AnimationEditView";
            this.Text = "AnimationEditView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt;
        private System.Windows.Forms.Button applyAnimation;
    }
}
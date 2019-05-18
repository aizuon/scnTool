namespace NetsphereScnTool.Forms
{
    partial class ImportOBJView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportOBJView));
            this.sceneNameLabel = new System.Windows.Forms.Label();
            this.sceneSubnameLabel = new System.Windows.Forms.Label();
            this.textureNameLabel = new System.Windows.Forms.Label();
            this.sceneName = new System.Windows.Forms.TextBox();
            this.sceneSubname = new System.Windows.Forms.TextBox();
            this.textureName = new System.Windows.Forms.TextBox();
            this.setNames = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sceneNameLabel
            // 
            this.sceneNameLabel.AutoSize = true;
            this.sceneNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sceneNameLabel.Location = new System.Drawing.Point(39, 45);
            this.sceneNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sceneNameLabel.Name = "sceneNameLabel";
            this.sceneNameLabel.Size = new System.Drawing.Size(104, 21);
            this.sceneNameLabel.TabIndex = 0;
            this.sceneNameLabel.Text = "Scene Name: ";
            // 
            // sceneSubnameLabel
            // 
            this.sceneSubnameLabel.AutoSize = true;
            this.sceneSubnameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sceneSubnameLabel.Location = new System.Drawing.Point(39, 95);
            this.sceneSubnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sceneSubnameLabel.Name = "sceneSubnameLabel";
            this.sceneSubnameLabel.Size = new System.Drawing.Size(128, 21);
            this.sceneSubnameLabel.TabIndex = 1;
            this.sceneSubnameLabel.Text = "Scene Subname: ";
            // 
            // textureNameLabel
            // 
            this.textureNameLabel.AutoSize = true;
            this.textureNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textureNameLabel.Location = new System.Drawing.Point(39, 149);
            this.textureNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textureNameLabel.Name = "textureNameLabel";
            this.textureNameLabel.Size = new System.Drawing.Size(112, 21);
            this.textureNameLabel.TabIndex = 2;
            this.textureNameLabel.Text = "Texture Name: ";
            // 
            // sceneName
            // 
            this.sceneName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sceneName.Location = new System.Drawing.Point(267, 45);
            this.sceneName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sceneName.Name = "sceneName";
            this.sceneName.Size = new System.Drawing.Size(253, 25);
            this.sceneName.TabIndex = 3;
            // 
            // sceneSubname
            // 
            this.sceneSubname.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sceneSubname.Location = new System.Drawing.Point(267, 95);
            this.sceneSubname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sceneSubname.Name = "sceneSubname";
            this.sceneSubname.Size = new System.Drawing.Size(253, 25);
            this.sceneSubname.TabIndex = 4;
            // 
            // textureName
            // 
            this.textureName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textureName.Location = new System.Drawing.Point(267, 149);
            this.textureName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textureName.Name = "textureName";
            this.textureName.Size = new System.Drawing.Size(253, 25);
            this.textureName.TabIndex = 5;
            // 
            // setNames
            // 
            this.setNames.Location = new System.Drawing.Point(225, 202);
            this.setNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.setNames.Name = "setNames";
            this.setNames.Size = new System.Drawing.Size(112, 40);
            this.setNames.TabIndex = 6;
            this.setNames.Text = "Apply";
            this.setNames.UseVisualStyleBackColor = true;
            this.setNames.Click += new System.EventHandler(this.SetNames_Click);
            // 
            // ImportOBJView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 260);
            this.Controls.Add(this.setNames);
            this.Controls.Add(this.textureName);
            this.Controls.Add(this.sceneSubname);
            this.Controls.Add(this.sceneName);
            this.Controls.Add(this.textureNameLabel);
            this.Controls.Add(this.sceneSubnameLabel);
            this.Controls.Add(this.sceneNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImportOBJView";
            this.Text = "Import OBJ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sceneNameLabel;
        private System.Windows.Forms.Label sceneSubnameLabel;
        private System.Windows.Forms.Label textureNameLabel;
        private System.Windows.Forms.TextBox sceneName;
        private System.Windows.Forms.TextBox sceneSubname;
        private System.Windows.Forms.TextBox textureName;
        private System.Windows.Forms.Button setNames;
    }
}
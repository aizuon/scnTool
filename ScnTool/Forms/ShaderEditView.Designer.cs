namespace NetsphereScnTool.Forms
{
    partial class ShaderEditView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShaderEditView));
            this.applyShader = new System.Windows.Forms.Button();
            this.Cutout = new System.Windows.Forms.CheckBox();
            this.NoCulling = new System.Windows.Forms.CheckBox();
            this.Billboard = new System.Windows.Forms.CheckBox();
            this.Flare = new System.Windows.Forms.CheckBox();
            this.ZWriteOff = new System.Windows.Forms.CheckBox();
            this.Shader = new System.Windows.Forms.CheckBox();
            this.NoFog = new System.Windows.Forms.CheckBox();
            this.NoMipmap = new System.Windows.Forms.CheckBox();
            this.Shadow = new System.Windows.Forms.CheckBox();
            this.Water = new System.Windows.Forms.CheckBox();
            this.Distortion = new System.Windows.Forms.CheckBox();
            this.Dark = new System.Windows.Forms.CheckBox();
            this.None = new System.Windows.Forms.CheckBox();
            this.NoLight = new System.Windows.Forms.CheckBox();
            this.Transparent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // applyShader
            // 
            this.applyShader.Location = new System.Drawing.Point(100, 268);
            this.applyShader.Name = "applyShader";
            this.applyShader.Size = new System.Drawing.Size(81, 30);
            this.applyShader.TabIndex = 1;
            this.applyShader.Text = "Apply";
            this.applyShader.UseVisualStyleBackColor = true;
            this.applyShader.Click += new System.EventHandler(this.ApplyShader_Click);
            // 
            // Cutout
            // 
            this.Cutout.AutoSize = true;
            this.Cutout.Location = new System.Drawing.Point(186, 43);
            this.Cutout.Name = "Cutout";
            this.Cutout.Size = new System.Drawing.Size(76, 25);
            this.Cutout.TabIndex = 3;
            this.Cutout.Text = "Cutout";
            this.Cutout.UseVisualStyleBackColor = true;
            this.Cutout.CheckedChanged += new System.EventHandler(this.Cutout_CheckedChanged);
            // 
            // NoCulling
            // 
            this.NoCulling.AutoSize = true;
            this.NoCulling.Location = new System.Drawing.Point(12, 74);
            this.NoCulling.Name = "NoCulling";
            this.NoCulling.Size = new System.Drawing.Size(99, 25);
            this.NoCulling.TabIndex = 4;
            this.NoCulling.Text = "NoCulling";
            this.NoCulling.UseVisualStyleBackColor = true;
            this.NoCulling.CheckedChanged += new System.EventHandler(this.NoCulling_CheckedChanged);
            // 
            // Billboard
            // 
            this.Billboard.AutoSize = true;
            this.Billboard.Location = new System.Drawing.Point(186, 74);
            this.Billboard.Name = "Billboard";
            this.Billboard.Size = new System.Drawing.Size(91, 25);
            this.Billboard.TabIndex = 5;
            this.Billboard.Text = "Billboard";
            this.Billboard.UseVisualStyleBackColor = true;
            this.Billboard.CheckedChanged += new System.EventHandler(this.Billboard_CheckedChanged);
            // 
            // Flare
            // 
            this.Flare.AutoSize = true;
            this.Flare.Location = new System.Drawing.Point(12, 105);
            this.Flare.Name = "Flare";
            this.Flare.Size = new System.Drawing.Size(63, 25);
            this.Flare.TabIndex = 6;
            this.Flare.Text = "Flare";
            this.Flare.UseVisualStyleBackColor = true;
            this.Flare.CheckedChanged += new System.EventHandler(this.Flare_CheckedChanged);
            // 
            // ZWriteOff
            // 
            this.ZWriteOff.AutoSize = true;
            this.ZWriteOff.Location = new System.Drawing.Point(186, 105);
            this.ZWriteOff.Name = "ZWriteOff";
            this.ZWriteOff.Size = new System.Drawing.Size(98, 25);
            this.ZWriteOff.TabIndex = 7;
            this.ZWriteOff.Text = "ZWriteOff";
            this.ZWriteOff.UseVisualStyleBackColor = true;
            this.ZWriteOff.CheckedChanged += new System.EventHandler(this.ZWriteOff_CheckedChanged);
            // 
            // Shader
            // 
            this.Shader.AutoSize = true;
            this.Shader.Location = new System.Drawing.Point(12, 136);
            this.Shader.Name = "Shader";
            this.Shader.Size = new System.Drawing.Size(78, 25);
            this.Shader.TabIndex = 8;
            this.Shader.Text = "Shader";
            this.Shader.UseVisualStyleBackColor = true;
            this.Shader.CheckedChanged += new System.EventHandler(this.Shader_CheckedChanged);
            // 
            // NoFog
            // 
            this.NoFog.AutoSize = true;
            this.NoFog.Location = new System.Drawing.Point(186, 136);
            this.NoFog.Name = "NoFog";
            this.NoFog.Size = new System.Drawing.Size(76, 25);
            this.NoFog.TabIndex = 9;
            this.NoFog.Text = "NoFog";
            this.NoFog.UseVisualStyleBackColor = true;
            this.NoFog.CheckedChanged += new System.EventHandler(this.NoFog_CheckedChanged);
            // 
            // NoMipmap
            // 
            this.NoMipmap.AutoSize = true;
            this.NoMipmap.Location = new System.Drawing.Point(12, 167);
            this.NoMipmap.Name = "NoMipmap";
            this.NoMipmap.Size = new System.Drawing.Size(108, 25);
            this.NoMipmap.TabIndex = 10;
            this.NoMipmap.Text = "NoMipmap";
            this.NoMipmap.UseVisualStyleBackColor = true;
            this.NoMipmap.CheckedChanged += new System.EventHandler(this.NoMipmap_CheckedChanged);
            // 
            // Shadow
            // 
            this.Shadow.AutoSize = true;
            this.Shadow.Location = new System.Drawing.Point(186, 167);
            this.Shadow.Name = "Shadow";
            this.Shadow.Size = new System.Drawing.Size(85, 25);
            this.Shadow.TabIndex = 11;
            this.Shadow.Text = "Shadow";
            this.Shadow.UseVisualStyleBackColor = true;
            this.Shadow.CheckedChanged += new System.EventHandler(this.Shadow_CheckedChanged);
            // 
            // Water
            // 
            this.Water.AutoSize = true;
            this.Water.Location = new System.Drawing.Point(12, 198);
            this.Water.Name = "Water";
            this.Water.Size = new System.Drawing.Size(70, 25);
            this.Water.TabIndex = 12;
            this.Water.Text = "Water";
            this.Water.UseVisualStyleBackColor = true;
            this.Water.CheckedChanged += new System.EventHandler(this.Water_CheckedChanged);
            // 
            // Distortion
            // 
            this.Distortion.AutoSize = true;
            this.Distortion.Location = new System.Drawing.Point(186, 198);
            this.Distortion.Name = "Distortion";
            this.Distortion.Size = new System.Drawing.Size(98, 25);
            this.Distortion.TabIndex = 13;
            this.Distortion.Text = "Distortion";
            this.Distortion.UseVisualStyleBackColor = true;
            this.Distortion.CheckedChanged += new System.EventHandler(this.Distortion_CheckedChanged);
            // 
            // Dark
            // 
            this.Dark.AutoSize = true;
            this.Dark.Location = new System.Drawing.Point(110, 223);
            this.Dark.Name = "Dark";
            this.Dark.Size = new System.Drawing.Size(62, 25);
            this.Dark.TabIndex = 14;
            this.Dark.Text = "Dark";
            this.Dark.UseVisualStyleBackColor = true;
            this.Dark.CheckedChanged += new System.EventHandler(this.Dark_CheckedChanged);
            // 
            // None
            // 
            this.None.AutoSize = true;
            this.None.Location = new System.Drawing.Point(12, 12);
            this.None.Name = "None";
            this.None.Size = new System.Drawing.Size(67, 25);
            this.None.TabIndex = 15;
            this.None.Text = "None";
            this.None.UseVisualStyleBackColor = true;
            this.None.CheckedChanged += new System.EventHandler(this.None_CheckedChanged);
            // 
            // NoLight
            // 
            this.NoLight.AutoSize = true;
            this.NoLight.Location = new System.Drawing.Point(186, 12);
            this.NoLight.Name = "NoLight";
            this.NoLight.Size = new System.Drawing.Size(85, 25);
            this.NoLight.TabIndex = 16;
            this.NoLight.Text = "NoLight";
            this.NoLight.UseVisualStyleBackColor = true;
            this.NoLight.CheckedChanged += new System.EventHandler(this.NoLight_CheckedChanged);
            // 
            // Transparent
            // 
            this.Transparent.AutoSize = true;
            this.Transparent.Location = new System.Drawing.Point(12, 43);
            this.Transparent.Name = "Transparent";
            this.Transparent.Size = new System.Drawing.Size(111, 25);
            this.Transparent.TabIndex = 17;
            this.Transparent.Text = "Transparent";
            this.Transparent.UseVisualStyleBackColor = true;
            this.Transparent.CheckedChanged += new System.EventHandler(this.Transparent_CheckedChanged);
            // 
            // ShaderEditView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 319);
            this.Controls.Add(this.Transparent);
            this.Controls.Add(this.NoLight);
            this.Controls.Add(this.None);
            this.Controls.Add(this.Dark);
            this.Controls.Add(this.Distortion);
            this.Controls.Add(this.Water);
            this.Controls.Add(this.Shadow);
            this.Controls.Add(this.NoMipmap);
            this.Controls.Add(this.NoFog);
            this.Controls.Add(this.Shader);
            this.Controls.Add(this.ZWriteOff);
            this.Controls.Add(this.Flare);
            this.Controls.Add(this.Billboard);
            this.Controls.Add(this.NoCulling);
            this.Controls.Add(this.Cutout);
            this.Controls.Add(this.applyShader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShaderEditView";
            this.Text = "ShaderEditView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button applyShader;
        private System.Windows.Forms.CheckBox Cutout;
        private System.Windows.Forms.CheckBox NoCulling;
        private System.Windows.Forms.CheckBox Billboard;
        private System.Windows.Forms.CheckBox Flare;
        private System.Windows.Forms.CheckBox ZWriteOff;
        private System.Windows.Forms.CheckBox Shader;
        private System.Windows.Forms.CheckBox NoFog;
        private System.Windows.Forms.CheckBox NoMipmap;
        private System.Windows.Forms.CheckBox Shadow;
        private System.Windows.Forms.CheckBox Water;
        private System.Windows.Forms.CheckBox Distortion;
        private System.Windows.Forms.CheckBox Dark;
        private System.Windows.Forms.CheckBox None;
        private System.Windows.Forms.CheckBox NoLight;
        private System.Windows.Forms.CheckBox Transparent;
    }
}
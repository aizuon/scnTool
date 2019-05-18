namespace NetsphereScnTool.Forms
{
  partial class ScenarioView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenarioView));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_new_map = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_open_map = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_close_map = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_save = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_save_map = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_replace_map = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_undo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_redo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_delete_scene = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_extract_scene = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_import_scene = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_export_obj = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_import_obj = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_replace_model = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editShaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTextureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.context_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_delete_scene = new System.Windows.Forms.ToolStripMenuItem();
            this.context_export_scene = new System.Windows.Forms.ToolStripMenuItem();
            this.context_import_scene = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.context_export_model_obj = new System.Windows.Forms.ToolStripMenuItem();
            this.importOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.editShaderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.lbl_search = new System.Windows.Forms.Label();
            this.data_view = new System.Windows.Forms.DataGridView();
            this.col_img = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_subname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.drawMeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.drawMeshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            this.context_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_view)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file,
            this.menu_edit});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(776, 28);
            this.menu.TabIndex = 0;
            // 
            // menu_file
            // 
            this.menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_new_map,
            this.menu_open_map,
            this.menu_close_map,
            this.menu_save,
            this.menu_exit});
            this.menu_file.Image = ((System.Drawing.Image)(resources.GetObject("menu_file.Image")));
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(57, 24);
            this.menu_file.Text = "File";
            // 
            // menu_new_map
            // 
            this.menu_new_map.Image = ((System.Drawing.Image)(resources.GetObject("menu_new_map.Image")));
            this.menu_new_map.Name = "menu_new_map";
            this.menu_new_map.Size = new System.Drawing.Size(124, 22);
            this.menu_new_map.Text = "New scn";
            this.menu_new_map.Click += new System.EventHandler(this.menu_new_map_Click);
            // 
            // menu_open_map
            // 
            this.menu_open_map.Image = ((System.Drawing.Image)(resources.GetObject("menu_open_map.Image")));
            this.menu_open_map.Name = "menu_open_map";
            this.menu_open_map.Size = new System.Drawing.Size(124, 22);
            this.menu_open_map.Text = "Open scn";
            this.menu_open_map.Click += new System.EventHandler(this.menu_open_map_Click);
            // 
            // menu_close_map
            // 
            this.menu_close_map.Enabled = false;
            this.menu_close_map.Image = ((System.Drawing.Image)(resources.GetObject("menu_close_map.Image")));
            this.menu_close_map.Name = "menu_close_map";
            this.menu_close_map.Size = new System.Drawing.Size(124, 22);
            this.menu_close_map.Text = "Close scn";
            this.menu_close_map.Click += new System.EventHandler(this.menu_close_map_Click);
            // 
            // menu_save
            // 
            this.menu_save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_save_map,
            this.menu_replace_map});
            this.menu_save.Enabled = false;
            this.menu_save.Image = ((System.Drawing.Image)(resources.GetObject("menu_save.Image")));
            this.menu_save.Name = "menu_save";
            this.menu_save.Size = new System.Drawing.Size(124, 22);
            this.menu_save.Text = "Save";
            // 
            // menu_save_map
            // 
            this.menu_save_map.Image = ((System.Drawing.Image)(resources.GetObject("menu_save_map.Image")));
            this.menu_save_map.Name = "menu_save_map";
            this.menu_save_map.Size = new System.Drawing.Size(196, 22);
            this.menu_save_map.Text = "Save Map (CTRL+S)";
            this.menu_save_map.Click += new System.EventHandler(this.menu_save_map_Click);
            // 
            // menu_replace_map
            // 
            this.menu_replace_map.Image = ((System.Drawing.Image)(resources.GetObject("menu_replace_map.Image")));
            this.menu_replace_map.Name = "menu_replace_map";
            this.menu_replace_map.Size = new System.Drawing.Size(196, 22);
            this.menu_replace_map.Text = "Replace Map (CTRL+R)";
            this.menu_replace_map.Click += new System.EventHandler(this.menu_replace_map_Click);
            // 
            // menu_exit
            // 
            this.menu_exit.Image = ((System.Drawing.Image)(resources.GetObject("menu_exit.Image")));
            this.menu_exit.Name = "menu_exit";
            this.menu_exit.Size = new System.Drawing.Size(124, 22);
            this.menu_exit.Text = "Exit";
            this.menu_exit.Click += new System.EventHandler(this.menu_exit_Click);
            // 
            // menu_edit
            // 
            this.menu_edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_undo,
            this.menu_redo,
            this.toolStripSeparator2,
            this.menu_delete_scene,
            this.menu_extract_scene,
            this.menu_import_scene,
            this.toolStripSeparator4,
            this.menu_export_obj,
            this.menu_import_obj,
            this.menu_replace_model,
            this.toolStripSeparator1,
            this.editShaderToolStripMenuItem,
            this.changeTextureToolStripMenuItem1,
            this.toolStripSeparator7,
            this.drawMeshToolStripMenuItem1});
            this.menu_edit.Enabled = false;
            this.menu_edit.Image = ((System.Drawing.Image)(resources.GetObject("menu_edit.Image")));
            this.menu_edit.Name = "menu_edit";
            this.menu_edit.Size = new System.Drawing.Size(59, 24);
            this.menu_edit.Text = "Edit";
            // 
            // menu_undo
            // 
            this.menu_undo.Enabled = false;
            this.menu_undo.Image = ((System.Drawing.Image)(resources.GetObject("menu_undo.Image")));
            this.menu_undo.Name = "menu_undo";
            this.menu_undo.Size = new System.Drawing.Size(197, 22);
            this.menu_undo.Text = "Undo (CTRL+Z)";
            this.menu_undo.Click += new System.EventHandler(this.menu_undo_Click);
            // 
            // menu_redo
            // 
            this.menu_redo.Enabled = false;
            this.menu_redo.Image = ((System.Drawing.Image)(resources.GetObject("menu_redo.Image")));
            this.menu_redo.Name = "menu_redo";
            this.menu_redo.Size = new System.Drawing.Size(197, 22);
            this.menu_redo.Text = "Redo (CTRL+Y)";
            this.menu_redo.Click += new System.EventHandler(this.menu_redo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(194, 6);
            // 
            // menu_delete_scene
            // 
            this.menu_delete_scene.Image = ((System.Drawing.Image)(resources.GetObject("menu_delete_scene.Image")));
            this.menu_delete_scene.Name = "menu_delete_scene";
            this.menu_delete_scene.Size = new System.Drawing.Size(197, 22);
            this.menu_delete_scene.Text = "Delete scene(s)";
            this.menu_delete_scene.Click += new System.EventHandler(this.menu_delete_scene_Click);
            // 
            // menu_extract_scene
            // 
            this.menu_extract_scene.Image = ((System.Drawing.Image)(resources.GetObject("menu_extract_scene.Image")));
            this.menu_extract_scene.Name = "menu_extract_scene";
            this.menu_extract_scene.Size = new System.Drawing.Size(197, 22);
            this.menu_extract_scene.Text = "Export scene(s)";
            this.menu_extract_scene.Click += new System.EventHandler(this.menu_extract_scene_Click);
            // 
            // menu_import_scene
            // 
            this.menu_import_scene.Image = ((System.Drawing.Image)(resources.GetObject("menu_import_scene.Image")));
            this.menu_import_scene.Name = "menu_import_scene";
            this.menu_import_scene.Size = new System.Drawing.Size(197, 22);
            this.menu_import_scene.Text = "Import scene(s)";
            this.menu_import_scene.Click += new System.EventHandler(this.menu_import_scene_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(194, 6);
            // 
            // menu_export_obj
            // 
            this.menu_export_obj.Image = ((System.Drawing.Image)(resources.GetObject("menu_export_obj.Image")));
            this.menu_export_obj.Name = "menu_export_obj";
            this.menu_export_obj.Size = new System.Drawing.Size(197, 22);
            this.menu_export_obj.Text = "Export model(s) as OBJ";
            this.menu_export_obj.Click += new System.EventHandler(this.menu_export_obj_Click);
            // 
            // menu_import_obj
            // 
            this.menu_import_obj.Image = ((System.Drawing.Image)(resources.GetObject("menu_import_obj.Image")));
            this.menu_import_obj.Name = "menu_import_obj";
            this.menu_import_obj.Size = new System.Drawing.Size(197, 22);
            this.menu_import_obj.Text = "Import OBJ(s) as model";
            this.menu_import_obj.Click += new System.EventHandler(this.menu_import_obj_Click);
            // 
            // menu_replace_model
            // 
            this.menu_replace_model.Image = ((System.Drawing.Image)(resources.GetObject("menu_replace_model.Image")));
            this.menu_replace_model.Name = "menu_replace_model";
            this.menu_replace_model.Size = new System.Drawing.Size(197, 22);
            this.menu_replace_model.Text = "Replace model";
            this.menu_replace_model.Click += new System.EventHandler(this.menu_replace_model_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // editShaderToolStripMenuItem
            // 
            this.editShaderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editShaderToolStripMenuItem.Image")));
            this.editShaderToolStripMenuItem.Name = "editShaderToolStripMenuItem";
            this.editShaderToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.editShaderToolStripMenuItem.Text = "Edit shader";
            this.editShaderToolStripMenuItem.Click += new System.EventHandler(this.EditShaderToolStripMenuItem_Click);
            // 
            // changeTextureToolStripMenuItem1
            // 
            this.changeTextureToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("changeTextureToolStripMenuItem1.Image")));
            this.changeTextureToolStripMenuItem1.Name = "changeTextureToolStripMenuItem1";
            this.changeTextureToolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
            this.changeTextureToolStripMenuItem1.Text = "Change texture";
            this.changeTextureToolStripMenuItem1.Click += new System.EventHandler(this.ChangeTextureToolStripMenuItem1_Click);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status});
            this.status.Location = new System.Drawing.Point(0, 440);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.status.Size = new System.Drawing.Size(776, 25);
            this.status.TabIndex = 1;
            this.status.Text = "status";
            // 
            // lbl_status
            // 
            this.lbl_status.ActiveLinkColor = System.Drawing.SystemColors.ControlText;
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Image = ((System.Drawing.Image)(resources.GetObject("lbl_status.Image")));
            this.lbl_status.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(77, 20);
            this.lbl_status.Text = "Welcome";
            this.lbl_status.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            // 
            // context_menu
            // 
            this.context_menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.context_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_delete_scene,
            this.context_export_scene,
            this.context_import_scene,
            this.toolStripSeparator3,
            this.context_export_model_obj,
            this.importOBJToolStripMenuItem,
            this.replaceModelToolStripMenuItem,
            this.toolStripSeparator5,
            this.editShaderToolStripMenuItem1,
            this.changeTextureToolStripMenuItem,
            this.toolStripSeparator6,
            this.drawMeshToolStripMenuItem});
            this.context_menu.Name = "context_menu";
            this.context_menu.Size = new System.Drawing.Size(199, 256);
            // 
            // context_delete_scene
            // 
            this.context_delete_scene.Image = ((System.Drawing.Image)(resources.GetObject("context_delete_scene.Image")));
            this.context_delete_scene.Name = "context_delete_scene";
            this.context_delete_scene.Size = new System.Drawing.Size(198, 26);
            this.context_delete_scene.Text = "Delete scene(s)";
            this.context_delete_scene.Click += new System.EventHandler(this.context_delete_scene_Click);
            // 
            // context_export_scene
            // 
            this.context_export_scene.Image = ((System.Drawing.Image)(resources.GetObject("context_export_scene.Image")));
            this.context_export_scene.Name = "context_export_scene";
            this.context_export_scene.Size = new System.Drawing.Size(198, 26);
            this.context_export_scene.Text = "Export scene(s)";
            this.context_export_scene.Click += new System.EventHandler(this.context_export_scene_Click);
            // 
            // context_import_scene
            // 
            this.context_import_scene.Image = ((System.Drawing.Image)(resources.GetObject("context_import_scene.Image")));
            this.context_import_scene.Name = "context_import_scene";
            this.context_import_scene.Size = new System.Drawing.Size(198, 26);
            this.context_import_scene.Text = "Import scene(s)";
            this.context_import_scene.Click += new System.EventHandler(this.context_import_scene_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(195, 6);
            // 
            // context_export_model_obj
            // 
            this.context_export_model_obj.Image = ((System.Drawing.Image)(resources.GetObject("context_export_model_obj.Image")));
            this.context_export_model_obj.Name = "context_export_model_obj";
            this.context_export_model_obj.Size = new System.Drawing.Size(198, 26);
            this.context_export_model_obj.Text = "Export model(s) as OBJ";
            this.context_export_model_obj.Click += new System.EventHandler(this.context_export_model_obj_Click);
            // 
            // importOBJToolStripMenuItem
            // 
            this.importOBJToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importOBJToolStripMenuItem.Image")));
            this.importOBJToolStripMenuItem.Name = "importOBJToolStripMenuItem";
            this.importOBJToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.importOBJToolStripMenuItem.Text = "Import OBJ as model";
            this.importOBJToolStripMenuItem.Click += new System.EventHandler(this.ImportOBJToolStripMenuItem_Click);
            // 
            // replaceModelToolStripMenuItem
            // 
            this.replaceModelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("replaceModelToolStripMenuItem.Image")));
            this.replaceModelToolStripMenuItem.Name = "replaceModelToolStripMenuItem";
            this.replaceModelToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.replaceModelToolStripMenuItem.Text = "Replace model";
            this.replaceModelToolStripMenuItem.Click += new System.EventHandler(this.replaceModelToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(195, 6);
            // 
            // editShaderToolStripMenuItem1
            // 
            this.editShaderToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("editShaderToolStripMenuItem1.Image")));
            this.editShaderToolStripMenuItem1.Name = "editShaderToolStripMenuItem1";
            this.editShaderToolStripMenuItem1.Size = new System.Drawing.Size(198, 26);
            this.editShaderToolStripMenuItem1.Text = "Edit shader";
            this.editShaderToolStripMenuItem1.Click += new System.EventHandler(this.EditShaderToolStripMenuItem1_Click);
            // 
            // changeTextureToolStripMenuItem
            // 
            this.changeTextureToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeTextureToolStripMenuItem.Image")));
            this.changeTextureToolStripMenuItem.Name = "changeTextureToolStripMenuItem";
            this.changeTextureToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.changeTextureToolStripMenuItem.Text = "Change texture";
            this.changeTextureToolStripMenuItem.Click += new System.EventHandler(this.ChangeTextureToolStripMenuItem_Click);
            // 
            // txt_find
            // 
            this.txt_find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_find.Enabled = false;
            this.txt_find.Location = new System.Drawing.Point(546, 443);
            this.txt_find.Margin = new System.Windows.Forms.Padding(2);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(209, 20);
            this.txt_find.TabIndex = 3;
            this.txt_find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_find.Visible = false;
            this.txt_find.TextChanged += new System.EventHandler(this.txt_find_TextChanged);
            // 
            // lbl_search
            // 
            this.lbl_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_search.AutoSize = true;
            this.lbl_search.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_search.Location = new System.Drawing.Point(473, 447);
            this.lbl_search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(72, 13);
            this.lbl_search.TabIndex = 4;
            this.lbl_search.Text = "Search model";
            this.lbl_search.Visible = false;
            // 
            // data_view
            // 
            this.data_view.AllowUserToAddRows = false;
            this.data_view.AllowUserToDeleteRows = false;
            this.data_view.AllowUserToResizeColumns = false;
            this.data_view.AllowUserToResizeRows = false;
            this.data_view.BackgroundColor = System.Drawing.Color.White;
            this.data_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_img,
            this.col_name,
            this.col_subname,
            this.col_type});
            this.data_view.ContextMenuStrip = this.context_menu;
            this.data_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_view.Location = new System.Drawing.Point(0, 28);
            this.data_view.Margin = new System.Windows.Forms.Padding(2);
            this.data_view.Name = "data_view";
            this.data_view.ReadOnly = true;
            this.data_view.RowTemplate.Height = 24;
            this.data_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_view.Size = new System.Drawing.Size(776, 412);
            this.data_view.TabIndex = 5;
            this.data_view.VirtualMode = true;
            this.data_view.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.data_view_CellPainting);
            // 
            // col_img
            // 
            this.col_img.DataPropertyName = "Image";
            this.col_img.FillWeight = 25F;
            this.col_img.HeaderText = "*";
            this.col_img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.col_img.Name = "col_img";
            this.col_img.ReadOnly = true;
            this.col_img.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_img.Width = 50;
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "Name";
            this.col_name.FillWeight = 25F;
            this.col_name.HeaderText = "Scene Name";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Width = 248;
            // 
            // col_subname
            // 
            this.col_subname.DataPropertyName = "Subname";
            this.col_subname.FillWeight = 25F;
            this.col_subname.HeaderText = "Scene Subname";
            this.col_subname.Name = "col_subname";
            this.col_subname.ReadOnly = true;
            this.col_subname.Width = 247;
            // 
            // col_type
            // 
            this.col_type.DataPropertyName = "ChunkType";
            this.col_type.FillWeight = 25F;
            this.col_type.HeaderText = "Scene Type";
            this.col_type.Name = "col_type";
            this.col_type.ReadOnly = true;
            this.col_type.Width = 247;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(195, 6);
            // 
            // drawMeshToolStripMenuItem
            // 
            this.drawMeshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("drawMeshToolStripMenuItem.Image")));
            this.drawMeshToolStripMenuItem.Name = "drawMeshToolStripMenuItem";
            this.drawMeshToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.drawMeshToolStripMenuItem.Text = "Draw mesh";
            this.drawMeshToolStripMenuItem.Click += new System.EventHandler(this.DrawMeshToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(198, 6);
            // 
            // drawMeshToolStripMenuItem1
            // 
            this.drawMeshToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("drawMeshToolStripMenuItem1.Image")));
            this.drawMeshToolStripMenuItem1.Name = "drawMeshToolStripMenuItem1";
            this.drawMeshToolStripMenuItem1.Size = new System.Drawing.Size(201, 26);
            this.drawMeshToolStripMenuItem1.Text = "Draw mesh";
            this.drawMeshToolStripMenuItem1.Click += new System.EventHandler(this.DrawMeshToolStripMenuItem1_Click);
            // 
            // ScenarioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(776, 465);
            this.Controls.Add(this.data_view);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(792, 504);
            this.Name = "ScenarioView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Netsphere Scn Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScenarioView_FormClosed);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.context_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.MenuStrip menu;
    private System.Windows.Forms.ToolStripMenuItem menu_file;
    private System.Windows.Forms.ToolStripMenuItem menu_new_map;
    private System.Windows.Forms.ToolStripMenuItem menu_open_map;
    private System.Windows.Forms.ToolStripMenuItem menu_close_map;
    private System.Windows.Forms.ToolStripMenuItem menu_save;
    private System.Windows.Forms.ToolStripMenuItem menu_save_map;
    private System.Windows.Forms.ToolStripMenuItem menu_replace_map;
    private System.Windows.Forms.ToolStripMenuItem menu_exit;
    private System.Windows.Forms.StatusStrip status;
    private System.Windows.Forms.ToolStripStatusLabel lbl_status;
    private System.Windows.Forms.ToolStripMenuItem menu_edit;
    private System.Windows.Forms.ToolStripMenuItem menu_undo;
    private System.Windows.Forms.ToolStripMenuItem menu_redo;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem menu_delete_scene;
    private System.Windows.Forms.ContextMenuStrip context_menu;
    private System.Windows.Forms.ToolStripMenuItem context_delete_scene;
    private System.Windows.Forms.TextBox txt_find;
    private System.Windows.Forms.Label lbl_search;
    private System.Windows.Forms.ToolStripMenuItem menu_extract_scene;
    private System.Windows.Forms.ToolStripMenuItem context_export_scene;
    private System.Windows.Forms.ToolStripMenuItem menu_import_scene;
    private System.Windows.Forms.ToolStripMenuItem context_import_scene;
    private System.Windows.Forms.DataGridView data_view;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem menu_export_obj;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem context_export_model_obj;
    private System.Windows.Forms.DataGridViewImageColumn col_img;
    private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
    private System.Windows.Forms.DataGridViewTextBoxColumn col_subname;
    private System.Windows.Forms.DataGridViewTextBoxColumn col_type;
        private System.Windows.Forms.ToolStripMenuItem importOBJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_import_obj;
        private System.Windows.Forms.ToolStripMenuItem replaceModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_replace_model;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem editShaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem editShaderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeTextureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changeTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem drawMeshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem drawMeshToolStripMenuItem1;
    }
}


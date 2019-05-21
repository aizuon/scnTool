using BlubLib.IO;
using NetsphereScnTool.Scene;
using NetsphereScnTool.Scene.Chunks;
using NetsphereScnTool.UndoRedo;
using NetsphereScnTool.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetsphereScnTool.Forms
{
    public partial class ScenarioView : Form
    {
        private SceneContainer container;
        private SceneUndoManager undo_manager;

        private string container_path = string.Empty;

        public ScenarioView()
        {
            InitializeComponent();

            data_view.AutoGenerateColumns = false;
            data_view.RowHeadersVisible = false;

            data_view.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            data_view.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            data_view.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            data_view.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            data_view.CellBorderStyle = DataGridViewCellBorderStyle.None;
            data_view.RowTemplate.Height = 20;
        }

        #region Overrides
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                undo();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Y))
            {
                redo();
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                save();
                return true;
            }

            if (keyData == (Keys.Control | Keys.R))
            {
                replace();
                return true;
            }

            if (keyData == Keys.Delete)
            {
                delete_scene();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Functions

        private void f_remove_scene(int[] indexes)
        {
            if (container == null)
                return;

            for (int i = 0; i < indexes.Length; i++)
            {
                string name = null;
                try
                { name = container.ElementAt(indexes[i]).Name; }
                catch { }

                if (name == null)
                    continue;

                var scene = container.FirstOrDefault(x => x.Name == name);
                if (scene != null)
                    container.Remove(scene);
            }
        }

        private bool f_extract_obj(SceneChunk scene)
        {
            if (container == null)
                return false;

            if (scene != null && scene.ChunkType == ChunkType.ModelData)
            {
                var folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    string file_name = scene.Name + ".obj";

                    var exporter = new Obj_Exporter();

                    exporter.Export(Path.Combine(folder.SelectedPath, file_name), scene as ModelChunk);
                    return true;
                }
            }

            return false;
        }

        private bool f_import_obj()
        {
            if (container == null)
                return false;

            var file = new OpenFileDialog();
            file.Filter = ".obj|*.obj";

            if (file.ShowDialog() == DialogResult.OK)
            {
                new Task(() =>
                {
                    var tcs = new TaskCompletionSource<bool>();
                    var importView = new ImportOBJView(tcs);
                    importView.ShowDialog();
                    tcs.Task.GetAwaiter().GetResult();

                    var importer = new Obj_Importer();

                    importer.Import(file.FileName, importView.TextureName, importView.SceneName, importView.SceneSubname, container);
                    importView.Dispose();
                }).Start();

                return true;
            }

            return false;
        }

        private bool f_replace_model(int index)
        {
            if (container == null)
                return false;

            string name = container.ElementAt(index).Name;
            var scene = container.FirstOrDefault(x => x.Name == name);

            var file = new OpenFileDialog();
            file.Filter = ".obj|*.obj";

            if (file.ShowDialog() == DialogResult.OK)
            {
                var importer = new Obj_Importer();

                importer.ReplaceModel(file.FileName, scene as ModelChunk);

                return true;
            }

            return false;
        }

        private bool f_edit_shader(int index)
        {
            if (container == null)
                return false;

            string name = container.ElementAt(index).Name;
            var scene = container.FirstOrDefault(x => x.Name == name);

            var model = scene as ModelChunk;

            new Task(() =>
            {
                var tcs = new TaskCompletionSource<bool>();
                var shadereditView = new ShaderEditView(model.Shader, tcs);
                shadereditView.ShowDialog();
                tcs.Task.GetAwaiter().GetResult();

                var editor = new Obj_Editor();

                editor.EditShader(model, shadereditView.selectedShader);
                shadereditView.Dispose();
            }).Start();

            return true;
        }

        private bool f_change_texture(int index)
        {
            if (container == null)
                return false;

            string name = container.ElementAt(index).Name;
            var scene = container.FirstOrDefault(x => x.Name == name);

            var model = scene as ModelChunk;

            var txts = new List<string>();

            foreach (var tds in model.TextureData.Textures)
                txts.Add(tds.FileName);

            new Task(() =>
            {
                var tcs = new TaskCompletionSource<bool>();
                var texturechangeView = new TextureChangeView(txts, tcs);
                texturechangeView.ShowDialog();
                tcs.Task.GetAwaiter().GetResult();

                var editor = new Obj_Editor();

                editor.ChangeTexture(model, texturechangeView.Textures);
                texturechangeView.Dispose();
            }).Start();

            return true;
        }

        private bool f_edit_animation(int index)
        {
            if (container == null)
                return false;

            string name = container.ElementAt(index).Name;
            var scene = container.FirstOrDefault(x => x.Name == name);

            var bone = scene as BoneChunk;

            if (bone != null)
            {
                new Task(() =>
                {
                    var tcs = new TaskCompletionSource<bool>();
                    var animationeditView = new AnimationEditView(bone.Animation, tcs);
                    animationeditView.ShowDialog();
                    tcs.Task.GetAwaiter().GetResult();

                    var editor = new Obj_Editor();

                    editor.EditAnimation(bone, animationeditView.BoneAnimation);
                    animationeditView.Dispose();
                }).Start();
            }
            else
            {
                var model = scene as ModelChunk;

                new Task(() =>
                {
                    var tcs = new TaskCompletionSource<bool>();
                    var animationeditView = new AnimationEditView(model.Animation, tcs);
                    animationeditView.ShowDialog();
                    tcs.Task.GetAwaiter().GetResult();

                    var editor = new Obj_Editor();

                    editor.EditAnimation(model, animationeditView.ModelAnimation);
                    animationeditView.Dispose();
                }).Start();
            }

            return true;
        }

        private void f_draw_mesh(int index)
        {
            if (container == null)
                return;

            string name = container.ElementAt(index).Name;
            var scene = container.FirstOrDefault(x => x.Name == name);

            var model = scene as ModelChunk;

            new Task(() =>
            {
                var drawMesh = new DrawMesh(model.Mesh);

                drawMesh.ShowDialog();
            }).Start();
        }

        private bool f_extract_obj(IEnumerable<SceneChunk> scenes)
        {
            var exporter = new Obj_Exporter();

            if (container == null)
                return false;

            if (scenes.Count() <= 0)
                return false;

            var folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < scenes.Count(); i++)
                {
                    if (scenes.ElementAt(i) != null && scenes.ElementAt(i).ChunkType == ChunkType.ModelData)
                    {
                        string file_name = scenes.ElementAt(i).Name + ".obj";
                        exporter.Export(Path.Combine(folder.SelectedPath, file_name), scenes.ElementAt(i) as ModelChunk);
                    }
                }

                return true;
            }

            return false;
        }

        private bool f_extract_scene(string name)
        {
            if (container == null)
                return false;

            var chunk = container.FirstOrDefault(x => x.Name == name);
            if (chunk != null)
            {
                var save_dg = new SaveFileDialog();
                save_dg.FileName = $"{chunk.Name}";
                save_dg.Filter = ".scn_part|*.scn_part";

                if (save_dg.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = new FileStream(save_dg.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.WriteEnum(chunk.ChunkType);
                        bw.WriteCString(chunk.Name);
                        bw.WriteCString(chunk.SubName);

                        bw.Serialize(chunk);
                    }
                    return true;
                }
            }
            return false;
        }

        private bool f_extract_scene(string[] strings)
        {
            if (container == null)
                return false;

            var folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    var chunk = container.FirstOrDefault(x => x.Name == strings[i]);
                    if (chunk != null)
                    {
                        string full_path = $"{folder.SelectedPath}//{chunk.Name}.scn_part";

                        using (var fs = new FileStream(full_path, FileMode.Create, FileAccess.Write, FileShare.None))
                        using (var bw = new BinaryWriter(fs))
                        {
                            bw.WriteEnum(chunk.ChunkType);
                            bw.WriteCString(chunk.Name);
                            bw.WriteCString(chunk.SubName);

                            bw.Serialize(chunk);
                        }
                    }
                }
                return true;
            }
            return false;
        }

        private bool f_import_scene()
        {
            if (container == null)
                return false;

            var file = new OpenFileDialog();
            file.Multiselect = true;
            file.Filter = ".scn_part|*.scn_part";

            if (file.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < file.FileNames.Length; i++)
                {
                    using (var fs = new FileStream(file.FileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    using (var br = new BinaryReader(fs))
                    {
                        SceneChunk chunk = null;

                        var type = br.ReadEnum<ChunkType>();
                        string name = br.ReadCString();
                        string subname = br.ReadCString();

                        switch (type)
                        {
                            case ChunkType.Bone:
                                chunk = new BoneChunk(container)
                                {
                                    Name = name,
                                    SubName = subname,
                                    Image = Properties.Resources.bone
                                };

                                chunk.Deserialize(fs);
                                container.Add(chunk);
                                break;

                            case ChunkType.BoneSystem:
                                chunk = new BoneSystemChunk(container)
                                {
                                    Name = name,
                                    SubName = subname,
                                    Image = Properties.Resources.bone_system
                                };

                                chunk.Deserialize(fs);
                                container.Add(chunk);
                                break;

                            case ChunkType.Box:
                                chunk = new BoxChunk(container)
                                {
                                    Name = name,
                                    SubName = subname,
                                    Image = Properties.Resources.box
                                };

                                chunk.Deserialize(fs);
                                container.Add(chunk);
                                break;

                            case ChunkType.ModelData:
                                chunk = new ModelChunk(container)
                                {
                                    Name = name,
                                    SubName = subname,
                                    Image = Properties.Resources.model
                                };

                                chunk.Deserialize(fs);
                                container.Add(chunk);
                                break;

                            case ChunkType.Shape:
                                chunk = new ShapeChunk(container)
                                {
                                    Name = name,
                                    SubName = subname,
                                    Image = Properties.Resources.shape
                                };

                                chunk.Deserialize(fs);
                                container.Add(chunk);
                                break;

                            case ChunkType.SkyDirect1:
                                chunk = new SkyDirect1Chunk(container)
                                {
                                    Name = name,
                                    SubName = subname,
                                    Image = Properties.Resources.sky
                                };

                                chunk.Deserialize(fs);
                                container.Add(chunk);
                                break;

                            default:
                                return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Internal
        private void update_status()
        {
            string sceneName = container.Header.Name;
            string sceneParent = container.Header.SubName;
            int objectCount = container.Count;

            lbl_status.Text = $"New model opened: [Name: {sceneName}, Parent name: {sceneParent}, Count: {objectCount}]";
        }

        private void update_view()
        {
            var bSource = new BindingSource();
            bSource.DataSource = container;
            data_view.DataSource = bSource;

            data_view.Update();
        }

        private void check_undo_redo()
        {
            if (undo_manager.CanUndo())
                Extensions.EnableOrDisable(ComponentState.Enable, menu_undo);
            else
                Extensions.EnableOrDisable(ComponentState.Disable, menu_undo);

            if (undo_manager.CanRedo())
                Extensions.EnableOrDisable(ComponentState.Enable, menu_redo);
            else
                Extensions.EnableOrDisable(ComponentState.Disable, menu_redo);
        }

        private void undo()
        {
            undo_manager.Undo();
            container = undo_manager.GetContainer();

            check_undo_redo();

            update_view();
            update_status();
        }

        private void redo()
        {
            undo_manager.Redo();
            container = undo_manager.GetContainer();

            check_undo_redo();

            update_view();
            update_status();
        }

        private void delete_scene()
        {
            if (data_view.Rows.Count <= 0)
                return;

            var indexes = new List<int>();

            for (int i = 0; i < data_view.SelectedRows.Count; i++)
            {
                int currentIndex = data_view.SelectedRows[i].Index;
                indexes.Add(currentIndex);
            }

            f_remove_scene(indexes.ToArray());

            if (container != null)
            {
                undo_manager.Save(container);
                update_view();
                update_status();
            }
        }

        private void save()
        {
            if (container == null)
                return;

            var file = new SaveFileDialog();
            file.FileName = Path.GetFileName(container_path);
            file.Filter = "scn|*.scn";

            if (file.ShowDialog() == DialogResult.OK)
            {
                container.Write(file.FileName);
                MessageBox.Show($"{Path.GetFileName(file.FileName)} successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void replace()
        {
            if (container == null)
                return;

            container.Write(container_path);
            MessageBox.Show($"{Path.GetFileName(container_path)} successfully replaced", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void extract_obj()
        {
            if (container == null)
                return;

            bool result = false;

            if (data_view.SelectedRows.Count == 1)
            {
                int index = data_view.SelectedRows[0].Index;
                var source = container[index];
                if (source != null)
                    result = f_extract_obj(source);
            }
            else
            {
                var scenes = new List<SceneChunk>();

                for (int i = 0; i < data_view.SelectedRows.Count; i++)
                {
                    int currentIndex = data_view.SelectedRows[i].Index;
                    var scene = container[currentIndex];

                    if (scene != null)
                        scenes.Add(scene);
                }

                if (scenes.Count > 0)
                    result = f_extract_obj(scenes);
            }

            if (result)
                MessageBox.Show("All scene(s) exported...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Unable to export scene(s)", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void extract_scene()
        {
            if (container == null)
                return;

            bool result = false;

            if (data_view.SelectedRows.Count == 1)
            {
                int index = data_view.SelectedRows[0].Index;
                var source = container[index];
                if (source != null)
                    result = f_extract_scene(source.Name);
            }
            else
            {
                var keys = new List<string>();
                for (int i = 0; i < data_view.SelectedRows.Count; i++)
                {
                    int index = data_view.SelectedRows[i].Index;
                    keys.Add(container[index].Name);
                }

                if (keys.Count > 0)
                    result = f_extract_scene(keys.ToArray());
            }

            if (result)
                MessageBox.Show("All scene(s) exported...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Unable to export scene(s)", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void import_scene()
        {
            if (container == null)
                return;

            bool result = false;
            result = f_import_scene();

            if (result)
            {
                update_view();
                update_status();

                undo_manager.Save(container);
            }
            else
                MessageBox.Show("Unable to import scene(s)", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void replace_model()
        {
            if (container == null)
                return;

            bool result = false;
            result = f_replace_model(data_view.SelectedRows[0].Index);

            if (result)
            {
                update_view();
                update_status();

                undo_manager.Save(container);
            }
            else
                MessageBox.Show("Unable to replace scene", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void edit_shader()
        {
            if (container == null)
                return;

            bool result = false;
            result = f_edit_shader(data_view.SelectedRows[0].Index);

            if (result)
            {
                update_view();
                update_status();

                undo_manager.Save(container);
            }
            else
                MessageBox.Show("Unable to change shader", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void change_texture()
        {
            if (container == null)
                return;

            bool result = false;
            result = f_change_texture(data_view.SelectedRows[0].Index);

            if (result)
            {
                update_view();
                update_status();

                undo_manager.Save(container);
            }
            else
                MessageBox.Show("Unable to change texture", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void edit_animation()
        {
            if (container == null)
                return;

            bool result = false;
            result = f_edit_animation(data_view.SelectedRows[0].Index);

            if (result)
            {
                update_view();
                update_status();

                undo_manager.Save(container);
            }
            else
                MessageBox.Show("Unable to change animation", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void draw_mesh()
        {
            if (container == null)
                return;

            f_draw_mesh(data_view.SelectedRows[0].Index);

            update_view();
            update_status();

            undo_manager.Save(container);
        }

        private void import_obj()
        {
            if (container == null)
                return;

            bool result = false;
            result = f_import_obj();

            if (result)
            {
                update_view();
                update_status();

                undo_manager.Save(container);
            }
            else
                MessageBox.Show("Unable to import scene", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Events

        /*    TEST CODE
        private void data_view_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          // MC START TEST
          //if (e.ColumnIndex > 1 || e.RowIndex < 0 || e.RowIndex >= this.massesList.Count)
          if (e.ColumnIndex > 1 || e.RowIndex < 0 || e.RowIndex >= data_view.Rows.Count)
            return;
          // MC END TEST
          if (e.ColumnIndex == 0)
          {
            int RealRowIndex = 0;
            SceneChunk tmp_cm = (SceneChunk)data_view.Rows[e.RowIndex].DataBoundItem;
            RealRowIndex = this.container.IndexOf(tmp_cm);
            e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            bool HasChildOrBrother = (RealRowIndex + 1 < this.container.Count && this.container[RealRowIndex + 1].Grade == ParentGrade.Child);


            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

            Brush b = new SolidBrush(System.Drawing.Color.White);
            Rectangle rect1 = new Rectangle(e.CellBounds.Left + 1, e.CellBounds.Top + 1, e.CellBounds.Width - 3, e.CellBounds.Height - 3);
            //Rectangle rect2 = new Rectangle(e.CellBounds.Left , e.CellBounds.Top, e.CellBounds.Width-1 , e.CellBounds.Height -1);
            Pen p2 = new Pen(System.Drawing.Color.FromArgb(160, 160, 160), 1);
            //e.Graphics.DrawRectangle(p2, rect2);
            //e.Graphics.DrawLine(p2, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Top);
            e.Graphics.DrawLine(p2, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);

            if (this.container[RealRowIndex].Grade == ParentGrade.Father) // Is Father
            {
              //Pen pen = new Pen(Color.Red);
              ////e.PaintParts
              //e.Graphics.DrawRectangle(pen, 0, 0, 8, 8);
              ////System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportMasses));
              ////dgvMasses.Rows[e.RowIndex].Cells[0].Value = resources.GetObject("redCross");
              //e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
              //bool HasBrother = (e.RowIndex + 1 < this.massesList.Count && this.massesList[e.RowIndex + 1].RowTypeIdentifier == 1);
              using (Pen p = new Pen(System.Drawing.Color.Red, 1))
              {
                //Brush b = new SolidBrush(dgvMasses.Rows[e.RowIndex].DefaultCellStyle.BackColor);


                int X = e.CellBounds.Left + e.CellBounds.Width / 2;
                int Y = e.CellBounds.Top + e.CellBounds.Height / 2;
                Rectangle rect = new Rectangle(X - 5, Y - 5, 10, 10);
                e.Graphics.DrawRectangle(p, rect);
                e.Graphics.DrawLine(p, X - 3, Y, X + 3, Y);
                if (HasChildOrBrother)
                {
                  if (!data_view.Rows[e.RowIndex + 1].Visible)
                    e.Graphics.DrawLine(p, X, Y - 3, X, Y + 3);
                  else
                  {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    e.Graphics.DrawLine(p, X, Y + 5, X, Y + e.CellBounds.Height / 2);
                  }
                }


              }

              e.Handled = true;

            }
            else // is Child
            {
              e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

              using (Pen p = new Pen(System.Drawing.Color.Blue, 1))
              {
                int X = e.CellBounds.Left + e.CellBounds.Width / 2;
                int Y = e.CellBounds.Top + e.CellBounds.Height / 2;
                //Rectangle rect = new Rectangle(X - 4, Y - 4, 8, 8);
                //e.Graphics.DrawRectangle(p, rect);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                if (HasChildOrBrother)
                  e.Graphics.DrawLine(p, X, Y - e.CellBounds.Height / 2, X, Y + e.CellBounds.Height / 2);
                else
                  e.Graphics.DrawLine(p, X, Y - e.CellBounds.Height / 2, X, Y);

                e.Graphics.DrawLine(p, X + 1, Y, X + +e.CellBounds.Width / 2, Y);

              }

              e.Handled = true;
            }
          }
          if (e.ColumnIndex == 1)
            e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
        }
        */

        private void data_view_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { } //Fake

        private void txt_find_TextChanged(object sender, EventArgs e) { }

        private void ScenarioView_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        #endregion

        private void menu_new_map_Click(object sender, EventArgs e)
        {
            Extensions.EnableOrDisable(ComponentState.Disable, menu_new_map, menu_open_map);
            Extensions.EnableOrDisable(ComponentState.Enable, menu_close_map, menu_save, menu_edit);
            Extensions.EnableOrDisable(ComponentState.Enable, txt_find);
        }

        private void menu_open_map_Click(object sender, EventArgs e)
        {
            if (container != null)
                return;

            var file = new OpenFileDialog();
            file.Filter = ".scn|*.scn";

            if (file.ShowDialog() == DialogResult.OK)
            {
                container = SceneContainer.ReadFrom(file.FileName);

                if (undo_manager == null)
                {
                    undo_manager = new SceneUndoManager(50);
                    undo_manager.ObjectSaved += Undo_manager_ObjectSaved;
                }

                container_path = file.FileName;
                undo_manager.Save(container);

                Extensions.EnableOrDisable(ComponentState.Disable, menu_new_map, menu_open_map);
                Extensions.EnableOrDisable(ComponentState.Enable, menu_close_map, menu_save, menu_edit);
                Extensions.EnableOrDisable(ComponentState.Enable, txt_find);

                update_view();
                update_status();
            }
        }

        private void menu_close_map_Click(object sender, EventArgs e)
        {
            if (container == null)
                return;

            container = null;
            container_path = string.Empty;

            undo_manager.ClearSystem();
            data_view.Rows.Clear();

            lbl_status.Text = "Scene closed";

            Extensions.EnableOrDisable(ComponentState.Enable, menu_new_map, menu_open_map);
            Extensions.EnableOrDisable(ComponentState.Disable, menu_close_map, menu_save, menu_edit);
            Extensions.EnableOrDisable(ComponentState.Disable, txt_find);
        }

        private void menu_replace_map_Click(object sender, EventArgs e) => replace();

        private void Undo_manager_ObjectSaved(object sender, EventArgs e) => check_undo_redo();

        private void menu_exit_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void menu_save_map_Click(object sender, EventArgs e) => save();

        private void menu_delete_scene_Click(object sender, EventArgs e) => delete_scene();

        private void menu_undo_Click(object sender, EventArgs e) => undo();

        private void menu_redo_Click(object sender, EventArgs e) => redo();

        private void context_delete_scene_Click(object sender, EventArgs e) => delete_scene();

        private void menu_extract_scene_Click(object sender, EventArgs e) => extract_scene();

        private void context_export_scene_Click(object sender, EventArgs e) => extract_scene();

        private void menu_import_scene_Click(object sender, EventArgs e) => import_scene();

        private void context_import_scene_Click(object sender, EventArgs e) => import_scene();

        private void menu_export_obj_Click(object sender, EventArgs e) => extract_obj();

        private void context_export_model_obj_Click(object sender, EventArgs e) => extract_obj();

        private void ImportOBJToolStripMenuItem_Click(object sender, EventArgs e) => import_obj();

        private void replaceModelToolStripMenuItem_Click(object sender, EventArgs e) => replace_model();

        private void menu_import_obj_Click(object sender, EventArgs e) => import_obj();

        private void menu_replace_model_Click(object sender, EventArgs e) => replace_model();

        private void EditShaderToolStripMenuItem1_Click(object sender, EventArgs e) => edit_shader();

        private void EditShaderToolStripMenuItem_Click(object sender, EventArgs e) => edit_shader();

        private void ChangeTextureToolStripMenuItem_Click(object sender, EventArgs e) => change_texture();

        private void ChangeTextureToolStripMenuItem1_Click(object sender, EventArgs e) => change_texture();

        private void DrawMeshToolStripMenuItem_Click(object sender, EventArgs e) => draw_mesh();

        private void DrawMeshToolStripMenuItem1_Click(object sender, EventArgs e) => draw_mesh();

        private void EditAnimationToolStripMenuItem1_Click(object sender, EventArgs e) => edit_animation();

        private void EditAnimationToolStripMenuItem_Click(object sender, EventArgs e) => edit_animation();
    }
}
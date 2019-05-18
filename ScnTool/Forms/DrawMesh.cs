using NetsphereScnTool.Scene.Chunks;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NetsphereScnTool.Forms
{
    public partial class DrawMesh : Form
    {
        private readonly MeshData _mesh;
        private float rotationx = 1.00f;
        private float rotationz = 0.00f;
        private float scale = 0.05f;
        private Vector3 trans = new Vector3(-50, -170, 0);

        public DrawMesh(MeshData mesh)
        {
            InitializeComponent();
            DoubleBuffered = true;

            _mesh = mesh;
        }

        private void DrawMesh_Paint(object sender, PaintEventArgs e)
        {
            float centerX = ClientSize.Width / 2.0f;
            float centerY = ClientSize.Height / 2.0f;

            var transform = Matrix4x4.CreateTranslation(trans)
                * Matrix4x4.CreateScale(scale)
                * Matrix4x4.CreateRotationX(rotationx)
                * Matrix4x4.CreateRotationZ(rotationz);

            var v3list = new List<Vector3>();

            foreach (var v3 in _mesh.Vertices)
                v3list.Add(Vector3.Transform(v3, transform));

            for (int i = 0; i < _mesh.Faces.Count; i++)
            {
                var p1 = new PointF(v3list[(int)_mesh.Faces[i].X].X + centerX, v3list[(int)_mesh.Faces[i].X].Y + centerY);
                var p2 = new PointF(v3list[(int)_mesh.Faces[i].Y].X + centerX, v3list[(int)_mesh.Faces[i].Y].Y + centerY);
                var p3 = new PointF(v3list[(int)_mesh.Faces[i].Z].X + centerX, v3list[(int)_mesh.Faces[i].Z].Y + centerY);
                e.Graphics.DrawLine(Pens.White, p1, p2);
                e.Graphics.DrawLine(Pens.White, p2, p3);
                e.Graphics.DrawLine(Pens.White, p1, p3);
            }
        }

        private void DrawMesh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void DrawMesh_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    rotationx += 0.1f;
                    break;

                case Keys.Down:
                    rotationx -= 0.1f;
                    break;

                case Keys.Right:
                    rotationz += 0.1f;
                    break;

                case Keys.Left:
                    rotationz -= 0.1f;
                    break;

                case Keys.W:
                    trans.Y -= 10;
                    break;

                case Keys.S:
                    trans.Y += 10;
                    break;

                case Keys.A:
                    trans.X -= 10;
                    break;

                case Keys.D:
                    trans.X += 10;
                    break;
            }

            Refresh();
        }

        private void DrawMesh_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                scale += 0.05f;
            else
            {
                if (scale > 0.05f)
                {
                    scale -= 0.05f;
                }
            }

            Refresh();
        }
    }
}

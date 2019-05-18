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

        public DrawMesh(MeshData mesh)
        {
            InitializeComponent();

            _mesh = mesh;
        }

        private void DrawMesh_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            float centerX = ClientSize.Width / 2.0f;
            float centerY = ClientSize.Height / 2.0f;

            var rx = Matrix4x4.CreateRotationX(rotationx);
            var rz = Matrix4x4.CreateRotationZ(rotationz);
            var s = Matrix4x4.CreateScale(scale);
            var t = Matrix4x4.CreateTranslation(-50, -170, 0);

            var v3list = new List<Vector3>();

            foreach (var v3 in _mesh.Vertices)
            {
                var temp = Vector3.Transform(v3, s);
                var temp2 = Vector3.Transform(temp, t);
                var temp3 = Vector3.Transform(temp2, rz);
                v3list.Add(Vector3.Transform(temp3, rx));
            }

            for (int i = 0; i < v3list.Count - 1; i++)
            {
                g.DrawLine(new Pen(Color.White), new PointF(v3list[i].X + centerX, v3list[i].Y + centerY), new PointF(v3list[i + 1].X + centerX, v3list[i + 1].Y + centerY));
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
                    rotationx += 0.05f;
                    break;

                case Keys.Down:
                    if (rotationx > 0.05f)
                        rotationx -= 0.05f;
                    break;

                case Keys.Right:
                    rotationz += 0.05f;
                    break;

                case Keys.Left:
                    if (rotationz > 0.05f)
                        rotationz -= 0.05f;
                    break;
            }

            Refresh();
        }

        private void DrawMesh_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
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

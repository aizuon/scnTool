using NetsphereScnTool.Scene.Chunks;
using System;
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
        private float rotationy = 0.00f;
        private float rotationz = 0.00f;
        private float scale = 0.05f;
        private float trans = 10.0f;
        private Vector3 translation = new Vector3(-50, -170, 0);
        private bool Fill = false;
        private bool Light = true;

        public DrawMesh(MeshData mesh)
        {
            InitializeComponent();
            DoubleBuffered = true;

            _mesh = mesh;

            float maxX = 0;
            float maxY = 0;

            foreach (var v in _mesh.Vertices)
            {
                float absX = Math.Abs(v.X);
                float absY = Math.Abs(v.Y);
                float absZ = Math.Abs(v.Z);

                if (absX > maxX)
                    maxX = absX;

                if (absY > maxY)
                    maxY = absY;
            }

            float scaleX = (ClientSize.Width / maxX) * scale;
            float scaleY = (ClientSize.Height / maxY) * scale;

            float scaleMin = Math.Min(scaleX, scaleY);

            if (scaleMin > scale)
                scale = scaleMin;

            float transMin = Math.Min(maxX, maxY);

            if (transMin > trans)
                trans = transMin;
        }

        private bool IsClockwise(PointF p1, PointF p2, PointF p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X) >= 0;
        }

        private void DrawMesh_Paint(object sender, PaintEventArgs e)
        {
            float centerX = ClientSize.Width / 2.0f;
            float centerY = ClientSize.Height / 2.0f;

            var transform = Matrix4x4.CreateTranslation(translation)
                * Matrix4x4.CreateScale(scale)
                * Matrix4x4.CreateRotationX(rotationx)
                * Matrix4x4.CreateRotationY(rotationy)
                * Matrix4x4.CreateRotationZ(rotationz);

            var v3list = new List<Vector3>();

            foreach (var v3 in _mesh.Vertices)
                v3list.Add(Vector3.Transform(v3, transform));

            float maxZ = 0;
            foreach (var v in v3list)
            {
                var absZ = Math.Abs(v.Z);

                if (absZ > maxZ)
                    maxZ = absZ;
            }

            for (int i = 0; i < _mesh.Faces.Count; i++)
            {
                var p1 = new PointF(v3list[(int)_mesh.Faces[i].X].X + centerX, v3list[(int)_mesh.Faces[i].X].Y + centerY);
                var p2 = new PointF(v3list[(int)_mesh.Faces[i].Y].X + centerX, v3list[(int)_mesh.Faces[i].Y].Y + centerY);
                var p3 = new PointF(v3list[(int)_mesh.Faces[i].Z].X + centerX, v3list[(int)_mesh.Faces[i].Z].Y + centerY);

                if (Fill == true)
                {
                    if (IsClockwise(p1, p2, p3))
                    {
                        if (Light == true)
                        {
                            var grayscale = (int)(Math.Abs((v3list[(int)_mesh.Faces[i].X].Z + v3list[(int)_mesh.Faces[i].Y].Z + v3list[(int)_mesh.Faces[i].Z].Z) / 3) * 255 / maxZ);

                            e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(grayscale, grayscale, grayscale)), new PointF[] { p1, p2, p3 });
                        }

                        else
                            e.Graphics.FillPolygon(Brushes.White, new PointF[] { p1, p2, p3 });
                    }
                }

                else
                {
                    e.Graphics.DrawLine(Pens.White, p1, p2);
                    e.Graphics.DrawLine(Pens.White, p2, p3);
                    e.Graphics.DrawLine(Pens.White, p1, p3);
                }
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
                case Keys.W:
                    rotationx += 0.1f;
                    break;

                case Keys.S:
                    rotationx -= 0.1f;
                    break;

                case Keys.D:
                    rotationz += 0.1f;
                    break;

                case Keys.A:
                    rotationz -= 0.1f;
                    break;

                case Keys.Q:
                    rotationy += 0.1f;
                    break;

                case Keys.E:
                    rotationy -= 0.1f;
                    break;

                case Keys.Up:
                    translation.Y -= trans;
                    break;

                case Keys.Down:
                    translation.Y += trans;
                    break;

                case Keys.Left:
                    translation.X -= trans;
                    break;

                case Keys.Right:
                    translation.X += trans;
                    break;

                case Keys.F:
                    Fill = !Fill;
                    break;

                case Keys.G:
                    Light = !Light;
                    break;

                case Keys.R:
                    trans *= 2;
                    break;

                case Keys.T:
                    trans /= 2;
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

        private void DrawMesh_ClientSizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}

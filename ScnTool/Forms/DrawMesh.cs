﻿using NetsphereScnTool.Scene.Chunks;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace NetsphereScnTool.Forms
{
    public partial class DrawMesh : Form
    {
        private readonly MeshData _mesh;

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

            var r = Matrix4x4.CreateRotationX(1.00f);
            var s = Matrix4x4.CreateScale(0.05f);
            var t = Matrix4x4.CreateTranslation(-50, -170, 0);

            var v3list = new List<Vector3>();

            foreach (var v3 in _mesh.Vertices)
            {
                var temp = Vector3.Transform(v3, s);
                var temp2 = Vector3.Transform(temp, t);
                v3list.Add(Vector3.Transform(temp2, r));
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
    }
}
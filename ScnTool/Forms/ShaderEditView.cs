using NetsphereScnTool.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetsphereScnTool.Forms
{
    public partial class ShaderEditView : Form
    {
        public RenderState selectedShader;

        private readonly TaskCompletionSource<bool> _tcs;

        private readonly List<CheckBox> cbx;
        private readonly List<RenderState> evals;

        public ShaderEditView(RenderState shader, TaskCompletionSource<bool> tcs)
        {
            InitializeComponent();

            cbx = Controls.OfType<CheckBox>().Where(c => c != None).ToList();

            evals = Enum.GetValues(typeof(RenderState)).Cast<RenderState>().Where(s => s != RenderState.None).ToList();

            uint i = 0;
            foreach (var eval in evals)
            {
                if (shader.HasFlag(eval))
                {
                    foreach (var c in cbx)
                    {
                        if (c.Name == eval.ToString())
                        {
                            c.Checked = true;
                            i++;
                        }
                    }
                }
            }

            if (i == 0)
                None.Checked = true;

            _tcs = tcs;
        }

        private void ApplyShader_Click(object sender, EventArgs e)
        {
            uint i = 0;
            foreach (var c in cbx)
            {
                if (c.Checked == true)
                {
                    foreach (var eval in evals)
                    {
                        if (c.Name == eval.ToString())
                        {
                            selectedShader |= eval;
                            i++;
                        }
                    }
                }
            }

            if (i == 0)
                selectedShader = RenderState.None;

            _tcs.SetResult(true);
            Hide();
        }

        private void None_CheckedChanged(object sender, EventArgs e)
        {
            if (None.Checked == true)
            {
                foreach (var c in cbx)
                    c.Checked = false;
            }
        }

        private void Transparent_CheckedChanged(object sender, EventArgs e)
        {
            if (Transparent.Checked == true)
                None.Checked = false;
        }

        private void NoLight_CheckedChanged(object sender, EventArgs e)
        {
            if (NoLight.Checked == true)
                None.Checked = false;
        }

        private void Cutout_CheckedChanged(object sender, EventArgs e)
        {
            if (Cutout.Checked == true)
                None.Checked = false;
        }

        private void Billboard_CheckedChanged(object sender, EventArgs e)
        {
            if (Billboard.Checked == true)
                None.Checked = false;
        }

        private void NoCulling_CheckedChanged(object sender, EventArgs e)
        {
            if (NoCulling.Checked == true)
                None.Checked = false;
        }

        private void Flare_CheckedChanged(object sender, EventArgs e)
        {
            if (Flare.Checked == true)
                None.Checked = false;
        }

        private void ZWriteOff_CheckedChanged(object sender, EventArgs e)
        {
            if (ZWriteOff.Checked == true)
                None.Checked = false;
        }

        private void Shader_CheckedChanged(object sender, EventArgs e)
        {
            if (Shader.Checked == true)
                None.Checked = false;
        }

        private void NoFog_CheckedChanged(object sender, EventArgs e)
        {
            if (NoFog.Checked == true)
                None.Checked = false;
        }

        private void NoMipmap_CheckedChanged(object sender, EventArgs e)
        {
            if (NoMipmap.Checked == true)
                None.Checked = false;
        }

        private void Shadow_CheckedChanged(object sender, EventArgs e)
        {
            if (Shadow.Checked == true)
                None.Checked = false;
        }

        private void Water_CheckedChanged(object sender, EventArgs e)
        {
            if (Water.Checked == true)
                None.Checked = false;
        }

        private void Distortion_CheckedChanged(object sender, EventArgs e)
        {
            if (Distortion.Checked == true)
                None.Checked = false;
        }

        private void Dark_CheckedChanged(object sender, EventArgs e)
        {
            if (Dark.Checked == true)
                None.Checked = false;
        }
    }
}

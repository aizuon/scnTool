using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetsphereScnTool.Forms
{
    public partial class TextureChangeView : Form
    {
        public List<string> Textures;

        private readonly TaskCompletionSource<bool> _tcs;

        public TextureChangeView(List<string> txts, TaskCompletionSource<bool> tcs)
        {
            InitializeComponent();

            Textures = txts;

            foreach (string t in txts)
                this.txts.AppendText(t + Environment.NewLine);

            _tcs = tcs;
        }

        private void ApplyTexture_Click(object sender, EventArgs e)
        {
            var split = txts.Text.Split(Environment.NewLine.ToCharArray());
            var slist = split.ToList();
            slist.Remove(string.Empty);
            Textures = slist;

            _tcs.SetResult(true);
            Hide();
        }
    }
}

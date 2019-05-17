using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetsphereScnTool.Forms
{
    public partial class ImportOBJView : Form
    {
        public string SceneName;
        public string SceneSubname;
        public string TextureName;

        private readonly TaskCompletionSource<bool> _tcs;

        public ImportOBJView(TaskCompletionSource<bool> tcs)
        {
            InitializeComponent();
            _tcs = tcs;
        }

        private void ImportOBJView_Load(object sender, EventArgs e)
        {

        }

        private void SetNames_Click(object sender, EventArgs e)
        {
            SceneName = sceneName.Text;
            SceneSubname = sceneSubname.Text;
            TextureName = textureName.Text;

            _tcs.SetResult(true);
            Hide();
        }
    }
}

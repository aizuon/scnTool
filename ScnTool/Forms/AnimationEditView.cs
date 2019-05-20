using NetsphereScnTool.Scene.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NetsphereScnTool.Forms
{
    public partial class AnimationEditView : Form
    {
        public IDictionary<string, TransformKeyData2> Animation;
        public TaskCompletionSource<bool> _tcs;

        public AnimationEditView(IDictionary<string, TransformKeyData2> animation, TaskCompletionSource<bool> tcs)
        {
            InitializeComponent();

            Animation = animation;

            _tcs = tcs;

            var xml = new XDocument();
            var root = new XElement("animations");

            for (int i = 0; i < Animation.Count; i++)
            {
                var e = new XElement("animation");

                var keylist = Animation.Keys.ToList();
                var vallist = Animation.Values.ToList();

                e.SetAttributeValue("index", i);
                e.SetAttributeValue("name", keylist[i]);
                e.SetAttributeValue("tick_time", vallist[i].Duration.TotalMilliseconds);

                var e2 = new XElement("initials");

                var e3 = new XElement("init_position");
                e3.SetAttributeValue("X", vallist[i].TransformKey.Translation.X);
                e3.SetAttributeValue("Y", vallist[i].TransformKey.Translation.Y);
                e3.SetAttributeValue("Z", vallist[i].TransformKey.Translation.Z);

                var e4 = new XElement("init_rotation");
                e4.SetAttributeValue("X", vallist[i].TransformKey.Rotation.X);
                e4.SetAttributeValue("Y", vallist[i].TransformKey.Rotation.Y);
                e4.SetAttributeValue("Z", vallist[i].TransformKey.Rotation.Z);
                e4.SetAttributeValue("W", vallist[i].TransformKey.Rotation.W);

                var e5 = new XElement("init_scale");
                e5.SetAttributeValue("X", vallist[i].TransformKey.Scale.X);
                e5.SetAttributeValue("Y", vallist[i].TransformKey.Scale.Y);
                e5.SetAttributeValue("Z", vallist[i].TransformKey.Scale.Z);

                e2.Add(new XElement[] { e3, e4, e5 });
                e.Add(e2);
                root.Add(e);
            }

            xml.Add(root);

            txt.Text = xml.ToString();
        }

        private void ApplyAnimation_Click(object sender, EventArgs e)
        {
            var xml = XDocument.Parse(txt.Text);

            var es = xml.Root.Elements().ToList();
            var keylist = Animation.Keys.ToList();
            var vallist = Animation.Values.ToList();

            for (int i = 0; i < es.Count(); i++)
            {
                var ats = es[i].Attributes().ToList();

                keylist[i] = ats[1].Value;
                vallist[i].Duration = TimeSpan.FromMilliseconds(ats[2].Value.GetHashCode());

                var ems = es[i].Elements().ToList()[0].Elements().ToList();

                vallist[i].TransformKey.Translation = new Vector3(
                    float.Parse(ems[0].Attribute("X").Value),
                    float.Parse(ems[0].Attribute("Y").Value),
                    float.Parse(ems[0].Attribute("Z").Value)
                );

                vallist[i].TransformKey.Rotation = new Quaternion(
                    float.Parse(ems[1].Attribute("X").Value),
                    float.Parse(ems[1].Attribute("Y").Value),
                    float.Parse(ems[1].Attribute("Z").Value),
                    float.Parse(ems[1].Attribute("W").Value)
                );

                vallist[i].TransformKey.Scale = new Vector3(
                    float.Parse(ems[2].Attribute("X").Value),
                    float.Parse(ems[2].Attribute("Y").Value),
                    float.Parse(ems[2].Attribute("Z").Value)
                );
            }

            _tcs.SetResult(true);
            Hide();
        }
    }
}

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
        public IList<BoneAnimation> BoneAnimation;
        public IList<ModelAnimation> ModelAnimation;
        public TaskCompletionSource<bool> _tcs;

        private readonly AnimationType _type;

        public AnimationEditView(IList<BoneAnimation> animation, TaskCompletionSource<bool> tcs)
        {
            InitializeComponent();

            _tcs = tcs;
            _type = AnimationType.Bone;

            var xml = new XDocument();
            var root = new XElement("animations");

            for (int i = 0; i < animation.Count; i++)
            {
                var e = new XElement("animation");

                var transformkeydata = animation[i].TransformKeyData;

                e.SetAttributeValue("index", i);
                e.SetAttributeValue("name", animation[i].Name);
                e.SetAttributeValue("name2", animation[i].Copy == null ? " " : animation[i].Copy);
                e.SetAttributeValue("tick_time", transformkeydata.Duration.TotalMilliseconds);

                var e2 = new XElement("initials");

                var e3 = new XElement("init_position");
                e3.SetAttributeValue("X", transformkeydata.TransformKey.Translation.X);
                e3.SetAttributeValue("Y", transformkeydata.TransformKey.Translation.Y);
                e3.SetAttributeValue("Z", transformkeydata.TransformKey.Translation.Z);

                var e4 = new XElement("init_rotation");
                var eulerrotinit = transformkeydata.TransformKey.Rotation.ToEuler();
                e4.SetAttributeValue("X", eulerrotinit.X);
                e4.SetAttributeValue("Y", eulerrotinit.Y);
                e4.SetAttributeValue("Z", eulerrotinit.Z);

                var e5 = new XElement("init_scale");
                e5.SetAttributeValue("X", transformkeydata.TransformKey.Scale.X);
                e5.SetAttributeValue("Y", transformkeydata.TransformKey.Scale.Y);
                e5.SetAttributeValue("Z", transformkeydata.TransformKey.Scale.Z);

                e2.Add(new XElement[] { e3, e4, e5 });

                var e6 = new XElement("transform_key");
                for (int j = 0; j < transformkeydata.TransformKey.TKey.Count; j++)
                {
                    var e7 = new XElement("translation_key");
                    e7.SetAttributeValue("tick_time", transformkeydata.TransformKey.TKey[j].Duration.TotalMilliseconds);
                    e7.SetAttributeValue("X", transformkeydata.TransformKey.TKey[j].Translation.X);
                    e7.SetAttributeValue("Y", transformkeydata.TransformKey.TKey[j].Translation.Y);
                    e7.SetAttributeValue("Z", transformkeydata.TransformKey.TKey[j].Translation.Z);

                    e6.Add(e7);
                }

                for (int k = 0; k < transformkeydata.TransformKey.RKey.Count; k++)
                {
                    var e8 = new XElement("rotation_key");
                    e8.SetAttributeValue("tick_time", transformkeydata.TransformKey.RKey[k].Duration.TotalMilliseconds);
                    var eulerrot = transformkeydata.TransformKey.RKey[k].Rotation.ToEuler();
                    e8.SetAttributeValue("X", eulerrot.X);
                    e8.SetAttributeValue("Y", eulerrot.Y);
                    e8.SetAttributeValue("Z", eulerrot.Z);

                    e6.Add(e8);
                }

                for (int l = 0; l < transformkeydata.TransformKey.SKey.Count; l++)
                {
                    var e9 = new XElement("scale_key");
                    e9.SetAttributeValue("tick_time", transformkeydata.TransformKey.SKey[l].Duration.TotalMilliseconds);
                    e9.SetAttributeValue("X", transformkeydata.TransformKey.SKey[l].Scale.X);
                    e9.SetAttributeValue("Y", transformkeydata.TransformKey.SKey[l].Scale.Y);
                    e9.SetAttributeValue("Z", transformkeydata.TransformKey.SKey[l].Scale.Z);

                    e6.Add(e9);
                }

                var e10 = new XElement("float_keys");
                for (int m = 0; m < transformkeydata.FloatKeys.Count; m++)
                {
                    var e11 = new XElement("float_key");
                    e11.SetAttributeValue("tick_time", transformkeydata.FloatKeys[m].Duration.TotalMilliseconds);
                    e11.SetAttributeValue("alpha", transformkeydata.FloatKeys[m].Alpha);

                    e10.Add(e11);
                }

                e.Add(e2);
                e.Add(e6);
                e.Add(e10);
                root.Add(e);
            }

            xml.Add(root);

            txt.Text = xml.ToString();
        }

        public AnimationEditView(IList<ModelAnimation> animation, TaskCompletionSource<bool> tcs)
        {
            InitializeComponent();

            _tcs = tcs;
            _type = AnimationType.Model;

            var xml = new XDocument();
            var root = new XElement("animations");

            for (int i = 0; i < animation.Count; i++)
            {
                var e = new XElement("animation");

                var transformkeydata2 = animation[i].TransformKeyData2;

                e.SetAttributeValue("index", i);
                e.SetAttributeValue("name", animation[i].Name);
                e.SetAttributeValue("tick_time", transformkeydata2.Duration.TotalMilliseconds);

                var e2 = new XElement("initials");

                var e3 = new XElement("init_position");
                e3.SetAttributeValue("X", transformkeydata2.TransformKey.Translation.X);
                e3.SetAttributeValue("Y", transformkeydata2.TransformKey.Translation.Y);
                e3.SetAttributeValue("Z", transformkeydata2.TransformKey.Translation.Z);

                var e4 = new XElement("init_rotation");
                var eulerrotinit = transformkeydata2.TransformKey.Rotation.ToEuler();
                e4.SetAttributeValue("X", eulerrotinit.X);
                e4.SetAttributeValue("Y", eulerrotinit.Y);
                e4.SetAttributeValue("Z", eulerrotinit.Z);

                var e5 = new XElement("init_scale");
                e5.SetAttributeValue("X", transformkeydata2.TransformKey.Scale.X);
                e5.SetAttributeValue("Y", transformkeydata2.TransformKey.Scale.Y);
                e5.SetAttributeValue("Z", transformkeydata2.TransformKey.Scale.Z);

                e2.Add(new XElement[] { e3, e4, e5 });

                var e6 = new XElement("transform_key");
                for (int j = 0; j < transformkeydata2.TransformKey.TKey.Count; j++)
                {
                    var e7 = new XElement("translation_key");
                    e7.SetAttributeValue("tick_time", transformkeydata2.TransformKey.TKey[j].Duration.TotalMilliseconds);
                    e7.SetAttributeValue("X", transformkeydata2.TransformKey.TKey[j].Translation.X);
                    e7.SetAttributeValue("Y", transformkeydata2.TransformKey.TKey[j].Translation.Y);
                    e7.SetAttributeValue("Z", transformkeydata2.TransformKey.TKey[j].Translation.Z);

                    e6.Add(e7);
                }

                for (int k = 0; k < transformkeydata2.TransformKey.RKey.Count; k++)
                {
                    var e8 = new XElement("rotation_key");
                    e8.SetAttributeValue("tick_time", transformkeydata2.TransformKey.RKey[k].Duration.TotalMilliseconds);
                    var eulerrot = transformkeydata2.TransformKey.RKey[k].Rotation.ToEuler();
                    e8.SetAttributeValue("X", eulerrot.X);
                    e8.SetAttributeValue("Y", eulerrot.Y);
                    e8.SetAttributeValue("Z", eulerrot.Z);

                    e6.Add(e8);
                }

                for (int l = 0; l < transformkeydata2.TransformKey.SKey.Count; l++)
                {
                    var e9 = new XElement("scale_key");
                    e9.SetAttributeValue("tick_time", transformkeydata2.TransformKey.SKey[l].Duration.TotalMilliseconds);
                    e9.SetAttributeValue("X", transformkeydata2.TransformKey.SKey[l].Scale.X);
                    e9.SetAttributeValue("Y", transformkeydata2.TransformKey.SKey[l].Scale.Y);
                    e9.SetAttributeValue("Z", transformkeydata2.TransformKey.SKey[l].Scale.Z);

                    e6.Add(e9);
                }

                var e10 = new XElement("float_keys");
                for (int m = 0; m < transformkeydata2.FloatKeys.Count; m++)
                {
                    var e11 = new XElement("float_key");
                    e11.SetAttributeValue("tick_time", transformkeydata2.FloatKeys[m].Duration.TotalMilliseconds);
                    e11.SetAttributeValue("alpha", transformkeydata2.FloatKeys[m].Alpha);

                    e10.Add(e11);
                }

                var e12 = new XElement("morph_keys");
                for (int n = 0; n < transformkeydata2.MorphKeys.Count; n++)
                {
                    var e13 = new XElement("morph_key");
                    e13.SetAttributeValue("tick_time", transformkeydata2.MorphKeys[n].Duration.TotalMilliseconds);
                    
                    for (int o = 0; o < transformkeydata2.MorphKeys[n].Positions.Count; o++)
                    {
                        var e14 = new XElement("morph_position");
                        e14.SetAttributeValue("X", transformkeydata2.MorphKeys[n].Positions[o].X);
                        e14.SetAttributeValue("Y", transformkeydata2.MorphKeys[n].Positions[o].Y);
                        e14.SetAttributeValue("Z", transformkeydata2.MorphKeys[n].Positions[o].Z);

                        e13.Add(e14);
                    }

                    for (int p = 0; p < transformkeydata2.MorphKeys[n].Rotations.Count; p++)
                    {
                        var e15 = new XElement("morph_rotation");
                        var eulerrotmorph = transformkeydata2.MorphKeys[n].Rotations[p].ToEuler();
                        e15.SetAttributeValue("X", eulerrotmorph.X);
                        e15.SetAttributeValue("Y", eulerrotmorph.Y);
                        e15.SetAttributeValue("Z", eulerrotmorph.Z);

                        e13.Add(e15);
                    }

                    e12.Add(e13);
                }

                e.Add(e2);
                e.Add(e6);
                e.Add(e10);
                e.Add(e12);
                root.Add(e);
            }

            xml.Add(root);

            txt.Text = xml.ToString();
        }

        private void ApplyAnimation_Click(object sender, EventArgs e)
        {
            if (_type == AnimationType.Bone)
                ApplyAnimation_Click_Bone();
            else
                ApplyAnimation_Click_Model();

            _tcs.SetResult(true);
            Hide();
        }

        private void ApplyAnimation_Click_Bone()
        {
            var xml = XDocument.Parse(txt.Text);

            var es = xml.Root.Elements().ToList();

            BoneAnimation = new List<BoneAnimation>();

            for (int i = 0; i < es.Count(); i++)
            {
                var anim = new BoneAnimation();

                var ats = es[i].Attributes().ToList();
                var transformkeydata = new TransformKeyData();

                anim.Name = ats[1].Value;
                anim.Copy = ats[2].Value == " " ? null : ats[2].Value;
                transformkeydata.Duration = TimeSpan.FromMilliseconds(double.Parse(ats[3].Value));

                var inits = es[i].Elements().ToList()[0].Elements().ToList();
                if (inits.Count != 0)
                {
                    transformkeydata.TransformKey = new TransformKey();

                    transformkeydata.TransformKey.Translation = new Vector3(
                        float.Parse(inits[0].Attribute("X").Value),
                        float.Parse(inits[0].Attribute("Y").Value),
                        float.Parse(inits[0].Attribute("Z").Value)
                    );

                    transformkeydata.TransformKey.Rotation = new Vector3(
                        float.Parse(inits[1].Attribute("X").Value),
                        float.Parse(inits[1].Attribute("Y").Value),
                        float.Parse(inits[1].Attribute("Z").Value)
                    ).ToQuaternion();

                    transformkeydata.TransformKey.Scale = new Vector3(
                        float.Parse(inits[2].Attribute("X").Value),
                        float.Parse(inits[2].Attribute("Y").Value),
                        float.Parse(inits[2].Attribute("Z").Value)
                    );

                    var transformkey = es[i].Elements().ToList()[1].Elements();

                    var translationkey = transformkey.Where(_ => _.Name == "translation_key").ToList();
                    for (int j = 0; j < translationkey.Count(); j++)
                    {
                        transformkeydata.TransformKey.TKey.Add(new TKey
                        {
                            Duration = TimeSpan.FromMilliseconds(double.Parse(translationkey[j].Attribute("tick_time").Value)),
                            Translation = new Vector3(
                                float.Parse(translationkey[j].Attribute("X").Value),
                                float.Parse(translationkey[j].Attribute("Y").Value),
                                float.Parse(translationkey[j].Attribute("Z").Value)
                                )
                        });
                    }

                    var rotationkey = transformkey.Where(_ => _.Name == "rotation_key").ToList();
                    for (int k = 0; k < rotationkey.Count(); k++)
                    {
                        transformkeydata.TransformKey.RKey.Add(new RKey
                        {
                            Duration = TimeSpan.FromMilliseconds(double.Parse(rotationkey[k].Attribute("tick_time").Value)),
                            Rotation = new Vector3(
                                float.Parse(rotationkey[k].Attribute("X").Value),
                                float.Parse(rotationkey[k].Attribute("Y").Value),
                                float.Parse(rotationkey[k].Attribute("Z").Value)
                                ).ToQuaternion()
                        });
                    }

                    var scalekey = transformkey.Where(_ => _.Name == "scale_key").ToList();
                    for (int l = 0; l < scalekey.Count(); l++)
                    {
                        transformkeydata.TransformKey.SKey.Add(new SKey
                        {
                            Duration = TimeSpan.FromMilliseconds(double.Parse(scalekey[l].Attribute("tick_time").Value)),
                            Scale = new Vector3(
                                float.Parse(scalekey[l].Attribute("X").Value),
                                float.Parse(scalekey[l].Attribute("Y").Value),
                                float.Parse(scalekey[l].Attribute("Z").Value)
                                )
                        });
                    }
                }

                var floatkey = es[i].Elements().ToList()[2].Elements().ToList();
                for (int m = 0; m < floatkey.Count(); m++)
                {
                    transformkeydata.FloatKeys.Add(new FloatKey
                    {
                        Duration = TimeSpan.FromMilliseconds(double.Parse(floatkey[m].Attribute("tick_time").Value)),
                        Alpha = float.Parse(floatkey[m].Attribute("alpha").Value)
                    });
                }

                anim.TransformKeyData = transformkeydata;
                BoneAnimation.Add(anim);
            }
        }

        private void ApplyAnimation_Click_Model()
        {
            var xml = XDocument.Parse(txt.Text);

            var es = xml.Root.Elements().ToList();

            ModelAnimation = new List<ModelAnimation>();

            for (int i = 0; i < es.Count(); i++)
            {
                var anim = new ModelAnimation();

                var ats = es[i].Attributes().ToList();
                var transformkeydata2 = new TransformKeyData2
                {
                    TransformKey = new TransformKey()
                };

                anim.Name = ats[1].Value;
                transformkeydata2.Duration = TimeSpan.FromMilliseconds(double.Parse(ats[2].Value));

                var inits = es[i].Elements().ToList()[0].Elements().ToList();
                if (inits.Count != 0)
                {
                    transformkeydata2.TransformKey.Translation = new Vector3(
                    float.Parse(inits[0].Attribute("X").Value),
                    float.Parse(inits[0].Attribute("Y").Value),
                    float.Parse(inits[0].Attribute("Z").Value)
                );

                    transformkeydata2.TransformKey.Rotation = new Vector3(
                        float.Parse(inits[1].Attribute("X").Value),
                        float.Parse(inits[1].Attribute("Y").Value),
                        float.Parse(inits[1].Attribute("Z").Value)
                    ).ToQuaternion();

                    transformkeydata2.TransformKey.Scale = new Vector3(
                        float.Parse(inits[2].Attribute("X").Value),
                        float.Parse(inits[2].Attribute("Y").Value),
                        float.Parse(inits[2].Attribute("Z").Value)
                    );

                    var transformkey = es[i].Elements().ToList()[1].Elements();

                    var translationkey = transformkey.Where(_ => _.Name == "translation_key").ToList();
                    for (int j = 0; j < translationkey.Count(); j++)
                    {
                        transformkeydata2.TransformKey.TKey.Add(new TKey
                        {
                            Duration = TimeSpan.FromMilliseconds(double.Parse(translationkey[j].Attribute("tick_time").Value)),
                            Translation = new Vector3(
                                float.Parse(translationkey[j].Attribute("X").Value),
                                float.Parse(translationkey[j].Attribute("Y").Value),
                                float.Parse(translationkey[j].Attribute("Z").Value)
                                )
                        });
                    }

                    var rotationkey = transformkey.Where(_ => _.Name == "rotation_key").ToList();
                    for (int k = 0; k < rotationkey.Count(); k++)
                    {
                        transformkeydata2.TransformKey.RKey.Add(new RKey
                        {
                            Duration = TimeSpan.FromMilliseconds(double.Parse(rotationkey[k].Attribute("tick_time").Value)),
                            Rotation = new Vector3(
                                float.Parse(rotationkey[k].Attribute("X").Value),
                                float.Parse(rotationkey[k].Attribute("Y").Value),
                                float.Parse(rotationkey[k].Attribute("Z").Value)
                                ).ToQuaternion()
                        });
                    }

                    var scalekey = transformkey.Where(_ => _.Name == "scale_key").ToList();
                    for (int l = 0; l < scalekey.Count(); l++)
                    {
                        transformkeydata2.TransformKey.SKey.Add(new SKey
                        {
                            Duration = TimeSpan.FromMilliseconds(double.Parse(scalekey[l].Attribute("tick_time").Value)),
                            Scale = new Vector3(
                                float.Parse(scalekey[l].Attribute("X").Value),
                                float.Parse(scalekey[l].Attribute("Y").Value),
                                float.Parse(scalekey[l].Attribute("Z").Value)
                                )
                        });
                    }
                }

                var floatkey = es[i].Elements().ToList()[2].Elements().ToList();
                for (int m = 0; m < floatkey.Count(); m++)
                {
                    transformkeydata2.FloatKeys.Add(new FloatKey
                    {
                        Duration = TimeSpan.FromMilliseconds(double.Parse(floatkey[m].Attribute("tick_time").Value)),
                        Alpha = float.Parse(floatkey[m].Attribute("alpha").Value)
                    });
                }

                var morphkey = es[i].Elements().ToList()[3].Elements().ToList();
                for (int n = 0; n < morphkey.Count(); n++)
                {
                    var m = new MorphKey();

                    m.Duration = TimeSpan.FromMilliseconds(double.Parse(morphkey[n].Attribute("tick_time").Value));

                    var mpl = new List<Vector3>();
                    var mp = morphkey[n].Elements().Where(_ => _.Name == "morph_position").ToList();
                    for (int o = 0; o < mp.Count; o++)
                    {
                        mpl.Add(new Vector3(
                            float.Parse(mp[o].Attribute("X").Value),
                            float.Parse(mp[o].Attribute("Y").Value),
                            float.Parse(mp[o].Attribute("Z").Value)));
                    }
                    m.Positions = mpl;

                    var mrl = new List<Quaternion>();
                    var mr = morphkey[n].Elements().Where(_ => _.Name == "morph_rotation").ToList();
                    for (int p = 0; p < mr.Count; p++)
                    {
                        mrl.Add(new Vector3(
                            float.Parse(mr[p].Attribute("X").Value),
                            float.Parse(mr[p].Attribute("Y").Value),
                            float.Parse(mr[p].Attribute("Z").Value)).ToQuaternion());
                    }
                    m.Rotations = mrl;

                    transformkeydata2.MorphKeys.Add(m);
                }

                anim.TransformKeyData2 = transformkeydata2;
                ModelAnimation.Add(anim);
            }
        }

        private enum AnimationType : byte
        {
            Bone,
            Model
        }
    }
}

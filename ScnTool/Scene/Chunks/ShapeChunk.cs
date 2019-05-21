using BlubLib.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace NetsphereScnTool.Scene.Chunks
{
    public class ShapeChunk : SceneChunk
    {
        public override ChunkType ChunkType => ChunkType.Shape;

        public IList<Tuple<Vector3, Vector3>> Unk { get; set; }

        public ShapeChunk(SceneContainer container)
            : base(container)
        {
            Unk = new List<Tuple<Vector3, Vector3>>();
        }

        public override void Serialize(Stream stream)
        {
            base.Serialize(stream);

            using (var w = stream.ToBinaryWriter(true))
            {
                w.Write(Version);
                if (Version >= 0.1000000014901161f)
                {
                    w.Write(Unk.Count);
                    foreach (var unk in Unk)
                    {
                        w.Write(unk.Item1.X);
                        w.Write(unk.Item1.Y);
                        w.Write(unk.Item1.Z);

                        w.Write(unk.Item2.X);
                        w.Write(unk.Item2.Y);
                        w.Write(unk.Item2.Z);
                    }
                }
            }
        }

        public override void Deserialize(Stream stream)
        {
            base.Deserialize(stream);

            using (var r = stream.ToBinaryReader(true))
            {
                Version = r.ReadSingle();

                if (Version >= 0.1000000014901161f)
                {
                    uint count = r.ReadUInt32();
                    for (int i = 0; i < count; i++)
                    {
                        Unk.Add(Tuple.Create(new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle()),
                            new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle())));
                    }
                }
            }
        }
    }
}

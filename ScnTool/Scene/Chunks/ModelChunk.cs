using BlubLib.IO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace NetsphereScnTool.Scene.Chunks
{
    public class ModelChunk : SceneChunk
    {
        public override ChunkType ChunkType => ChunkType.ModelData;

        public Shader Shader { get; set; }
        public TextureData TextureData { get; set; }
        public MeshData Mesh { get; set; }
        public IList<WeightBone> WeightBone { get; set; }
        public IList<ModelAnimation> Animation { get; set; }

        public ModelChunk(SceneContainer container)
            : base(container)
        {
            Shader = Shader.None;
            TextureData = new TextureData(this);
            Mesh = new MeshData(this);
            WeightBone = new List<WeightBone>();
            Animation = new List<ModelAnimation>();
        }

        public override void Serialize(Stream stream)
        {
            base.Serialize(stream);

            using (var w = stream.ToBinaryWriter(true))
            {
                w.Write(Version);

                w.WriteEnum(Shader);

                w.Serialize(TextureData);
                w.Serialize(Mesh);

                w.Write(WeightBone.Count);
                w.Serialize(WeightBone);

                w.Write(Animation.Count);
                foreach (var pair in Animation)
                {
                    w.WriteCString(pair.Name);
                    w.Serialize(pair.TransformKeyData2);
                }
            }
        }

        public override void Deserialize(Stream stream)
        {
            base.Deserialize(stream);

            using (var r = stream.ToBinaryReader(true))
            {
                // ## CoreLib::Scene::CRenderable
                Version = r.ReadSingle();
                Shader = r.ReadEnum<Shader>();
                // ## CoreLib::Scene::CRenderable

                TextureData = new TextureData(this);
                TextureData.Deserialize(stream);

                Mesh = new MeshData(this);
                Mesh.Deserialize(stream);

                WeightBone = r.DeserializeArray<WeightBone>(r.ReadInt32()).ToList();

                int count = r.ReadInt32();
                for (int i = 0; i < count; ++i)
                    Animation.Add(new ModelAnimation { Name = r.ReadCString(), TransformKeyData2 = r.Deserialize<TransformKeyData2>() });
            }
        }
    }

    public class MeshData : IManualSerializer
    {
        public ModelChunk ModelChunk { get; }

        public List<Vector3> Vertices { get; set; }
        public List<Vector3> Faces { get; set; }
        public List<Vector3> Normals { get; set; }
        public List<Vector2> UV { get; set; }
        public List<Vector2> UV2 { get; set; }

        public List<Vector3> Tangents { get; set; }

        public MeshData(ModelChunk modelChunk)
        {
            Vertices = new List<Vector3>();
            Faces = new List<Vector3>();
            Normals = new List<Vector3>();
            UV = new List<Vector2>();
            UV2 = new List<Vector2>();
            Tangents = new List<Vector3>();

            ModelChunk = modelChunk;
        }

        public virtual void Serialize(Stream stream)
        {
            using (var w = stream.ToBinaryWriter(true))
            {
                w.Write(Vertices.Count);
                foreach (var vertex in Vertices)
                {
                    w.Write(vertex.X);
                    w.Write(vertex.Y);
                    w.Write(vertex.Z);
                }

                w.Write(Faces.Count);
                foreach (var face in Faces)
                {
                    w.Write((short)face.X);
                    w.Write((short)face.Y);
                    w.Write((short)face.Z);
                }

                w.Write(Normals.Count);
                foreach (var normal in Normals)
                {
                    w.Write(normal.X);
                    w.Write(normal.Y);
                    w.Write(normal.Z);
                }

                w.Write(UV.Count);
                foreach (var uv in UV)
                {
                    w.Write(uv.X);
                    w.Write(uv.Y);
                }

                if (ModelChunk.TextureData.ExtraUV == 1)
                {
                    foreach (var uv in UV2)
                    {
                        w.Write(uv.X);
                        w.Write(uv.Y);
                    }
                }

                w.Write(Tangents.Count);
                foreach (var unk in Tangents)
                {
                    w.Write(unk.X);
                    w.Write(unk.Y);
                    w.Write(unk.Z);
                }
            }
        }

        public virtual void Deserialize(Stream stream)
        {
            using (var r = stream.ToBinaryReader(true))
            {
                int count = r.ReadInt32();
                for (int i = 0; i < count; i++)
                    Vertices.Add(new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle()));

                count = r.ReadInt32();
                for (int i = 0; i < count; i++)
                    Faces.Add(new Vector3(r.ReadInt16(), r.ReadInt16(), r.ReadInt16()));

                count = r.ReadInt32();
                for (int i = 0; i < count; i++)
                    Normals.Add(new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle()));

                count = r.ReadInt32();
                for (int i = 0; i < count; i++)
                    UV.Add(new Vector2(r.ReadSingle(), r.ReadSingle()));

                if (ModelChunk.TextureData.ExtraUV == 1)
                {
                    for (int i = 0; i < count; i++)
                        UV2.Add(new Vector2(r.ReadSingle(), r.ReadSingle()));
                }

                count = r.ReadInt32();
                for (int i = 0; i < count; i++)
                    Tangents.Add(new Vector3(r.ReadSingle(), r.ReadSingle(), r.ReadSingle()));
            }
        }
    }

    public class WeightBone : IManualSerializer
    {
        public string Name { get; set; }
        public Matrix4x4 Matrix { get; set; }
        public IList<WeightData> Weight { get; set; }

        public WeightBone()
        {
            Name = "";
            Matrix = Matrix4x4.Identity;
            Weight = new List<WeightData>();
        }

        public virtual void Serialize(Stream stream)
        {
            using (var w = stream.ToBinaryWriter(true))
            {
                w.WriteCString(Name);
                w.Write(Matrix);

                w.Write(Weight.Count);
                foreach (var weight in Weight)
                {
                    w.Write(weight.Vertex);
                    w.Write(weight.Weight);
                }
            }
        }

        public virtual void Deserialize(Stream stream)
        {
            using (var r = stream.ToBinaryReader(true))
            {
                Name = r.ReadCString();
                Matrix = r.ReadMatrix();

                uint count = r.ReadUInt32();
                for (int i = 0; i < count; i++)
                    Weight.Add(new WeightData { Vertex = r.ReadUInt32(), Weight = r.ReadSingle() });
            }
        }
    }

    public struct WeightData
    {
        public uint Vertex;
        public float Weight;
    }

    // Game::CActorGeomData
    public class TextureData : IManualSerializer
    {
        public float Version { get; set; }
        public ModelChunk ModelChunk { get; }
        public uint ExtraUV { get; set; }
        public List<TextureEntry> Textures { get; set; }

        public TextureData(ModelChunk modelChunk)
        {
            ModelChunk = modelChunk;
            Textures = new List<TextureEntry>();
        }

        public virtual void Serialize(Stream stream)
        {
            using (var w = stream.ToBinaryWriter(true))
            {
                w.Write(Version);
                if (Version >= 0.2000000029802322f)
                    w.Write(ExtraUV);

                w.Write(Textures.Count);
                foreach (var texture in Textures)
                {
                    w.WriteCString(texture.FileName, 1024);
                    if (Version >= 0.2000000029802322f)
                        w.WriteCString(texture.FileName2, 1024);

                    w.Write(texture.FaceCounter);
                    w.Write(texture.FaceCount);
                }
            }
        }

        public virtual void Deserialize(Stream stream)
        {
            using (var r = stream.ToBinaryReader(true))
            {
                Version = r.ReadSingle();

                if (Version >= 0.2000000029802322f)
                    ExtraUV = r.ReadUInt32();

                uint count = r.ReadUInt32();
                for (int i = 0; i < count; i++)
                {
                    var textureData = new TextureEntry
                    {
                        FileName = r.ReadCString(1024),
                        FileName2 = ""
                    };

                    if (Version >= 0.2000000029802322f)
                        textureData.FileName2 = r.ReadCString(1024);

                    textureData.FaceCounter = r.ReadInt32();
                    textureData.FaceCount = r.ReadInt32();

                    Textures.Add(textureData);
                }
            }
        }
    }

    public struct TextureEntry
    {
        public string FileName;
        public string FileName2;
        public int FaceCounter;
        public int FaceCount;
    }
}

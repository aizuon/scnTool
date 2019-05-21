using BlubLib.IO;
using NetsphereScnTool.Scene.Chunks;
using NetsphereScnTool.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace NetsphereScnTool.Scene
{
    public class SceneContainer : SortableBindingList<SceneChunk>
    {
        public SceneHeader Header { get; set; }

        public SceneContainer()
        {
            Header = new SceneHeader();
        }

        public SceneContainer(IEnumerable<SceneChunk> collection)
            : base(collection)
        {
            Header = new SceneHeader();
        }

        public object Clone()
        {
            var container = new SceneContainer();
            container.AddRange(this);
            container.Header = Header;

            return container;
        }

        #region ReadFrom

        public static SceneContainer ReadFrom(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                return ReadFrom(fs);
        }

        public static SceneContainer ReadFrom(byte[] data)
        {
            using (var s = new MemoryStream(data))
                return ReadFrom(s);
        }

        public static SceneContainer ReadFrom(Stream stream)
        {
            var container = new SceneContainer();

            using (var r = new BinaryReader(stream))
            {
                container.Header.Deserialize(stream);

                // CoreLib::Scene::CSceneGroup
                uint chunkCount = r.ReadUInt32();

                if (container.Header.Version >= 0.2000000029802322f)
                    r.ReadByte(); // ToDo ReadString

                for (int i = 0; i < chunkCount; i++)
                {
                    var type = r.ReadEnum<ChunkType>();
                    string name = r.ReadCString();
                    string subName = r.ReadCString();

                    SceneChunk chunk;
                    switch (type)
                    {
                        case ChunkType.ModelData:
                            chunk = new ModelChunk(container)
                            {
                                Name = name,
                                SubName = subName,
                                Image = Properties.Resources.model
                            };
                            chunk.Deserialize(stream);
                            container.Add(chunk);
                            break;

                        case ChunkType.Box:
                            chunk = new BoxChunk(container)
                            {
                                Name = name,
                                SubName = subName,
                                Image = Properties.Resources.box
                            };
                            chunk.Deserialize(stream);
                            container.Add(chunk);
                            break;

                        case ChunkType.Bone:
                            chunk = new BoneChunk(container)
                            {
                                Name = name,
                                SubName = subName,
                                Image = Properties.Resources.bone
                            };
                            chunk.Deserialize(stream);
                            container.Add(chunk);
                            break;

                        case ChunkType.BoneSystem:
                            chunk = new BoneSystemChunk(container)
                            {
                                Name = name,
                                SubName = subName,
                                Image = Properties.Resources.bone_system
                            };
                            chunk.Deserialize(stream);
                            container.Add(chunk);
                            break;

                        case ChunkType.Shape:
                            chunk = new ShapeChunk(container)
                            {
                                Name = name,
                                SubName = subName,
                                Image = Properties.Resources.shape
                            };
                            chunk.Deserialize(stream);
                            container.Add(chunk);
                            break;

                        case ChunkType.SkyDirect1:
                            chunk = new SkyDirect1Chunk(container)
                            {
                                Name = name,
                                SubName = subName,
                                Image = Properties.Resources.sky
                            };
                            chunk.Deserialize(stream);
                            container.Add(chunk);
                            break;

                        default:
                            throw new Exception($"Unknown chunk type: 0x{(int)type:X4} StreamPosition: {r.BaseStream.Position}");
                    }
                }
            }

            return container;
        }

        #endregion

        public void Write(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                Write(fs);
        }

        public void Write(Stream stream)
        {
            using (var w = new BinaryWriter(stream))
            {
                w.Serialize(Header);

                w.Write(Count);
                if (Header.Version >= 0.2000000029802322f)
                    w.Write((byte)0);

                foreach (var chunk in this)
                {
                    w.WriteEnum(chunk.ChunkType);
                    w.WriteCString(chunk.Name);
                    w.WriteCString(chunk.SubName);

                    w.Serialize(chunk);
                }
            }
        }
    }

    public class SceneHeader : IManualSerializer
    {
        public const uint c_Version = 1;
        public const uint Magic = 0x6278d57a;

        public string Name { get; set; }
        public string SubName { get; set; }
        public float Version { get; set; }
        public Matrix4x4 Matrix { get; set; }

        internal SceneHeader()
        {
            Name = "";
            SubName = "";
            Version = 0.1f;
            Matrix = Matrix4x4.Identity;
        }

        public void Serialize(Stream stream)
        {
            using (var w = stream.ToBinaryWriter(true))
            {
                w.Write(c_Version);
                w.Write(Magic);

                w.WriteCString(Name);
                w.WriteCString(SubName);

                w.Write(Version);
                w.Write(Matrix);
                w.Write(Version);
            }
        }

        public void Deserialize(Stream stream)
        {
            using (var r = stream.ToBinaryReader(true))
            {
                uint value;
                do
                {
                    value = r.ReadUInt32();
                    if (value != Magic)
                        r.BaseStream.Seek(-3, SeekOrigin.Current);
                } while (value != Magic);

                Name = r.ReadCString();
                SubName = r.ReadCString();

                // CoreLib::Scene::CSceneNode
                Version = r.ReadSingle();
                Matrix = r.ReadMatrix();

                // CoreLib::Scene::CSceneGroup
                Version = r.ReadSingle();
            }
        }
    }
}

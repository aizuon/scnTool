using NetsphereScnTool.Scene.Chunks;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;

namespace NetsphereScnTool.Utility
{
    public class Obj_Exporter
    {
        public void Export(string fileName, ModelChunk model)
        {
            try
            { using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None)) { } }
            catch { fileName = fileName.Replace(model.Name, "invalid_file_name"); }

            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var w = new StreamWriter(fs))
            {
                WriteObject(w, model, fileName);
            }
            string mtl = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".mtl");
            using (var fs = new FileStream(mtl, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var w = new StreamWriter(fs))
            {
                WriteMaterial(w, model);
            }
        }
        public void Export(string fileName, ICollection<ModelChunk> models)
        {
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var w = new StreamWriter(fs))
            {
                WriteObject(w, models, fileName);
            }
            string mtl = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".mtl");
            using (var fs = new FileStream(mtl, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var w = new StreamWriter(fs))
            {
                WriteMaterial(w, models);
            }
        }

        private void WriteObject(TextWriter w, ModelChunk model, string fileName)
        {
            w.WriteLine("mtllib {0}.mtl", Path.GetFileNameWithoutExtension(fileName));
            w.WriteLine();
            Vector3 scale;
            Quaternion rotation;
            Vector3 translation;

            Matrix4x4.Decompose(model.Matrix, out scale, out rotation, out translation);

            foreach (var vertex in model.Mesh.Vertices)
            {
                var v = Vector3.Transform(vertex, model.Matrix);  //Matrice invertita
                w.WriteLine(string.Format(CultureInfo.InvariantCulture, "v {0:0.0000} {1:0.0000} {2:0.0000}", v.X/100, v.Y/100, v.Z/100));
            }
            w.WriteLine();
            foreach (var vn in model.Mesh.Normals)
                w.WriteLine(string.Format(CultureInfo.InvariantCulture, "vn {0:0.0000} {1:0.0000} {2:0.0000}", vn.X/100, vn.Y/100, vn.Z/100));
            w.WriteLine();
            foreach (var vt in model.Mesh.UV)
                w.WriteLine(string.Format(CultureInfo.InvariantCulture, "vt {0:0.0000} {1:0.0000} {2:0.0000}", vt.X/100, 0.0f - vt.Y/100, 0.0f));
            w.WriteLine();
            w.WriteLine("g " + model.Name);
            // Face indices: S4 starts at 0 - Wavefront OBJ at 1
            foreach (var texture in model.TextureData.Textures)
            {
                var tex = texture.FileName;
                foreach (var c in Path.GetInvalidPathChars())
                    tex = tex.Replace(c, '?');

                foreach (var c in Path.GetInvalidFileNameChars())
                    tex = tex.Replace(c, '?');

                tex = tex.Replace("?", "");
                tex = tex.Replace("�", "");

                w.WriteLine("usemtl " + Path.GetFileNameWithoutExtension(tex));
                w.WriteLine();
                for (int i = texture.FaceCounter; i < (texture.FaceCount + texture.FaceCounter); i++)
                {
                    var face = model.Mesh.Faces[i];
                    float x = face.X + 1;
                    float y = face.Y + 1;
                    float z = face.Z + 1;
                    w.WriteLine(string.Format(CultureInfo.InvariantCulture, "f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}", x, y, z));
                }
                w.WriteLine();
            }
        }
        private void WriteMaterial(TextWriter w, ModelChunk model)
        {
            var ls = new List<string>();
            foreach (var texture in model.TextureData.Textures)
            {
                var tex = texture.FileName;
                foreach (var c in Path.GetInvalidPathChars())
                    tex = tex.Replace(c, '?');

                foreach (var c in Path.GetInvalidFileNameChars())
                    tex = tex.Replace(c, '?');

                tex = tex.Replace("?", "");
                tex = tex.Replace("�", "");

                string name = Path.GetFileNameWithoutExtension(tex);
                if (ls.Contains(name))
                    continue;
                w.WriteLine("newmtl {0}", name);
                w.WriteLine("\tNs 10.0000");
                w.WriteLine("\tNi 1.5000");
                w.WriteLine("\td 1.0000");
                w.WriteLine("\tTr 0.0000");
                w.WriteLine("\tTf 1.0000 1.0000 1.0000");
                w.WriteLine("\tillum 2");
                w.WriteLine("\tKa 0.5880 0.5880 0.5880");
                w.WriteLine("\tKd 0.5880 0.5880 0.5880");
                w.WriteLine("\tKs 0.0000 0.0000 0.0000");
                w.WriteLine("\tKe 0.0000 0.0000 0.0000");
                w.WriteLine("\tmap_Ka {0}", tex);
                w.WriteLine("\tmap_Kd {0}", tex);
                w.WriteLine();
                ls.Add(name);
            }
        }
        private void WriteObject(TextWriter w, IEnumerable<ModelChunk> models, string fileName)
        {
            w.WriteLine("mtllib {0}.mtl", Path.GetFileNameWithoutExtension(fileName));
            w.WriteLine();
            int vertexCounter = 0;
            foreach (var model in models)
            {
                Vector3 scale;
                Quaternion rotation;
                Vector3 translation;

                Matrix4x4.Decompose(model.Matrix, out scale, out rotation, out translation);

                foreach (var vertex in model.Mesh.Vertices)
                {
                    var v = Vector3.Transform(vertex, model.Matrix);
                    w.WriteLine(string.Format(CultureInfo.InvariantCulture, "v {0:0.0000} {1:0.0000} {2:0.0000}", v.X/100, v.Y/100, v.Z/100));
                }
                w.WriteLine();
                foreach (var vn in model.Mesh.Normals)
                {
                    w.WriteLine(string.Format(CultureInfo.InvariantCulture, "vn {0:0.0000} {1:0.0000} {2:0.0000}", vn.X/100, vn.Y/100, vn.Z/100));
                }
                w.WriteLine();
                foreach (var vt in model.Mesh.UV)
                {
                    w.WriteLine(string.Format(CultureInfo.InvariantCulture, "vt {0:0.0000} {1:0.0000} {2:0.0000}", vt.X/100, 0.0f - vt.Y/100, 0.0f));
                }
                w.WriteLine();
                w.WriteLine("g " + model.Name);
                // Face indices: S4 starts at 0 - Wavefront OBJ at 1
                foreach (var texture in model.TextureData.Textures)
                {
                    var tex = texture.FileName;
                    foreach (var c in Path.GetInvalidPathChars())
                        tex = tex.Replace(c, '?');

                    foreach (var c in Path.GetInvalidFileNameChars())
                        tex = tex.Replace(c, '?');

                    tex = tex.Replace("?", "");
                    tex = tex.Replace("�", "");

                    w.WriteLine("usemtl " + Path.GetFileNameWithoutExtension(tex));
                    w.WriteLine();
                    for (int i = texture.FaceCounter; i < (texture.FaceCount + texture.FaceCounter); i++)
                    {
                        var face = model.Mesh.Faces[i];
                        float x = face.X + 1 + vertexCounter;
                        float y = face.Y + 1 + vertexCounter;
                        float z = face.Z + 1 + vertexCounter;
                        w.WriteLine(string.Format(CultureInfo.InvariantCulture, "f {0}/{0}/{0} {1}/{2}/{1} {2}/{2}/{2}", x, y, z));
                    }
                    w.WriteLine();
                }
                vertexCounter += model.Mesh.Vertices.Count;
            }
        }
        private void WriteMaterial(TextWriter w, IEnumerable<ModelChunk> models)
        {
            var ls = new List<string>();
            foreach (var model in models)
            {
                foreach (var texture in model.TextureData.Textures)
                {
                    var tex = texture.FileName;
                    foreach (var c in Path.GetInvalidPathChars())
                        tex = tex.Replace(c, '?');

                    foreach (var c in Path.GetInvalidFileNameChars())
                        tex = tex.Replace(c, '?');

                    tex = tex.Replace("?", "");
                    tex = tex.Replace("�", "");

                    string name = Path.GetFileNameWithoutExtension(tex);
                    if (ls.Contains(name))
                        continue;
                    w.WriteLine("newmtl {0}", name);
                    w.WriteLine("\tNs 10.0000");
                    w.WriteLine("\tNi 1.5000");
                    w.WriteLine("\td 1.0000");
                    w.WriteLine("\tTr 0.0000");
                    w.WriteLine("\tTf 1.0000 1.0000 1.0000");
                    w.WriteLine("\tillum 2");
                    w.WriteLine("\tKa 0.5880 0.5880 0.5880");
                    w.WriteLine("\tKd 0.5880 0.5880 0.5880");
                    w.WriteLine("\tKs 0.0000 0.0000 0.0000");
                    w.WriteLine("\tKe 0.0000 0.0000 0.0000");
                    w.WriteLine("\tmap_Ka {0}", tex.Replace(".tga", ".dds"));
                    w.WriteLine("\tmap_Kd {0}", tex.Replace(".tga", ".dds"));
                    w.WriteLine();
                    ls.Add(name);
                }
            }
        }
    }
}

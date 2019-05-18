using NetsphereScnTool.Scene;
using NetsphereScnTool.Scene.Chunks;
using System.Collections.Generic;
using System.Linq;

namespace NetsphereScnTool.Utility
{
    public class Obj_Editor
    {
        public void EditShader(ModelChunk model, RenderState shader)
        {
            model.RenderState = shader;
        }

        public void ChangeTexture(ModelChunk model, List<string> textures)
        {
            var texts = model.TextureData.Textures;

            var txt = new List<TextureEntry>();

            for (var i = 0; i < texts.Count; i++)
            {
                txt.Add(new TextureEntry
                {
                    FileName = textures[i],
                    FileName2 = texts[i].FileName2,
                    FaceCount = texts[i].FaceCount,
                    FaceCounter = texts[i].FaceCounter
                });
            }

            model.TextureData.Textures = txt;
        }
    }
}

using NetsphereScnTool.Scene;
using NetsphereScnTool.Scene.Chunks;
using System.Collections.Generic;

namespace NetsphereScnTool.Utility
{
    public class Obj_Editor
    {
        public void EditShader(ModelChunk model, Shader shader) => model.Shader = shader;

        public void ChangeTexture(ModelChunk model, IList<string> textures)
        {
            var texts = model.TextureData.Textures;

            var txt = new List<TextureEntry>();

            for (int i = 0; i < texts.Count; i++)
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

        public void EditAnimation(BoneChunk bone, IList<BoneAnimation> animation) => bone.Animation = animation;

        public void EditAnimation(ModelChunk model, IList<ModelAnimation> animation) => model.Animation = animation;
    }
}

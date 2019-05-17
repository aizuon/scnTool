namespace ObjParser.Types
{
    interface IType
    {
        // v = Vertex
        // vt = TextureVertex
        // vn = Naturals
        // f = Faces

        void LoadFromStringArray(string[] data);
    }
}

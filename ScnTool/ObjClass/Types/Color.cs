namespace ObjParser.Types
{
    public class Color : IType
    {
        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }

        public Color()
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public void LoadFromStringArray(string[] data)
        {
            if (data.Length != 4)
                return;
            r = float.Parse(data[1]);
            g = float.Parse(data[2]);
            b = float.Parse(data[3]);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", r, g, b);
        }
    }
}

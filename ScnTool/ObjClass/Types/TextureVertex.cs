using System;

namespace ObjParser.Types
{
    public class TextureVertex : IType
    {
        public const int MinimumDataLength = 3;
        public const string Prefix = "vt";

        public double X { get; set; }

        public double Y { get; set; }

        public int Index { get; set; }

        public void LoadFromStringArray(string[] data)
        {
            if (data.Length < MinimumDataLength)
                throw new ArgumentException("Input array must be of minimum length " + MinimumDataLength, "data");

            if (!data[0].ToLower().Equals(Prefix))
                throw new ArgumentException("Data prefix must be '" + Prefix + "'", "data");

            double x, y;

            x = Convert.ToDouble(data[1].Replace(".", ","));
            y = Convert.ToDouble(data[2].Replace(".", ","));

            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("vt {0} {1}", X, Y);
        }
    }
}

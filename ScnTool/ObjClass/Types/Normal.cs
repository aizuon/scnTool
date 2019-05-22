using System;

namespace ObjParser.Types
{
    public class Normal : IType
    {
        public const int MinimumDataLength = 4;
        public const string Prefix = "vn";

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public int Index { get; set; }

        public void LoadFromStringArray(string[] data)
        {
            if (data.Length < MinimumDataLength)
                throw new ArgumentException("Input array must be of minimum length " + MinimumDataLength, "data");

            if (!data[0].ToLower().Equals(Prefix))
                throw new ArgumentException("Data prefix must be '" + Prefix + "'", "data");

            double x, y, z;

            x = Convert.ToDouble(data[1].Replace(".", ","));
            y = Convert.ToDouble(data[2].Replace(".", ","));
            z = Convert.ToDouble(data[3].Replace(".", ","));

            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() => string.Format("v {0} {1} {2}", X, Y, Z);
    }
}

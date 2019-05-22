namespace ObjParser
{
    public class Extent
    {
        public double XMax { get; set; }
        public double XMin { get; set; }
        public double YMax { get; set; }
        public double YMin { get; set; }
        public double ZMax { get; set; }
        public double ZMin { get; set; }

        public double XSize => XMax - XMin;
        public double YSize => YMax - YMin;
        public double ZSize => ZMax - ZMin;
    }
}

using System.IO;

namespace BlubLib.IO
{
    public interface IManualSerializer
    {
        void Serialize(Stream stream);
        void Deserialize(Stream stream);
    }
}

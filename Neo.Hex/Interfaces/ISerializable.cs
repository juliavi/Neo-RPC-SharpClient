using System.IO;

namespace Neo.Base.Interfaces
{
    /// <summary>
    /// Provide an interface for serialization
    /// </summary>
    /// <note>Taken from neo-project</note>
    public interface ISerializable
    {
        int Size { get; }

        /// <summary>
        /// Serialization
        /// </summary>
        /// <param name="writer">Stored serialized results</param>
        void Serialize(BinaryWriter writer);

        /// <summary>
        /// Deserialization
        /// </summary>
        /// <param name="reader">Data Source</param>
        void Deserialize(BinaryReader reader);
    }
}

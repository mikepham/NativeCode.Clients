using System.Runtime.Serialization;

namespace NativeCode.BitBucket.Models
{
    [DataContract]
    public class PagingOptions
    {
        [DataMember]
        public string Next { get; protected set; }

        [DataMember]
        public short Size { get; protected set; }
    }
}
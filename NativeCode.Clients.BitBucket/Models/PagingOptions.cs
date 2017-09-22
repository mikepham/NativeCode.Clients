namespace NativeCode.Clients.BitBucket.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PagingOptions
    {
        [DataMember]
        public string Next { get; protected set; }

        [DataMember]
        public short Size { get; protected set; }
    }
}
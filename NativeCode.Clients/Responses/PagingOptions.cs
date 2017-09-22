namespace NativeCode.Clients.Responses
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
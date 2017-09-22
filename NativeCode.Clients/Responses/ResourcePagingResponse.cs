namespace NativeCode.Clients.Responses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class ResourcePagingResponse<T> : PagingOptions, IResponse
    {
        [DataMember]
        public IEnumerable<ErrorResponse> Errors { get; protected set; } = Enumerable.Empty<ErrorResponse>();

        [DataMember]
        public short Page { get; protected set; }

        [DataMember]
        public short Pagelen { get; protected set; }

        [DataMember]
        public IEnumerable<T> Values { get; protected set; } = Enumerable.Empty<T>();
    }
}
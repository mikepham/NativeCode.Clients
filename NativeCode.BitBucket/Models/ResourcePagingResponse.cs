using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace NativeCode.BitBucket.Models
{
    [DataContract]
    public class ResourcePagingResponse<T> : PagingOptions, IResponse
    {
        [DataMember]
        public IEnumerable<ErrorResponse> Errors { get; protected set; } = Enumerable.Empty<ErrorResponse>();
        
        [DataMember]
        public string Next { get; protected set; }

        [DataMember]
        public short Page { get; protected set; }

        [DataMember]
        public int Pagelen { get; protected set; }

        [DataMember]
        public IEnumerable<T> Values { get; protected set; } = Enumerable.Empty<T>();
    }
}
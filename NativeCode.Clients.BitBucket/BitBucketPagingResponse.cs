namespace NativeCode.Clients.BitBucket
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Responses;

    [DataContract]
    public class BitBucketPagingResponse<T> : PagingResponse<T>
    {
        [DataMember]
        public string Next { get; protected set; }

        [DataMember]
        public short Page { get; protected set; }

        [DataMember]
        public short Pagelen { get; protected set; }

        [DataMember]
        public short Size { get; protected set; }

        [DataMember]
        public IEnumerable<T> Values { get; protected set; } = Enumerable.Empty<T>();

        public override int GetPageIndex()
        {
            return this.Page;
        }

        public override int GetPageCount()
        {
            return this.Pagelen;
        }

        public override int GetPageSize()
        {
            return this.Size;
        }

        public override string GetNextPageUrl()
        {
            return this.Next;
        }
    }
}
using System.Collections.Generic;

namespace NativeCode.BitBucket.Models
{
    public abstract class ResourcePagingResponse<T> : PagingOptions, IResponse
    {
        public short Page { get; }

        public int Pagelen { get; }

        public IEnumerable<T> Values { get; }
        public IEnumerable<ErrorResponse> Errors { get; }
    }
}
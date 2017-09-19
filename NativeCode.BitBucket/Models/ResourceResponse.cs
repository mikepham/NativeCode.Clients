using System.Collections.Generic;

namespace NativeCode.BitBucket.Models
{
    public abstract class ResourceResponse<T> : IResponse
    {
        public IEnumerable<ErrorResponse> Errors { get; }
    }
}
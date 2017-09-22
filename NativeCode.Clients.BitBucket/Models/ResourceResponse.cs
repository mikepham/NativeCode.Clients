namespace NativeCode.Clients.BitBucket.Models
{
    using System.Collections.Generic;

    public abstract class ResourceResponse<T> : IResponse
    {
        public IEnumerable<ErrorResponse> Errors { get; }
    }
}
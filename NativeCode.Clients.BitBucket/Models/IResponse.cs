namespace NativeCode.Clients.BitBucket.Models
{
    using System.Collections.Generic;

    public interface IResponse
    {
        IEnumerable<ErrorResponse> Errors { get; }
    }
}
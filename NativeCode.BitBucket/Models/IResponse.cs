using System.Collections.Generic;

namespace NativeCode.BitBucket.Models
{
    public interface IResponse
    {
        IEnumerable<ErrorResponse> Errors { get; }
    }
}
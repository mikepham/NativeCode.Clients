namespace NativeCode.Clients.Responses
{
    using System.Collections.Generic;

    public interface IResponse
    {
        IEnumerable<ErrorResponse> Errors { get; }
    }
}
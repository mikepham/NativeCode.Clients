namespace NativeCode.Clients.Responses
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PagingResponse<T> : ResourceResponse<T>
    {
    }
}
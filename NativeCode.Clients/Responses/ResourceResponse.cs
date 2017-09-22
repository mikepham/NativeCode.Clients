namespace NativeCode.Clients.Responses
{
    using System.Runtime.Serialization;

    [DataContract]
    public abstract class ResourceResponse<T> : IResponse
    {
    }
}
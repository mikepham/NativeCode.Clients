namespace NativeCode.Clients.Responses
{
    using System.Runtime.Serialization;
    using JetBrains.Annotations;

    [DataContract]
    public abstract class PagingResponse<T> : ResourceResponse<T>
    {
        public abstract int GetPageIndex();

        public abstract int GetPageCount();

        public abstract int GetPageSize();

        [CanBeNull]
        public abstract string GetNextPageUrl();
    }
}
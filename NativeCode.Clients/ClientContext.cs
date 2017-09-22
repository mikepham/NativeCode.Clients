namespace NativeCode.Clients
{
    using System.Collections.Generic;

    public abstract class ClientContext
    {
        public IDictionary<string, string> Parameters { get; } = new Dictionary<string, string>();
    }
}
namespace NativeCode.Clients
{
    using System.Linq;

    public static class Args
    {
        public static bool Require(params string[] parameters)
        {
            return parameters.All(parameter => string.IsNullOrWhiteSpace(parameter) == false);
        }
    }
}
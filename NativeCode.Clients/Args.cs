namespace NativeCode.Clients
{
    using System;
    using System.Linq;

    public static class Args
    {
        public static bool Require(params string[] parameters)
        {
            return parameters.All(parameter => string.IsNullOrWhiteSpace(parameter) == false);
        }

        public static void RequireThrow(params string[] parameters)
        {
            if (Require(parameters) == false)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
        }
    }
}
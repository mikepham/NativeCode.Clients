namespace NativeCode.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public abstract class ClientContext
    {
        public IDictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

        protected T GetEnumParameter<T>([CallerMemberName] string name = default(string)) where T : struct
        {
            var value = this.GetParameter(null, name);

            if (Enum.TryParse<T>(value, true, out var enumValue))
            {
                return enumValue;
            }

            return default(T);
        }

        protected string GetParameter(string defaultValue = default(string), [CallerMemberName] string name = default(string))
        {
            if (this.Parameters.ContainsKey(name))
            {
                return this.Parameters[name];
            }

            return defaultValue;
        }

        protected void SetEnumParameter<T>(T value, [CallerMemberName] string name = default(string)) where T : struct
        {
            this.SetParameter(value.ToString(), name);
        }

        protected void SetParameter(string value, [CallerMemberName] string name = default(string))
        {
            if (this.Parameters.ContainsKey(name))
            {
                if (value == null)
                {
                    this.Parameters.Remove(name);
                }
                else
                {
                    this.Parameters[name] = value;
                }
            }
            else
            {
                this.Parameters.Add(name, value);
            }
        }
    }
}
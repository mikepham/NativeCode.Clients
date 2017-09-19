using System;

namespace NativeCode.BitBucket.Models.V2
{
    public class User
    {
        public string AccountId { get; protected set; }

        public DateTimeOffset CreatedOn { get; protected set; }

        public string DisplayName { get; protected set; }

        public bool IsStaff { get; protected set; }

        public string Location { get; protected set; }

        public BitBucketResourceType Type { get; protected set; }

        public string Username { get; protected set; }

        public Guid Uuid { get; protected set; }

        public string Website { get; protected set; }
    }
}
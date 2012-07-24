using System;

namespace JanrainTest1.Models
{
    public class AuthInfo
    {
        public string stat { get; set; }
        public Profile profile { get; set; }

        public bool IsOk()
        {
            return string.Equals(stat, "ok", StringComparison.InvariantCultureIgnoreCase);
        }

        public class Profile
        {
            public string url { get; set; }
            public string preferredUsername { get; set; }
            public string email { get; set; }
            public Name name { get; set; }
            public string photo { get; set; }
            public string displayName { get; set; }
            public string identifier { get; set; }
            public string verifiedEmail { get; set; }
            public string providerName { get; set; }
            public string googleUserId { get; set; }

            public class Name
            {
                public string givenName { get; set; }
                public string familyName { get; set; }
                public string formatted { get; set; }
            }
        }
    }
}
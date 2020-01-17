using System;

namespace Entities
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public GenderType Gender { get; set; }
    }

    public enum GenderType
    {
        Male = 1,

        Female = 2
    }
}
using System;
using Entities.Common;

namespace Entities
{
    public class UserModel : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public GenderType Gender { get; set; }
        public string ConfirmPassword { get; set; }
        public string Access_token { get; set; }
    }

    public enum GenderType
    {
        Male = 1,

        Female = 2
    }
}
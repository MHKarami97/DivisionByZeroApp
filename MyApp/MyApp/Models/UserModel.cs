using System;

namespace MyApp.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long NationalCode { get; set; }
        public string City { get; set; }
        public DateTime BirthDay { get; set; }
        public string Type { get; set; }
        public string Ip { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int VerifyCode { get; set; }
    }
}
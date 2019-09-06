using System;

namespace MyApp.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long NationalCode { get; set; }
        public string City { get; set; }
        public DateTime BirthDay { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
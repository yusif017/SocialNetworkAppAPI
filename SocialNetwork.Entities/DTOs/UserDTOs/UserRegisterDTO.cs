using SocialNetwork.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.DTOs.UserDTOs
{
    public class UserRegisterDTO
    {
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}

using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Entities.Concrete
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string EmailToken { get; set; }
        public bool EmailConfirm { get; set; }
        public DateTime EmailExpiresDate { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

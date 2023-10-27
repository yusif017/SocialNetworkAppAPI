using SocialNetwork.Core.Entities.Abstract;
using SocialNetwork.Core.Entities.Concrete;
using SocialNetwork.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.Concrete
{
    public class User : AppUser, IEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public string Avatar { get; set; }
        public Gender Gender { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime Birthday { get; set; }
        public List<FriendList> FriendLists { get; set; }
    }
}

using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.Concrete
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime PostPublishDate { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Reaction> Reactions { get; set; }
        public List<Comment> Comments { get; set; }

    }
}

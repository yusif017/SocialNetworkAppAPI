using SocialNetwork.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public int RoleName { get; set; }
    }
}

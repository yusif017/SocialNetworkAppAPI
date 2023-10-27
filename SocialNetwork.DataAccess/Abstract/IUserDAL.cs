using SocialNetwork.Core.DataAccess;
using SocialNetwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IUserDAL : IRepositoryBase<User>
    {
    }
}

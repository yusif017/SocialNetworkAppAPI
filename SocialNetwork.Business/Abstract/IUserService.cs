using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Abstract
{
    public interface IUserService
    {
        IResult Login(UserLoginDTO userLoginDTO);
        IResult Register(UserRegisterDTO userRegisterDTO);
        IResult SendEmail();
        IResult VerifyEmail(string email, string token);
        IDataResult<UserProfileDTO> GetUserProfile(int userId);
        IResult AddFriend(int userId, int friendId);
    }
}

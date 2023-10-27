using AutoMapper;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Utilities.Business;
using SocialNetwork.Core.Utilities.Result.Abstract;
using SocialNetwork.Core.Utilities.Result.Concrete.ErrorResult;
using SocialNetwork.Core.Utilities.Result.Concrete.SuccessResult;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;
using SocialNetwork.Entities.DTOs.UserDTOs;
using SocialNetwork.Core.Security.HashHelper;
using SocialNetwork.Entities.SharedModel;
using MassTransit;

namespace SocialNetwork.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserManager(IUserDAL userDAL, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userDAL = userDAL;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public IResult AddFriend(int userId, int friendId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserProfileDTO> GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public IResult Login(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public IResult Register(UserRegisterDTO userRegisterDTO)
        {
            var result = BusinessRules.Check(CheckUserAge(userRegisterDTO.Birthday), CheckUserEmail(userRegisterDTO.Email));

            if(!result.Success)
                return new ErrorResult();

            var mapToUser = _mapper.Map<User>(userRegisterDTO);
            mapToUser.Avatar = "/";
            mapToUser.CoverPhoto = "/";
            mapToUser.EmailToken = Guid.NewGuid().ToString();
            byte[] passwordHash, passwordSalt;
            Hasing.HashPassword(userRegisterDTO.Password, out passwordHash, out passwordSalt);

            mapToUser.PasswordHash = passwordHash;
            mapToUser.PasswordSalt = passwordSalt;
            // Token Expires Date
            mapToUser.EmailExpiresDate = DateTime.Now.AddSeconds(30000);

            SendEmailCommand sendEmailCommand = new()
            {
                Email = mapToUser.Email,
                Name = mapToUser.Name,
                Surname = mapToUser.Surname,
                Token = mapToUser.EmailToken
            };
            _publishEndpoint.Publish<SendEmailCommand>(sendEmailCommand);

            _userDAL.Add(mapToUser);
            return new SuccessResult();
        }

        private IResult CheckUserAge(DateTime birthday)
        {
            var check = DateTime.Now.Year - birthday.Year;
            if (check < 18)
                return new ErrorResult();

            return new SuccessResult();
        }

        private IResult CheckUserEmail(string email)
        {
            var check = _userDAL.Get(x => x.Email == email);
            if(check is not null)
                return new ErrorResult();

            return new SuccessResult();
        }

        public IResult SendEmail()
        {
            throw new NotImplementedException();
        }

        public IResult VerifyEmail(string email, string token)
        {
            throw new NotImplementedException();
        }
    }
}

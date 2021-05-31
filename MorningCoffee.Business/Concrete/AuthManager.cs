using MorningCoffee.Business.Abstract;
using MorningCoffee.Business.Constants;
using MorningCoffee.Core.Entities.Concrete;
using MorningCoffee.Core.Utilities.Results;
using MorningCoffee.Core.Utilities.Security.Hashing;
using MorningCoffee.Core.Utilities.Security.JWT;
using MorningCoffee.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var token = _tokenHelper.CreateAccessToken(user, claims);
            return new SuccessDataResult<AccessToken>(token, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            var hash = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordSalt, userToCheck.PasswordSalt);
            if (!hash)
            {
                return new ErrorDataResult<User>(Messages.PasswordNotMatch);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCheck = _userService.GetByEmail(userForRegisterDto.Email);
            if (userToCheck != null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExist);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordSalt, out passwordHash);

            User user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }
    }
}

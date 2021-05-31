using MorningCoffee.Core.Entities.Concrete;
using MorningCoffee.Core.Utilities.Results;
using MorningCoffee.Core.Utilities.Security.JWT;
using MorningCoffee.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateToken(User user);

    }
}

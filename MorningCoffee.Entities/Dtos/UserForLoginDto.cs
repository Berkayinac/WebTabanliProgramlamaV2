using MorningCoffee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

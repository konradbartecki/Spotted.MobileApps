using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotted.Core.Model.Interfaces;
using Spotted.Core.Validator;

namespace Spotted.Core.Model.Requests
{
    public class RegisterRequest : IValidable
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReenteredPassword { get; set; }
        public User.Sex Sex { get; set; }

        public void CheckValidity()
        {
            CheckModel.Email(Email);
            CheckModel.Password(Password);
            CheckModel.Password(ReenteredPassword);
            CheckModel.RegisterPassword(Password, ReenteredPassword);
        }

        public RegisterRequestDTO AsDto()
        {
            return new RegisterRequestDTO()
            {
                email = this.Email,
                password = this.Password,
                sex = (int) this.Sex
            };
        }

        public class RegisterRequestDTO
        {
            public string email { get; set; }
            public string password { get; set; }
            public int sex { get; set; }
        }
    }
}

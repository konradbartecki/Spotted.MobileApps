using Spotted.Model.Entities;
using Spotted.Model.Interfaces;

namespace Spotted.Model.Requests
{
    public class RegisterRequest : IValidable, IDtoConvertable
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReenteredPassword { get; set; }
        public User.Sex Sex { get; set; }

        public void CheckValidity()
        {
            ModelValidator.Email(Email);
            ModelValidator.Password(Password);
            ModelValidator.Password(ReenteredPassword);
            ModelValidator.RegisterPassword(Password, ReenteredPassword);
        }

        object IDtoConvertable.AsDto()
        {
            return new RegisterRequestDTO()
            {
                email = this.Email,
                password = this.Password,
                sex = (int)this.Sex
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

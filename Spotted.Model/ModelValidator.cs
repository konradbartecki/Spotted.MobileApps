using Spotted.Model.Enums;
using Spotted.Model.Exceptions;

namespace Spotted.Model
{
    public static class ModelValidator
    {
        public static void Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ModelInvalidException(ModelError.EmailEmpty);
        }

        public static void Password(string password)
        {
            if(string.IsNullOrWhiteSpace(password)) throw new ModelInvalidException(ModelError.PasswordEmpty);
        }

        public static void RegisterPassword(string password, string reenterPassword)
        {
            if(password != reenterPassword) throw new ModelInvalidException(ModelError.PasswordDoesNotMatch);

        }
    }
}

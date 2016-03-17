using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotted.Core.Model.Enums;
using Spotted.Core.Model.Exceptions;

namespace Spotted.Core.Validator
{
    public static class CheckModel
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

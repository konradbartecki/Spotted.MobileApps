using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Core.Model.Enums
{
    public enum ModelError
    {
        UnknownError,
         
        EmailEmpty,
        EmailIncorrect,

        PasswordEmpty,
        PasswordTooShort,
        PasswordDoesNotMatch,

        
        
    }
}

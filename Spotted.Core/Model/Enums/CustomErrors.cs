using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Core.Model.Enums
{
    public enum CustomErrors
    {
        TokenInvalid = 401,
        ModelInvalid = 1400,
        LoginFailed = 1401,
        EmailExists = 1402,           
    }
}

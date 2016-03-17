using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace Spotted.Core.ViewModels
{
    class LoginViewModel : MvxViewModel
    {
        private string _email;
        private string _password;
        #region FullProps
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion
    }
}

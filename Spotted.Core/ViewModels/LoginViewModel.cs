using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Spotted.Core.Helpers;
using Spotted.Model.Entities;
using Spotted.Model.Requests;
using Spotted.Model.Enums;

namespace Spotted.Core.ViewModels
{
    public class LoginRegisterViewModel : MvxViewModel
    {
        private string _email;
        private string _password;
        private string _reenteredPassword;
        private Gender _selectedGender;

        #region FullProps
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                RaisePropertyChanged(() => Password);
            }
        }
        public string ReenteredPassword
        {
            get { return _reenteredPassword; }
            set
            {
                _reenteredPassword = value;
                RaisePropertyChanged(() => ReenteredPassword);
            }
        }
        public Gender SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                _selectedGender = value;
                RaisePropertyChanged(() => SelectedGender);
            }
        }

        #endregion

        public async Task LoginAsync()
        {
            try
            {
                var loginRequest = new LoginRequest()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                loginRequest.CheckValidity();

                using (var service = Config.GetMobileService())
                {
                    service.AccessToken = await service.Login(loginRequest);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
        }
    }
}

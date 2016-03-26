using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;
using Spotted.Core.Helpers;
using Spotted.Model.Entities;
using Spotted.Model.Requests;
using Spotted.Model.Enums;

namespace Spotted.Core.ViewModels
{
    public class LoginRegisterViewModel : MvxViewModel
    {
        #region TextAlias
        private static readonly string _loginText = "Login";
        private static readonly string _registerText = "Register";
        private static readonly string _switchToLogin = "Login instead";
        private static readonly string _switchToRegister = "Register instead";
        #endregion

        #region PrivateProps
        private string _email;
        private string _password;
        private string _reenteredPassword;
        private Gender _selectedGender;
        private bool _inRegisterMode = false;
        private MvxVisibility _registerModeVisibility = MvxVisibility.Collapsed;
        private string _mainActionText = _loginText;
        private string _switchModeText = _registerText;
        #endregion

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
        public MvxVisibility RegisterModeVisibility
        {
            get { return _registerModeVisibility; }
            set
            {
                _registerModeVisibility = value;
                RaisePropertyChanged(() => RegisterModeVisibility);
            }
        }
        #endregion

        #region UIContents
        public string MainActionText => _mainActionText;
        public string SwitchModeText => _switchModeText;
        #endregion


        /// <summary>
        /// Logs or register a user based on an action
        /// </summary>
        /// <returns></returns>;
        public async Task MainActionAsync()
        {
            if (_inRegisterMode)
            {
                await RegisterAsync();
                await LoginAsync();
            }               
            else
                await LoginAsync();
        }

        private async Task LoginAsync()
        {
            try
            {
                using (var service = Config.GetMobileService())
                {
                    var loginRequest = new LoginRequest()
                    {
                        Email = this.Email,
                        Password = this.Password
                    };
                    loginRequest.CheckValidity();
                    service.AccessToken = await service.Login(loginRequest);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
        }

        private async Task RegisterAsync()
        {
            try
            {
                using (var service = Config.GetMobileService())
                {
                    var regsiterRequest = new RegisterRequest()
                    {
                        Email = this.Email,
                        Password = this.Password,
                        ReenteredPassword = this.ReenteredPassword,
                        Gender = Gender.Unknown
                    };
                    regsiterRequest.CheckValidity();

                    await service.Register(regsiterRequest);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
        }

        public void SwitchMode()
        {
            _inRegisterMode = !_inRegisterMode;
            RegisterModeVisibility = _inRegisterMode ? MvxVisibility.Visible : MvxVisibility.Collapsed;
            _mainActionText = _inRegisterMode ? _registerText : _loginText;
            _switchModeText = _inRegisterMode ? _switchToLogin : _switchToRegister;
            RaisePropertyChanged(() => MainActionText);
            RaisePropertyChanged(() => SwitchModeText);
        }
    }
}

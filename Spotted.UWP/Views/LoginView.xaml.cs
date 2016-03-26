﻿using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using MvvmCross.WindowsUWP.Views;
using Spotted.Core.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Spotted.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : MvxWindowsPage
    {
        private bool RegisterModeEnabled = false;

        public new LoginRegisterViewModel ViewModel
        {
            get { return (LoginRegisterViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public LoginView()
        {
            this.InitializeComponent();
        }

        private void SwitchAction_Click(object sender, RoutedEventArgs e)
        {
            if (RegisterModeEnabled)
            {
                RegisterPanel.Visibility = Visibility.Collapsed;
                RegisterModeEnabled = false;
                Login.Content = "Login";
                SwitchAction.Content = "Sign up instead";
            }
            else
            {
                RegisterPanel.Visibility = Visibility.Visible;
                RegisterModeEnabled = true;
                Login.Content = "Register";
                SwitchAction.Content = "Login instead";
            }
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            await LoginOrRegister();
        }

        private async Task LoginOrRegister()
        {
            try
            {
                EmailBox.IsEnabled = false;
                PasswordBox.IsEnabled = false;
                SwitchAction.IsEnabled = false;
                Login.IsEnabled = false;
                ProgressRing.IsActive = true;

                await ViewModel.LoginAsync();
            }
            finally
            {
                EmailBox.IsEnabled = true;
                PasswordBox.IsEnabled = true;
                SwitchAction.IsEnabled = true;
                Login.IsEnabled = true;
                ProgressRing.IsActive = false;
            }
        }

        private async void PasswordBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                await LoginOrRegister();
        }

        private void EmailBox_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                PasswordBox.Focus(FocusState.Keyboard);
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Frame.Navigate(typeof (MainView));
        }
    }
}

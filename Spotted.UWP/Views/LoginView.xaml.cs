using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MvvmCross.WindowsUWP.Views;
using Spotted.Core;
using Spotted.Core.Model.Exceptions;
using Spotted.Core.Model.ServiceRequests;
using Spotted.UWP.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Spotted.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : MvxWindowsPage
    {
        private bool RegisterModeEnabled = false;
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

                using (var service = Config.GetMobileService())
                {

                    if (RegisterModeEnabled == false)
                    {
                        var token = await service.Login(new LoginRequest()
                        {
                            Email = EmailBox.Text,
                            Password = PasswordBox.Password
                        });
                        service.AccessToken = token;
                        await new MessageDialog(service.AccessToken).ShowAsync();
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (ModelInvalidException ex)
            {
                await new MessageDialog(ex.ToString()).ShowAsync();
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
            Frame.Navigate(typeof (MainView));
        }
    }
}

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
using Spotted.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Spotted.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool RegisterModeEnabled = false;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SwitchAction_Click(object sender, RoutedEventArgs e)
        {
            if (RegisterModeEnabled)
            {
                RegisterModeEnabled = false;
                Login.Content = "Login";
                SwitchAction.Content = "Sign up instead";
            }
            else
            {
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

                object res = null;

                if (RegisterModeEnabled == false)
                    res = await Config.Client.LoginAsync(EmailBox.Text, PasswordBox.Password);
                else
                    res = await Config.Client.RegisterAsync();
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
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
    }
}

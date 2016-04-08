using System.Threading.Tasks;
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
        public new LoginRegisterViewModel ViewModel
        {
            get { return (LoginRegisterViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public LoginView()
        {
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginOrRegister();
        }

        private void LoginOrRegister()
        {
            try
            {
                EmailBox.IsEnabled = false;
                PasswordBox.IsEnabled = false;
                SwitchAction.IsEnabled = false;
                Login.IsEnabled = false;
                ProgressRing.IsActive = true;

                ViewModel.MainActionCommand.Execute(null);
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

        private void PasswordBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                LoginOrRegister();
        }

        private void EmailBox_OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                PasswordBox.Focus(FocusState.Keyboard);
        }
    }
}

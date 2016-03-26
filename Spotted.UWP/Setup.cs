using Windows.UI.Xaml.Controls;
using MvvmCross.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Core;
using MvvmCross.WindowsUWP.Platform;
using Spotted.Core.Services;
using Spotted.UWP.Services;

namespace Spotted.UWP
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            Mvx.RegisterSingleton<IUserNotificationService>(new UwpUserNotificationService());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MvvmCross.Platform.WindowsCommon.Platform;
using Spotted.Core.Services;

namespace Spotted.UWP.Services
{
    public class UwpUserNotificationService : IUserNotificationService
    {
        public void DisplayError(string message)
        {
            new MessageDialog(message).ShowAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Spotted.Core.Model.Interfaces;

namespace Spotted.UWP.Model
{
    public class UWPNotifier : IUserNotifier
    {
        public void NotifyError(string Title, string Error)
        {
            throw new NotImplementedException();
        }

        public async void NotifyError(string Error)
        {
            await new MessageDialog(Error).ShowAsync();
        }
    }
}

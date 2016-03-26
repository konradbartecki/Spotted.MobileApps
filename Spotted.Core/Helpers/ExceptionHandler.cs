using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using Spotted.Model.Exceptions;
using Spotted.Core.Services;
using Spotted.MobileServiceProxy.Exceptions;

namespace Spotted.Core.Helpers
{
    internal static class ExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            var notifier = Mvx.Resolve<IUserNotificationService>();

            if (ex is ModelInvalidException)
                notifier.DisplayError(ex.Message);
            else if(ex is MobileServiceException)
                notifier.DisplayError(ex.Message);
            else
                ExceptionDispatchInfo.Capture(ex).Throw();
        }
    }
}

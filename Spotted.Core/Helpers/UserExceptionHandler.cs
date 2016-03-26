using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using Spotted.Model.Exceptions;
using Spotted.Core.Services;

namespace Spotted.Core.Helpers
{
    public static class UserExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            var notifier = Mvx.Resolve<IUserNotificationService>();

            if (ex is ModelInvalidException)
                notifier.DisplayError(ex.Message);
        }
    }
}

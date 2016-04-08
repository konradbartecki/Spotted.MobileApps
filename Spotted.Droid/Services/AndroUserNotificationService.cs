using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Spotted.Core.Services;

namespace Spotted.Droid.Services
{
    public class AndroUserNotificationService : IUserNotificationService
    {
        public void DisplayError(string message)
        {
            var toast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            toast.Show();
        }
    }
}
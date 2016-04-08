using Android.App;
using Android.Content.Res;
using Android.OS;
using MvvmCross.Droid.Views;
using Spotted.Core.ViewModels;

namespace Spotted.Droid.Views
{
    [Activity(NoHistory = true)]
    public class LoginView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.LoginView);
        }

        public new LoginRegisterViewModel ViewModel
        {
            get { return (LoginRegisterViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}

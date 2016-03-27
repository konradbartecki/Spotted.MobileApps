using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Spotted.Core.Helpers;
using Spotted.Model.Entities;

namespace Spotted.Core.ViewModels
{
    public class FeedViewModel : MvxViewModel
    {
        private ObservableCollection<Post> _posts;

        public ObservableCollection<Post> Posts
        {
            get { return _posts; }
            set
            {
                _posts = value;
                RaisePropertyChanged(() => Posts);
            }
        }

        public async Task DownloadPosts()
        {
            try
            {
                using (var service = Config.GetMobileService())
                {
                    var data = await service.GetPosts();
                    Posts = new ObservableCollection<Post>(data);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
        }
    }
}

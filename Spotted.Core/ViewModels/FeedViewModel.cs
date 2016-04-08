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
                    var posts = await service.GetPosts();
                    foreach (var post in posts)
                    {
                        var foundGroup = SpottedCache.Groups.FirstOrDefault(x => x.Id == post.Group?.Id);
                        if (foundGroup == null)
                        {
                            post.Group = new BasicGroup()
                            {
                                Name = "Spotted"
                            };
                        }
                        else
                        {
                            post.Group = foundGroup;
                        }
                    }

                    posts = posts.OrderByDescending(x => x.Created).ToList();
                    Posts = new ObservableCollection<Post>(posts);
                }
            }
            catch (Exception e)
            {
                await ExceptionHandler.Handle(e);
            }
        }
    }
}

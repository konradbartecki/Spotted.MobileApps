using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Core.Model.Interfaces
{
    public interface IUserNotifier
    {
        void NotifyError(string Title, string Error);
        void NotifyError(string Error);
    }
}

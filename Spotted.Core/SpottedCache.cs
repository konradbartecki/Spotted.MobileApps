using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Binding.Combiners;
using Spotted.Model.Entities;

namespace Spotted.Core
{
    public static class SpottedCache
    {

        public static List<BasicGroup> Groups { get; set; }

        //public static List<Post> Posts { get; set; } = new List<Post>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotted.Model.Interfaces;

namespace Spotted.Model.Entities
{
    public class Group : BasicGroup, IGeolocated
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

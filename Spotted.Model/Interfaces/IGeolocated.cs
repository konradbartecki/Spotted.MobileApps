using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotted.Model.Interfaces
{
    public interface IGeolocated
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}

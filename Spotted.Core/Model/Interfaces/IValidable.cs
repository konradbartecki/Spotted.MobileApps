using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotted.Core.Model.Exceptions;

namespace Spotted.Core.Model.Interfaces
{
    /// <summary>
    /// Implemented by requests sent to API
    /// </summary>
    interface IValidable
    {
        /// <summary>
        /// Checks for validity of current object
        /// </summary>
        /// <exception cref="ModelInvalidException">Throws exception with field that was invalid</exception>
        void CheckValidity();

        
    }
}

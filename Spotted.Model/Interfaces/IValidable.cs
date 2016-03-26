using Spotted.Model.Exceptions;

namespace Spotted.Model.Interfaces
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

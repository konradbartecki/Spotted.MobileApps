using System;
using Spotted.Model.Enums;

namespace Spotted.Model.Exceptions
{
    public class ModelInvalidException : Exception
    {
        public ModelError ModelError { get; set; }

        public ModelInvalidException(ModelError error) : base(error.ToString())
        {
            this.ModelError = error;
        }

        public override string ToString()
        {
            return ModelError.ToString();
        }
    }
}

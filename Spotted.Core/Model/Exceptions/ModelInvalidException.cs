using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotted.Core.Model.Enums;

namespace Spotted.Core.Model.Exceptions
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

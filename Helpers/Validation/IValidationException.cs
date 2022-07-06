using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Helpers.Validation
{
    public interface IValidationException
    {
        IList<ValidationError> Errors { get; set; }

        void Add(ValidationError error);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Helpers.Validation
{
    public class ValidationException: Exception, IValidationException
    {
        public ValidationException() : base()
        {
            Errors = new List<ValidationError>();
        }

        public ValidationException(string key, string message = "") : base()
        {
            Errors = new List<ValidationError>();
            message = string.IsNullOrWhiteSpace(message) ? string.Empty : message;
            Add(new ValidationError(key, message));
        }

        public ValidationException(string key, params object[] args) : this()
        {
            IList<string> extParam = new List<string>();
            foreach(object param in args)
            {
                extParam.Add(param.ToString());
            }
            Add(new ValidationError(key, string.Empty, extParam));
        }

        public System.Collections.Generic.IList<ValidationError> Errors { get; set; }

        public void Add(ValidationError error)
        {
            Errors.Add(error);
        }

        public void Add(IList<ValidationError> errors)
        {
            foreach( var validationError in errors)
            {
                Add(validationError);
            }
        }
    }
}

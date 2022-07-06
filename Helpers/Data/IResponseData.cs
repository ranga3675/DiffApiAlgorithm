using DiffApi.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Helpers.Data
{
    public interface IResponseData<T>
    {
        void SetStatus(System.Net.HttpStatusCode httpStatusCode);
        void SetErrors(IList<ValidationError> errors);
        void SetData(T data);

    }
}

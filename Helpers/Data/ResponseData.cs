using DiffApi.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DiffApi.Helpers.Data
{
    public class ResponseData<T> : IResponseData<T>
    {
        public T Data { get; set; }

        public IList<ValidationError> Errors { get; set; }

        public HttpStatusCode Status { get; set; }

        public void SetData(T data)
        {
            Data = data;
        }

        public void SetErrors(IList<ValidationError> errors)
        {
            Errors = errors;
        }
        public void SetStatus(HttpStatusCode httpStatusCode)
        {
            Status = httpStatusCode;
        }
    }
}

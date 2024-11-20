using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Result
{
    public class ResponseModel<T>
    {
        public ResponseModel()
        {
        }
        public ResponseModel<T> Success(T data)
        {
            Data = data;
            IsSuccess = true;
            ErrorMessage = string.Empty;
            return this;
        }
        public ResponseModel<T> Fail(string errorMessage)
        {
            Data = default(T);
            IsSuccess = false;
            ErrorMessage = errorMessage;
            return this;
        }
        public T? Data { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }

    }
}

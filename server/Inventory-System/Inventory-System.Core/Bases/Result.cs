using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Bases
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public string MessageKey { get; }
        public T Data { get; }
        public ResultStatus Status { get; }

        private Result(bool isSuccess, string messageKey, ResultStatus status, T data = default)
        {
            IsSuccess = isSuccess;
            MessageKey = messageKey;
            Data = data;
            Status = status;
        }

        public static Result<T> Success(T data, string messageKey = "Succeeded")
          => new Result<T>(true, messageKey, ResultStatus.Success, data);
        public static Result<T> Created(T data, string messageKey = "Created")
           => new Result<T>(true, messageKey, ResultStatus.Created, data);

        public static Result<T> Failure(ResultStatus status)
          => new Result<T>(false, status.ToString(), status);
        public static Result<T> Failure(string messageKey, ResultStatus status)
            => new Result<T>(false, messageKey, status);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Base
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
    public class SuccessServiceApiResult<T> : ServiceApiResult<T>
    {
        public SuccessServiceApiResult(T data, string message) : base(data, true, message)
        {
        }

        public SuccessServiceApiResult(T data) : base(data, true)
        {
        }

        public SuccessServiceApiResult(string message) : base(default, true, message)
        {

        }

        public SuccessServiceApiResult() : base(default, true)
        {

        }
    }
    public interface IServiceApiResult<out T> : IResult
    {
        T Data { get; }
    }
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        string Link { get; }
    }
    public class ServiceApiResult<T> : Result, IServiceApiResult<T>
    {
        public ServiceApiResult(T data, bool success, string message, string link) : base(success, message, link)
        {
            Data = data;
        }

        public ServiceApiResult(T data, bool success, string message, string link, bool UserNeedsToLogin) : base(success, message, link, UserNeedsToLogin)
        {
            Data = data;
        }

        public ServiceApiResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public ServiceApiResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
    public class Result : IResult
    {
        public Result(bool success, string message, string link) : this(success)
        {
            Message = message;
            Link = link;
        }

        public Result(bool success, string message, string link, bool userNeedsToLogin) : this(success)
        {
            Message = message;
            Link = link;
            UserNeedsToLogin = userNeedsToLogin;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public bool UserNeedsToLogin { get; }
        public string Message { get; }
        public string Link { get; }
    }
}

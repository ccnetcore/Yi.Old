using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yi.Framework.Common.Models
{
    /// <summary>
    /// 结果数据
    /// </summary>
    public class Result
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public static Result Instance(bool status, string msg)
        {
            return new Result() { status = status, code = 500, msg = msg };
        }
        public static Result Error(string msg = "fail")
        {
            return new Result() { status = false, code = 500, msg = msg };
        }
        public static Result Success(string msg = "succeed")
        {
            return new Result() { status = true, code = 200, msg = msg };
        }
        public Result SetData(object obj)
        {
            this.data = obj;
            return this;
        }
        public Result SetCode(int Code)
        {
            this.code = Code;
            return this;
        }
    }
    public class Result<T>
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
        public T data { get; set; }

        public static Result<T> Instance(bool status, string msg)
        {
            return new Result<T>() { status = status, code = 500, msg = msg };
        }
        public static Result<T> Error(string msg = "fail")
        {
            return new Result<T> { status = false, code = 500, msg = msg };
        }
        public static Result<T> Success(string msg = "succeed")
        {
            return new Result<T> { status = true, code = 200, msg = msg };
        }
        public Result<T> SetData(T TValue)
        {
            this.data = TValue;
            return this;
        }
    }

}
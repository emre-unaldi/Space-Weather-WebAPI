using System;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        private T data;
        public DataResult(bool success, T data) : base(success) => this.Data = data;

        public DataResult(bool success, string Message, T data) : base(success, Message) => this.Data = data;

        public T Data { get => data; set => data = value; }
    }
}

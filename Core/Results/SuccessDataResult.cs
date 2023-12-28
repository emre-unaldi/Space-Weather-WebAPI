using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(true, message, data) { }
        public SuccessDataResult(T data) : base(true, data) { }
        public SuccessDataResult(string message) : base(default, message, default) { }
        public SuccessDataResult() : base(true, default) { }
    }
}

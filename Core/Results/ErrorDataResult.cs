using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(false, message, data) { }
        public ErrorDataResult(T data) : base(false, data) { }
        public ErrorDataResult(string message) : base(false, message, default) { }
        public ErrorDataResult() : base(false, default) { }
    }
}

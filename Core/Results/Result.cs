using System;

namespace Core.Results
{
    public class Result : IResult
    {
        private bool success;
        private string message;

        public Result(bool success)
        {
            this.Success = success;
        }

        public Result(string message)
        {
            this.Message = message;
        }

        public Result(bool success, string message)
        {
            this.Message = message;
            this.Success = success;
        }

        public bool Success { get => success; set => success = value; }
        public string Message { get => message; set => message = value; }
    }
}

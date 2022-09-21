using System;

namespace Paycore.Base.Response
{
    public class ApplicationResult<T> : CommonApplicationResult
    {
        //It's for results. Returns true or false or error message.
        public ApplicationResult(T data)
        {
            Result = data;
        }
        public ApplicationResult(string error)
        {
            ErrorMessage = error;
            Succeeded = false;
        }

        public T Result { get; set; }
    }

    public class ApplicationResult : CommonApplicationResult
    {

    }
    public class CommonApplicationResult
    {
        public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }

    }
}

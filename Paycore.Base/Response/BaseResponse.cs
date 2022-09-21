using Serilog;

namespace Paycore.Base.Response
{
    public class BaseResponse<T>
    {
        //Base response class checks if is success or not
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Response { get; private set; }

        public BaseResponse(bool isSuccess)
        {
            Response = default;
            Success = isSuccess;
            Message = isSuccess ? "Success" : "Fault";
        }

        public BaseResponse(T resource)
        {
            Success = true;
            Message = "Success";
            Response = resource;
        }

        public BaseResponse(string message)
        {
            Success = false;
            Response = default;

            if (!string.IsNullOrWhiteSpace(message))
            {
                Log.Information(message);
                Message = message;
            }
        }
    }
}

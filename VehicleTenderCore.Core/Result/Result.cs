namespace VehicleTenderCore.Core.Result
{
    public class Result
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public Result(string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
    }
}
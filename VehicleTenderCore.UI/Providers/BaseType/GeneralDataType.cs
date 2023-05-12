using System.Net;

namespace VehicleTenderCore.UI.Providers.BaseType
{
    public class GeneralDataType<T>: GeneralType
    {
        public T Data { get; set; }

        public GeneralDataType(string message, HttpStatusCode statusCode,T data):base(message,statusCode)
        {
            Message = message;
        }
    }

    public class GeneralType
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public GeneralType(string message, HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}

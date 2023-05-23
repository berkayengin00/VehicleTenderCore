using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTenderCore.Core.Result
{
    public class DataResult<T> : Result
    {
        public T Data { get; set; }

        public DataResult(string message, T data, bool isSuccess) : base(message, isSuccess)
        {
            Data = data;
        }
    }

}

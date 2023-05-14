using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace VehicleTenderCore.Core.SessionExtensions
{

    public static class SessionExtension
    {
        public static void MySessionSet(this ISession session, string key,object value)
        {
           
            var result = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)); 
            session.Set(key,result);
        }

        public static T MySessionGet<T>(this ISession session, string key)
        {

            if (session.TryGetValue(key, out byte[] value))
            {
                string json = Encoding.UTF8.GetString(value);
                return JsonConvert.DeserializeObject<T>(json);
            }

            return default(T);

        }
    }

}

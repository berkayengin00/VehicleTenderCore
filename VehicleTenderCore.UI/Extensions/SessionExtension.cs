using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace VehicleTenderCore.UI.Extensions
{
	public static class SessionExtension
	{
		public static void MySessionSet(this ISession session, string key, object value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));

		}
		public static T MySessionGet<T>(this ISession session, string key)
		{
			var result = session.GetString(key);

			return result == null ? default(T) : JsonConvert.DeserializeObject<T>(result);
		}
	}
}

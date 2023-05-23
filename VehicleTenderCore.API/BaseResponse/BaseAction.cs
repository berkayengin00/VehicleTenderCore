using Microsoft.AspNetCore.Mvc;

namespace VehicleTenderCore.API.BaseResponse
{
	public class BaseAction
	{
		public IActionResult ReturnResponseWithData(object data, string message)
		{
			if (data == null)
			{
				return new BadRequestObjectResult(message);
			}
			return new OkObjectResult(data);
		}
		public IActionResult ReturnResponse(string message,bool isSuccess)
		{
			if (isSuccess)
			{
				return new BadRequestObjectResult(message);
			}
			return new OkObjectResult(message);
		}
	}
}

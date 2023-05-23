using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VehicleTender.Entity.Enum;
using VehicleTender.Entity.View;
using VehicleTenderCore.Entities.View;
using VehicleTenderCore.UI.Extensions;

namespace VehicleTenderCore.UI.Filters
{
	public class CheckRole : ActionFilterAttribute
	{

		private List<int> _roles;
		public CheckRole(params int[] roles)
		{

			_roles = roles.ToList();
		}
		
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var _httpContextAccessor = (IHttpContextAccessor)filterContext.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor));
			var session = _httpContextAccessor.HttpContext?.Session.MySessionGet<SessionVMForUser>("user");
			if (session == null)
			{
				filterContext.Result = new RedirectResult("/Login/Login");
			}
			else
			{
				var userRole = session.UserType;
				bool isAuthorized = false;
				foreach (var item in _roles)
				{

					if (item == userRole)
					{
						// işleme devam et
						isAuthorized = true;
						return;
					}

				}

				filterContext.Result = new RedirectResult("/Login/Login");
			}
			base.OnActionExecuting(filterContext);
		}
	}
}

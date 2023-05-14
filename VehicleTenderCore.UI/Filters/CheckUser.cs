using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using VehicleTenderCore.Entities.View;

namespace VehicleTenderCore.UI.Filters
{
    //public class CheckRetailCustomer : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        if (context.ActionArguments["loginVm"] is RetailCustomerLoginVM vm)
    //        {
    //            var userResult = new LoginDal().CheckAdmin(vm);

    //            if (userResult.IsSuccess)
    //            {
    //                if (context.HttpContext.Session.GetString("Admin") != null)
    //                {
    //                    context.Result = new RedirectResult("RetailCustomer/GetAll");
    //                    return;
    //                }

    //                RememberMe(context.HttpContext.Response, vm.RememberMe, vm.Email);

    //                context.HttpContext.Session.SetString("Admin", userResult.Data);
    //                context.HttpContext.Session.SetInt32("Timeout", 30);
    //                context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(
    //                    new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userResult.Data.Email) },
    //                        CookieAuthenticationDefaults.AuthenticationScheme)));

    //                //context.Controller.TempData.Add("message", userResult);
    //                context.Result = new RedirectResult("/Admin/Index");
    //                return;
    //            }
    //        }

    //        base.OnActionExecuting(context);
    //    }

    //    public void RememberMe(HttpResponse response, bool rememberMe, string email)
    //    {
    //        if (rememberMe && !response.Cookies.ContainsKey("loginInfo"))
    //        {
    //            CookieOptions options = new CookieOptions();
    //            options.Expires = DateTime.Now.AddDays(1);
    //            response.Cookies.Append("loginInfo", $"{email},true", options);
    //        }
    //        else if (response.Cookies.ContainsKey("loginInfo") && !rememberMe)
    //        {
    //            response.Cookies.Delete("loginInfo");
    //        }
    //    }

    //}
}

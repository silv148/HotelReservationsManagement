using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using HotelReservationsManager.Models;
using HotelReservationsManager.ExtentionMethods;

namespace HotelReservationsManagement.ActionFilters
{
    public class AuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<User>("loggedUser") == null)
                context.Result = new RedirectResult("/Home/Login");
            if (context.HttpContext.Session.GetObject<User>("loggedUser").ReleaseDate != null)
                context.Result = new RedirectResult("/Home/Login");
        }
    }
}

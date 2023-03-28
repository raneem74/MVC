using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Models
{
    public class OrderExceptionHandler : HandleErrorAttribute
    {
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            //if(filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled == true)
            //{
            //}

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "NoOrderError"
            };

            base.OnException(filterContext);
        }


    }
}
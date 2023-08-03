using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Filters
{
	//我的自定义筛选器
	public class MyFiltersAttribute : Attribute,IActionFilter
	{
		
		//在执行操作之前
		public  void OnActionExecuting(ActionExecutingContext filterContext)
		{
			//回去session中存在的UserId判断UserId是否为空
			//var userid = filterContext.HttpContext.Session["UserId"];
			//cookie
			var userid2 = filterContext.HttpContext.Request.Cookies["UserId"];
			//判断userid是否为空
			if (userid2 == null)
			{
				//var result = filterContext.Result;

				//为空  则设置返回的结果为登陆页面
				filterContext.Result = new RedirectResult("/Admin/Account/LoginView");
			}




		}

		//在执行操作之后
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
		}
	}
}
using Microsoft.AspNetCore.Mvc;
using Models;
using IBLL;
using BLL;
using common;
using Microsoft.AspNetCore.Http;
using System;
using Castle.Core.Resource;

namespace UI.Areas.APP.Controllers
{
    [Area("APP")]
    public class AccountController : Controller
    {
        private PastryMSDB _dbContext;
        private ICustomerInfoBLL _CustomerInfoBLL;
        public AccountController(PastryMSDB dbContext, ICustomerInfoBLL CustomerInfoBLL)
        {
            _dbContext = dbContext;
            _CustomerInfoBLL = CustomerInfoBLL;
        }
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string account, string password)
        {
            ReturnResult result = new ReturnResult();

            ////把.net对象转换成json
            //string jsonstr = JsonConvert.SerializeObject(result);
            ////把json字符串转换成.net对象 
            //ReturnResult res = JsonConvert.DeserializeObject<ReturnResult>(jsonstr);

            //判断 账号是否为空
            if (string.IsNullOrWhiteSpace(account))
            {
                result.Msg = "账号不能为空";
                return Json(result);
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                result.Msg = "密码不能为空";
                return Json(result);
            }

            string msg;
            string customerName;
            string customerid;
            //调用  登录 业务逻辑
            bool isSuccess = _CustomerInfoBLL.Login(account, password, out msg, out customerName, out customerid);
            //把提示 消息赋值给结果对象msg属性
            result.Msg = msg;

            if (isSuccess)
            {
                result.IsSuccess = isSuccess;
                result.Code = 200;
                result.Data = customerName;
                //把信息存到Session
                //HttpContext.Session["UserName"] = username;
                //HttpContext.Session["UserId"] = userid;

                //HttpCookie cookie = new HttpCookie("UserId", userid);
                //cookie.Expires=DateTime.Now.AddDays(100);//设置过期时间为100天后过期
                //Response.Cookies.Add(cookie);

                //HttpCookie cookieName = new HttpCookie("UserName", Server.UrlEncode(username));
                //cookieName.Expires = DateTime.Now.AddDays(100);//设置过期时间为100天后过期
                //Response.Cookies.Add(cookieName);


                //Session
                HttpContext.Session.SetString("UserId", customerid);
                HttpContext.Session.SetString("UserName", customerName);

                //HttpContext.Session.GetString(userid);
                //HttpContext.Session.GetString(username);

                //Cookies
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(2);

                Response.Cookies.Append("UserId", customerid);
                Response.Cookies.Append("UserName", customerName);

                return Json(result);
            }
            else
            {
                result.Code = 500;
                return Json(result);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Models;
using IBLL;
using BLL;
using common;
using Microsoft.AspNetCore.Http;
using System;
using Castle.Core.Resource;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private PastryMSDB _dbContext;
        private IStaffInfoBLL _staffInfoBLL;//员工信息表
        public AccountController(PastryMSDB dbContext, IStaffInfoBLL staffInfoBLL)
        {
            _dbContext = dbContext;
            _staffInfoBLL = staffInfoBLL;
        }
        public IActionResult LoginView()
        {
            return View();
        }

        /// <summary>
        /// 员工登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
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
            string staffName;
            string staffId;
            //调用  登录 业务逻辑
            bool isSuccess = _staffInfoBLL.Login(account, password, out msg, out staffName, out staffId);
            //把提示 消息赋值给结果对象msg属性
            result.Msg = msg;

            if (isSuccess)
            {
                result.IsSuccess = isSuccess;
                result.Code = 200;
                result.Data = staffName;
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
                HttpContext.Session.SetString("UserId", staffId);
                HttpContext.Session.SetString("UserName", staffName);

                //HttpContext.Session.GetString(userid);
                //HttpContext.Session.GetString(username);

                //Cookies
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(2);

                Response.Cookies.Append("UserId", staffId);
                Response.Cookies.Append("UserName", staffName);

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

using IBLL.RBAC;
using Infrastructure.OptResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Infrastructure.Extensions;
using Web.Controllers;

namespace Web.Areas.Common.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IAccountService _AccountService;
        public LoginController(IAccountService accountService)
        {
            this._AccountService = accountService;
        }
        //
        // GET: /Common/Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//防止XSS攻击
        public ActionResult Index(LoginVM loginVM)
        {
            try
            {
                OperationResult result = _AccountService.Login(loginVM);
                if (result.ResultType == OperationResultType.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                string msg = result.Message ?? result.ResultType.GetDescription();
                ModelState.AddModelError("", msg);
                return View(loginVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View(loginVM);
            }
        }

        public ActionResult Logout()
        {
            _AccountService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
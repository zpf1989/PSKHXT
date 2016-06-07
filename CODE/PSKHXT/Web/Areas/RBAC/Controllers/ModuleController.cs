using IBLL.RBAC;
using Infrastructure;
using Infrastructure.Enums;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Controllers;
using Web.Extension.Common;
using Web.Extension.Filters;
using Infrastructure.Extensions;
using ViewModel.RBAC;

namespace Web.Areas.RBAC.Controllers
{
    public class ModuleController : BaseController
    {
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            this._moduleService = moduleService;
        }

        //
        // GET: /RBAC/Module/
        [Layout]
        public ActionResult Index()
        {
            GetAvailableButtons();
            ViewData.Add("enableItems", DataSourceHelper.GetIsTrue());
            return View();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="moduleName"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public JsonResult GetModules(int limit, int offset, string moduleName, int enable)
        {
            int total = 0;
            Expression<Func<Module, bool>> where = m => true;
            if (!string.IsNullOrEmpty(moduleName))
            {
                where = where.And(m => m.Name.Contains(moduleName));
            }
            if (enable >= 0)
            {
                bool isEnabled = enable > 0;
                where = where.And(m => m.Enabled == isEnabled);
            }
            var result = _moduleService.GetModuleVMList(where, limit, offset, out total);
            return Json(new { total = total, rows = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            ViewData["parentModules"] = _moduleService.Modules
                .Where(m => m.IsMenu == true && m.Enabled == true && m.ParentId == null)
                .Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() })
                .ToList();
            return PartialView(new ModuleVM());
        }

        /// <summary>
        /// 获取页面按钮可见权限
        /// </summary>
        [NonAction]
        private void GetAvailableButtons()
        {
            string userId = (HttpContext.User.Identity as FormsIdentity).Ticket.UserData;
            IList<Permission> permissionCache = CacheHelper.GetCache(CacheKey.StrPermissionsByUid + "_" + userId) as List<Permission>;
            if (permissionCache != null)
            {
                //新增按钮
                ViewData.Add("btnAddModulePermission", permissionCache.FirstOrDefault(p => p.Enabled == true && p.Code == EnumPermissionCode.AddModule.ToString()));
                //修改按钮
                ViewData.Add("btnEditModulePermission", permissionCache.FirstOrDefault(p => p.Enabled == true && p.Code == EnumPermissionCode.EditModule.ToString()));
            }

        }
    }
}
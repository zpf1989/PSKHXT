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
using Infrastructure.OptResult;

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

        #region 增加
        [HttpGet]
        public ActionResult Add()
        {
            GetParentModuleList(null);
            return PartialView(new ModuleVM());
        }

        [HttpPost]
        public ActionResult Add(ModuleVM moduleVM)
        {
            if (!ModelState.IsValid)
            {
                return Json(new OperationResult(OperationResultType.ParamError, "参数错误，请重新输入"));
            }
            var result = _moduleService.Insert(moduleVM);
            result.Message = result.Message ?? result.ResultType.GetDescription();
            return Json(result);
        }
        #endregion

        #region 修改
        [IsAjax]
        public ActionResult Edit(int id = 0)
        {
            var module = _moduleService.Modules.FirstOrDefault(m => m.Id == id);
            if (module == null)
            {
                return Add();
            }
            var moduleVM = new ModuleVM
            {
                Id = module.Id,
                Name = module.Name,
                ParentId = module.ParentId,
                LinkUrl = module.LinkUrl,
                IsMenu = module.IsMenu,
                Code = module.Code,
                Description = module.Description,
                Enabled = module.Enabled,
            };
            GetParentModuleList(module);
            return PartialView("Add", moduleVM);
        }

        [HttpPost]
        public ActionResult Edit(ModuleVM moduleVM)
        {
            if (!ModelState.IsValid)
            {
                return Json(new OperationResult(OperationResultType.ParamError, "参数错误，请重新输入"));
            }
            OperationResult result = _moduleService.Update(moduleVM);
            result.Message = result.Message ?? result.ResultType.GetDescription();
            return Json(result);
        }
        #endregion

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
        /// <summary>
        /// 获取上级模块列表
        /// </summary>
        /// <param name="module">模块实例，用来设置上级模块下拉列表的当前选择项</param>
        private void GetParentModuleList(Module module)
        {
            List<SelectListItem> selItems = null;
            if (module == null)
            {
                selItems = _moduleService.Modules
                .Where(m => m.IsMenu == true && m.Enabled == true && m.ParentId == null)
                .Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() })
                .ToList();
            }
            else
            {
                selItems = _moduleService.Modules
                  .Where(m => m.IsMenu == true && m.Enabled == true && m.ParentId == null && m.Id != module.Id)
                  .Select(m => new SelectListItem()
                  {
                      Text = m.Name,
                      Value = m.Id.ToString(),
                      Selected = (module.ParentId.HasValue && module.ParentId.Value == m.Id)
                  })
                  .ToList();
            }

            ViewData["parentModules"] = selItems;
        }
    }
}
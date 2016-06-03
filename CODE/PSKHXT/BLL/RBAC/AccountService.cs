using IBLL.RBAC;
using IDAL;
using IDAL.RBAC;
using Infrastructure;
using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using ViewModel;

namespace BLL.RBAC
{
    /// <summary>
    /// 账户业务类
    /// </summary>
    public class AccountService : ServiceBase, IAccountService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IRoleService _RoleService;

        public AccountService(IUserRepository userRepository, IRoleService roleService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._UserRepository = userRepository;
            this._RoleService = roleService;
        }

        public IQueryable<User> Users
        {
            get
            {
                return this._UserRepository.Entities;
            }
        }

        public OperationResult Login(LoginVM loginInfo)
        {
            PublicHelper.CheckArgument(loginInfo, "loginInfo");
            User user = this._UserRepository
                .GetEntitiesByEager(new List<string> { "Roles", "UserGroups" })
                .SingleOrDefault(m => m.UserName == loginInfo.LoginName.Trim());
            OperationResult optResult;
            if (user == null)
            {
                optResult = new OperationResult(OperationResultType.QueryNull, "指定账户不存在");
            }
            else if (user.Password != EncryptionHelper.GetMd5Hash(loginInfo.Password.Trim()))
            {
                optResult = new OperationResult(OperationResultType.Warning, "用户密码不正确");
            }
            else
            {
                optResult = new OperationResult(OperationResultType.Success, "登录成功", user);
                SetUserPermissionCache(user);
            }
            if (optResult.ResultType != OperationResultType.Success)
            {
                return optResult;
            }
            SetAuthAndCookie(optResult.AppendData as User, loginInfo.IsRememberLogin);
            optResult.AppendData = null;
            return optResult;
        }

        /// <summary>
        /// 设置用户权限缓存
        /// </summary>
        /// <param name="user"></param>
        private void SetUserPermissionCache(User user)
        {
            var roleIds = user.Roles.Select(r => r.Id).ToList();//用户所属角色
            var roleIdsByUserGroup = user.UserGroups.SelectMany(g => g.Roles).Select(r => r.Id).ToList();//从用户组继承而来的角色
            roleIds.AddRange(roleIdsByUserGroup);//所有角色
            roleIds = roleIds.Distinct().ToList();//去重
            List<Permission> permissions = this._RoleService.Roles
                .Where(r => roleIds.Contains(r.Id) && r.Enabled)
                .SelectMany(r => r.Permissions)
                .Distinct()
                .ToList();
            SetUserPermissionCache(user, permissions);
        }

        /// <summary>
        /// 设置认证和cookie
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isRememberLogin"></param>
        private void SetAuthAndCookie(User user, bool isRememberLogin)
        {
            //失效时间
            DateTime expiration = isRememberLogin ? DateTime.Now.AddDays(LoginVM.RememberMeExpiration) : DateTime.Now.Add(FormsAuthentication.Timeout);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                version: 1,//指定版本号（随意）
               name: user.UserName,//登录用户名
               issueDate: DateTime.Now,//发布时间
               expiration: expiration,//失效时间
               isPersistent: true,//是否为持久Cookie
               userData: user.Id.ToString(),//用户数据:可用 ((System.Web.Security.FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData 获取
               cookiePath: FormsAuthentication.FormsCookiePath//指定 Cookie 为 Web.config 中 <forms path="/" … /> path 属性，不指定则默认为“/”
                );
            //设置cookie
            string str = FormsAuthentication.Encrypt(authTicket);//加密身份验票
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, str);
            if (isRememberLogin)
            {
                cookie.Expires = DateTime.Now.AddDays(LoginVM.RememberMeExpiration);//此句非常重要，少了的话，就算此 Cookie 在身份验票中指定为持久性 Cookie ，也只是即时型的 Cookie 关闭浏览器后就失效；
            }
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                return;
            }
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 设置用户权限缓存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissions"></param>
        public void SetUserPermissionCache(User user, List<Permission> permissions)
        {
            var strCacheKey = CacheKey.StrPermissionsByUid + "_" + user.Id;
            //设置Cache过期时间为1天
            CacheHelper.SetCache(strCacheKey, permissions, Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0, 0));
        }
    }
}

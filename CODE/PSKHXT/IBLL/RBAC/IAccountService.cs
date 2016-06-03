using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace IBLL.RBAC
{
    /// <summary>
    /// 账户模块业务接口
    /// </summary>
    public interface IAccountService
    {
        IQueryable<User> Users { get; }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        /// <returns>业务操作结果OperationResult</returns>
        OperationResult Login(LoginVM loginInfo);

        /// <summary>
        /// 用户退出
        /// </summary>
        void Logout();
        /// <summary>
        /// 设置用户权限缓存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissions"></param>
        void SetUserPermissionCache(User user, List<Permission> permissions);
    }
}

using Infrastructure.OptResult;
using Model.RBAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.RBAC;

namespace IBLL.RBAC
{
    /// <summary>
    /// 用户信息业务接口
    /// </summary>
    public interface IUserService
    {
        IQueryable<User> Users { get; }
        OperationResult Insert(UserVM userVM);
        OperationResult Update(UserVM userVM);
        OperationResult Delete(IEnumerable<UserVM> list);
        OperationResult ResetPassword(IEnumerable<UserVM> list);
        OperationResult UpdateUserRoles(int userId, string[] chkRoleIds);
        OperationResult UpdateUserGroups(int userId, string[] chkUserGroupIds);
    }
}

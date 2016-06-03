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
    /// 用户组信息业务接口
    /// </summary>
    public interface IUserGroupService
    {
        IQueryable<UserGroup> UserGroups { get; }
        OperationResult Insert(UserGroupVM userGroupVM);
        OperationResult Update(UserGroupVM userGroupVM);
        OperationResult Delete(IEnumerable<UserGroupVM> list);
        OperationResult UpdateUserGroupRoles(int userGroupId, string[] chkRoleIds);
    }
}

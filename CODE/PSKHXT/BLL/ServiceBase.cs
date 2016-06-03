using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 核心业务实现基类
    /// </summary>
    public class ServiceBase
    {
        protected IUnitOfWork UnitOfWork;
        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}

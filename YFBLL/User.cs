using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFBLL
{
    /// <summary>
    /// 用户业务层(调用数据访问层方法，取得数据库结果)
    /// </summary>
   public class BLLUser
    {

        public static bool BLL_AddUser (YFModel.User user)
        {
            return YFDAL.DAL_User.DAL_AddUser(user);

        }
    }
}

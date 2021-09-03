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

        public static List<YFModel.User> list()
        {
            return YFDAL.DALUser.List();
        }

        public static bool BLL_AddUser (YFModel.User user)
        {
            return YFDAL.DALUser.DAL_AddUser(user);
        }

        public static YFModel.User BLL_GetUser(int id)
        {
            return YFDAL.DALUser.DAL_GetUser(id);
        }

        public static YFModel.User BLL_GetUser(string username)
        {
            return YFDAL.DALUser.DAL_GetUser(username);
        }

        public static bool BLL_UptUser(YFModel.User user)
        {
            return YFDAL.DALUser.DAL_UptUser(user);
        }

        public static bool BLL_DelUser(int id)
        {
            return YFDAL.DALUser.DAL_DelUser(id);
        }

        public static bool BLL_SearchUser(string username)
        {
            return YFDAL.DALUser.DAL_UserSearch(username);
        }
        public static bool BLL_UserLogin(string username,string password)
        {
            return YFDAL.DALUser.DAL_UserLogin(username,password);
        }

    }
}

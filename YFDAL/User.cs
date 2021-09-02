using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFDAL
{
    /// <summary>
    /// 用户数据访问层
    /// </summary>
    public class DAL_User
    {
        /// <summary>
        /// ユーザ登録
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool DAL_AddUser(YFModel.User user)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("INSERT INTO ");
            strsql.Append("t_user( ");
            strsql.Append("username ");
            strsql.Append(",password ");
            strsql.Append(",name ");
            strsql.Append(",address ");
            strsql.Append(",sex ");
            strsql.Append(",mobile ");
            strsql.Append(",email ");
            strsql.Append(",qq ");
            strsql.Append(",state ");
            strsql.Append(",adddate ");
            strsql.Append(")VALUES( ");
            strsql.AppendFormat("  {0} ",user.Username);
            strsql.AppendFormat(" ,{0} ", user.Password);
            strsql.AppendFormat(" ,{0} ", user.Name);
            strsql.AppendFormat(" ,{0} ", user.Address);
            strsql.AppendFormat(" ,{0} ", user.Sex);
            strsql.AppendFormat(" ,{0} ", user.Mobile);
            strsql.AppendFormat(" ,{0} ", user.Email);
            strsql.AppendFormat(" ,{0} ", user.Qq); ;
            strsql.AppendFormat(" ,{0} ", user.State);
            strsql.AppendFormat(" ,{0} ", user.Adddate);
            strsql.Append(") ");

            //string strsql = " insert into t_user (username,password,name,address,sex,mobile,email,qq,state,adddate) values ('"+ user.Username + "','"+ user.Password + "','"+ user.Name+"','"+user.Address+"','"+user.Sex+"','"+ user .Mobile+ "','"+user.Email+"','"+user.Qq+"','"+user.State+"','" + user.Adddate+ "') ";

            int intRes = YFUtility.YFMsSqlHelper.ExecuteSql(strsql.ToString());

            if(intRes>0)
            {
                result = true;
            }
            return result;

        }
    }
}

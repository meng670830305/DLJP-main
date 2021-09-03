using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFDAL
{
    /// <summary>
    /// 用户数据访问层
    /// </summary>
    public class DALUser
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
            strsql.AppendFormat("  '{0}' ",user.Username);
            strsql.AppendFormat(" ,'{0}' ", user.Password);
            strsql.AppendFormat(" ,'{0}' ", user.Name);
            strsql.AppendFormat(" ,'{0}' ", user.Address);
            strsql.AppendFormat(" ,{0} ", user.Sex);
            strsql.AppendFormat(" ,'{0}' ", user.Mobile);
            strsql.AppendFormat(" ,'{0}' ", user.Email);
            strsql.AppendFormat(" ,'' ", user.Qq); ;
            strsql.AppendFormat(" ,{0} ", user.State);
            strsql.AppendFormat(" ,CONVERT(DATETIME,'{0}')", user.Adddate);
            strsql.Append(") ");

            int intRes = YFUtility.YFMsSqlHelper.ExecuteSql(strsql.ToString());

            if(intRes>0)
            {
                result = true;
            }
            return result;

        }

        public static bool DAL_UserSearch(string username)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT *   ");
            strsql.Append("FROM t_user ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND username= '{0}' ", username);
            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            if(dt.Rows.Count != 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public static bool DAL_UserLogin(string username,string password)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * ");
            strsql.Append("FROM t_user ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND username= '{0}' ", username);
            strsql.AppendFormat("AND password= '{0}' ", password);
            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            if (dt.Rows.Count == 0)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public static List<YFModel.User> List()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * ");
            strsql.Append("FROM t_user ");
            strsql.Append("ORDER BY ");
            strsql.Append("id  desc");
            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            return Dttolist(dt);
        }

        public static List<YFModel.User> Dttolist(DataTable dt)
        {
            List<YFModel.User> list = new List<YFModel.User>();
            if (dt.Rows.Count != 0)
            {
                for (int i=0;i <dt.Rows.Count;i++)
                {
                    YFModel.User user = new YFModel.User();
                    user.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    user.Username = dt.Rows[i]["username"].ToString();
                    user.Password = dt.Rows[i]["password"].ToString();
                    user.Name = dt.Rows[i]["name"].ToString();
                    user.Address = dt.Rows[i]["address"].ToString();
                    user.Sex = int.Parse(dt.Rows[i]["sex"].ToString());
                    user.Address = dt.Rows[i]["address"].ToString();
                    user.Mobile = dt.Rows[i]["mobile"].ToString();
                    user.Email = dt.Rows[i]["email"].ToString(); ;
                    user.State = int.Parse(dt.Rows[i]["state"].ToString());
                    user.Adddate = DateTime.Parse(dt.Rows[i]["adddate"].ToString());

                    list.Add(user);
                }
            }
            return list;
        }

        public static YFModel.User DAL_GetUser(string username)
        {
            YFModel.User user = new YFModel.User();
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * ");
            strsql.Append("FROM t_user ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND username= '{0}' ", username);

            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            if (dt.Rows.Count != 0)
            {
                user.Id = int.Parse(dt.Rows[0]["id"].ToString());
                user.Username = dt.Rows[0]["username"].ToString();
                user.Password = dt.Rows[0]["password"].ToString();
                user.Name = dt.Rows[0]["name"].ToString();
                user.Address = dt.Rows[0]["address"].ToString();
                user.Sex = int.Parse(dt.Rows[0]["sex"].ToString());
                user.Address = dt.Rows[0]["address"].ToString();
                user.Mobile = dt.Rows[0]["mobile"].ToString();
                user.Email = dt.Rows[0]["email"].ToString(); ;
                user.State = int.Parse(dt.Rows[0]["state"].ToString());
                user.Adddate = DateTime.Parse(dt.Rows[0]["adddate"].ToString());
            }
            return user;
        }

        public static YFModel.User DAL_GetUser(int id)
        {
            YFModel.User user = new YFModel.User();
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * ");
            strsql.Append("FROM t_user ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND id= '{0}' ", id);
            
            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            if (dt.Rows.Count != 0)
            {
                user.Id = int.Parse(dt.Rows[0]["id"].ToString());
                user.Username = dt.Rows[0]["username"].ToString();
                user.Password = dt.Rows[0]["password"].ToString();
                user.Name = dt.Rows[0]["name"].ToString();
                user.Address = dt.Rows[0]["address"].ToString();
                user.Sex = int.Parse(dt.Rows[0]["sex"].ToString());
                user.Address = dt.Rows[0]["address"].ToString();
                user.Mobile = dt.Rows[0]["mobile"].ToString();
                user.Email = dt.Rows[0]["email"].ToString(); ;
                user.State = int.Parse(dt.Rows[0]["state"].ToString());
                user.Adddate = DateTime.Parse(dt.Rows[0]["adddate"].ToString());
            }
            return user;
        }

            public static bool DAL_UptUser(YFModel.User user)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("UPDATE t_user ");
            strsql.Append("SET  ");
            strsql.AppendFormat("  password = '{0}' ", user.Password);
            strsql.AppendFormat(" ,name = '{0}' ", user.Name);
            strsql.AppendFormat(" ,address = '{0}' ", user.Address);
            strsql.AppendFormat(" ,sex = {0} ", user.Sex);
            strsql.AppendFormat(" ,mobile = '{0}' ", user.Mobile);
            strsql.AppendFormat(" ,email = '{0}' ", user.Email);
            strsql.AppendFormat(" ,qq = '' ", user.Qq); ;
            strsql.AppendFormat(" ,state = {0} ", user.State);
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND id= {0} ", user.Id);
            int intRes = YFUtility.YFMsSqlHelper.ExecuteSql(strsql.ToString());
            if (intRes > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static bool DAL_DelUser(int id)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("DELETE ");
            strsql.Append("FROM t_user ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND id= '{0}' ", id);
            int intRes = YFUtility.YFMsSqlHelper.ExecuteSql(strsql.ToString());
            if (intRes>0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFDAL
{
    public class DALShopping
    {
        public static bool Add_Shopping(YFModel.Shopping shopping)
        {
            bool blnRes = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("INSERT INTO ");
            strsql.Append("t_shopping ( ");
            strsql.Append("goodsid ");
            strsql.Append(",userid ");
            strsql.Append(",num ");
            strsql.Append(",state ");
            strsql.Append(",adddate ");
            strsql.Append(")VALUES( ");
            strsql.AppendFormat("   {0} ", shopping.Goods.Id);
            strsql.AppendFormat(" , {0} ", shopping.User.Id);
            strsql.AppendFormat(" , {0} ", shopping.Num);
            strsql.AppendFormat(" , {0} ", shopping.State);
            strsql.AppendFormat(" ,CONVERT(DATETIME,'{0}')", shopping.Adddate);
            strsql.Append(") ");

            int intRes = YFUtility.YFMsSqlHelper.ExecuteSql(strsql.ToString());

            if (intRes > 0)
            {
                blnRes = true;
            }
            return blnRes;
        }

        public static bool DAL_DelShopping(int id)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("DELETE ");
            strsql.Append("FROM t_shopping ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND id= '{0}' ", id);
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

        public static List<YFModel.Shopping> DAL_SearchShopping(int goodsId,int userId,int state)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * ");
            strsql.Append("FROM t_shopping ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND goodsId = {0} ", goodsId);
            strsql.AppendFormat("AND userid = {0} ", userId);
            strsql.AppendFormat("AND state = {0} ", state);
            strsql.Append("ORDER BY ");
            strsql.Append("id  desc");
            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            
            //if (dt.Rows.Count > 0)
            //{
            //    result = true;
            //}
            //else
            //{
            //    result = false;
            //}
            return Dttolist(dt);
        }


        public static List<YFModel.Shopping> List()
        {
            YFModel.User user = (YFModel.User)YFUtility.SessionHelper.GetSession("user");
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * ");
            strsql.Append("FROM t_shopping ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND userid = {0} ",user.Id);
            strsql.Append("ORDER BY ");
            strsql.Append("id  desc");
            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            return Dttolist(dt);
        }
        public static List<YFModel.Shopping> Dttolist(DataTable dt)
        {
            List<YFModel.Shopping> list = new List<YFModel.Shopping>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    YFModel.Shopping shopping = new YFModel.Shopping();
                    shopping.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    YFModel.Goods goods= YFDAL.DALGoods.GetGoods(int.Parse(dt.Rows[i]["goodsid"].ToString()));
                    shopping.Goods = goods;
                    YFModel.User user = YFDAL.DALUser.DAL_GetUser(int.Parse(dt.Rows[i]["userid"].ToString()));
                    shopping.User = user;
                    shopping.Num = int.Parse(dt.Rows[i]["num"].ToString());
                    shopping.State = int.Parse(dt.Rows[i]["state"].ToString());
                    shopping.Adddate = DateTime.Parse(dt.Rows[i]["adddate"].ToString());

                    list.Add(shopping);
                }
            }
            return list;
        }

        public static bool DAL_UptShopping(int goodsId, int userId, int state)
        {
            bool result = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("UPDATE t_shopping ");
            strsql.Append("SET  ");
            strsql.Append("  num = num+1 ");
            strsql.Append("WHERE ");
            strsql.Append("1=1 ");
            strsql.AppendFormat("AND goodsid= {0} ", goodsId);
            strsql.AppendFormat("AND userid= {0} ", userId);
            strsql.AppendFormat("AND state= {0} ", state);
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

    }
}

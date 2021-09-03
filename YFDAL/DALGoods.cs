using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YFUtility;

namespace YFDAL
{
    public class DALGoods
    {
        public static bool Add_Goods(YFModel.Goods goods)
        {
            bool blnRes = false;
            StringBuilder strsql = new StringBuilder();
            strsql.Append("INSERT INTO ");
            strsql.Append("t_goods( ");
            strsql.Append("title ");
            strsql.Append(",price ");
            strsql.Append(",num ");
            strsql.Append(",img ");
            strsql.Append(",detail ");
            strsql.Append(",state ");
            strsql.Append(",adddate ");
            strsql.Append(")VALUES( ");
            strsql.AppendFormat("  '{0}' ", goods.Title);
            strsql.AppendFormat(" , {0} ", goods.Price);
            strsql.AppendFormat(" , {0} ", goods.Num);
            strsql.AppendFormat(" ,'{0}' ", goods.Img);
            strsql.AppendFormat(" ,'{0}' ", goods.Detail);
            strsql.AppendFormat(" ,{0} ", goods.State);
            strsql.AppendFormat(" ,CONVERT(DATETIME,'{0}')", goods.Adddate);
            strsql.Append(") ");

            int intRes = YFUtility.YFMsSqlHelper.ExecuteSql(strsql.ToString());

            if (intRes > 0)
            {
                blnRes = true;
            }
            return blnRes;
        }

        public static List<YFModel.Goods> List()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT * ");
            strsql.Append("FROM t_goods ");
            strsql.Append("ORDER BY ");
            strsql.Append("id  desc");
            DataTable dt = new DataTable();
            dt = YFUtility.YFMsSqlHelper.Query(strsql.ToString()).Tables[0];
            return Dttolist(dt);
        }
        public static List<YFModel.Goods> Dttolist(DataTable dt)
        {
            List<YFModel.Goods> list = new List<YFModel.Goods>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    YFModel.Goods goods = new YFModel.Goods();
                    goods.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    goods.Title = dt.Rows[i]["title"].ToString();
                    goods.Price =int.Parse(dt.Rows[i]["price"].ToString());
                    goods.Num = int.Parse(dt.Rows[i]["num"].ToString());
                    goods.Img = dt.Rows[i]["img"].ToString();
                    goods.Detail = dt.Rows[i]["detail"].ToString();
                    goods.State = int.Parse(dt.Rows[i]["state"].ToString());
                    goods.Adddate =DateTime.Parse(dt.Rows[i]["adddate"].ToString());
                    
                    list.Add(goods);
                }
            }
            return list;
        }
    }
}

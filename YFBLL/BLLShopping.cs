using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFBLL
{
    public class BLLShopping
    {
        public static bool Add_shopping(YFModel.Shopping shopping)
        {
            return YFDAL.DALShopping.Add_Shopping(shopping);
        }

        public static bool Del_shopping(int id)
        {
            return YFDAL.DALShopping.DAL_DelShopping(id);
        }

        public static List<YFModel.Shopping> list()
        {
            return YFDAL.DALShopping.List();
        }

        public static List<YFModel.Shopping> list(int goodsId,int userId,int state)
        {
            return YFDAL.DALShopping.DAL_SearchShopping(goodsId, userId, state);
        }

        public static bool BLL_UptShopping(int goodsId, int userId, int state)
        {
            return YFDAL.DALShopping.DAL_UptShopping(goodsId, userId, state);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YFUtility;
using YFModel;


namespace YFBLL
{
    public class BLLGoods
    {
        public static bool Add_Goods(YFModel.Goods goods)
        {
            return YFDAL.DALGoods.Add_Goods(goods);
        }

        public static List<YFModel.Goods> list()
        {
            return YFDAL.DALGoods.List();
        }

        public static YFModel.Goods GetGoods(int id)
        {
            return YFDAL.DALGoods.GetGoods(id);
        }



    }
}

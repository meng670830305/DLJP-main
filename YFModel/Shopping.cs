using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFModel
{
    public class Shopping
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        private int id;
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// 関連商品
        /// </summary>
        private YFModel.Goods goods;
        public Goods Goods { get => goods; set => goods = value; }
        /// <summary>
        /// 関連ユーザー
        /// </summary>
        private YFModel.User user;
        public User User { get => user; set => user = value; }
        /// <summary>
        /// 数量
        /// </summary>
        private int num;
        public int Num { get => num; set => num = value; }
        /// <summary>
        /// 状態
        /// </summary>
        private int state;
        public int State { get => state; set => state = value; }

        /// <summary>
        /// 作成日付
        /// </summary>
        private DateTime adddate;
        public DateTime Adddate { get => adddate; set => adddate = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFModel
{
    public class Goods
    {
        private int id;
        private string title;
        private int price;
        private int num;
        private string img;
        private string detail;
        private int state;
        private DateTime adddate;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int Price { get => price; set => price = value; }
        public string Img { get => img; set => img = value; }
        public string Detail { get => detail; set => detail = value; }
        public int State { get => state; set => state = value; }
        public DateTime Adddate { get => adddate; set => adddate = value; }
        public int Num { get => num; set => num = value; }
    }
}

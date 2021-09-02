using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YFModel
{
    public class User
    {
        private int id;
        public int Id
        {
            get { return Id; }
            set { Id = value; }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;
        public string Password { get => password; set => password = value; }

        private string name;
        public string Name { get => password; set => password = value; }


        private string address;
        public string Address { get => address; set => address = value; }


        private int sex;
        public int Sex { get => sex; set => sex = value; }
        
        
        private string mobile;
        public string Mobile { get => mobile; set => mobile = value; }

        private string email;
        public string Email { get => email; set => email = value; }

        private string qq;
        public string Qq { get => qq; set => qq = value; }

        private int state;
        public int State { get => state; set => state = value; }
        

        private DateTime adddate;
        public DateTime Adddate { get => adddate; set => adddate = value; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class AccountModel
    {
        public int id { set; get; }
        public String userName { set; get; }
        public String passWord { set; get; }

        public String name { set; get; }
        public String mobile { set; get; }
        public String email { set; get; }

        public String mgs { set; get; }
    }
}
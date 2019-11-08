using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class UserRoleModel
    {
        public UserRoleModel()
        {

        }

        public UserRoleModel(int userId, string sRole)
        {
            this.userId = userId;
            this.sRole = sRole;
        }

        public int userId { set; get; }
        public string sRole { set; get; }
    }
}
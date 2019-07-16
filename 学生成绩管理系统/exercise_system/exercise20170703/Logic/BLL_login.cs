using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exercise20170703.Logic
{
    public class BLL_login
    {
        Data.DAL_login dal = new Data.DAL_login();

        //登录校验,返回结果
        public bool Login(string username, string password)
        {
            return dal.Login(username, password);
        }
    }
}
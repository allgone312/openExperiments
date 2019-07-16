using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2016816_vs2015.BLL
{
    public class BLL_Login
    {
        DAL.DAL_Login dal = new DAL.DAL_Login();

        /// <summary>
        /// 是否存在当前用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool isUserExist(string name, string password)
        {
            return dal.isUserExist(name, password);
        }
    }
}

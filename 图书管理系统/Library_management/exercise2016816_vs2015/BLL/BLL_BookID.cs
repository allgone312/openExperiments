using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2016816_vs2015.BLL
{
    public class BLL_BookID
    {
        private DAL.DAL_BookID dal = new DAL.DAL_BookID();

        /// <summary>
        /// 是否存在书号
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public bool isbookidExist(string bookid)
        {
            return dal.isbookidExist(bookid);
        }
    }
}

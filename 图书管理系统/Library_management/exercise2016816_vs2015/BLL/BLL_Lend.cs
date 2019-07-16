using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2016816_vs2015.BLL
{
    public class BLL_Lend
    {
        public DAL.DAL_Lend dal = new DAL.DAL_Lend();

        /// <summary>
        /// 插入一条借阅信息
        /// </summary>
        /// <param name="lend"></param>
        public void insertLend(Lend lend)
        {
            dal.insertLend(lend);
        }

        /// <summary>
        /// 获取全部借阅信息
        /// </summary>
        /// <returns></returns>
        public LinkedList<Lend> readLend()
        {
            return dal.readLend();
        }

        /// <summary>
        /// 删除一条借阅信息
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="bookid"></param>
        public void delLend(string isbn,string bookid)
        {
            dal.delLend(isbn,bookid);
        }

        /// <summary>
        /// 是否存在当前书号的借阅信息
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public bool isBookIDExit(string bookid)
        {
            return dal.isBookIDExit(bookid);
        }
    }
}

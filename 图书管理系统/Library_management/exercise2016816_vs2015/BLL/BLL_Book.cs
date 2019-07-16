using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2016816_vs2015.BLL
{
    public class BLL_Book
    {
        public DAL_Book dal = new DAL_Book();

        /// <summary>
        /// 插入一本图书
        /// </summary>
        /// <param name="book"></param>
        public void insertBook(Book book)
        {
            dal.insertBook(book);
        }

        /// <summary>
        /// 获取全部书籍
        /// </summary>
        /// <returns></returns>
        public LinkedList<Book> readBook()
        {
            return dal.readBook();
        }

        /// <summary>
        /// 改变一本书籍数据
        /// </summary>
        /// <param name="book"></param>
        public void updateBook(Book book)
        {
            dal.updateBook(book);
        }

        /// <summary>
        /// 书籍是否存在
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public bool isBookExit(string isbn)
        {
            return dal.isBookExit(isbn);
        }

        /// <summary>
        /// 获取某本特定书籍
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Book getBook(string isbn)
        {
            LinkedList<Book> books = dal.readBook();
            Node<Book> outNode = books.Head.Next;
            int count = books.count;
            while (count != 0)
            {
                if (outNode.Data.ISBN == isbn)
                {
                    return outNode.Data;
                }
                outNode = outNode.Next;
                count--;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise2016816_vs2015
{
    public class DAL_Book
    {
        public string xmlPath;//book.xml路径
        public XmlDocument xmlDoc;
        public XmlNode xn;

        public DAL_Book()
        {
            xmlPath = MyClass.bookXml;
            xmlDoc = new XmlDocument();
        }
        /// <summary>
        /// 插入一本图书
        /// </summary>
        /// <param name="book"></param>
        public void insertBook(Book book)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("bookstore");
            XmlElement xelKey = xmlDoc.CreateElement("book");
            XmlAttribute xelName = xmlDoc.CreateAttribute("Name");
            xelName.InnerText = book.Name;
            xelKey.SetAttributeNode(xelName);
            XmlAttribute xelISBN = xmlDoc.CreateAttribute("ISBN");
            xelISBN.InnerText = book.ISBN;
            xelKey.SetAttributeNode(xelISBN);

            XmlElement xelAuthor = xmlDoc.CreateElement("Author");
            xelAuthor.InnerText = book.author;
            xelKey.AppendChild(xelAuthor);
            XmlElement xelTotalNum = xmlDoc.CreateElement("totalNum");
            xelTotalNum.InnerText = book.totalNum.ToString();
            xelKey.AppendChild(xelTotalNum);
            XmlElement xelNowNum = xmlDoc.CreateElement("nowNum");
            xelNowNum.InnerText = book.nowNum.ToString();
            xelKey.AppendChild(xelNowNum);
            xn.AppendChild(xelKey);
            xmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 获取所有图书信息
        /// </summary>
        /// <returns></returns>
        public LinkedList<Book> readBook()
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("bookstore");
            LinkedList<Book> books = new LinkedList<Book>();
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
                Book book = new Book();
                XmlElement xe = (XmlElement)xn1;
                book.ISBN = xe.GetAttribute("ISBN").ToString();
                book.Name = xe.GetAttribute("Name").ToString();
                XmlNodeList xnl0 = xe.ChildNodes;
                book.author = xnl0.Item(0).InnerText;
                book.totalNum = int.Parse(xnl0.Item(1).InnerText);
                book.nowNum = int.Parse(xnl0.Item(2).InnerText);
                books.In(book);
            }
            return books;
        }
        
        /// <summary>
        /// 改变一本书的数据
        /// </summary>
        /// <param name="book"></param>
        public void updateBook(Book book)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("bookstore");
            XmlElement xe = xmlDoc.DocumentElement;
            string strPath = string.Format("/bookstore/book[@ISBN=\"{0}\"]", book.ISBN);
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);
            selectXe.SetAttribute("Name", book.Name);
            selectXe.GetElementsByTagName("Author").Item(0).InnerText = book.author;
            selectXe.GetElementsByTagName("totalNum").Item(0).InnerText = book.totalNum.ToString();
            selectXe.GetElementsByTagName("nowNum").Item(0).InnerText = book.nowNum.ToString();
            xmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 书籍是否存在
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public bool isBookExit(string isbn)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("bookstore");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
                XmlElement xe = (XmlElement)xn1;
                if (xe.GetAttribute("ISBN") == isbn)
                    return true;
            }
            return false;
        }
    }
}

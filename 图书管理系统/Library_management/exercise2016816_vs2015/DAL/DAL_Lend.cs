using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise2016816_vs2015.DAL
{
    public class DAL_Lend
    {
        public string xmlPath;//lend.xml路径
        public XmlDocument xmlDoc;
        public XmlNode xn;
        public DAL_Lend()
        {
            xmlPath = MyClass.lendXml;
            xmlDoc = new XmlDocument();
        }

        /// <summary>
        /// 插入一条借阅信息
        /// </summary>
        /// <param name="lend"></param>
        public void insertLend(Lend lend)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("lend");
            XmlElement xelKey = xmlDoc.CreateElement("person");
            XmlAttribute xelISBN = xmlDoc.CreateAttribute("ISBN");
            xelISBN.InnerText = lend.ISBN;
            xelKey.SetAttributeNode(xelISBN);
            XmlAttribute xelBookId = xmlDoc.CreateAttribute("bookID");
            xelBookId.InnerText = lend.bookID;
            xelKey.SetAttributeNode(xelBookId);
            XmlAttribute xelDate = xmlDoc.CreateAttribute("date");
            xelDate.InnerText = lend.date.ToString();
            xelKey.SetAttributeNode(xelDate);

            xn.AppendChild(xelKey);
            xmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 获取全部借阅信息
        /// </summary>
        /// <returns></returns>
        public LinkedList<Lend> readLend()
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("lend");
            LinkedList<Lend> lends = new LinkedList<Lend>();
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
                Lend lend = new Lend();
                XmlElement xe = (XmlElement)xn1;
                lend.ISBN = xe.GetAttribute("ISBN").ToString();
                lend.bookID = xe.GetAttribute("bookID").ToString();
                lend.date = DateTime.Parse(xe.GetAttribute("date"));
                lends.In(lend);
            }
            return lends;
        }

        /// <summary>
        /// 删除一条借阅信息
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="bookid"></param>
        public void delLend(string isbn,string bookid)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("lend");
            XmlElement xe = xmlDoc.DocumentElement; // DocumentElement 获取xml文档对象的根XmlElement.
            string strPath = string.Format("/lend/person[@ISBN=\"{0}\" and @bookID=\"{1}\"]",isbn,bookid);
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);  //selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            if (selectXe == null)
                throw new Exception("不存在此借阅记录!");
            selectXe.ParentNode.RemoveChild(selectXe);
            xmlDoc.Save(xmlPath);
        }

        /// <summary>
        /// 是否存在当前书号的借阅信息
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public bool isBookIDExit(string bookid)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("lend");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode xn1 in xnl)
            {
                XmlElement xe = (XmlElement)xn1;
                if (xe.GetAttribute("bookID") == bookid)
                    return true;
            }
            return false;
        }
    }
}

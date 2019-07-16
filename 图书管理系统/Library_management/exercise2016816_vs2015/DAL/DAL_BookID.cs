using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise2016816_vs2015.DAL
{
    public class DAL_BookID
    {
        public string xmlPath;//bookid.xml路径
        public XmlDocument xmlDoc;
        public XmlNode xn;
        public DAL_BookID()
        {
            xmlPath = MyClass.bookidXml;
            xmlDoc = new XmlDocument();
        }

        /// <summary>
        /// 是否存在书号
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public bool isbookidExist(string bookid)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("login");
            XmlElement xe = xmlDoc.DocumentElement; // DocumentElement 获取xml文档对象的根XmlElement.
            string strPath = string.Format("/login/person[@bookid=\"{0}\"]", bookid);
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);  //selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            if (selectXe == null)
                return false;
            return true;
        }
    }
}

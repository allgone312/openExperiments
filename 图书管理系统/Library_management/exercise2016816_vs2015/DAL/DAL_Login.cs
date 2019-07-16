using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise2016816_vs2015.DAL
{
    public class DAL_Login
    {
        public string xmlPath;
        public XmlDocument xmlDoc;
        public XmlNode xn;
        public DAL_Login()
        {
            xmlPath = MyClass.loginXml;
            xmlDoc = new XmlDocument();
        }
        /// <summary>
        /// 是否存在当前用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool isUserExist(string name,string password)
        {
            xmlDoc.Load(xmlPath);
            xn = xmlDoc.SelectSingleNode("login");
            XmlElement xe = xmlDoc.DocumentElement; // DocumentElement 获取xml文档对象的根XmlElement.
            string strPath = string.Format("/login/person[@name=\"{0}\" and @password=\"{1}\"]", name,password);
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);  //selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            if (selectXe == null)
                return false;
            return true;
        }
    }
}

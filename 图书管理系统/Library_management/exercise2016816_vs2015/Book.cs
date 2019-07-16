using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2016816_vs2015
{
    /// <summary>
    /// 书籍信息的实体类
    /// </summary>
    public class Book
    {
        public string ISBN//书号
        {
            get;set;
        }
        public string Name//书名
        {
            get;set;
        }
        public string author//作者
        {
            get;set;
        }
        public int totalNum//库存量
        {
            get;set;
        }
        public int nowNum//现存量
        {
            get;set;
        }
    }
}

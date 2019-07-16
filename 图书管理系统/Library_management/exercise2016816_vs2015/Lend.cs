using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2016816_vs2015
{
    /// <summary>
    /// 借阅信息的实体类
    /// </summary>
    public class Lend
    {
        public string ISBN//书号
        {
            get;set;
        }
        public string bookID//书证号
        {
            get;set;
        }
        public DateTime date//归还日期
        {
            get;set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace exercise20170703.Logic
{
    public class BLL_query
    {
        private Data.DAL_student dals = new Data.DAL_student();
        private Data.DAL_major_list dalm = new Data.DAL_major_list();
        private Data.DAL_class dalc = new Data.DAL_class();

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public DataSet getAll()
        {
            return dals.getAll();
        }

        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <param name="major"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public DataSet getByKey(string major, string keyword)
        {
            return dals.getByKey(major, keyword);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="stu"></param>
        public void deleteStudent(aStudent stu)
        {
            dals.deleteStudent(stu);
        }
    }
}
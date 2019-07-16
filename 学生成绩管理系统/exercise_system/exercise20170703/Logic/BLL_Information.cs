using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exercise20170703.Logic
{
    public class BLL_Information
    {
        private Data.DAL_student dals = new Data.DAL_student();
        private Data.DAL_major_list dalm = new Data.DAL_major_list();
        private Data.DAL_class dalc = new Data.DAL_class();

        /// <summary>
        /// 查询一个学生
        /// </summary>
        /// <param name="mainkey"></param>
        /// <returns></returns>
        public aStudent getStudent(long mainid)
        {
            return dals.getStudent(mainid);
        }

        /// <summary>
        /// 根据专业id获取专业名
        /// </summary>
        /// <param name="mlid"></param>
        /// <returns></returns>
        public string getMajorName(int mlid)
        {
            return dalm.getMajorName(mlid);
        }
    }
}
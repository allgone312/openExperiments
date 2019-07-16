using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exercise20170703.Logic
{
    public class BLL_update
    {
        private Data.DAL_student dals = new Data.DAL_student();
        private Data.DAL_major_list dalm = new Data.DAL_major_list();
        private Data.DAL_class dalc = new Data.DAL_class();
        /// <summary>
        /// 根据专业名获取专业id
        /// </summary>
        /// <param name="major">专业名</param>
        /// <returns>专业id</returns>
        public int getMajorNum(string major)
        {
            return dalm.getMajorNum(major);
        }


        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="stu"></param>
        public void updateStudent(aStudent stu)
        {
            dals.updateStudent(stu);
        }

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
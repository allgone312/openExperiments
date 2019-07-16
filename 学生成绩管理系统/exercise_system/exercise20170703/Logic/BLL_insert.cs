using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exercise20170703.Logic
{    
    public class BLL_insert
    {
        private Data.DAL_student dals = new Data.DAL_student();
        private Data.DAL_major_list dalm = new Data.DAL_major_list();
        private Data.DAL_class dalc = new Data.DAL_class();

        /// <summary>
        /// 插入学生信息
        /// </summary>
        /// <param name="stu"></param>
        public void insertStudent(aStudent stu)
        {
            if (!dalc.isClassExist(stu.mlId, stu.time.Year))
                dalc.createClass(stu.time.Year, stu.mlId, 2);
            stu.classId = dalc.getClassId(stu.time.Year, stu.mlId);
            stu.studId = stu.classId * 100 + dalc.getClassPNum(stu.classId) + 1;
            dals.insertStudent(stu);
        }

        /// <summary>
        /// 根据专业名获取专业id
        /// </summary>
        /// <param name="major">专业名</param>
        /// <returns>专业id</returns>
        public int getMajorNum(string major)
        {
            return dalm.getMajorNum(major);
        }
    }
}
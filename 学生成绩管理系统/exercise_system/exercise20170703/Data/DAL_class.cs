using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace exercise20170703.Data
{
    public class DAL_class
    {
        protected string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();//连接字符串

        /// <summary>
        /// 查询是否存在该专业的班级
        /// </summary>
        /// <param name="mlid">专业</param>
        /// <param name="year">哪一级</param>
        /// <returns>存在返回1</returns>
        public bool isClassExist(int mlid,int year)
        {
            bool isE = false;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                //打开数据库
                con.Open();
                string sql = string.Format("select * from T_Class where mlid={0} and cyear={1}", mlid,year);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        isE = true;
                }
            }
            return isE;
        }

        /// <summary>
        /// 生成班级
        /// </summary>
        /// <param name="year">哪级学生</param>
        /// <param name="mlid">哪个专业</param>
        /// <param name="num">生成几个班级</param>
        public void createClass(int year,int mlid,int num)
        {
            List<long> list = new List<long>();
            for(int i=11;i<=10+num;i++)
            {
                long num1 = year * 100000 + mlid * 100 + i;
                list.Add(num1);
            }

            //创建与Student数据库的连接
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //打开数据库
                con.Open();
                foreach(long l in list)
                {
                    string sql = string.Format("insert into T_Class values({0},{1},{2},0)",l, mlid, year);
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                            throw new Exception("插入T_Class失败");
                    }
                }
            }
        }

        /// <summary>
        /// 获取要分配到的班级号
        /// </summary>
        /// <returns></returns>
        public long getClassId(int year,int mlid)
        {
            //创建与Student数据库的连接
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //打开数据库
                con.Open();
                string sql = string.Format("select top 1 classid from T_Class where mlid = {0} and cyear = {1} order by pnum", mlid, year);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                        throw new Exception("没有查询到班级号");
                    return (long)result;
                }
            }
        }

        /// <summary>
        /// 获取班级人数
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int getClassPNum(long classid)
        {
            int num;
            //创建与Student数据库的连接
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //打开数据库
                con.Open();
                string sql = string.Format("select pnum from T_Class where classid={0}", classid);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                        throw new Exception("没有查询到班级号");
                    num = (int)result;
                }
            }
            return num;
        }
    }
}
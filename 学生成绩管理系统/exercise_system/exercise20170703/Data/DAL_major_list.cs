using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace exercise20170703.Data
{
    public class DAL_major_list
    {
        protected string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();//连接字符串

        /// <summary>
        /// 获取专业列表
        /// </summary>
        public List<string> getMajorName()
        {
            List<string> list = new List<string>();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = "select * from T_Major_list";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader[2].ToString());
                    }
                    reader.Close();
                }
            }

            return list;
        }

        /// <summary>
        /// 根据专业名获取专业id
        /// </summary>
        /// <param name="major">专业名</param>
        /// <returns>专业id</returns>
        public int getMajorNum(string major)
        {
            int num = 0;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = string.Format("select * from T_Major_list where majorin='{0}'", major);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        num = int.Parse(reader[0].ToString());
                    }
                    reader.Close();
                }
            }

            return num;
        }

        /// <summary>
        /// 根据专业id获取专业名
        /// </summary>
        /// <param name="mlid"></param>
        /// <returns></returns>
        public string getMajorName(int mlid)
        {
            string majorin = "";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = string.Format("select * from T_Major_list where mlid='{0}'", mlid);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        majorin = reader[2].ToString();
                    }
                    reader.Close();
                }
            }
            return majorin;
        }
    }
}
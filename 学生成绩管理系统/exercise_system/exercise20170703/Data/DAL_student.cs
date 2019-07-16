using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace exercise20170703.Data
{
    public class DAL_student
    {
        protected string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();//连接字符串

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="stu"></param>
        public void insertStudent(aStudent stu)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = string.Format("insert into T_Student(idnumber,name,time,sex,birthdate,nation,birthplace,mlid,classid,studid,address,phone) " +
                    "values({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},'{10}',{11})",
                    stu.idNumber, stu.name, stu.time, stu.sex, stu.birthDate, stu.nation,
                    stu.birthPlace, stu.mlId, stu.classId, stu.studId, stu.address, stu.phone);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 0)
                        throw new Exception("插入T_Student失败");
                }
            }
        }

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="stu"></param>
        public void updateStudent(aStudent stu)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = string.Format("update T_Student set idnumber={0},name='{1}',time='{2}',"+
                    "sex='{3}',birthdate='{4}',nation='{5}',birthplace='{6}',mlid={7},"+
                    "classid={8},studid={9},'address={10}',phone={11} where mainkey={12}",
                    stu.idNumber, stu.name, stu.time, stu.sex, stu.birthDate, stu.nation,
                    stu.birthPlace, stu.mlId, stu.classId, stu.studId, stu.address, stu.phone,stu.mainKey);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 0)
                        throw new Exception("修改T_Student失败");
                }
            }
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="stu"></param>
        public void deleteStudent(aStudent stu)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = string.Format("delete from T_Student where mainid={0}", stu.mainKey);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result == 0)
                        throw new Exception("删除T_Student失败");
                }
            }
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public DataSet getAll()
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = @"select mainid as '编号', studid as '学号',name as '姓名',classid as '班级',majorin as '所选专业',idnumber as '身份证号'
                             from T_Student left join T_Major_list 
                             on T_Student.mlid = T_Major_list.mlid 
                             order by studid";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.Fill(ds);
                }
            }
            return ds;
        }

        /// <summary>
        /// 条件筛选
        /// </summary>
        /// <param name="major"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public DataSet getByKey(string major,string keyword)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = @"select mainid as '编号', studid as '学号',name as '姓名',classid as '班级',majorin as '所选专业',idnumber as '身份证号'
                             from T_Student left join T_Major_list 
                             on T_Student.mlid = T_Major_list.mlid";

                sql += string.Format(" where majorin='{0}'", major);

                if (keyword != "")
                    sql += string.Format(" and name like '%{0}%'", keyword);

                sql +=" order by studid";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.Fill(ds);
                }
            }
            return ds;
        }

        /// <summary>
        /// 查询一个学生
        /// </summary>
        /// <param name="mainkey"></param>
        /// <returns></returns>
        public aStudent getStudent(long mainid)
        {
            //创建与Student数据库的连接
            using (SqlConnection con = new SqlConnection(conStr))
            {
                aStudent stu = new aStudent();
                //打开数据库
                con.Open();
                string sql = string.Format("select * from T_Student where mainid={0}",mainid);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    var reader = cmd.ExecuteReader();
                    if (reader == null)
                        throw new Exception("未查询到任何数据");
                    while(reader.Read())
                    {
                        stu.mainKey = (long)reader[0];
                        stu.idNumber = (long)reader[1];
                        stu.name = reader[2].ToString();
                        stu.time = (DateTime)reader[3];
                        stu.sex = reader[4].ToString();
                        stu.birthDate = (DateTime)reader[5];
                        stu.nation = reader[6].ToString();
                        stu.birthPlace = reader[7].ToString();
                        stu.mlId = (int)reader[8];
                        stu.classId = (long)reader[9];
                        stu.studId = (long)reader[10];
                        stu.address = reader[11].ToString();
                        stu.phone = (long)reader[12];
                    }

                    reader.Close();
                    return stu;
                }
            }
        }
    }
}
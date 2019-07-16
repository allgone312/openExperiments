using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace exercise20170703.Data
{
    public class DAL_login
    {
        protected string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();//连接字符串

        //登录校验,返回结果
        public bool Login(string username, string password)
        {
            bool isSuccess = false;
            //连接数据库
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //打开数据库
                con.Open();
                //校验用户名和密码
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "select count(*) from T_role where username=@Username and password=@Password";
                    cmd.Parameters.Add(new SqlParameter("Username", username));
                    cmd.Parameters.Add(new SqlParameter("Password", password));
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result > 0)
                    {
                        isSuccess = true;
                    }
                }
                //登录失败时找出错误
                if (isSuccess == false)
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "select * from T_role where username='" + username + "'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                throw new Exception("密码错误");
                            else
                                throw new Exception("用户不存在");
                        }
                    }
                }
            }
            return isSuccess;
        }
    }
}
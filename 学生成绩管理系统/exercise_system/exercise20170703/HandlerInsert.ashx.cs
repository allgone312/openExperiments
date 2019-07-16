using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exercise20170703
{
    /// <summary>
    /// 对Insert.aspx的要求作出反应
    /// </summary>
    public class HandlerInsert : IHttpHandler
    {
        Data.DAL_major_list dal = new Data.DAL_major_list();
        public void ProcessRequest(HttpContext context)
        {
            var data = context.Request["data"];
            context.Response.ContentType = "text/plain";
            try
            {
                if (data == "1")
                {
                    List<string> list = new List<string>();
                    list = dal.getMajorName();
                    string res = string.Empty;
                    res = string.Join("-", list);
                    context.Response.Write(res);
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                context.Response.Write("error");
                ex.GetType();//用户异常处理
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
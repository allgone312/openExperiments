using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exercise20170703
{
    public partial class Query : System.Web.UI.Page
    {
        Logic.BLL_query bll = new Logic.BLL_query();
        protected string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();//连接字符串
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Request.Cookies["susername"] != null)
                {
                    admin_name.InnerHtml = HttpContext.Current.Request.Cookies["susername"].Value.Trim();
                }
                GridView1.DataSource = bll.getAll();
                GridView1.DataBind();
            }
            catch(Exception exce)
            {

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = bll.getAll();
            GridView1.DataBind();
        }

        protected void btn_sear_ServerClick(object sender, EventArgs e)
        {
            string major = Request.Form["smajor"].ToString();
            string keyword = Request.Form["sname"].ToString().Trim();
            GridView1.DataSource = bll.getByKey(major, keyword);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int i = e.NewSelectedIndex;//获得当前选择列的行标
            string idStr = GridView1.DataKeys[i].Value.ToString();//DataKeyNames="mainid"获取主键的值
            Response.Redirect("Information.aspx?mainid=" + idStr);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int i = e.NewEditIndex;//获得当前选择列的行标
            string idStr = GridView1.DataKeys[i].Value.ToString();//DataKeyNames="mainid"获取主键的值
            Response.Redirect("Update.aspx?mainid=" + idStr);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int i = e.RowIndex;//获取选中行的索引
                string idStr = GridView1.DataKeys[i].Value.ToString();//DataKeyNames="ID"获取主键的值
                long id = Convert.ToInt64(idStr);
                aStudent stu = new aStudent();
                stu.mainKey = id;
                bll.deleteStudent(stu);
                GridView1.DataSource = bll.getAll();
                GridView1.DataBind();
            }
            catch (Exception exce)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "error", "<script>alert('" + exce.Message + "！')</script>");
            }
        }
    }
}
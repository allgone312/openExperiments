using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exercise20170703
{
    public partial class Login : System.Web.UI.Page
    {
        Logic.BLL_login bll = new Logic.BLL_login();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_log_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if(bll.Login(username.Value, password.Value))
                {
                    //添加cookie缓存
                    HttpCookie cookie = new HttpCookie("susername");
                    cookie.Value = username.Value;
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception exce)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "error", "<script>alert('" + exce.Message + "！')</script>");
            }
        }
    }
}
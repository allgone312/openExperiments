using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exercise20170703
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["susername"] != null)
            {
                admin_name.InnerHtml = HttpContext.Current.Request.Cookies["susername"].Value.Trim();
            }
        }
    }
}
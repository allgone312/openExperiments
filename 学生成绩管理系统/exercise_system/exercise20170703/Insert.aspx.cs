using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exercise20170703
{
    public partial class Insert : System.Web.UI.Page
    {
        private Logic.BLL_insert bll = new Logic.BLL_insert();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["susername"] != null)
            {
                admin_name.InnerHtml = HttpContext.Current.Request.Cookies["susername"].Value.Trim();
            }
        }

        protected void btn_sub_ServerClick(object sender, EventArgs e)
        {
            aStudent stu = new aStudent();
            stu.idNumber = long.Parse(idnumber.Value);
            stu.name = sname.Value;
            stu.time = DateTime.Parse(stime.Value);
            stu.sex = ssex.Value;
            stu.birthDate = DateTime.Parse(sbirthdate.Value);
            stu.nation = snation.Value;
            stu.birthPlace = sbirthplace.Value;
            stu.mlId = bll.getMajorNum(Request.Form["smajor"]);

            if(saddress.Value!="")
            {
                stu.address = saddress.Value;
            }

            if(sphone.Value!="")
            {
                stu.phone = long.Parse(sphone.Value);
            }

            bll.insertStudent(stu);
            this.ClientScript.RegisterStartupScript(this.GetType(), "error", "<script>alert('" + "插入成功" + "！')</script>");
        }
    }
}
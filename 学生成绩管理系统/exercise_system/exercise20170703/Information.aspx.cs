using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exercise20170703
{
    public partial class Information : System.Web.UI.Page
    {
        long mainId = Convert.ToInt64(HttpContext.Current.Request.QueryString["mainid"]);//主键
        Logic.BLL_Information bll = new Logic.BLL_Information();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["susername"] != null)
            {
                admin_name.InnerHtml = HttpContext.Current.Request.Cookies["susername"].Value.Trim();
            }
            if (mainId!=0)
            {
                aStudent stu = bll.getStudent(mainId);

                sname.Value = stu.name;
                stime.Value = stu.time.ToString();
                classid.Value = stu.classId.ToString();
                studid.Value = stu.studId.ToString();
                ssex.Value = stu.sex;
                sbirthdate.Value = stu.birthDate.ToString();
                idnumber.Value = stu.idNumber.ToString();
                snation.Value = stu.nation;
                sbirthplace.Value = stu.birthPlace;
                //smajor.InnerHtml = bll.getMajorName(stu.mlId);
                HiddenField1.Value = bll.getMajorName(stu.mlId);
                saddress.Value = stu.address;
                sphone.Value = stu.phone.ToString();
            }
        }
    }
}
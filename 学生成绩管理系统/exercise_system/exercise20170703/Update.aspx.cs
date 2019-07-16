using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exercise20170703
{
    public partial class Update : System.Web.UI.Page
    {
        long mainId = Convert.ToInt64(HttpContext.Current.Request.QueryString["mainid"]);//主键
        Logic.BLL_update bll = new Logic.BLL_update();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["susername"] != null)
            {
                admin_name.InnerHtml = HttpContext.Current.Request.Cookies["susername"].Value.Trim();
            }

            if (mainId != 0)
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
            stu.studId = int.Parse(studid.Value);
            stu.classId = int.Parse(classid.Value);

            if (saddress.Value != "")
            {
                stu.address = saddress.Value;
            }

            if (sphone.Value != "")
            {
                stu.phone = long.Parse(sphone.Value);
            }

            bll.updateStudent(stu);
        }
    }
}
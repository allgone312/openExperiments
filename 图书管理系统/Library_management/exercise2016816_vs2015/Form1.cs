using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace exercise2016816_vs2015
{
    public partial class libraryForm : Form
    {
        public libraryForm()
        {
            InitializeComponent();
        }
        //初始化功能窗体
        public window1 w1;
        public window2 w2;
        public window3 w3;
        public window4 w4;

        private void FormIndex_Load(object sender, EventArgs e)
        {
            w1 = new window1();
            w2 = new window2();
            w3 = new window3();
            w4 = new window4();
            buttonAdd.Visible = false;
            labelNote.Text = "1.借阅书籍需要通过输入书籍13位ISBN码\n\n"
                + "2.可以通过[全部书籍]页面找到所需书籍信息\n\n"
                + "3.已知书籍ISBN码可以直接进入[书籍借阅]界面完成操作\n\n"
                + "4.借阅和归还书籍都要通过书证号";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            w1.Show();
            groupBoxWindows.Controls.Clear();
            groupBoxWindows.Controls.Add(w1);
        }

        private void buttonLend_Click(object sender, EventArgs e)
        {
            w2.Show();
            groupBoxWindows.Controls.Clear();
            groupBoxWindows.Controls.Add(w2);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            w3.Show();
            groupBoxWindows.Controls.Clear();
            groupBoxWindows.Controls.Add(w3);
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            w4.Show();
            groupBoxWindows.Controls.Clear();
            groupBoxWindows.Controls.Add(w4);
            //DAL_Book dal = new DAL_Book();
            //List<Book> books = new List<Book>();
            //books = dal.readBook();
            //foreach (Book b in books)
            //{
            //    string str = string.Format("{0},{1},{2},{3},{4}", b.ISBN, b.Name, b.author, b.totalNum.ToString(), b.nowNum.ToString());
            //    MessageBox.Show(str);
            //}
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                //登录
                if(btnSwitch.Text=="登录")
                {
                    if (nameBox.Text == "" || passwordBox.Text == "")
                        throw new Exception("账号密码框不能为空！");
                    BLL.BLL_Login login = new BLL.BLL_Login();
                    if (login.isUserExist(nameBox.Text, passwordBox.Text))
                    {
                        groupBoxRole.Visible = false;
                        labelRole.Text = "当前用户：管理员";
                        btnSwitch.Text = "注销";
                        buttonAdd.Visible = true;
                    }
                    else
                        throw new Exception("账号或密码错误");
                }
                //注销
                else
                {
                    buttonAdd.Visible = false;
                    labelRole.Text = "当前用户：游客";
                    groupBoxRole.Visible = true;
                    btnSwitch.Text = "登录";
                    nameBox.Text = "";
                    passwordBox.Text = "";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

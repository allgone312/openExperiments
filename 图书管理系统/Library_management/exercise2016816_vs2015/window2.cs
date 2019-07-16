using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace exercise2016816_vs2015
{
    public partial class window2 : UserControl
    {
        public BLL.BLL_Book bll = new BLL.BLL_Book();
        public BLL.BLL_Lend bll2 = new BLL.BLL_Lend();
        public BLL.BLL_BookID bll3 = new BLL.BLL_BookID();
        public window2()
        {
            InitializeComponent();
            groupBoxBook.Visible = false;
            groupBoxPerson.Visible = false;
            buttonSubmit.Visible = false;
            labelNote.Text = "1.把鼠标移入书号框，自动识别剪贴板内书号并填充\n\n"
                + "2.请在借书后两周内归还书籍，否则要支付（超时天数*1）元的违约金";
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (isbnBox.Text == "")
                {
                    throw new Exception("书号不能为空！");
                }
                if (!Regex.IsMatch(isbnBox.Text, @"^\d{13}$"))
                {
                    throw new Exception("请输入正确的书号！");
                }
                Book book = bll.getBook(isbnBox.Text);
                if (book == null)
                {
                    throw new Exception("不存在此书籍！");
                }
                groupBoxBook.Visible = true;
                labelName.Text = "书名：" + book.Name;
                labelAuthor.Text = "作者：" + book.author;
                labelNum.Text = "现存数：" + book.nowNum;
                if (book.nowNum == 0)
                {
                    throw new Exception("书籍现存数为0！");
                }
                groupBoxPerson.Visible = true;
                buttonSubmit.Visible = true;
                datePicker.Value = DateTime.Now.AddDays(14);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookidBox.Text == "" || isbnBox.Text == "")
                    throw new Exception("输入框不能为空!");
                int num = int.Parse(bookidBox.Text);
                if (!bll3.isbookidExist(bookidBox.Text))
                    throw new Exception("不存在此书号");
                Lend lend = new Lend();
                lend.bookID = bookidBox.Text;
                lend.date = datePicker.Value;
                lend.ISBN = isbnBox.Text;
                bll2.insertLend(lend);
                Book newbook = bll.getBook(isbnBox.Text);
                newbook.nowNum -= 1;
                bll.updateBook(newbook);
                MessageBox.Show("借书成功，请在"+datePicker.Value+"之前归还此书！");
                groupBoxBook.Visible = false;
                groupBoxPerson.Visible = false;
                buttonSubmit.Visible = false;
                bookidBox.Text = "";
                isbnBox.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("书证号应为数字！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 复制剪切板内符合13位ISBN正则的书号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isbnBox_MouseEnter(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                if (Regex.IsMatch(iData.GetData(DataFormats.Text).ToString(), @"^\d{13}$"))
                    isbnBox.Text = iData.GetData(DataFormats.Text).ToString();
            }
        }
    }
}

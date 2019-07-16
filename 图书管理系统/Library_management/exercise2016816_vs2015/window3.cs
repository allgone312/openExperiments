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
    public partial class window3 : UserControl
    {
        public BLL.BLL_Book bll = new BLL.BLL_Book();
        public BLL.BLL_Lend bll2 = new BLL.BLL_Lend();
        public BLL.BLL_BookID bll3 = new BLL.BLL_BookID();
        public window3()
        {
            InitializeComponent();
            labelNote.Text = "1.正确输入书证号后点击获取借阅信息按钮，列表内会显示该书号全部借阅信息\n\n"
                + "2.还书日期超过应归还日期，要支付（超时天数*1）元的违约金\n\n"
                + "3.双击列表内书籍所在行便可归还书籍";
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookidBox.Text == "")
                    throw new Exception("输入框不能为空!");
                int num = int.Parse(bookidBox.Text);
                if (!bll3.isbookidExist(bookidBox.Text))
                    throw new Exception("不存在此书号");

                databind(dataGridView1);
                dataGridView1.Columns[1].HeaderCell.Value = "书证号";
                dataGridView1.Columns[2].HeaderCell.Value = "归还日期";
                AutoSizeColumn(dataGridView1);
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
        /// 数据绑定函数
        /// </summary>
        /// <param name="dg1"></param>
        private void databind(DataGridView dg1)
        {
            List<Lend> list1 = new List<Lend>();
            LinkedList<Lend> lends = bll2.readLend();

            Node<Lend> outNode = lends.Head.Next;
            int count = lends.count;
            while (count != 0)
            {
                if (outNode.Data.bookID == bookidBox.Text)
                {
                    list1.Add(outNode.Data);
                }
                outNode = outNode.Next;
                count--;
            }

            dg1.DataSource = list1;
        }
        /// <summary>
        /// 根据数据调整列宽
        /// </summary>
        /// <param name="dgViewFiles"></param>
        private void AutoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                width += dgViewFiles.Columns[i].Width;
            }
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                string ISBN = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//获得本行第一个单元格的数据
                Book book = bll.getBook(ISBN);
                int days = calOverDateMoney(DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                //string question = "确认归还此书?\n" + book.Name + "\n" + book.author;
                string question = string.Format("确认归还此书?\n书名：{0}\n作者：{1}", book.Name, book.author);
                if (days > 0)
                {
                    //question = question + "\n超时" + days.ToString() + "天，需支付违约金" + days.ToString() + "元";
                    question += string.Format("\n超时{0}天，需支付违约金{0}元", days, days);
                }
                DialogResult dr = MessageBox.Show(question, "确认书籍信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    bll2.delLend(ISBN, bookidBox.Text);
                    MessageBox.Show("删除一条记录!");
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 计算违约金
        /// </summary>
        /// <param name="startdate"></param>
        /// <returns></returns>
        private int calOverDateMoney(DateTime startdate)
        {
            TimeSpan sp = DateTime.Now.Subtract(startdate);
            return sp.Days;
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            if(bookidBox.Text!="")
                databind(dataGridView1);

        }
    }
}

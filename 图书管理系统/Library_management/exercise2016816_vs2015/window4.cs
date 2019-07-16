using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace exercise2016816_vs2015
{
    public partial class window4 : UserControl
    {
        private BLL.BLL_Book bll = new BLL.BLL_Book();
        //private BLL.BLL_Lend bll2 = new BLL.BLL_Lend();

        public window4()
        {
            InitializeComponent();

            dataBindBook(dataGridView1);

            dataGridView1.Columns[1].HeaderCell.Value = "书名";
            dataGridView1.Columns[2].HeaderCell.Value = "著作者";
            dataGridView1.Columns[3].HeaderCell.Value = "库存量";
            dataGridView1.Columns[4].HeaderCell.Value = "现存量";

            //dataBindLend(dataGridView2);

            //dataGridView2.Columns[1].HeaderCell.Value = "书证号";
            //dataGridView2.Columns[2].HeaderCell.Value = "归还日期";

            AutoSizeColumn(dataGridView1);
            //AutoSizeColumn(dataGridView2);
            labelNote.Text = "1.填写书名框并点击查找按钮后列表内会显示查询到的内容\n\n"
                + "2.双击单元格即可复制选中书籍的ISBN,移动到需要填写ISBN的界面上会自动识别填充\n\n"
                + "3.在书名框为空的情况下列表默认显示全部书籍";
        }

        private void window4_MouseEnter(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                dataBindBook(dataGridView1);
                //dataBindLend(dataGridView2);
            }
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

        /// <summary>
        /// 书籍信息绑定
        /// </summary>
        /// <param name="dgview"></param>
        /// <param name="books"></param>
        private void dataBindBook(DataGridView dgview)
        {
            List<Book> list1 = new List<Book>();
            LinkedList<Book> books = bll.readBook();

            Node<Book> outNode = books.Head.Next;
            int count = books.count;
            while (count != 0)
            {
                list1.Add(outNode.Data);
                outNode = outNode.Next;
                count--;
            }

            dgview.DataSource = list1;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {

            }
            else
            {
                string ISBN = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//获得本行第一个单元格的数据
                Clipboard.SetDataObject(ISBN);
                MessageBox.Show("已复制ISBN");
                nameBox.Text = "";
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameBox.Text == "")
                    throw new Exception("书名不能为空！");
                List<Book> list1 = new List<Book>();
                LinkedList<Book> books = bll.readBook();

                Node<Book> outNode = books.Head.Next;
                int count = books.count;
                while (count != 0)
                {
                    if (outNode.Data.Name.Contains(nameBox.Text))
                    {
                        list1.Add(outNode.Data);
                    }
                    outNode = outNode.Next;
                    count--;
                }

                dataGridView1.DataSource = list1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///// <summary>
        ///// 借阅信息绑定
        ///// </summary>
        ///// <param name="dgview"></param>
        //private void dataBindLend(DataGridView dgview)
        //{
        //    List<Lend> list1 = new List<Lend>();
        //    LinkedList<Lend> lends = bll2.readLend();

        //    Node<Lend> outNode = lends.Head.Next;
        //    int count = lends.count;
        //    while (count != 0)
        //    {
        //        list1.Add(outNode.Data);
        //        outNode = outNode.Next;
        //        count--;
        //    }

        //    dgview.DataSource = list1;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace exercise2016816_vs2015
{
    public partial class window1 : UserControl
    {
        public DAL_Book dal = new DAL_Book();
        public BLL.BLL_Book bll = new BLL.BLL_Book();
        public window1()
        {
            InitializeComponent();
            groupBoxBook.Enabled = false;
            buttonSubmit.Enabled = false;
            labelNote.Text = "1.书号为13位ISBN国标码\n\n"
                + "2.如果书库内有该书籍，则只会增加该书的数量";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ISBNBox.Text == "" || nameBox.Text == "" || authorBox.Text == "" || numBox.Text == "")
                    throw new Exception("输入框不能为空!");
                Book book = new Book();
                book.ISBN = ISBNBox.Text;
                book.Name = nameBox.Text;
                book.author = authorBox.Text;
                book.totalNum = int.Parse(numBox.Text);
                if (book.totalNum < 0)
                    throw new Exception("采购数量应该大于0!");
                book.nowNum = book.totalNum;
                if (dal.isBookExit(book.ISBN))
                {
                    LinkedList<Book> books = dal.readBook();
                    Node<Book> outNode = books.Head.Next;
                    int count = books.count;
                    while (count != 0)
                    {
                        if (outNode.Data.ISBN == book.ISBN)
                        {
                            book.totalNum += outNode.Data.totalNum;
                            book.nowNum += outNode.Data.nowNum;
                            break;
                        }
                        outNode = outNode.Next;
                        count--;
                    }
                    dal.updateBook(book);
                    MessageBox.Show("成功修改一条记录");
                }
                else
                {
                    dal.insertBook(book);
                    MessageBox.Show("成功添加一条记录");
                }
                groupBoxBook.Enabled = false;
                nameBox.Text = "";
                authorBox.Text = "";
                numBox.Text = "";
                ISBNBox.Text = "";
                buttonSubmit.Enabled = false;
            }
            catch(FormatException)
            {
                MessageBox.Show("采购数量只能整数！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void window1_Load(object sender, EventArgs e)
        {

        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            groupBoxBook.Enabled = false;
            nameBox.Text = "";
            authorBox.Text = "";
            labelOut.Text = "";

            try
            {
                if (ISBNBox.Text == "")
                {
                    throw new Exception("书号不能为空！");
                }
                if (!Regex.IsMatch(ISBNBox.Text, @"^\d{13}$"))
                {
                    throw new Exception("请输入正确的书号！");
                }
                if (bll.isBookExit(ISBNBox.Text))
                {
                    labelOut.Text = "书库里存在该书籍";
                    Book newbook = bll.getBook(ISBNBox.Text);
                    nameBox.Text = newbook.Name;
                    authorBox.Text = newbook.author;
                }
                else
                {
                    groupBoxBook.Enabled = true;
                }
                buttonSubmit.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

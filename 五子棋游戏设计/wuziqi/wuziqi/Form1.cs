using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wuziqi
{
    public partial class Form1 : Form
    {
        //游戏是否开始
        private bool start;
        //下的是黑子还是白子
        private bool type = true;
        //棋盘大小
        private const int size = 15;
        //是否为空，空为0，不为空为1、2
        //private int[,] ChessCheck = new int[11, 11];
        private int[,] ChessCheck = new int[size, size];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            start = false;
            button1.Enabled = true;
            button2.Enabled = false;
            this.Width = MainSize.Wid;
            this.Height = MainSize.Hei;
            this.Location = new Point(260, 75);//设置窗体起始位置
            label1.Text = "游戏未开始";
        }
        private void InitializeThis()
        {
            //棋盘存储数组 函数
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    ChessCheck[i, j] = 0;
            start = false;//是否开始游戏
            this.panel1.Invalidate();//棋盘重新加载（画）
            type = true;//默认黑棋先下
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "游戏开始";
            start = true;
            button1.Enabled = false;
            button2.Enabled = true;
        }
        //画棋盘
        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            ChessBoard.DrawCB(g);//重新加载（画）棋盘
            Chess.ReDrawC(panel1, ChessCheck);//重新加载（画）棋子。
        }
        //设置游戏控制界面的大小
        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            panel2.Size = new Size(MainSize.Wid - MainSize.CBWid - 20, MainSize.Hei);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要重新开始？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                label1.Text = "游戏未开始";
                start = false;
                button1.Enabled = true;
                button2.Enabled = false;
                InitializeThis();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        //根据鼠标点击的位置画棋子
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //把棋盘分为【15，15】的数组

            if (start)
            {
                int x1 = (e.X) / MainSize.CBGap;

                int y1 = (e.Y) / MainSize.CBGap;

                try
                {
                    //判断此位置是否为空
                    if (ChessCheck[x1, y1] != 0)
                    {
                        return;//已经有棋子占领这个位置了
                    }

                    //下黑子还是白子

                    if (type)
                    {
                        ChessCheck[x1, y1] = 1;
                    }
                    else
                    {
                        ChessCheck[x1, y1] = 2;
                    }

                    //画棋子

                    Chess.DrawC(panel1, type, e);

                    //换颜色

                    type = !type;

                }
                catch (Exception)
                {
                    //防止因鼠标点击边界，而导致数组越界，进而运行中断。
                }

                //判断是否胜利

                if (IsFull(ChessCheck) && !BlackVictory(ChessCheck) && !WhiteVictory(ChessCheck))
                {
                    MessageBox.Show("平局");
                    start = false;
                    label1.Text = "平局！请重置后继续";
                }
                if (BlackVictory(ChessCheck))
                {
                    MessageBox.Show("黑方胜利(Black Win)");
                    start = false;
                    label1.Text = "黑方胜！请重置后继续";
                }
                if (WhiteVictory(ChessCheck))
                {
                    MessageBox.Show("白方胜利(White Win)");
                    start = false;
                    label1.Text = "白方胜！请重置后继续";
                }
            }
            else
            {
                MessageBox.Show("请先开始游戏！", "提示信息！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //是否满格
        public bool IsFull(int[,] ChessCheck)
        {
            bool full = true;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (ChessCheck[i, j] == 0)
                        return full = false;
                }
            }
            return full;
        }
        //是否黑子胜利
        public bool BlackVictory(int[,] ChessBack)
        {
            bool Win = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (ChessCheck[i, j] != 0)
                    {
                        //纵向判断
                        if (j < 11)
                        {
                            if (ChessCheck[i, j] == 1 && ChessCheck[i, j + 1] == 1 && ChessCheck[i, j + 2] == 1 && ChessCheck[i, j + 3] == 1 && ChessCheck[i, j + 4] == 1)
                            {
                                return Win = true;
                            }
                        }
                        //横向判断
                        if (i < 11)
                        {
                            if (ChessCheck[i, j] == 1 && ChessCheck[i + 4, j] == 1 && ChessCheck[i + 1, j] == 1 && ChessCheck[i + 2, j] == 1 && ChessCheck[i + 3, j] == 1)
                            {
                                return Win = true;
                            }
                        }
                        //斜向右下判断
                        if (i < 11 && j < 11)
                        {
                            if (ChessCheck[i, j] == 1 && ChessCheck[i + 1, j + 1] == 1 && ChessCheck[i + 2, j + 2] == 1 && ChessCheck[i + 3, j + 3] == 1 && ChessCheck[i + 4, j + 4] == 1)
                            {
                                return Win = true;
                            }
                        }
                        //斜向左下判断
                        if (i >= 4 && j < 11)
                        {
                            if (ChessCheck[i, j] == 1 && ChessCheck[i - 1, j + 1] == 1 && ChessCheck[i - 2, j + 2] == 1 && ChessCheck[i - 3, j + 3] == 1 && ChessCheck[i - 4, j + 4] == 1)
                            {
                                return Win = true;
                            }
                        }
                    }
                }
            }
            return Win;
        }
        //是否白子赢，代码同上
        public bool WhiteVictory(int[,] ChessBack)
        {
            bool Win = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (ChessCheck[i, j] != 0)
                    {
                        if (j < 11)
                        {
                            if (ChessCheck[i, j] == 2 && ChessCheck[i, j + 1] == 2 && ChessCheck[i, j + 2] == 2 && ChessCheck[i, j + 3] == 2 && ChessCheck[i, j + 4] == 2)
                            {
                                return Win = true;
                            }
                        }
                        if (i < 11)
                        {
                            if (ChessCheck[i, j] == 2 && ChessCheck[i + 4, j] == 2 && ChessCheck[i + 1, j] == 2 && ChessCheck[i + 2, j] == 2 && ChessCheck[i + 3, j] == 2)
                            {
                                return Win = true;
                            }
                        }
                        if (i < 11 && j < 11)
                        {
                            if (ChessCheck[i, j] == 2 && ChessCheck[i + 1, j + 1] == 2 && ChessCheck[i + 2, j + 2] == 2 && ChessCheck[i + 3, j + 3] == 2 && ChessCheck[i + 4, j + 4] == 2)
                            {
                                return Win = true;
                            }


                        }
                        if (i >= 4 && j < 11)
                            if (ChessCheck[i, j] == 2 && ChessCheck[i - 1, j + 1] == 2 && ChessCheck[i - 2, j + 2] == 2 && ChessCheck[i - 3, j + 3] == 2 && ChessCheck[i - 4, j + 4] == 2)
                            {
                                return Win = true;
                            }
                    }
                }
            }
            return Win;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

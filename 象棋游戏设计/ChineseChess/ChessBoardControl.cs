using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ChineseChess
{
    /// <summary>
    /// 棋盘控件
    /// </summary>
    public partial class ChessBoardControl : UserControl
    {
        private Piece[,] ArrPiece { get; set; } 

        public ChessBoardControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //初始化数组
            InitArrPieceInfo();

            Graphics g = e.Graphics;
            int width = this.Width;
            int height = this.Height;
            int padding = this.Padding.All * 20;
            int center = height / 2;//垂直中心位置
            int s_width = (width - 2 * padding) / 8;//每一条横线的间距
            int s_heigth = (height - 2 * padding) / 9;//每一条竖线的间距
            int start_x = padding;//起始位置
            int start_y = padding;//起始位置
            Pen pen = new Pen(Brushes.Black, 1.5f);
            Dictionary<string, string[]> dicNums = new Dictionary<string, string[]>();
            dicNums.Add("up", new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            dicNums.Add("down", new string[9] { "九", "八", "七", "六", "五", "四", "三", "二", "一" });
            Font font = new Font("宋体", 12, FontStyle.Regular);
            for (int i = 0; i < 9; i++)
            {
                //竖线九条
                Point p0 = new Point(start_x + i * s_width, start_y);
                Point p1 = new Point(start_x + i * s_width, start_y + (s_heigth * 4));
                Point p2 = new Point(start_x + i * s_width, start_y + (s_heigth * 5));
                Point p3 = new Point(start_x + i * s_width, start_y + (s_heigth * 9));
                g.DrawLine(pen, p0, p1);
                g.DrawLine(pen, p2, p3);
                //上下的文字
                Point p_up = new Point(start_x + i * s_width - 5, padding / 2);
                Point p_down = new Point(start_x + i * s_width - 5, start_y + (s_heigth * 9) + padding / 3);
                g.DrawString(dicNums["up"][i], font, Brushes.Black, p_up);
                g.DrawString(dicNums["down"][i], font, Brushes.Black, p_down);
                //数组赋值
                for (int j = 0; j < 10; j++)
                {
                    Point absLocation = ArrPiece[i, j].AbsoluteLocation;
                    absLocation.X = start_x + i * s_width;
                    ArrPiece[i, j].AbsoluteLocation = absLocation;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                //横线十条
                Point p0 = new Point(start_x, start_y + i * s_heigth);
                Point p1 = new Point(start_x + s_width * 8, start_y + i * s_heigth);
                g.DrawLine(pen, p0, p1);
                //数组赋值
                for (int j = 0; j < 9; j++)
                {
                    Point absLocation = ArrPiece[j, i].AbsoluteLocation;
                    absLocation.Y = start_y + i * s_heigth;
                    ArrPiece[j, i].AbsoluteLocation = absLocation;
                }
            }
            //绘制九宫格
            for (int i = 0; i < 2; i++)
            {
                Point p0 = new Point(start_x + (3 + i * 2) * s_width, start_y);
                Point p1 = new Point(start_x + (5 - i * 2) * s_width, start_y + (s_heigth * 2));
                Point p2 = new Point(start_x + (3 + i * 2) * s_width, start_y + (s_heigth * 7));
                Point p3 = new Point(start_x + (5 - i * 2) * s_width, start_y + (s_heigth * 9));
                g.DrawLine(pen, p0, p1);
                g.DrawLine(pen, p2, p3);
            }

            //兵和卒处有拐角，从左往右
            for (int i = 0; i < 5; i++)
            {
                int p_x = start_x + 2 * i * s_width;
                int p_y = start_y + 3 * s_heigth;
                DrawCorner(g, pen, p_x, p_y);//兵
                p_y = start_y + 6 * s_heigth;
                DrawCorner(g, pen, p_x, p_y);//卒
            }
            //炮处的拐角，从左往右
            for (int i = 0; i < 2; i++)
            {
                int p_x = start_x + (1 + 6 * i) * s_width;
                int p_y = start_y + 2 * s_heigth;
                DrawCorner(g, pen, p_x, p_y);//炮
                p_y = start_y + 7 * s_heigth;
                DrawCorner(g, pen, p_x, p_y);//炮
            }
            //绘制楚河汉界
            Point p_0 = new Point(2 * s_width, center - 25);
            Point p_1 = new Point(7 * s_width, center + 20);
            font = new Font("方正隶二繁体", 30, FontStyle.Regular);
            g.DrawString("楚河", font, Brushes.Black, p_0);
            Matrix mtxSave = g.Transform;
            Matrix mtxRotate = g.Transform;
            mtxRotate.RotateAt(180, p_1);
            g.Transform = mtxRotate;
            g.DrawString("汉界", font, Brushes.Black, p_1);
            g.Transform = mtxSave;
            //绘制外边框
            g.DrawRectangle(pen, 3, 3, width - 6, height - 6);
            g.DrawRectangle(pen, 5, 5, width - 10, height - 10);
            g.DrawRectangle(pen, 7, 7, width - 14, height - 14);
        }

        /// <summary>
        /// 绘制拐角
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="p_x"></param>
        /// <param name="p_y"></param>
        private void DrawCorner(Graphics g, Pen pen, int p_x, int p_y)
        {
            //左上
            Point p0 = new Point(p_x - 2, p_y - 7);
            Point p1 = new Point(p_x - 2, p_y - 2);
            Point p2 = new Point(p_x - 7, p_y - 2);
            Point p3 = new Point(p_x - 2, p_y - 2);
            g.DrawLine(pen, p0, p1);
            g.DrawLine(pen, p2, p3);
            //右上
            Point p10 = new Point(p_x + 2, p_y - 7);
            Point p11 = new Point(p_x + 2, p_y - 2);
            Point p12 = new Point(p_x + 2, p_y - 2);
            Point p13 = new Point(p_x + 7, p_y - 2);
            g.DrawLine(pen, p10, p11);
            g.DrawLine(pen, p12, p13);
            //左下
            Point p15 = new Point(p_x - 7, p_y + 2);
            Point p16 = new Point(p_x - 2, p_y + 2);
            Point p17 = new Point(p_x - 2, p_y + 2);
            Point p18 = new Point(p_x - 2, p_y + 7);
            g.DrawLine(pen, p15, p16);
            g.DrawLine(pen, p17, p18);  
            //右下
            Point p5 = new Point(p_x + 2, p_y + 7);
            Point p6 = new Point(p_x + 2, p_y + 2);
            Point p7 = new Point(p_x + 7, p_y + 2);
            Point p8 = new Point(p_x + 2, p_y + 2);
            g.DrawLine(pen, p5, p6);
            g.DrawLine(pen, p7, p8);
        }

        /// <summary>
        /// 初始化棋子数组
        /// </summary>
        private void InitArrPieceInfo()
        {
            ArrPiece = new Piece[9, 10];
            bool isRed = false;
            //初始化棋子位置信息
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j >= 5)
                    {
                        isRed = true;
                    }
                    else {
                        isRed = false;
                    }
                    ArrPiece[i, j] = new Piece()
                    {
                        RelativeLocation = new Point(i, j),
                        AbsoluteLocation = new Point(0, 0),
                        IsRed = isRed
                    };
                }
            }
        }

        /// <summary>
        /// 初始化开始信息
        /// </summary>
        public void InitStartInfo()
        {
            if (ArrPiece != null)
            {
                this.Controls.Clear();
                string[] arrTmp0 = new string[9] { "車", "馬", "象", "士", "将", "士", "象", "馬", "車" };
                string[] arrTmp1 = new string[9] { "車", "馬", "相", "仕", "帅", "仕", "相", "馬", "車" };
                int radius = 45;
                Color backColor = Color.Gold;
                for (int i = 0; i < 9; i++)
                {
                    PieceControl p0 = new PieceControl()
                    {
                        Text = arrTmp0[i],
                        BackColor = backColor,
                        PieceInfo = ArrPiece[i, 0],
                        Width = radius,
                        Height = radius
                    };
                    p0.Click += Piece_Click;
                    this.Controls.Add(p0);
                    PieceControl p1 = new PieceControl()
                    {
                        Text = arrTmp1[i],
                        BackColor = backColor,
                        PieceInfo = ArrPiece[i, 9],
                        Width = radius,
                        Height = radius
                    };
                    p1.Click += Piece_Click;
                    this.Controls.Add(p1);
                }
                //炮
                for (int i = 0; i < 2; i++)
                {
                    PieceControl p0 = new PieceControl()
                    {
                        Text = "炮",
                        BackColor = backColor,
                        PieceInfo = ArrPiece[i * 6 + 1, 2],
                        Width = radius,
                        Height = radius
                    };
                    p0.Click += Piece_Click;
                    this.Controls.Add(p0);
                    PieceControl p1 = new PieceControl()
                    {
                        Text = "炮",
                        BackColor = backColor,
                        PieceInfo = ArrPiece[i * 6 + 1, 7],
                        Width = radius,
                        Height = radius
                    };
                    p1.Click += Piece_Click;
                    this.Controls.Add(p1);
                }
                //兵和卒
                for (int i = 0; i < 5; i++)
                {
                    PieceControl p0 = new PieceControl()
                    {
                        Text = "卒",
                        BackColor = backColor,
                        PieceInfo = ArrPiece[i * 2, 3],
                        Width = radius,
                        Height = radius
                    };
                    p0.Click += Piece_Click;
                    this.Controls.Add(p0);
                    PieceControl p1 = new PieceControl()
                    {
                        Text = "兵",
                        BackColor = backColor,
                        PieceInfo = ArrPiece[i * 2, 6],
                        Width = radius,
                        Height = radius
                    };
                    p1.Click += Piece_Click;
                    this.Controls.Add(p1);
                }
            }
        }

        /// <summary>
        /// 重置棋盘
        /// </summary>
        public void ResetInfo()
        {
            this.Controls.Clear();
        }

        /// <summary>
        /// 点击棋子事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Piece_Click(object sender, EventArgs e) {
            PieceControl p=  (PieceControl)sender;
            MessageBox.Show(string.Format("我是：{0}",p.Text));
        }
    }

    /// <summary>
    /// 棋子
    /// </summary>
    public class Piece {

        /// <summary>
        /// 绝对位置
        /// </summary>
        public Point AbsoluteLocation { get; set; }

        /// <summary>
        /// 相对位置
        /// </summary>
        public Point RelativeLocation { get; set; }

        /// <summary>
        /// 是否是红方
        /// </summary>
        public bool IsRed { get; set; }

    }
}

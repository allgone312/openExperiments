using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wuziqi
{
    class Chess
    {
        public static void DrawC(Panel p, bool type, MouseEventArgs e)
        {
            Graphics g = p.CreateGraphics();
            //确定棋子的中心位置
            int x1 = (e.X) / MainSize.CBGap;
            int x2 = x1 * MainSize.CBGap + 20 - 17;
            int y1 = (e.Y) / MainSize.CBGap;
            int y2 = y1 * MainSize.CBGap + 20 - 17;
            if (type)
            {
                g.FillEllipse(new SolidBrush(Color.Black), x2, y2, MainSize.ChessRadious, MainSize.ChessRadious);
            }
            else
            {
                g.FillEllipse(new SolidBrush(Color.White), x2, y2, MainSize.ChessRadious, MainSize.ChessRadious);
            }
        }

        //当界面被重新聚焦的时候，把棋盘上的棋子重新加载（画）出来
        public static void ReDrawC(Panel p, int[,] ChessCheck)
        {
            Graphics g = p.CreateGraphics();
            for (int i = 0; i < ChessCheck.GetLength(0); i++)
                for (int j = 0; j < ChessCheck.GetLength(1); j++)
                {
                    //MessageBox.Show("ReDrawC", "信息提示！", MessageBoxButtons.OK);
                    int type = ChessCheck[i, j];
                    if (type != 0)
                    {
                        //确定棋子的中心位置
                        int x2 = i * MainSize.CBGap + 20 - 17;
                        int y2 = j * MainSize.CBGap + 20 - 17;
                        if (type == 1)
                        {
                            g.FillEllipse(new SolidBrush(Color.Black), x2, y2, MainSize.ChessRadious, MainSize.ChessRadious);
                        }
                        else
                        {
                            g.FillEllipse(new SolidBrush(Color.White), x2, y2, MainSize.ChessRadious, MainSize.ChessRadious);
                        }
                    }
                }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wuziqi
{
    class ChessBoard
    {
        public static void DrawCB(Graphics g)
        {
            int num = MainSize.CBWid / MainSize.CBGap - 1;
            int gap = MainSize.CBGap;
            g.Clear(Color.Gold);
            for (int i = 0; i < num + 1; i++)
            {
                g.DrawLine(new Pen(Color.Black), 20, 20 + i * gap, 20 + num * gap, 20 + i * gap);
                g.DrawLine(new Pen(Color.Black), 20 + gap * i, 20, 20 + i * gap, 20 + gap * num);
            }
        }
    }
}

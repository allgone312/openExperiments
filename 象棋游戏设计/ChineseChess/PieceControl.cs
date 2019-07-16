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
    /// 棋子控件
    /// </summary>
    public partial class PieceControl : Button
    {
        private Piece pieceInfo;
        /// <summary>
        /// 棋子信息
        /// </summary>
        public Piece PieceInfo
        {
            get { return this.pieceInfo; }
            set
            {
                this.pieceInfo = value;
                Point absPoint = this.pieceInfo.AbsoluteLocation;
                this.Location =new Point(absPoint.X-this.Width/3,absPoint.Y-this.Height);
                this.ForeColor = this.pieceInfo.IsRed ? Color.Red : Color.Black;
            }
        }

        public PieceControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 控件重绘
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            GraphicsPath gPath = new GraphicsPath();
            // Set a new rectangle to the same size as the button's ClientRectangle property.
            Rectangle rectangle = this.ClientRectangle;
            g.DrawEllipse(new Pen(this.FlatAppearance.BorderColor), rectangle);
            gPath.AddEllipse(rectangle);

            // Set the button's Region property to the newly created  circle region.
            this.Region = new Region(gPath);
            Rectangle inRect = new Rectangle(2, 2, this.Width - 4, this.Height - 3);
            g.FillEllipse(new SolidBrush(this.BackColor), rectangle);
            g.DrawEllipse(new Pen(Color.Black,2), inRect);

            Font font = new Font("楷体", 25, FontStyle.Regular);
            g.DrawString(this.Text, font, new SolidBrush(this.ForeColor), 0,5);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            //Graphics g = e.Graphics;
            //Rectangle inRect = new Rectangle(0, 0, this.Width , this.Height);
            //g.FillEllipse(new SolidBrush(this.BackColor), inRect);
        }
    }
}

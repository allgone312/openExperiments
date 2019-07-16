using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseChess
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnCancel.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.chessBoardControl1.InitStartInfo();
            this.btnStart.Enabled = false;
            this.btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.chessBoardControl1.ResetInfo();
            this.btnStart.Enabled = true;
            this.btnCancel.Enabled = false;
        }


    }
}

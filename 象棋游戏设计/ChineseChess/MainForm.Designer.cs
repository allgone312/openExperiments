namespace ChineseChess
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.spCtrl = new System.Windows.Forms.SplitContainer();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chessBoardControl1 = new ChineseChess.ChessBoardControl();
            ((System.ComponentModel.ISupportInitialize)(this.spCtrl)).BeginInit();
            this.spCtrl.Panel1.SuspendLayout();
            this.spCtrl.Panel2.SuspendLayout();
            this.spCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // spCtrl
            // 
            this.spCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spCtrl.Location = new System.Drawing.Point(0, 0);
            this.spCtrl.Name = "spCtrl";
            // 
            // spCtrl.Panel1
            // 
            this.spCtrl.Panel1.BackgroundImage = global::ChineseChess.Properties.Resources.bg;
            this.spCtrl.Panel1.Controls.Add(this.btnCancel);
            this.spCtrl.Panel1.Controls.Add(this.btnStart);
            this.spCtrl.Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // spCtrl.Panel2
            // 
            this.spCtrl.Panel2.Controls.Add(this.chessBoardControl1);
            this.spCtrl.Size = new System.Drawing.Size(784, 562);
            this.spCtrl.SplitterDistance = 200;
            this.spCtrl.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::ChineseChess.Properties.Resources.bg;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(62, 133);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 59);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::ChineseChess.Properties.Resources.bg;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(62, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 59);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "重置";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chessBoardControl1
            // 
            this.chessBoardControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.chessBoardControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chessBoardControl1.BackgroundImage")));
            this.chessBoardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chessBoardControl1.Location = new System.Drawing.Point(0, 0);
            this.chessBoardControl1.Name = "chessBoardControl1";
            this.chessBoardControl1.Padding = new System.Windows.Forms.Padding(2);
            this.chessBoardControl1.Size = new System.Drawing.Size(580, 562);
            this.chessBoardControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.spCtrl);
            this.Name = "MainForm";
            this.Text = "中国象棋";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.spCtrl.Panel1.ResumeLayout(false);
            this.spCtrl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spCtrl)).EndInit();
            this.spCtrl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spCtrl;
        private ChessBoardControl chessBoardControl1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
    }
}


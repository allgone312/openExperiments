namespace exercise2016816_vs2015
{
    partial class window1
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ISBNBox = new System.Windows.Forms.RichTextBox();
            this.numBox = new System.Windows.Forms.RichTextBox();
            this.nameBox = new System.Windows.Forms.RichTextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.authorBox = new System.Windows.Forms.RichTextBox();
            this.buttonGet = new System.Windows.Forms.Button();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelOut = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.groupBoxBook.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 225);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "书号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "著作者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "书名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(37, 407);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "采购数量";
            // 
            // ISBNBox
            // 
            this.ISBNBox.Location = new System.Drawing.Point(138, 221);
            this.ISBNBox.Margin = new System.Windows.Forms.Padding(4);
            this.ISBNBox.MaxLength = 100;
            this.ISBNBox.Name = "ISBNBox";
            this.ISBNBox.Size = new System.Drawing.Size(340, 25);
            this.ISBNBox.TabIndex = 5;
            this.ISBNBox.Text = "";
            // 
            // numBox
            // 
            this.numBox.Location = new System.Drawing.Point(158, 404);
            this.numBox.Margin = new System.Windows.Forms.Padding(4);
            this.numBox.MaxLength = 5;
            this.numBox.Name = "numBox";
            this.numBox.Size = new System.Drawing.Size(340, 25);
            this.numBox.TabIndex = 7;
            this.numBox.Text = "";
            // 
            // nameBox
            // 
            this.nameBox.AutoWordSelection = true;
            this.nameBox.Location = new System.Drawing.Point(97, 29);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameBox.MaxLength = 100;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(340, 25);
            this.nameBox.TabIndex = 9;
            this.nameBox.Text = "";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSubmit.Location = new System.Drawing.Point(562, 485);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(85, 28);
            this.buttonSubmit.TabIndex = 10;
            this.buttonSubmit.Text = "提交";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // authorBox
            // 
            this.authorBox.AutoWordSelection = true;
            this.authorBox.Location = new System.Drawing.Point(97, 66);
            this.authorBox.Margin = new System.Windows.Forms.Padding(4);
            this.authorBox.MaxLength = 100;
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(340, 25);
            this.authorBox.TabIndex = 13;
            this.authorBox.Text = "";
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(548, 221);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(102, 25);
            this.buttonGet.TabIndex = 14;
            this.buttonGet.Text = "获取信息";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.Controls.Add(this.authorBox);
            this.groupBoxBook.Controls.Add(this.label2);
            this.groupBoxBook.Controls.Add(this.label3);
            this.groupBoxBook.Controls.Add(this.nameBox);
            this.groupBoxBook.Location = new System.Drawing.Point(38, 269);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Size = new System.Drawing.Size(609, 109);
            this.groupBoxBook.TabIndex = 15;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "书籍信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "主页>采购入库";
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.ForeColor = System.Drawing.Color.Red;
            this.labelOut.Location = new System.Drawing.Point(42, 471);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(0, 16);
            this.labelOut.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNote);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(38, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(612, 120);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用说明";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(20, 33);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(0, 16);
            this.labelNote.TabIndex = 0;
            // 
            // window1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelOut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBoxBook);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.numBox);
            this.Controls.Add(this.ISBNBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "window1";
            this.Size = new System.Drawing.Size(843, 715);
            this.Load += new System.EventHandler(this.window1_Load);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox ISBNBox;
        private System.Windows.Forms.RichTextBox numBox;
        private System.Windows.Forms.RichTextBox nameBox;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.RichTextBox authorBox;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNote;
    }
}

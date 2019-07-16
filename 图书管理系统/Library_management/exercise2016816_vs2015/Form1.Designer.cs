namespace exercise2016816_vs2015
{
    partial class libraryForm
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
            this.groupBoxSwitch = new System.Windows.Forms.GroupBox();
            this.buttonLend = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxWindows = new System.Windows.Forms.GroupBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.groupBoxRole = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.groupBoxSwitch.SuspendLayout();
            this.groupBoxWindows.SuspendLayout();
            this.groupBoxRole.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSwitch
            // 
            this.groupBoxSwitch.Controls.Add(this.buttonLend);
            this.groupBoxSwitch.Controls.Add(this.buttonDelete);
            this.groupBoxSwitch.Controls.Add(this.buttonQuery);
            this.groupBoxSwitch.Controls.Add(this.buttonAdd);
            this.groupBoxSwitch.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSwitch.Location = new System.Drawing.Point(867, 62);
            this.groupBoxSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSwitch.Name = "groupBoxSwitch";
            this.groupBoxSwitch.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSwitch.Size = new System.Drawing.Size(175, 715);
            this.groupBoxSwitch.TabIndex = 0;
            this.groupBoxSwitch.TabStop = false;
            this.groupBoxSwitch.Text = "窗口切换";
            // 
            // buttonLend
            // 
            this.buttonLend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLend.Location = new System.Drawing.Point(16, 92);
            this.buttonLend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLend.Name = "buttonLend";
            this.buttonLend.Size = new System.Drawing.Size(149, 37);
            this.buttonLend.TabIndex = 3;
            this.buttonLend.Text = "书籍借阅";
            this.buttonLend.UseVisualStyleBackColor = true;
            this.buttonLend.Click += new System.EventHandler(this.buttonLend_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDelete.Location = new System.Drawing.Point(16, 153);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(149, 37);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "书籍归还";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonQuery.Location = new System.Drawing.Point(16, 30);
            this.buttonQuery.Margin = new System.Windows.Forms.Padding(4);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(149, 37);
            this.buttonQuery.TabIndex = 1;
            this.buttonQuery.Text = "全部书籍";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAdd.Location = new System.Drawing.Point(16, 213);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(149, 37);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "采编入库";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBoxWindows
            // 
            this.groupBoxWindows.Controls.Add(this.groupBox1);
            this.groupBoxWindows.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxWindows.Location = new System.Drawing.Point(16, 62);
            this.groupBoxWindows.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxWindows.Name = "groupBoxWindows";
            this.groupBoxWindows.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxWindows.Size = new System.Drawing.Size(843, 715);
            this.groupBoxWindows.TabIndex = 1;
            this.groupBoxWindows.TabStop = false;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.BackColor = System.Drawing.SystemColors.Control;
            this.labelRole.Location = new System.Drawing.Point(13, 25);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(120, 16);
            this.labelRole.TabIndex = 2;
            this.labelRole.Text = "当前用户：游客";
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(949, 20);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(83, 27);
            this.btnSwitch.TabIndex = 3;
            this.btnSwitch.Text = "登录";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // groupBoxRole
            // 
            this.groupBoxRole.Controls.Add(this.label2);
            this.groupBoxRole.Controls.Add(this.passwordBox);
            this.groupBoxRole.Controls.Add(this.label1);
            this.groupBoxRole.Controls.Add(this.nameBox);
            this.groupBoxRole.Location = new System.Drawing.Point(199, 3);
            this.groupBoxRole.Name = "groupBoxRole";
            this.groupBoxRole.Size = new System.Drawing.Size(660, 52);
            this.groupBoxRole.TabIndex = 4;
            this.groupBoxRole.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(383, 17);
            this.passwordBox.MaxLength = 50;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(246, 26);
            this.passwordBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "账号";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(68, 17);
            this.nameBox.MaxLength = 50;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(246, 26);
            this.nameBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNote);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(30, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(772, 179);
            this.groupBox1.TabIndex = 5;
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
            // libraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 790);
            this.Controls.Add(this.groupBoxRole);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.groupBoxWindows);
            this.Controls.Add(this.groupBoxSwitch);
            this.Controls.Add(this.btnSwitch);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "libraryForm";
            this.Text = "图书管理系统";
            this.Load += new System.EventHandler(this.FormIndex_Load);
            this.groupBoxSwitch.ResumeLayout(false);
            this.groupBoxWindows.ResumeLayout(false);
            this.groupBoxRole.ResumeLayout(false);
            this.groupBoxRole.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSwitch;
        private System.Windows.Forms.Button buttonLend;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBoxWindows;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.GroupBox groupBoxRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNote;
    }
}


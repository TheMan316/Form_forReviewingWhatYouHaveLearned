namespace form_艾宾浩斯遗忘曲线记忆程序 {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.tbx_title = new System.Windows.Forms.TextBox();
            this.btn_showAnswer = new System.Windows.Forms.Button();
            this.btn_addNewMemoryModule = new System.Windows.Forms.Button();
            this.tbx_content = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_yes = new System.Windows.Forms.Button();
            this.btn_no = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择复习内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建复习内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_object = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_times_toRemember = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_refreshText = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_title
            // 
            this.tbx_title.BackColor = System.Drawing.SystemColors.Menu;
            this.tbx_title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_title.Location = new System.Drawing.Point(175, 139);
            this.tbx_title.Multiline = true;
            this.tbx_title.Name = "tbx_title";
            this.tbx_title.Size = new System.Drawing.Size(784, 135);
            this.tbx_title.TabIndex = 0;
            // 
            // btn_showAnswer
            // 
            this.btn_showAnswer.BackColor = System.Drawing.SystemColors.Info;
            this.btn_showAnswer.Location = new System.Drawing.Point(549, 285);
            this.btn_showAnswer.Name = "btn_showAnswer";
            this.btn_showAnswer.Size = new System.Drawing.Size(75, 23);
            this.btn_showAnswer.TabIndex = 2;
            this.btn_showAnswer.Text = "显示内容";
            this.btn_showAnswer.UseVisualStyleBackColor = false;
            this.btn_showAnswer.Click += new System.EventHandler(this.btn_showAnswer_Click);
            // 
            // btn_addNewMemoryModule
            // 
            this.btn_addNewMemoryModule.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_addNewMemoryModule.Location = new System.Drawing.Point(498, 103);
            this.btn_addNewMemoryModule.Name = "btn_addNewMemoryModule";
            this.btn_addNewMemoryModule.Size = new System.Drawing.Size(155, 28);
            this.btn_addNewMemoryModule.TabIndex = 3;
            this.btn_addNewMemoryModule.Text = "新增进记忆列表";
            this.btn_addNewMemoryModule.UseVisualStyleBackColor = false;
            this.btn_addNewMemoryModule.Click += new System.EventHandler(this.btn_addNewMemoryModule_Click);
            // 
            // tbx_content
            // 
            this.tbx_content.BackColor = System.Drawing.SystemColors.Menu;
            this.tbx_content.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_content.Location = new System.Drawing.Point(15, 360);
            this.tbx_content.Multiline = true;
            this.tbx_content.Name = "tbx_content";
            this.tbx_content.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_content.Size = new System.Drawing.Size(1070, 481);
            this.tbx_content.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(170, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "标题：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "内容：";
            // 
            // btn_yes
            // 
            this.btn_yes.BackColor = System.Drawing.Color.LightGreen;
            this.btn_yes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_yes.Location = new System.Drawing.Point(429, 330);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Size = new System.Drawing.Size(76, 28);
            this.btn_yes.TabIndex = 7;
            this.btn_yes.Text = "记得";
            this.btn_yes.UseVisualStyleBackColor = false;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            // 
            // btn_no
            // 
            this.btn_no.BackColor = System.Drawing.Color.Pink;
            this.btn_no.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_no.Location = new System.Drawing.Point(658, 330);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(76, 28);
            this.btn_no.TabIndex = 8;
            this.btn_no.Text = "忘记";
            this.btn_no.UseVisualStyleBackColor = false;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择复习内容ToolStripMenuItem,
            this.创建复习内容ToolStripMenuItem,
            this.说明ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 选择复习内容ToolStripMenuItem
            // 
            this.选择复习内容ToolStripMenuItem.Name = "选择复习内容ToolStripMenuItem";
            this.选择复习内容ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.选择复习内容ToolStripMenuItem.Text = "选择复习内容";
            // 
            // 创建复习内容ToolStripMenuItem
            // 
            this.创建复习内容ToolStripMenuItem.Name = "创建复习内容ToolStripMenuItem";
            this.创建复习内容ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.创建复习内容ToolStripMenuItem.Text = "创建复习主题";
            this.创建复习内容ToolStripMenuItem.Click += new System.EventHandler(this.创建复习内容ToolStripMenuItem_Click);
            // 
            // 说明ToolStripMenuItem
            // 
            this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
            this.说明ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.说明ToolStripMenuItem.Text = "说明";
            this.说明ToolStripMenuItem.Click += new System.EventHandler(this.说明ToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "当前复习主题：";
            // 
            // lbl_object
            // 
            this.lbl_object.AutoSize = true;
            this.lbl_object.Location = new System.Drawing.Point(130, 42);
            this.lbl_object.Name = "lbl_object";
            this.lbl_object.Size = new System.Drawing.Size(22, 15);
            this.lbl_object.TabIndex = 11;
            this.lbl_object.Text = "无";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "剩余复习数量：";
            // 
            // lbl_times_toRemember
            // 
            this.lbl_times_toRemember.AutoSize = true;
            this.lbl_times_toRemember.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_times_toRemember.Location = new System.Drawing.Point(134, 68);
            this.lbl_times_toRemember.Name = "lbl_times_toRemember";
            this.lbl_times_toRemember.Size = new System.Drawing.Size(18, 18);
            this.lbl_times_toRemember.TabIndex = 13;
            this.lbl_times_toRemember.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1029, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 41);
            this.button1.TabIndex = 14;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_refreshText
            // 
            this.btn_refreshText.Location = new System.Drawing.Point(175, 279);
            this.btn_refreshText.Name = "btn_refreshText";
            this.btn_refreshText.Size = new System.Drawing.Size(93, 29);
            this.btn_refreshText.TabIndex = 15;
            this.btn_refreshText.Text = "清空内容";
            this.btn_refreshText.UseVisualStyleBackColor = true;
            this.btn_refreshText.Click += new System.EventHandler(this.btn_refreshText_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(874, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 28);
            this.button2.TabIndex = 16;
            this.button2.Text = "更新内容";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RosyBrown;
            this.button3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.Cornsilk;
            this.button3.Location = new System.Drawing.Point(862, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 29);
            this.button3.TabIndex = 17;
            this.button3.Text = "删除知识点";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1104, 853);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_refreshText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_times_toRemember);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_object);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_yes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_content);
            this.Controls.Add(this.btn_addNewMemoryModule);
            this.Controls.Add(this.btn_showAnswer);
            this.Controls.Add(this.tbx_title);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1122, 900);
            this.MinimumSize = new System.Drawing.Size(1122, 900);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "艾宾浩斯记忆程序";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_title;
        private System.Windows.Forms.Button btn_showAnswer;
        private System.Windows.Forms.Button btn_addNewMemoryModule;
        private System.Windows.Forms.TextBox tbx_content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_yes;
        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择复习内容ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建复习内容ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbl_object;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lbl_times_toRemember;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_refreshText;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}


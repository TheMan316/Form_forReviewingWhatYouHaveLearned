using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace form_艾宾浩斯遗忘曲线记忆程序 {
    public partial class Form1 : Form {
        public static Form1 form;
        /// <summary>
        /// 当前选择的复习主题
        /// </summary>
        internal MemoryObject CurrentMemoryObject { get; set; }
        /// <summary>
        /// 所有的复习主题
        /// </summary>
        internal List<MemoryObject> List_MemoryObject { get; set; } = new List<MemoryObject>();

        public Form1() {
            form = this;
            InitializeComponent();
            Load_xml();
            if (this.List_MemoryObject.Count > 0) {
                string content = "当前所需复习的主题有：";
                for (int i = 0; i < List_MemoryObject.Count; i++) {
                    if (List_MemoryObject[i].Get_times_toRemember() > 0) {
                        content += $"\n{List_MemoryObject[i].ObjectName}，复习的知识数量为：" +
                            $"{List_MemoryObject[i].Get_times_toRemember()}";
                    }
                }
                MessageBox.Show(content);

            }
        }
        private void Load_xml() {
            if (File.Exists("list.txt")) {
                string[] fileNames = File.ReadAllLines("list.txt");
                foreach (var fileName in fileNames) {
                    string xmlFile = fileName + ".xml";
                    if (File.Exists(xmlFile) == false) {
                        continue;
                    }
                    var memoryObject = new MemoryObject(fileName);
                    //创建一个xml读取器
                    XmlTextReader reader = new XmlTextReader(xmlFile);
                    //会识别取换行符
                    reader.Normalization = false;
                    //循环“正在复习的内容”这个名字的所有元素
                    while (reader.ReadToFollowing("正在复习的内容")) {
                        while (reader.ReadToFollowing("模块")) {
                            //创建模块
                            MemoryModule module = new MemoryModule();
                            module.Title = reader.GetAttribute("标题");
                            module.Date_toRemember = Convert.ToUInt64(reader.GetAttribute("下次复习时间"));
                            module.TotalRememberTimes = Convert.ToInt32(reader.GetAttribute("共复习次数"));
                            module.MemberLevel = Convert.ToInt32(reader.GetAttribute("记忆等级"));
                            reader.ReadToFollowing("内容");
                            module.Content = reader.ReadString();
                            memoryObject.Add_memoryModule_toBeRemenbered(module);
                        }
                    }
                    while (reader.ReadToFollowing("无需复习的内容")) {
                        while (reader.ReadToFollowing("模块")) {
                            //创建模块
                            MemoryModule module = new MemoryModule();

                            module.Title = reader.GetAttribute("标题");
                            module.Date_toRemember = Convert.ToUInt64(reader.GetAttribute("下次复习时间"));
                            module.TotalRememberTimes = Convert.ToInt32(reader.GetAttribute("共复习次数"));
                            module.MemberLevel = Convert.ToInt32(reader.GetAttribute("记忆等级"));
                            reader.ReadToFollowing("内容");
                            module.Content = reader.ReadString();
                            memoryObject.Add_memoryModule_noNeedToBeRemenbered(module);

                        }
                    }
                    memoryObject.Update();
                    reader.Close();
                    this.List_MemoryObject.Add(memoryObject);
                }
                if (this.List_MemoryObject.Count > 0) {
                    this.CurrentMemoryObject = this.List_MemoryObject[0];
                    Update_currentText();
                    lbl_object.Text = this.CurrentMemoryObject.ObjectName;
                }
                for (int i = 0; i < this.List_MemoryObject.Count; i++) {
                    int j = i;
                    var toolStripMenuItem = new ToolStripMenuItem() {
                        Text = List_MemoryObject[i].ObjectName
                    };
                    toolStripMenuItem.Click += (o, e) => {
                        Choose_currentModuleObject(j);
                    };
                    选择复习内容ToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
                }
            }
        }
        private void Choose_currentModuleObject(int index) {
            this.CurrentMemoryObject = this.List_MemoryObject[index];

            Update_currentText();
            lbl_object.Text = this.CurrentMemoryObject.ObjectName;
        }

        private void btn_next_Click(object sender, EventArgs e) {

        }
        /// <summary>
        /// 更新下一个记忆模块的文本。包括标题，内容，数量。如果数量为0，会直接返回。
        /// </summary>
        private void Update_nextText(bool isRemember) {
            Clear_text();
            var memoryModule = this.CurrentMemoryObject.Get_nextMemoryModule(isRemember);
            lbl_times_toRemember.Text = this.CurrentMemoryObject.Get_times_toRemember().ToString();
            if (this.CurrentMemoryObject.Get_times_toRemember() == 0) {
                MessageBox.Show("该主题已经全部复习完成！");
                return;
            }
            var newMemoryModule = this.CurrentMemoryObject.Get_nextMemoryModule();
            tbx_title.Text = newMemoryModule.Title;
        }

        private void btn_addNewMemoryModule_Click(object sender, EventArgs e) {
            if (lbl_object.Text == "无") {
                MessageBox.Show("请先在菜单中添加一个复习主题！");
                return;
            }

            CurrentMemoryObject.Creat_memoryModule(tbx_title.Text, tbx_content.Text);
            Update_currentText();
        }
        public bool Exist_memoryObject(string name) {
            foreach (var memoryObject in this.List_MemoryObject) {
                if (memoryObject.ObjectName == name) {
                    return true;
                }
            }
            return false;
        }
        private void Delete_theMemoryObject(int index) {
            this.List_MemoryObject.RemoveAt(index);
        }
        private void 创建复习内容ToolStripMenuItem_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2();
            Clear_text();
            lbl_times_toRemember.Text = "0";
            form2.Show();

        }

        private void btn_refreshText_Click(object sender, EventArgs e) {
            Clear_text();
        }
        /// <summary>
        /// 清空文本所有内容
        /// </summary>
        private void Clear_text() {
            tbx_content.Clear();
            tbx_title.Clear();

        }

        private void button1_Click(object sender, EventArgs e) {
            this.CurrentMemoryObject.Update();
            Update_currentText();
        }
        private void Update_currentText() {
            Clear_text();
            lbl_times_toRemember.Text = this.CurrentMemoryObject.Get_times_toRemember().ToString();
            if (lbl_times_toRemember.Text == "0") {
                return;
            }
            var memoryModule = this.CurrentMemoryObject.Get_nextMemoryModule();
            tbx_title.Text = memoryModule.Title;

        }

        private void btn_yes_Click(object sender, EventArgs e) {
            if (Exist_memoryModule_toRemember()) {

                Update_nextText(true);
                this.CurrentMemoryObject.Update();
            }

        }
        /// <summary>
        /// 是否还存在复习的记忆模块
        /// </summary>
        /// <returns></returns>
        private bool Exist_memoryModule_toRemember() {
            Clear_text();
            lbl_times_toRemember.Text = this.CurrentMemoryObject.Get_memoryTree_toBeRemembered().Count.ToString();
            if (lbl_times_toRemember.Text == "0") {
                MessageBox.Show("暂无复习内容。");
                return false;
            }
            return true;
        }
        private void btn_no_Click(object sender, EventArgs e) {
            if (Exist_memoryModule_toRemember()) {

                Update_nextText(false);
                this.CurrentMemoryObject.Update();
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            btn_yes.Enabled = true;
            btn_no.Enabled = true;
        }

        private void btn_showAnswer_Click(object sender, EventArgs e) {
            tbx_content.Text = this.CurrentMemoryObject.Get_nextMemoryModule().Content;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            var stream = File.CreateText("list.txt");
            for (int i = 0; i < this.List_MemoryObject.Count; i++) {
                XDocument xml = new XDocument();
                XElement xRoot = new XElement("root");
                xml.Add(xRoot);
                var memoryObject = this.List_MemoryObject[i];
                XElement xMemoryObject1 = new XElement("正在复习的内容");
                xRoot.Add(xMemoryObject1);
                XElement xMemoryObject2 = new XElement("无需复习的内容");
                xRoot.Add(xMemoryObject2);
                var tree2 = memoryObject.Get_memoryTree_toBeRemembered();
                tree2.Add_attributeOfMemoryModule_toTheElement(xMemoryObject1);
                var tree1 = memoryObject.Get_memoryTree_noNeedToBeRemenbered();
                tree1.Add_attributeOfMemoryModule_toTheElement(xMemoryObject2);

                xml.Save($"{memoryObject.ObjectName}.xml");
                stream.WriteLine($"{memoryObject.ObjectName}");
            }
            stream.Close();
        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("版权归属：lingnan_man@qq.com\n初版完成时间：2022年11月4日1:26\n记忆等级分为10个等级：\n" +
                "第一级：30秒后进入复习时间。" +
                "\n第二级：5分钟后进入复习时间。" +
                "\n第三极：30分钟后进入复习时间。" +
                "\n第四级：3小时后进入复习时间。" +
                "\n第五级：12小时后进入复习时间。" +
                "\n第六级：24小时后进入复习时间。" +
                "\n第七级：2天后进入复习时间。" +
                "\n第八级：4天后进入复习时间。" +
                "\n第九级：7天后进入复习时间。" +
                "\n第十级：15天后进入复习时间。" +
                "\n【提示】如果未记住，记忆等级下降2级。");
        }

        private void button2_Click_1(object sender, EventArgs e) {
            this.CurrentMemoryObject.Get_nextMemoryModule().Title = tbx_title.Text;
            this.CurrentMemoryObject.Get_nextMemoryModule().Content = tbx_content.Text;

        }

        private void button3_Click(object sender, EventArgs e) {
            this.CurrentMemoryObject.Delete_nextMemoryModule();
            if (Exist_memoryModule_toRemember()) {
                Update_currentText();
                this.CurrentMemoryObject.Update();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}

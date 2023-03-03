using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_艾宾浩斯遗忘曲线记忆程序 {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (Form1.form.Exist_memoryObject(textBox1.Text)) {
                MessageBox.Show("已有相同的主题！");
                 return;
            }
            MemoryObject memoryObject = new MemoryObject(textBox1.Text);
            memoryObject.defaultMinimumLevel = comboBox1.SelectedIndex;
            Form1.form.CurrentMemoryObject = memoryObject;
            Form1.form.List_MemoryObject.Add(memoryObject);
            Form1.form.lbl_object.Text = Form1.form.CurrentMemoryObject.ObjectName;
            Form1.form.CurrentMemoryObject = Form1.form.List_MemoryObject[Form1.form.List_MemoryObject.Count - 1];
            var toolStripMenuItem = new ToolStripMenuItem() {
                Text = Form1.form.lbl_object.Text
            };
            toolStripMenuItem.Click += (o, f) => {
                Form1.form.Choose_currentModuleObject(Form1.form.List_MemoryObject.Count-1);
            };
            Form1.form.选择复习内容ToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            MessageBox.Show("创建成功，请为当前的新主题添加复习内容！");
            this.Close();
        }
       
        private void Form2_Load(object sender, EventArgs e) {

        }
    }
}

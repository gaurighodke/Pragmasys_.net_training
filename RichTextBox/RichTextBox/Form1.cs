using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace RichTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee e1 = new Employee();
            e1.EmpId = Convert.ToInt32(textBox1.Text);
            e1.EmpName = textBox2.Text;
            e1.salary = Convert.ToInt32(textBox3.Text);
            FileStream fs = new FileStream(@"C:\Users\test\Desktop\FileOp\sample.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            XmlSerializer ser = new XmlSerializer(typeof(Employee));
            ser.Serialize(fs, e1);
            fs.Close();


            MessageBox.Show("File Created and writing...");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\test\Desktop\FileOp\sample.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            richTextBox1.Text = sr.ReadToEnd().ToString();
            //richTextBox1.Text = sr.Read().ToString();
            //richTextBox1.Text = sr.Read().ToString();

            fs.Close();
            MessageBox.Show("File Created and reading...");


        }
    }
}

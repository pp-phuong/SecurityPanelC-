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

namespace SecurityPanel
{
    public partial class SecurityPanel : Form
    {
        string path = @"C:\Users\Em\source\repos\Baitap\log.txt";
        string pass = "1234";
        public SecurityPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text_pass.Text.Length < 4)
            {
                text_pass.Text += ((Button)sender).Text;
            }
            btnConfirm.Focus();

        }
        private void pressNumber(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Back)) btnClear_Click(sender, e);
            if (text_pass.Text.Length < 4 && e.KeyChar <= '9' && e.KeyChar >= '0')
            {
                text_pass.Text += e.KeyChar.ToString();
            }
            btnConfirm.Focus();
        }
        public void pressEnter()
        {
            DateTime now = DateTime.Now;
            using (StreamWriter sw = File.AppendText(path))
            {
                if (text_pass.Text == pass)
                {

                    sw.WriteLine(now + "    Login success");
                    MessageBox.Show("Đăng nhập thành công", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    text_pass.Text = "";
                }
                else
                {
                    sw.WriteLine(now + "    Login fail");
                    MessageBox.Show("Đăng nhập không thành công", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_pass.Text = "";
                }
            }
            Log();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Log();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            text_pass.Text = "";
            btnConfirm.Focus();

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            using (StreamWriter sw = File.AppendText(path))
            {
                if (text_pass.Text == pass)
                {

                    sw.WriteLine(now + "    Login success");
                    MessageBox.Show("Đăng nhập thành công", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    text_pass.Text = "";
                }
                else
                {
                    sw.WriteLine(now + "    Login fail");
                    MessageBox.Show("Đăng nhập không thành công", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    text_pass.Text = "";
                }
            }
            Log();
        }

        public void Log()
        {
            listBox1.Items.Clear();
            string[] log = File.ReadAllLines(path);
            foreach (string line in log)
            {
                listBox1.Items.Add(line);
            }
        }
    }
}

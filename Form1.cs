using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;

namespace RSAPwd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte[] GetBytes(string str)
        {
            List<byte> bytes = new List<byte>();
            foreach (char c in str)
            {
                bytes.Add(Convert.ToByte(c));
            }
            return bytes.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RSA rsa = null;
            string key = ConfigurationManager.AppSettings["privateKey"];
            if (!string.IsNullOrEmpty(key))
                rsa = new RSA(System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(key)));
            else
                rsa = new RSA();
            string s = rsa.Encrypt(textBox3.Text);
            textBox4.Text = s;
            textBox7.Text = rsa.PrivateKey;
            //MessageBox.Show(s.Length.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RSA rsa = null;
            string key = ConfigurationManager.AppSettings["privateKey"];
            if (!string.IsNullOrEmpty(key))
                rsa = new RSA(System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(key)));
            else
                rsa = new RSA();
            textBox5.Text = rsa.Decrypt(textBox4.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] data = System.Text.Encoding.Unicode.GetBytes(textBox7.Text);
            textBox6.Text = Convert.ToBase64String(data);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RSA rsa = new RSA();
            textBox1.Text = rsa.PrivateKey;
        }
    }
}

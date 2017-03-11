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

namespace 金絃獎_比賽順序抽籤系統
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> info = new List<string>();
        string[] group = new string[4] {"個人組", "團體組", "創作組", "鋼弦演奏組"};

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < group.Length; i++)
                comboBox1.Items.Add(group[i]);
            txtResult.Enabled = false;
            comboBox1.Text = "比賽組別";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Random rd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < txtInfo.Lines.Length; i++)
                info.Add(txtInfo.Lines[i]);
            int group_qaun = info.Count;
            for (int i = 0; i < group_qaun; i++)
            {
                int rand_num = rd.Next(group_qaun - i);
                txtResult.Text += (i + 1).ToString("D2");
                txtResult.Text += ". ";
                txtResult.Text += info[rand_num];
                info.RemoveAt(rand_num);
                txtResult.Text += Environment.NewLine;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = comboBox1.SelectedItem + "_比賽順序.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                writer.WriteLine("-----" + comboBox1.SelectedItem + "-----");
                writer.WriteLine();
                writer.Write(txtResult.Text);
                writer.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            info.Clear();
            txtResult.Text = "";
            txtInfo.Text = "";
            comboBox1.Text = "比賽組別";
        }
    }
}

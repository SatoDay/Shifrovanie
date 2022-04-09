using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shifrovanie
{
    public partial class Form1 : Form
    {
        private char[] alph1 =("abcdefghijklmnopqrstuvwxyz .,!?").ToCharArray();
        private char[] alph2 = ("абвгдеёжзийклмнопрстуфхцчщшъыьэюя .,!?").ToCharArray();
        private char[] active_alph;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            active_alph = alph1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] text = richTextBox1.Text.ToLower().ToCharArray();
            char[] key = textBox1.Text.ToLower().ToCharArray();
            int key_index = 0;

            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (key_index == key.Length)
                    key_index = 0;
                int ind = (Array.IndexOf(active_alph, text[i]) + Array.IndexOf(active_alph, key[key_index])) % active_alph.Length;
                key_index++;
                result += active_alph[ind]; 
                
            }
            richTextBox2.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] text = richTextBox2.Text.ToLower().ToCharArray();
            char[] key = textBox1.Text.ToLower().ToCharArray();
            int key_index = 0;

            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (key_index == key.Length)
                    key_index = 0;
                int ind = (Array.IndexOf(active_alph, text[i]) - Array.IndexOf(active_alph, key[key_index]));
                if (ind < 0)
                    ind += active_alph.Length;
                key_index++;
                result += active_alph[ind];

            }
            richTextBox1.Text = result;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            active_alph = alph1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            active_alph = alph2;
        }
    }
}

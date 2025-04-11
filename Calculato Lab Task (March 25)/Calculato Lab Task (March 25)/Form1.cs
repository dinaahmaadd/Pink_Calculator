using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculato_Lab_Task__March_25_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            int f = 1;
            float res = 0;

            if (temp.Length == 0 || temp[0] == '+' || temp[0] == '-' || temp[0] == '*' || temp[0] == '/')
            {
                f = 0;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '+' || temp[i] == '-' || temp[i] == '*' || temp[i] == '/')
                {
                    if (temp.Length < 3 || temp[i + 1] == '+' || temp[i + 1] == '-' || temp[i + 1] == '*' || temp[i + 1] == '/') 
                    {
                        f = 0;
                        break;
                    }
                }
            }

            if (f == 1)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == '*' || temp[i] == '/')
                    {
                        string num1 = "";
                        string num2 = "";

                        for (int j = i - 1; j >= 0; j--) 
                        {
                            if (temp[j] != '+' && temp[j] != '-' && temp[j] != '*' && temp[j] != '/')
                            {
                                num1 = temp[j] + num1;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int j = i + 1; j < temp.Length; j++)
                        {
                            if (temp[j] != '+' && temp[j] != '-' && temp[j] != '*' && temp[j] != '/')
                            {
                                num2 += temp[j];
                            }
                            else 
                            {
                                break;
                            }
                        }

                        if (temp[i] == '*')
                        {
                            res = float.Parse(num1) * float.Parse(num2);
                        }

                        if (temp[i] == '/')
                        {
                            if (float.Parse(num2) == 0)
                            {
                                f = 2;
                                break;
                            }
                            res = float.Parse(num1) / float.Parse(num2);
                        }
                        string result = res.ToString();

                        int start = i - num1.Length;
                        int end = i + num2.Length + 1;

                        string temp2 = "";

                        for (int k = 0; k < start; k++)
                        {
                            temp2 += temp[k]; 
                        }

                        temp2 += result;

                        for (int k = end; k < temp.Length; k++)
                        {
                            temp2 += temp[k];
                        }

                        temp = temp2;
                        i = start + result.Length - 1;
                    }
                }
            }

            if (f == 1)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] == '+' || temp[i] == '-')
                    {
                        string num1 = "";
                        string num2 = "";

                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (temp[j] != '+' && temp[j] != '-' && temp[j] != '*' && temp[j] != '/')
                            {
                                num1 = temp[j] + num1;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int j = i + 1; j < temp.Length; j++)
                        {
                            if (temp[j] != '+' && temp[j] != '-' && temp[j] != '*' && temp[j] != '/')
                            {
                                num2 += temp[j];
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (temp[i] == '+')
                        {
                            res = float.Parse(num1) + float.Parse(num2);
                        }

                        if (temp[i] == '-')
                        {
                            res = float.Parse(num1) - float.Parse(num2);
                        }
                        string result = res.ToString();

                        int start = i - num1.Length;
                        int end = i + num2.Length + 1;

                        string temp2 = "";

                        for (int k = 0; k < start; k++)
                        {
                            temp2 += temp[k];
                        }

                        temp2 += result;

                        for (int k = end; k < temp.Length; k++)
                        {
                            temp2 += temp[k];
                        }

                        temp = temp2;
                        i = start + result.Length - 1;
                    }
                }
            }


            if (f != 1) 
            {
                if (f == 0)
                {
                    MessageBox.Show("Invalid expression, Please re-check the expression.");
                    textBox1.Clear();
                }

                if (f == 2) 
                {
                    MessageBox.Show("Cannot divide by Zero.");
                    textBox1.Clear();
                }
            }
            else
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = temp;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string temp = "";
            temp = textBox1.Text;
            textBox1.Clear();

            for(int i=0; i<temp.Length - 1; i++)
            {
                textBox1.Text += temp[i];
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
        }
    }
}

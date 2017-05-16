using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {
        string textOnputFileName;
        string DataBase;
        string textInput;
        string[] DataBaseArray;
        string[] textInputArray;
        string[] textOnput;
        int Match = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase = System.IO.File.ReadAllText(textBox5.Text);
                textInput = System.IO.File.ReadAllText(textBox4.Text);
                DataBase = DataBase.Replace(" ", "");
                DataBase = DataBase.Replace("\t" + "\t" + "\t" + "\t", "\t");
                DataBase = DataBase.Replace("\t" + "\t" + "\t", "\t");
                DataBase = DataBase.Replace("\t" + "\t", "\t");
                DataBaseArray = DataBase.Split('\t', '\n');
                textInput = textInput.Replace(" ", "");
                textInput = textInput.Replace("\t", "");
                textInputArray = textInput.Split('\n');
                textOnput = new string[textInputArray.Length];


                //textOnput
                for (int ii = 0; ii <= textInputArray.Length - 1; ii = ii + 1)
                {
                    Match = 0;
                    for (int i = 0; i <= DataBaseArray.Length - 2; i = i + 2)
                    {
                        textInputArray[ii] = textInputArray[ii].Replace(" ", "");
                        textInputArray[ii] = textInputArray[ii].Replace("\r", "");
                        DataBaseArray[i] = DataBaseArray[i].Replace(" ", "");
                        DataBaseArray[i] = DataBaseArray[i].Replace("\r", "");
                        DataBaseArray[i] = DataBaseArray[i].Replace("\n", "");

                        if (textInputArray[ii] == DataBaseArray[i])
                        {
                            textOnput[ii] = DataBaseArray[i + 1];
                            textBox3.Text = textBox3.Text + textInputArray[ii] + "\t" + textOnput[ii] + "\n";
                            Match = 1;
                        }
                        else
                        { }

                    }
                    if (Match == 0)
                    {
                        textOnput[ii] = "Null";
                        textBox3.Text = textBox3.Text + textInputArray[ii] + "\t" + textOnput[ii] + "\r\n";
                    }
                }


                //DataBase
                for (int i = 0; i <= DataBaseArray.Length -2; i = i + 2)
                {
                    if (DataBaseArray[i] == "\t" || DataBaseArray[i] == "\r")
                    { }
                    else
                    {
                        textBox2.Text = textBox2.Text + DataBaseArray[i] + "\t" + DataBaseArray[i + 1] + "\r\n";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Error ^ ^ ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog textInputFile = new OpenFileDialog();
            if (textInputFile.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = textInputFile.FileName;
                textOnputFileName = textInputFile.FileName.Replace(".txt", "") + "_Output.txt";


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDataBaseFile = new OpenFileDialog();
            if (OpenDataBaseFile.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = OpenDataBaseFile.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] lines = { textBox3.Text };

            System.IO.File.WriteAllLines(textOnputFileName, lines);
            label2.Visible = true;
            label2.Text = "已存於" + textOnputFileName;
            //        textBox5.Text.Replace 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

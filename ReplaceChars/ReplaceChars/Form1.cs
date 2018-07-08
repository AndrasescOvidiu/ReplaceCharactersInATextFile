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

namespace ReplaceChars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public List<string> generateACharList()
        {
            List<string> chars = new List<string>();
            if (a1.Text.Length > 0)
            {
                chars.Add(a1.Text);
            }
            return chars;
        }
        public List<string> generateBCharList()
        {
            List<string> chars = new List<string>();
            if (b1.Text.Length > 0)
            {
                chars.Add(b1.Text);
            }
            return chars;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\Ovidiu\\Desktop";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            List<string> charsA = generateACharList();
            List<string> charsB = generateBCharList();

            MessageBox.Show(charsA[0]+ " " + charsB[0] );

            String generatedFile = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    String path = "C:\\Users\\Ovidiu\\Desktop\\result.docs";


                    if ((openFileDialog1.OpenFile()) != null)
                    {
                        var filestream = new System.IO.FileStream(openFileDialog1.FileName,
                                          System.IO.FileMode.Open,
                                          System.IO.FileAccess.Read,
                                          System.IO.FileShare.ReadWrite);
                        var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);
                        String lineOfText = "";
                        while ((lineOfText = file.ReadLine()) != null)
                        {
                            generatedFile += lineOfText+ Environment.NewLine;

                            generatedFile =  generatedFile.Replace(Convert.ToChar(charsA[0]), Convert.ToChar(charsB[0]));
                        }
         
                        File.WriteAllText(path, generatedFile);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            MessageBox.Show("Done");
        }
    }
}

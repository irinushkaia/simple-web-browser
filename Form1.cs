using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ProiectOOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {    
            InitializeComponent();
           // _Form1 = this;
        }
        //public static Form1 _Form1;
        
        public void write(string message)
        {
            richTextBox1.AppendText(message);
        }
        public void update(string message)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.Font, System.Drawing.FontStyle.Regular);
            richTextBox1.AppendText(message /*+ "\r\n"*/);
        }

        public void italic(string message)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.Font, System.Drawing.FontStyle.Italic);
            richTextBox1.AppendText(message /*+ "\r\n"*/);
        }
        public void bold(string message)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.Font, System.Drawing.FontStyle.Bold);
            richTextBox1.AppendText(message /*+ "\r\n"*/);
        }
        public void heading(string message)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newFontStyle = (FontStyle)(currentFont.Style | FontStyle.Bold);
            richTextBox1.SelectionFont = new Font(currentFont.FontFamily, 12,newFontStyle);
            richTextBox1.AppendText(message);
        }
        public void newline()
        {
            richTextBox1.AppendText(Environment.NewLine);
        }
        public void tab()
        {
            richTextBox1.AppendText("\t");
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "html|*.html" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = ofd.FileName;
                    richTextBox1.Clear(); //se goleste daca adaugi alt fisier de afisat
                    ManageHtml parse = new ManageHtml(ofd.FileName);
                
                    parse.GetText(this);
                    


                }

            }

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
   

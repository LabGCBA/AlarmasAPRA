using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace Alarma
{
    public partial class Form1 : Form
    {
        private bool scroll;

        public void addLog(String text)
        {
            scroll = checkBox1.Checked;
            if (InvokeRequired)
            {
                richTextBox1.Invoke((Action)delegate
                {
                    richTextBox1.AppendText(text + "\n");
                    if (scroll)
                        richTextBox1.ScrollToCaret();
                });
            }
            else
            {
                richTextBox1.AppendText(text + "\n");
                if (scroll)
                    richTextBox1.ScrollToCaret();
            }
        }

        public Form1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\herna\OneDrive\Documentos\Visual Studio 2015\Projects\Alarma\Alarma\config.ini");
            InitializeComponent();
            int top = 75;

            foreach (string line in lines)
            {
                Sensor sensor = new Sensor(top, line, this);
                top += 33;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}

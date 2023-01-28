using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingChecker
{
    public partial class Form1 : Form
    {
        private EncodingChecker ec;
        public Form1()
        {
            ec = new EncodingChecker();
            InitializeComponent();
        }

        private void choosePathButton_Click(object sender, EventArgs e)
        {
            var result = pathOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathTextBox.Text = pathOpenFileDialog.FileName;
            }
        }

        private void checkCodingButton_Click(object sender, EventArgs e)
        {
            var result = ec.GetFileEncoding(pathTextBox.Text);
            resultLabel.Text = result;
            resultLabel.Visible = true;
        }
    }
}
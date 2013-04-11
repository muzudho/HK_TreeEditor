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
        public Form1()
        {
            InitializeComponent();
        }


        private void FitSize()
        {
            this.uiMain1.Location = new Point(0, this.menuStrip1.Height);
            this.uiMain1.Width = this.ClientSize.Width;
            this.uiMain1.Height = this.ClientSize.Height - this.menuStrip1.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FitSize();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.FitSize();
        }
    }
}

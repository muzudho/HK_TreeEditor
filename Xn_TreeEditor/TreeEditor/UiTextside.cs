using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class UiTextside : UserControl
    {
        public UiTextside()
        {
            InitializeComponent();
        }

        private void FitSize()
        {
            this.toolStripContainer1.Location = new Point();
            this.toolStripContainer1.Width = this.ClientSize.Width;
            this.toolStripContainer1.Height = this.ClientSize.Height;

            this.richTextBox1.Location = new Point();
            this.richTextBox1.Width = this.toolStripContainer1.ContentPanel.Width;
            this.richTextBox1.Height = this.toolStripContainer1.ContentPanel.Height;
        }

        private void UiTextside_Load(object sender, EventArgs e)
        {
            this.FitSize();

            // フォント・ファミリー
            this.toolStripComboBox1.Items.Clear();
            //InstalledFontCollectionオブジェクトの取得
            System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection();
            //インストールされているすべてのフォントファミリアを取得
            FontFamily[] ffs = ifc.Families;
            foreach (FontFamily ff in ffs)
            {
                //ここではスタイルにRegularが使用できるフォントのみを表示
                if (ff.IsStyleAvailable(FontStyle.Regular))
                {
                    this.toolStripComboBox1.Items.Add(ff.Name);
                }
            }
            this.toolStripComboBox1.SelectedIndex = 0;

            // フォントサイズ
            this.toolStripComboBox2.Items.Clear();
            this.toolStripComboBox2.Items.AddRange(new string[] {"9","10","11" });
            this.toolStripComboBox2.SelectedIndex = 0;
        }

        private void UiTextside_Resize(object sender, EventArgs e)
        {
            this.FitSize();
        }

        private void toolStrip2_Resize(object sender, EventArgs e)
        {
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.TextBox.Width = this.toolStrip2.ClientSize.Width - 20;
        }
    }
}

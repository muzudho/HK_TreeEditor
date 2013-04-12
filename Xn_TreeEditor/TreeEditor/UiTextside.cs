using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeEditor
{
    public partial class UiTextside : UserControl
    {
        /// <summary>
        /// テキストの丸ごと履歴。
        /// </summary>
        private TextHistory textHistory;
        public TextHistory TextHistory
        {
            get
            {
                return textHistory;
            }
            set
            {
                textHistory = value;
            }
        }



        public void Undo()
        {
            string old;
            if (this.TextHistory.TryUndo(out old))
            {
                this.isAutoinputTextareaText = true;
                this.TextareaText = old;
                this.isAutoinputTextareaText = false;
            }
        }
        public void Redo()
        {
            string next;
            if (this.TextHistory.TryRedo(out next))
            {
                this.isAutoinputTextareaText = true;
                this.TextareaText = next;
                this.isAutoinputTextareaText = false;
            }
        }
        /// <summary>
        /// テキストエリアへの自動入力。
        /// </summary>
        private bool isAutoinputTextareaText;
        public bool IsAutoinputTextareaText
        {
            get
            {
                return isAutoinputTextareaText;
            }
            set
            {
                isAutoinputTextareaText = value;
            }
        }




        public UiTextside()
        {
            InitializeComponent();
            this.textHistory = new TextHistory();
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

            //━━━━━
            // フォント・ファミリー
            //━━━━━
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

            //━━━━━
            // フォントサイズ
            //━━━━━
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

        /// <summary>
        /// ノード名を入れるテキストボックスです。
        /// </summary>
        public ToolStripTextBox ToolStripTextBox1
        {
            get
            {
                return this.toolStripTextBox1;
            }
        }

        public string TextareaText
        {
            get
            {
                return this.richTextBox1.Text;
            }
            set
            {
                this.richTextBox1.Text = value;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!this.isAutoinputTextareaText)
            {
                this.TextHistory.Add(this.richTextBox1.Text);
            }

            UiMain uiMain = ((Form1)this.ParentForm).UiMain1;
            uiMain.TestChangeText();

            // 改行コードが違っても、文字が同じなら、変更なしと判定します。
            string text1 = uiMain.FileText.Replace("\r", "").Replace("\n", "");
            string text2 = this.richTextBox1.Text.Replace("\r", "").Replace("\n", "");

            uiMain.IsChangedText = text1.CompareTo(text2)!=0;
            //uiMain.IsChangedText = uiMain.FileText.CompareTo(this.richTextBox1.Text) != 0;

            //System.Console.WriteLine("★uiMain.FileText==this.richTextBox1.Text");
            //System.Console.WriteLine(uiMain.FileText==this.richTextBox1.Text);
            //System.Console.WriteLine("★uiMain.FileText.CompareTo(this.richTextBox1.Text)");
            //System.Console.WriteLine(uiMain.FileText.CompareTo(this.richTextBox1.Text));
            //System.Console.WriteLine("★uiMain.IsChangedText");
            //System.Console.WriteLine(uiMain.IsChangedText);
            //System.Console.WriteLine("★ファイルテキスト");
            //System.Console.WriteLine(uiMain.FileText);
            //System.Console.WriteLine("★テキストエリアテキスト");
            //System.Console.WriteLine(this.richTextBox1.Text);

            uiMain.RefreshTitleBar();
        }
    }
}

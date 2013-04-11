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
    public partial class UiMain : UserControl
    {
        public UiMain()
        {
            InitializeComponent();
        }

        private void FitSize()
        {
            this.toolStripContainer1.Location = new Point();
            this.toolStripContainer1.Width = this.ClientSize.Width;
            this.toolStripContainer1.Height = this.ClientSize.Height;

            this.treeView1.Location = new Point();
            this.treeView1.Width = this.splitContainer1.Panel1.Width;
            this.treeView1.Height = this.splitContainer1.Panel1.Height;

            this.uiTextside1.Location = new Point();
            this.uiTextside1.Width = this.splitContainer1.Panel2.Width;
            this.uiTextside1.Height = this.splitContainer1.Panel2.Height;
        }

        private void UiMain_Load(object sender, EventArgs e)
        {
            this.FitSize();

            //━━━━━
            //ツリービュー
            //━━━━━            
            this.treeView1.Nodes.Clear();
            this.treeView1.ImageList = this.imageList1;

            TreeNode treeNodeFruits = new TreeNode("果物");
            TreeNode treeNodeVegetables = new TreeNode("野菜",1,1);
            TreeNode[] treeNodeSubFolder = { treeNodeFruits, treeNodeVegetables};

            // 下位階層に対してまとめて項目（ノード）を追加
            TreeNode treeNodeFood = new TreeNode("食べ物", treeNodeSubFolder);

            TreeNode treeNodeDrink = new TreeNode("飲み物");
            TreeNode[] treeNodeRoot = { treeNodeFood, treeNodeDrink };

            // 最上位階層に対してまとめて項目（ノード）を追加
            treeView1.Nodes.AddRange(treeNodeRoot);

            treeView1.TopNode.Expand();
        }

        private void UiMain_Resize(object sender, EventArgs e)
        {
            this.FitSize();
        }
    }
}

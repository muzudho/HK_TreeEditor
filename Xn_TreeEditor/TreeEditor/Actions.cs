using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace TreeEditor
{


    public class Actions
    {

        public static void Undo(Form1 form1)
        {
            form1.UiMain1.UiTextside1.Undo();
        }

        public static void Redo(Form1 form1)
        {
            form1.UiMain1.UiTextside1.Redo();
        }

        /// <summary>
        /// プロジェクトの新規作成。
        /// </summary>
        public static void New(Form1 form1)
        {
            System.Console.WriteLine("プロジェクトを新規作成したい。");

            NewProjectDialog dlg = new NewProjectDialog();
            dlg.ShowDialog(form1);

            //━━━━━
            //ディレクトリー作成
            //━━━━━
            {
                string dir = dlg.UiNewProject.TextBox1.Text;
                System.Console.WriteLine("作成ディレクトリー：" + dir);

                if (Directory.Exists(@"save\" + dir))
                {
                    MessageBox.Show("もうあります。\n" + dir);
                }
                else
                {
                    form1.UiMain1.CreateDefaultProject(dir);
                    form1.UiMain1.OpenProject(dir);
                }
            }


            ////━━━━━
            ////ディレクトリー一覧
            ////━━━━━
            //{
            //    this.listBox1.Items.Clear();

            //    string[] dirs = Directory.GetDirectories("save");

            //    foreach (string dir in dirs)
            //    {
            //        System.Console.WriteLine("ディレクトリー：" + dir);

            //        string dir2 = dir;
            //        if (dir2.StartsWith(@"save\"))
            //        {
            //            dir2 = dir2.Substring(@"save\".Length, dir2.Length - @"save\".Length);
            //        }

            //        this.listBox1.Items.Add(dir2);
            //    }
            //}

            dlg.Dispose();

        }

        public static void LoadText(Form1 form1,string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string text = File.ReadAllText(filePath, Encoding.GetEncoding("Shift_JIS"));
                    form1.UiMain1.FilePath = filePath;
                    form1.UiMain1.FileText = text;
                    form1.UiMain1.UiTextside1.TextareaText = text;
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show(form1, filePath, "ファイルが無い");
            }
        }

        public static void SaveText(Form1 form1)
        {
            if (File.Exists(form1.UiMain1.FilePath))
            {
                try
                {
                    File.WriteAllText(form1.UiMain1.FilePath, form1.UiMain1.UiTextside1.TextareaText, Encoding.GetEncoding("Shift_JIS"));
                    form1.UiMain1.FileText = form1.UiMain1.UiTextside1.TextareaText;
                    form1.UiMain1.TestChangeText();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show(form1, form1.UiMain1.FilePath, "ファイルが無い");
            }
        }

    }
}

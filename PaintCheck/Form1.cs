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
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace PaintCheck
{
    public partial class Form1 : Form
    {
        string folderPath = @"C:\Users\balindattila\Desktop\templates";
        List<string> lista = new List<string>();
        Excel1 excel = new Excel1(@"C:\Users\balindattila\Desktop\torlendo4.xlsx", 1);//(@"\\fs\PaintCheck\TorloProgram\torlendo.xlsx", 1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddDataToList();
            successList.Items.Clear();
            failList.Items.Clear();
            MessageBox.Show($"{excel.GetRowNumber()}");

        }

        public void AddDataToList()
        {
            for (int i = 0; i < excel.GetRowNumber(); i++)
            {
                lista.Add(excel.ReadCell(i, 0));
            }

        }
        public void SHow()
        {
            foreach (var a in lista)
            {
                MessageBox.Show(a);
            }
        }
        public void DeleteFolder(string path)
        {
            var dir = new DirectoryInfo(path);
            var file = new FileInfo(path + "\\Thumbs.db");
            // var file = path + "\\" + "Thumbs.db";

            if (dir.Exists)
            {

                MessageBox.Show($"Létezik : {path}");
                if (file.Exists && IsFileLocked(file) == false)
                {
                    MessageBox.Show("Létezem és nem fogja semmi");

                    try
                    {
                        file.Delete();
                        MessageBox.Show("Thumbs.db törölve");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        failList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
                    }

                    foreach (FileInfo files in dir.EnumerateFiles())
                    {
                        files.Delete();
                    }
                    MessageBox.Show("Fájlok törölve");

                    try
                    {
                        dir.Delete(true);
                        // MessageBox.Show("");
                        successList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        failList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
                    }

                }
                else if (file.Exists && IsFileLocked(file) == true)
                {
                    failList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
                    //ide még move
                }
                else
                {
                     foreach (FileInfo files in dir.EnumerateFiles())
                      {
                          files.Delete();
                      }
                      MessageBox.Show("Fájlok törölve");

                      try
                      {
                          dir.Delete(true);
                          // MessageBox.Show("");
                          successList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.ToString());
                          failList.Items.Add(path);
                      }
                }

            }
            else
            {
                MessageBox.Show($"Nincs ilyen mappa + {path}");
               // successList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
            }
        }
        public void CreateString(string folderPath)
        {

            for (int i = 0; i < excel.GetRowNumber(); i++)
            {
               // string folderPath = @"C:\Users\balindattila\Desktop\templates";//@\\fs\PaintCheck\Klise Ellenorzes\templates";//"C:\\Users\\balindattila\\Desktop\\torlendo";
                folderPath = folderPath + "\\"+ lista[i];
                DeleteFolder(folderPath);
            }

        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            CreateString(folderPath);
            if (MessageBox.Show("Sikeres törlés", "Gratulálok!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                excel.WorkBookClose();
                excel.ExcelClose();
            }
        }
        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
        private void OpenFolder(string path)
        {
            if (Directory.Exists(path))
            {
                //ProcessStartInfo startInfo = new ProcessStartInfo
                //{
                //    Arguments = path,
                //    Name = "explorer.exe";
                //};
                Process.Start("explorer.exe", path);
            }
            else 
            {
                MessageBox.Show("Nincs ilyen mappa");
            }
        }

        private void successList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFolder(@"C:\Users\balindattila\Desktop\torlendo");
        }

        private void failList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFolder(folderPath+failList.SelectedItem.ToString());
        }
    }
}

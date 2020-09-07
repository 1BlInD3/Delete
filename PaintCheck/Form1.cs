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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;


namespace PaintCheck
{
    public partial class Form1 : Form
    {
        List<string> lista = new List<string>();
        Excel1 excel = new Excel1(@"C:\Users\balindattila\Desktop\torlendo3.xlsx",1);//(@"\\fs\PaintCheck\TorloProgram\torlendo.xlsx", 1);
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
                lista.Add(excel.ReadCell(i,0));
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
            var file = path + "\\" + "Thumbs.db";
            
            if (dir.Exists)
            {
               
                MessageBox.Show($"Létezik : {path}" );
                if (File.Exists(file))
                {
                    MessageBox.Show("Létezem");
                    try
                    {
                        File.Delete(file);
                        MessageBox.Show("Thumbs.db törölve");
                    }
                    catch (Exception e) 
                    {
                        MessageBox.Show(e.ToString());
                    }
                    

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
                    successList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length- path.LastIndexOf('\\')));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    failList.Items.Add(path);
                }                  
        
            }
            else
            {
              // MessageBox.Show($"Nincs ilyen mappa + {path}");
                successList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
            }
        }
        public void CreateString()
        {
            
            for (int i = 0; i < excel.GetRowNumber(); i++)
            {
                string folderPath = @"C:\Users\balindattila\Desktop\templates";//@\\fs\PaintCheck\Klise Ellenorzes\templates";//"C:\\Users\\balindattila\\Desktop\\torlendo";
                folderPath = folderPath+ "\\" +lista[i];
                DeleteFolder(folderPath);
            }
           
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            CreateString();
            if (MessageBox.Show("Sikeres törlés", "Gratulálok!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) 
            {
                excel.WorkBookClose();
                excel.ExcelClose();
            }
        }
    }
}

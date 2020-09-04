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
        Excel1 excel = new Excel1(@"\\fs\PaintCheck\TorloProgram\torlendo3.xlsx", 1);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddDataToList();
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
                //dir.Attributes = dir.Attributes & ~FileAttributes.Normal;
                MessageBox.Show($"If + {path}" );
                // if(dir.GetFiles(path)!= "Thumbs.db")
                if (File.Exists(file))
                {
                    MessageBox.Show("Létezem");
                }
                else {
                    //try
                    //{
                        dir.Delete(true);
                    MessageBox.Show("Töröltem");
                   // }
                  ///     MessageBox.Show(e.GetType().Name);
                   // }
                }
                   
        
            }
            else
            {
               // MessageBox.Show($"Else + {path}");
            }
        }
        public void CreateString()
        {
            
            for (int i = 0; i < excel.GetRowNumber(); i++)
            {
                string folderPath = @"\\fs\PaintCheck\Klise Ellenorzes\templates";//"C:\\Users\\balindattila\\Desktop\\torlendo";
                folderPath = folderPath+ "\\" +lista[i];
                DeleteFolder(folderPath);
            }
           
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            CreateString();
            if (MessageBox.Show("Sikeres törlés", "Gratulálok!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) 
            {
                this.Close();
            }
        }
    }
}

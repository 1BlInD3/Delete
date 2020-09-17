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
using System.Threading;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PaintCheck
{
    public partial class mainForm : Form
    {
        //"Icon made by Freepik from www.flaticon.com"
        string folderPath = @"\\fs\PaintCheck\Klise Ellenorzes\templates";
        string excelPath = @"\\fs\PaintCheck\TorloProgram\EFEN.xlsx";
        string successLogPath = @"\\fs\PaintCheck\TorloProgram\LOG\SuccessLog.txt";
        string noFolderLogPath = @"\\fs\PaintCheck\TorloProgram\LOG\NoFolderLog.txt";
        string failedLogPath = @"\\fs\PaintCheck\TorloProgram\LOG\FailedLog.txt";
        string excelListPath = @"\\fs\PaintCheck\TorloProgram\LOG\ExcelList.txt";
        // Excel1 excel = new Excel1(@"\\fs\PaintCheck\TorloProgram\EFEN.xlsx", 1);//(@"\\fs\PaintCheck\TorloProgram\torlendo.xlsx", 1);
        Excel1 excel;
        List<string> deletedFolder = new List<string>();
        List<string> noFolderList = new List<string>();
        List<string> failedList = new List<string>();
        List<string> lista = new List<string>();
        int rowNumber = 0;

        public mainForm()
        {
            excelCheck(excelPath);
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            InitializeComponent();
            AddDataToList();
            Thread.Sleep(500);
            t.Abort();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetForegroundWindow(this.Handle);
            successList.Items.Clear();
            failList.Items.Clear();
        }
        public void AddDataToList()
        {
            rowNumber = excel.GetRowNumber();
                for (int i = 0; i < rowNumber; i++)
                {
                    lista.Add(excel.ReadCell(i, 0));
                }
            allLabel.Text = (rowNumber.ToString()) + " db";
            excel.WorkBookClose();
            excel.ExcelClose();

        }
        public void DeleteFolder(string path)
        {
            var dir = new DirectoryInfo(path);
            var file = new FileInfo(path + "\\Thumbs.db");
          
            if (dir.Exists)
            {

                if (file.Exists && IsFileLocked(file) == false)
                {
                    try
                    {
                        file.Delete();
                       // MessageBox.Show("Thumbs.db törölve");
                    }catch (Exception exception)
                    {
                        //failList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
                        string folderName = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                        failList.Items.Add(folderName.Substring(1, folderName.Length - 1));
                        failedList.Add(folderName.Substring(1, folderName.Length - 1));
                        failLabel.Text = (failedList.Count.ToString() + " db");
                        MessageBox.Show(exception.Message);
                    }

                    foreach (FileInfo files in dir.EnumerateFiles())
                    {
                        files.Delete();
                    }

                    try
                    {
                        dir.Delete(true);
                        string folderName = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                        successList.Items.Add(folderName.Substring(1,folderName.Length-1));
                        deletedFolder.Add(folderName.Substring(1,folderName.Length-1));
                        successLabel.Text = (deletedFolder.Count.ToString()+" db");
                    }catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        string folderName = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                        failList.Items.Add(folderName.Substring(1, folderName.Length - 1));
                        failedList.Add(folderName.Substring(1, folderName.Length - 1));
                        failLabel.Text = (failedList.Count.ToString() + " db");
                    }

                }
                else if (file.Exists && IsFileLocked(file) == true)
                {

                    string folderName = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                    failList.Items.Add(folderName.Substring(1,folderName.Length-1));
                    failedList.Add(folderName.Substring(1, folderName.Length-1));
                    failLabel.Text = (failedList.Count.ToString() + " db");

                    //ide még move
                }
                else
                {
                     foreach (FileInfo files in dir.EnumerateFiles())
                      {
                          files.Delete();
                      }
                      try
                      {
                          dir.Delete(true);
                          // MessageBox.Show("");
                          successList.Items.Add(path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\')));
                          string folderName = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                          successList.Items.Add(folderName.Substring(1, folderName.Length-1));
                          deletedFolder.Add(folderName.Substring(1, folderName.Length-1));
                          successLabel.Text = (deletedFolder.Count.ToString() + " db");
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.ToString());
                        string folderName = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                        failList.Items.Add(folderName.Substring(1, folderName.Length - 1));
                        failedList.Add(folderName.Substring(1, folderName.Length - 1));
                        failLabel.Text = (failedList.Count.ToString() + " db");
                    }
                }

            }
            else
            {
                // MessageBox.Show($"Nincs ilyen mappa + {path}");
                string folderName = path.Substring(path.LastIndexOf('\\'), path.Length - path.LastIndexOf('\\'));
                successList.Items.Add("Nincs ilyen mappa :" + folderName.Substring(1,folderName.Length-1));
                noFolderList.Add(folderName.Substring(1, folderName.Length-1));
                noFolderLabel.Text = (noFolderList.Count.ToString()+ " db");
            }
        }
        public void CreateString()
        {

            for (int i = 0; i <rowNumber; i++)
            {
                // string folderPath = @"C:\Users\balindattila\Desktop\templates";//@\\fs\PaintCheck\Klise Ellenorzes\templates";//"C:\\Users\\balindattila\\Desktop\\torlendo";
                folderPath = @"\\fs\PaintCheck\Klise Ellenorzes\templates";
                folderPath = folderPath + "\\"+ lista[i];
                DeleteFolder(folderPath);
            }

        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            CreateString();
            deleteBtn.Enabled = false;
            Log(deletedFolder, successLogPath);
            Log(noFolderList, noFolderLogPath);
            Log(failedList, failedLogPath);
            Log(lista, excelListPath);
            try
            {
                SendEmail();
                MessageBox.Show("Sikeres törlés", "Gratulálok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Log elkészült, nem sikeres e-mail küldés");
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
               
                Process.Start("explorer.exe", path);
            }
            else 
            {
                MessageBox.Show("Nincs ilyen mappa");
            }
        }
        private void successList_SelectedIndexChanged(object sender, EventArgs e)
        {
           // OpenFolder(@"C:\Users\balindattila\Desktop\torlendo");
        }
        private void failList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFolder(folderPath+failList.SelectedItem.ToString());
        }
        private void Log(List<string> lista, string logFile)
        {
            if (File.Exists(logFile))
            {
                StreamWriter sw = File.AppendText(logFile);
                sw.WriteLine();
                sw.WriteLine("-------------");
                sw.WriteLine(DateTime.Now + "  "+ Environment.UserDomainName+"\\"+Environment.UserName);
                sw.WriteLine("-------------");
                sw.WriteLine();
                foreach (var a in lista)
                {
                    sw.WriteLine(a);
                }
                sw.Flush();
                sw.Close();
            }
            else 
            {
                using (File.Create(logFile)) 
                { 
                
                }
                StreamWriter sw = File.AppendText(logFile);
                sw.WriteLine();
                sw.WriteLine("-------------");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("-------------");
                sw.WriteLine();
                foreach (var a in lista)
                {
                    sw.WriteLine(a);
                }
                sw.Flush();
                sw.Close();
            }
        }
        private void SendEmail()
        {
            Outlook._Application _app = new Outlook.Application();
            Outlook._MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
            mail.To = "attila.balind@fusetech.hu";
            mail.Subject = "Klisé törlés logok";
            mail.Importance = Outlook.OlImportance.olImportanceHigh;
            mail.Attachments.Add(successLogPath, Outlook.OlAttachmentType.olByValue, 1, "SuccessLog");
            mail.Attachments.Add(noFolderLogPath, Outlook.OlAttachmentType.olByValue, 1, "NoFolderLog");
            mail.Attachments.Add(failedLogPath, Outlook.OlAttachmentType.olByValue, 1, "FailedLog");
            mail.Attachments.Add(excelListPath, Outlook.OlAttachmentType.olByValue, 1,"ExcelList");
            ((Outlook.MailItem)mail).Send();
        }
        public void StartForm()
        {
            Application.Run(new splashScreen());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public void excelCheck(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("Az alapértelmezett útvonalon nem található Excel fájl! \n Adj meg egy másikat","Figyelem",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    excel = new Excel1(filePath, 1);
                }
                else if (this.DialogResult == DialogResult.None) 
                {
                    Environment.Exit(-1);
                }
            }
            else 
            {
                excel = new Excel1(@"\\fs\PaintCheck\TorloProgram\EFEN.xlsx", 1);
            }
        }
      
    }
}

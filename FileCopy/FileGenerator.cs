using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileCopy
{
    public partial class FileGenerator : Form
    {
        public List<string> selectedFormats;
        public Dictionary<string, string> fileMap;
        public int numfilesPerFormat=10;
        public int numTotoalThreads=2;
        public string outputPath;
        public ErrorCode error;

        public const int MaxAllowedThreads = 30;

        public const int MaxAllowedFiles = 10000;

        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        public FileGenerator()
        {
            InitializeComponent();
            selectedFormats = new List<string>();
            fileMap = new Dictionary<string, string>();
            error = ErrorCode.None;
            string  current = Directory.GetCurrentDirectory();

            string sampleFolderPath = current + "\\Sample";

            if(Directory.Exists(sampleFolderPath))
            {
                string[] sampleFiles = Directory.GetFiles(sampleFolderPath);

                var items = fileFormatSelection.Items;
                items.Clear();
                foreach (string file in sampleFiles)
                {
                    fileMap.Add(Path.GetExtension(file), file);
                    items.Add(Path.GetExtension(file));
                }
            }
            else
            {
                error = ErrorCode.SampleFileNotPresent;
            }

        }



        public enum ErrorCode
        {
            None,
            SampleFileNotPresent,
            NoFileFormatSelected,
            InvalidNumberOfFilesValue,
            InvalidNumberofThreadsValue,
            InvalideOutputPath
        }

        private bool ValidateError()
        {
            string message = string.Empty;
            switch (error)
            {
                case ErrorCode.None:
                    return true;
                case ErrorCode.SampleFileNotPresent:
                    { message = "Sample File not present. Create Sample folder and restart."; break; }
                case ErrorCode.NoFileFormatSelected:
                    { message = "No file formats selected"; break; }
                case ErrorCode.InvalidNumberofThreadsValue:
                    { message = "Please provide number of threads between 1 and  "+MaxAllowedThreads; break; }
                case ErrorCode.InvalidNumberOfFilesValue:
                    { message = "Please provide number of Files between 1 and  " + MaxAllowedFiles; break; }
                case ErrorCode.InvalideOutputPath:
                    { message = "The Output Path is invalid"; break; }
                default:
                    { message = "Unknown Error happened"; break; }
            }

            MessageBox.Show(message);
            return false;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();            

            outputPath = outputloc.Text;
            if (!Directory.Exists(outputPath))
            {
                error = ErrorCode.InvalideOutputPath;
            }

            selectedFormats = GetSelectedFormats();

            if(selectedFormats.Count == 0)
            {
                error = ErrorCode.NoFileFormatSelected;
            }

            if (!ValidateError())
            {
                error = ErrorCode.None;
                return;
            }

            ThreadStart start = new ThreadStart(CopyFile);
            Thread[] threadArray = new Thread[numTotoalThreads];
           
            for (int i = 0; i < numTotoalThreads; i++)

            {
                threadArray[i] = new Thread(start);
                threadArray[i].Start();
            }

            waitHandle.WaitOne();
            watch.Stop();
            long seconds = watch.ElapsedMilliseconds / 1000;
            MessageBox.Show("File Generation Completed. Time taken is "+ seconds +" seconds");
            waitHandle.Reset();
        }

        private List<string> GetSelectedFormats()
        {
            List<string> selectedFormats = new List<string>();

            if (fileFormatSelection.CheckedItems.Count != 0)
            {             
                for (int x = 0; x < fileFormatSelection.CheckedItems.Count; x++)
                {
                    selectedFormats.Add(fileFormatSelection.CheckedItems[x].ToString());
                }
               
            }
            return selectedFormats;
        }

        public void CopyFile()
        {
            for(int i=0;i< numfilesPerFormat; i++)
            {
               foreach(var extension in selectedFormats)
                {
                    try
                    {
                        File.Copy(fileMap[extension], outputPath + "\\new" + System.Guid.NewGuid().ToString() + extension);
                    }
                    catch(IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }

                  
            }

            waitHandle.Set();
        }

        private void threadbox_TextChanged(object sender, EventArgs e)
        {
            int numthreads=-1;
            int.TryParse(threadbox.Text, out numthreads);
            if(numthreads == 0 || numthreads > MaxAllowedThreads)
            {
                error = ErrorCode.InvalidNumberofThreadsValue;
                return;
               
            }
            numTotoalThreads = numthreads;
            int totalfiles = GetSelectedFormats().Count * numfilesPerFormat * numthreads;
            totalFilesLabel.Text = "Total Files to Generate :    " + totalfiles;
        }

        private void numberfiles_TextChanged(object sender, EventArgs e)
        {
            int numfiles=-1;
            int.TryParse(numberfiles.Text, out numfiles);
            if(numfiles == 0 || numfiles > MaxAllowedFiles)
            {
                error = ErrorCode.InvalidNumberOfFilesValue;
                return;
               
            }
            numfilesPerFormat = numfiles;
            int totalfiles = GetSelectedFormats().Count * numfilesPerFormat * numTotoalThreads;
            totalFilesLabel.Text = "Total Files to Generate : " + totalfiles;

        }

        private void outputloc_TextChanged(object sender, EventArgs e)
        {
            int totalfiles = GetSelectedFormats().Count * numfilesPerFormat * numTotoalThreads;
            totalFilesLabel.Text = "Total Files to Generate :    " + totalfiles;
        }
    }
}

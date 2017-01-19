using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderMerge.Properties;

namespace FolderMerge
{
    public partial class FormFolderMerge : Form
    {
        public FormFolderMerge()
        {
            InitializeComponent();
        }

        private void buttonSelectSourceFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = Resources.Form1_buttonSelectSourceFolder_Description;
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBoxSourceFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonTargetFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = Resources.Form1_buttonTargetFolder_Description;
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBoxTargetFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            if (buttonMerge.Tag.ToString() == "Idle")
            {
                buttonMerge.Tag = "Running";
                buttonMerge.Text = Resources.Form1_buttonMerge_Click_CancelFolderMerge;
                if (backgroundWorkerCopyAll.IsBusy != true)
                {
                    backgroundWorkerCopyAll.RunWorkerAsync();
                }
            } else if (buttonMerge.Tag.ToString() == "Running")
            {
                if (backgroundWorkerCopyAll.IsBusy)
                {
                    buttonMerge.Tag = "Idle";
                    buttonMerge.Text = Resources.Form1_buttonMerge_Click_MergeFolders;
                    backgroundWorkerCopyAll.CancelAsync();
                }
            }

        }

        public void BackgroundCopyAll(DirectoryInfo source, DirectoryInfo target, BackgroundWorker worker)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            if (!Directory.Exists(source.FullName)) return;

            // Copy each file into it's new directory.
            foreach (FileInfo fileInfo in source.GetFiles("*.jpg"))
            {
                var targetFile = GetTargetFileName(fileInfo, target); 

                if (fileInfo.Name == "Thumbs.db") continue;
                if (worker.CancellationPending == true) return;

                var progressText = string.Format(@"Copying {0}\{1} to {2}", source.FullName, fileInfo.Name, target.FullName);
                worker.ReportProgress(0, progressText);

                fileInfo.CopyTo(targetFile, checkBoxOverwrite.Checked);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                BackgroundCopyAll(diSourceSubDir, target, worker);
            }
        }

        private void AddListViewMessage(string message)
        {
            listViewMessages.Items.Add(new ListViewItem
            {
                Text = message
            });
            listViewMessages.Items[listViewMessages.Items.Count - 1].EnsureVisible();
            listViewMessages.Refresh();
        }

        private string GetTargetFileName(FileInfo sourceFile, DirectoryInfo target)
        {
            int count = 1;

            string fileNameOnly = Path.GetFileNameWithoutExtension(sourceFile.FullName);
            string extension = Path.GetExtension(sourceFile.FullName);
            string path = target.FullName;
            string newFullPath = Path.Combine(path, sourceFile.Name);

            while (File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFullPath = Path.Combine(path, tempFileName + extension);
            }

            return newFullPath;
        }

        private void backgroundWorkerCopyAll_DoWork(object sender, DoWorkEventArgs e)
        {
            var source = new DirectoryInfo(textBoxSourceFolder.Text);
            var target = new DirectoryInfo(textBoxTargetFolder.Text);

            var worker = sender as BackgroundWorker;

            if (checkBoxDeleteAll.Checked)
            {
                var files = Directory.GetFiles(target.FullName);
                var cleanFiles = files.Where(x => x != "Thumbs.db").ToList();
                Parallel.ForEach(cleanFiles,  File.Delete);
            }

            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            BackgroundCopyAll(source, target, worker);

            if (backgroundWorkerCopyAll.CancellationPending == true)
            {
                e.Cancel = true;
            }
        }

        private void backgroundWorkerCopyAll_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AddListViewMessage(e.UserState.ToString());
        }

        private void backgroundWorkerCopyAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddListViewMessage("Complete...");
            buttonMerge.Tag = "Idle";
            buttonMerge.Text = Resources.Form1_buttonMerge_Click_MergeFolders;
        }
    }
}

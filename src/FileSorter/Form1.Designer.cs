namespace FileSorter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonMerge = new System.Windows.Forms.Button();
            this.textBoxTargetFolder = new System.Windows.Forms.TextBox();
            this.buttonTargetFolder = new System.Windows.Forms.Button();
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectSourceFolder = new System.Windows.Forms.Button();
            this.backgroundWorkerSort = new System.ComponentModel.BackgroundWorker();
            this.textBoxSearchPattern = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewMessages
            // 
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewMessages.Location = new System.Drawing.Point(12, 152);
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.Size = new System.Drawing.Size(704, 260);
            this.listViewMessages.TabIndex = 18;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Messages";
            this.columnHeader2.Width = 700;
            // 
            // buttonMerge
            // 
            this.buttonMerge.Location = new System.Drawing.Point(570, 418);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(146, 44);
            this.buttonMerge.TabIndex = 16;
            this.buttonMerge.Tag = "Idle";
            this.buttonMerge.Text = "Begin Sort";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
            // 
            // textBoxTargetFolder
            // 
            this.textBoxTargetFolder.Location = new System.Drawing.Point(12, 91);
            this.textBoxTargetFolder.Name = "textBoxTargetFolder";
            this.textBoxTargetFolder.Size = new System.Drawing.Size(543, 22);
            this.textBoxTargetFolder.TabIndex = 15;
            this.textBoxTargetFolder.Text = "C:\\temp\\FolderSortTesting";
            // 
            // buttonTargetFolder
            // 
            this.buttonTargetFolder.Location = new System.Drawing.Point(561, 87);
            this.buttonTargetFolder.Name = "buttonTargetFolder";
            this.buttonTargetFolder.Size = new System.Drawing.Size(155, 26);
            this.buttonTargetFolder.TabIndex = 14;
            this.buttonTargetFolder.Text = "Open Target Folder";
            this.buttonTargetFolder.UseVisualStyleBackColor = true;
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.Location = new System.Drawing.Point(12, 62);
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.Size = new System.Drawing.Size(543, 22);
            this.textBoxSourceFolder.TabIndex = 13;
            this.textBoxSourceFolder.Text = "C:\\temp\\FolderMergeTesting";
            // 
            // buttonSelectSourceFolder
            // 
            this.buttonSelectSourceFolder.Location = new System.Drawing.Point(561, 58);
            this.buttonSelectSourceFolder.Name = "buttonSelectSourceFolder";
            this.buttonSelectSourceFolder.Size = new System.Drawing.Size(155, 26);
            this.buttonSelectSourceFolder.TabIndex = 12;
            this.buttonSelectSourceFolder.Text = "Open Source Folder";
            this.buttonSelectSourceFolder.UseVisualStyleBackColor = true;
            // 
            // backgroundWorkerSort
            // 
            this.backgroundWorkerSort.WorkerReportsProgress = true;
            this.backgroundWorkerSort.WorkerSupportsCancellation = true;
            this.backgroundWorkerSort.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSort_DoWork);
            this.backgroundWorkerSort.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerSort_ProgressChanged);
            this.backgroundWorkerSort.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSort_RunWorkerCompleted);
            // 
            // textBoxSearchPattern
            // 
            this.textBoxSearchPattern.Location = new System.Drawing.Point(12, 124);
            this.textBoxSearchPattern.Name = "textBoxSearchPattern";
            this.textBoxSearchPattern.Size = new System.Drawing.Size(543, 22);
            this.textBoxSearchPattern.TabIndex = 19;
            this.textBoxSearchPattern.Text = "*.jpg";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 473);
            this.Controls.Add(this.textBoxSearchPattern);
            this.Controls.Add(this.listViewMessages);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.textBoxTargetFolder);
            this.Controls.Add(this.buttonTargetFolder);
            this.Controls.Add(this.textBoxSourceFolder);
            this.Controls.Add(this.buttonSelectSourceFolder);
            this.Name = "Form1";
            this.Text = "File Sorter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonMerge;
        private System.Windows.Forms.TextBox textBoxTargetFolder;
        private System.Windows.Forms.Button buttonTargetFolder;
        private System.Windows.Forms.TextBox textBoxSourceFolder;
        private System.Windows.Forms.Button buttonSelectSourceFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSort;
        private System.Windows.Forms.TextBox textBoxSearchPattern;
    }
}


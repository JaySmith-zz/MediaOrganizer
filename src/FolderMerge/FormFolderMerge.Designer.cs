namespace FolderMerge
{
    partial class FormFolderMerge
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
            this.buttonSelectSourceFolder = new System.Windows.Forms.Button();
            this.textBoxSourceFolder = new System.Windows.Forms.TextBox();
            this.textBoxTargetFolder = new System.Windows.Forms.TextBox();
            this.buttonTargetFolder = new System.Windows.Forms.Button();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorkerCopyAll = new System.ComponentModel.BackgroundWorker();
            this.checkBoxDeleteAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonSelectSourceFolder
            // 
            this.buttonSelectSourceFolder.Location = new System.Drawing.Point(570, 56);
            this.buttonSelectSourceFolder.Name = "buttonSelectSourceFolder";
            this.buttonSelectSourceFolder.Size = new System.Drawing.Size(155, 26);
            this.buttonSelectSourceFolder.TabIndex = 0;
            this.buttonSelectSourceFolder.Text = "Open Source Folder";
            this.buttonSelectSourceFolder.UseVisualStyleBackColor = true;
            this.buttonSelectSourceFolder.Click += new System.EventHandler(this.buttonSelectSourceFolder_Click);
            // 
            // textBoxSourceFolder
            // 
            this.textBoxSourceFolder.Location = new System.Drawing.Point(21, 60);
            this.textBoxSourceFolder.Name = "textBoxSourceFolder";
            this.textBoxSourceFolder.Size = new System.Drawing.Size(543, 22);
            this.textBoxSourceFolder.TabIndex = 1;
            this.textBoxSourceFolder.Text = "E:\\ImageSource";
            // 
            // textBoxTargetFolder
            // 
            this.textBoxTargetFolder.Location = new System.Drawing.Point(21, 89);
            this.textBoxTargetFolder.Name = "textBoxTargetFolder";
            this.textBoxTargetFolder.Size = new System.Drawing.Size(543, 22);
            this.textBoxTargetFolder.TabIndex = 4;
            this.textBoxTargetFolder.Text = "C:\\temp\\FolderMergeTesting";
            // 
            // buttonTargetFolder
            // 
            this.buttonTargetFolder.Location = new System.Drawing.Point(570, 85);
            this.buttonTargetFolder.Name = "buttonTargetFolder";
            this.buttonTargetFolder.Size = new System.Drawing.Size(155, 26);
            this.buttonTargetFolder.TabIndex = 3;
            this.buttonTargetFolder.Text = "Open Target Folder";
            this.buttonTargetFolder.UseVisualStyleBackColor = true;
            this.buttonTargetFolder.Click += new System.EventHandler(this.buttonTargetFolder_Click);
            // 
            // buttonMerge
            // 
            this.buttonMerge.Location = new System.Drawing.Point(579, 416);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(146, 44);
            this.buttonMerge.TabIndex = 5;
            this.buttonMerge.Tag = "Idle";
            this.buttonMerge.Text = "Merge Folders";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
            // 
            // checkBoxOverwrite
            // 
            this.checkBoxOverwrite.AutoSize = true;
            this.checkBoxOverwrite.Location = new System.Drawing.Point(21, 416);
            this.checkBoxOverwrite.Name = "checkBoxOverwrite";
            this.checkBoxOverwrite.Size = new System.Drawing.Size(133, 21);
            this.checkBoxOverwrite.TabIndex = 8;
            this.checkBoxOverwrite.Text = "Overwrite if exist";
            this.checkBoxOverwrite.UseVisualStyleBackColor = true;
            // 
            // listViewMessages
            // 
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewMessages.Location = new System.Drawing.Point(21, 120);
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.Size = new System.Drawing.Size(704, 290);
            this.listViewMessages.TabIndex = 10;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Messages";
            this.columnHeader2.Width = 700;
            // 
            // backgroundWorkerCopyAll
            // 
            this.backgroundWorkerCopyAll.WorkerReportsProgress = true;
            this.backgroundWorkerCopyAll.WorkerSupportsCancellation = true;
            this.backgroundWorkerCopyAll.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCopyAll_DoWork);
            this.backgroundWorkerCopyAll.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCopyAll_ProgressChanged);
            this.backgroundWorkerCopyAll.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCopyAll_RunWorkerCompleted);
            // 
            // checkBoxDeleteAll
            // 
            this.checkBoxDeleteAll.AutoSize = true;
            this.checkBoxDeleteAll.Location = new System.Drawing.Point(265, 416);
            this.checkBoxDeleteAll.Name = "checkBoxDeleteAll";
            this.checkBoxDeleteAll.Size = new System.Drawing.Size(258, 21);
            this.checkBoxDeleteAll.TabIndex = 11;
            this.checkBoxDeleteAll.Text = "Empty target directory before merge";
            this.checkBoxDeleteAll.UseVisualStyleBackColor = true;
            // 
            // FormFolderMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 472);
            this.Controls.Add(this.checkBoxDeleteAll);
            this.Controls.Add(this.listViewMessages);
            this.Controls.Add(this.checkBoxOverwrite);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.textBoxTargetFolder);
            this.Controls.Add(this.buttonTargetFolder);
            this.Controls.Add(this.textBoxSourceFolder);
            this.Controls.Add(this.buttonSelectSourceFolder);
            this.Name = "FormFolderMerge";
            this.Text = "Folder Merge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonSelectSourceFolder;
        private System.Windows.Forms.TextBox textBoxSourceFolder;
        private System.Windows.Forms.TextBox textBoxTargetFolder;
        private System.Windows.Forms.Button buttonTargetFolder;
        private System.Windows.Forms.Button buttonMerge;
        private System.Windows.Forms.CheckBox checkBoxOverwrite;
        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCopyAll;
        private System.Windows.Forms.CheckBox checkBoxDeleteAll;
    }
}


namespace TunicSaveManager {
    partial class SaveManager {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveManager));
            this.lblSaveFolder = new System.Windows.Forms.Label();
            this.linkChangeSavePath = new System.Windows.Forms.LinkLabel();
            this.lblSaveFolderPath = new System.Windows.Forms.Label();
            this.lblSnapshotFolder = new System.Windows.Forms.Label();
            this.lblSnapshotFolderPath = new System.Windows.Forms.Label();
            this.linkChangeSnapshotPath = new System.Windows.Forms.LinkLabel();
            this.btnCreateSnapshot = new System.Windows.Forms.Button();
            this.txtNewSnapshot = new System.Windows.Forms.TextBox();
            this.gboxNewSnapshot = new System.Windows.Forms.GroupBox();
            this.lblNewSnapshot = new System.Windows.Forms.Label();
            this.lblLoadSnapshot = new System.Windows.Forms.Label();
            this.btnLoadSnapshot = new System.Windows.Forms.Button();
            this.gboxLoadSnapshot = new System.Windows.Forms.GroupBox();
            this.btnDeleteSnapshot = new System.Windows.Forms.Button();
            this.cboxLoadSnapshot = new System.Windows.Forms.ComboBox();
            this.linkOpenSaveFolder = new System.Windows.Forms.LinkLabel();
            this.linkOpenSnapshotFolder = new System.Windows.Forms.LinkLabel();
            this.gboxNewSnapshot.SuspendLayout();
            this.gboxLoadSnapshot.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSaveFolder
            // 
            this.lblSaveFolder.AutoSize = true;
            this.lblSaveFolder.Location = new System.Drawing.Point(12, 9);
            this.lblSaveFolder.Name = "lblSaveFolder";
            this.lblSaveFolder.Size = new System.Drawing.Size(67, 15);
            this.lblSaveFolder.TabIndex = 1;
            this.lblSaveFolder.Text = "Save Folder";
            // 
            // linkChangeSavePath
            // 
            this.linkChangeSavePath.AutoSize = true;
            this.linkChangeSavePath.Location = new System.Drawing.Point(121, 9);
            this.linkChangeSavePath.Name = "linkChangeSavePath";
            this.linkChangeSavePath.Size = new System.Drawing.Size(56, 15);
            this.linkChangeSavePath.TabIndex = 2;
            this.linkChangeSavePath.TabStop = true;
            this.linkChangeSavePath.Text = "(Change)";
            this.linkChangeSavePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkChangePath_LinkClicked);
            // 
            // lblSaveFolderPath
            // 
            this.lblSaveFolderPath.AutoSize = true;
            this.lblSaveFolderPath.Location = new System.Drawing.Point(12, 33);
            this.lblSaveFolderPath.Name = "lblSaveFolderPath";
            this.lblSaveFolderPath.Size = new System.Drawing.Size(113, 15);
            this.lblSaveFolderPath.TabIndex = 3;
            this.lblSaveFolderPath.Text = "<No Path Selected>";
            // 
            // lblSnapshotFolder
            // 
            this.lblSnapshotFolder.AutoSize = true;
            this.lblSnapshotFolder.Location = new System.Drawing.Point(12, 70);
            this.lblSnapshotFolder.Name = "lblSnapshotFolder";
            this.lblSnapshotFolder.Size = new System.Drawing.Size(92, 15);
            this.lblSnapshotFolder.TabIndex = 1;
            this.lblSnapshotFolder.Text = "Snapshot Folder";
            // 
            // lblSnapshotFolderPath
            // 
            this.lblSnapshotFolderPath.AutoSize = true;
            this.lblSnapshotFolderPath.Location = new System.Drawing.Point(12, 94);
            this.lblSnapshotFolderPath.Name = "lblSnapshotFolderPath";
            this.lblSnapshotFolderPath.Size = new System.Drawing.Size(113, 15);
            this.lblSnapshotFolderPath.TabIndex = 3;
            this.lblSnapshotFolderPath.Text = "<No Path Selected>";
            // 
            // linkChangeSnapshotPath
            // 
            this.linkChangeSnapshotPath.AutoSize = true;
            this.linkChangeSnapshotPath.Location = new System.Drawing.Point(121, 70);
            this.linkChangeSnapshotPath.Name = "linkChangeSnapshotPath";
            this.linkChangeSnapshotPath.Size = new System.Drawing.Size(56, 15);
            this.linkChangeSnapshotPath.TabIndex = 2;
            this.linkChangeSnapshotPath.TabStop = true;
            this.linkChangeSnapshotPath.Text = "(Change)";
            this.linkChangeSnapshotPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkChangePath_LinkClicked);
            // 
            // btnCreateSnapshot
            // 
            this.btnCreateSnapshot.Location = new System.Drawing.Point(100, 66);
            this.btnCreateSnapshot.Name = "btnCreateSnapshot";
            this.btnCreateSnapshot.Size = new System.Drawing.Size(97, 23);
            this.btnCreateSnapshot.TabIndex = 4;
            this.btnCreateSnapshot.Text = "Create";
            this.btnCreateSnapshot.UseVisualStyleBackColor = true;
            this.btnCreateSnapshot.Click += new System.EventHandler(this.BtnCreateSnapshot_Click);
            // 
            // txtNewSnapshot
            // 
            this.txtNewSnapshot.Location = new System.Drawing.Point(6, 37);
            this.txtNewSnapshot.Name = "txtNewSnapshot";
            this.txtNewSnapshot.Size = new System.Drawing.Size(287, 23);
            this.txtNewSnapshot.TabIndex = 6;
            // 
            // gboxNewSnapshot
            // 
            this.gboxNewSnapshot.Controls.Add(this.lblNewSnapshot);
            this.gboxNewSnapshot.Controls.Add(this.txtNewSnapshot);
            this.gboxNewSnapshot.Controls.Add(this.btnCreateSnapshot);
            this.gboxNewSnapshot.Location = new System.Drawing.Point(12, 131);
            this.gboxNewSnapshot.Name = "gboxNewSnapshot";
            this.gboxNewSnapshot.Size = new System.Drawing.Size(299, 100);
            this.gboxNewSnapshot.TabIndex = 7;
            this.gboxNewSnapshot.TabStop = false;
            this.gboxNewSnapshot.Text = "New Snapshot";
            // 
            // lblNewSnapshot
            // 
            this.lblNewSnapshot.AutoSize = true;
            this.lblNewSnapshot.Location = new System.Drawing.Point(100, 19);
            this.lblNewSnapshot.Name = "lblNewSnapshot";
            this.lblNewSnapshot.Size = new System.Drawing.Size(91, 15);
            this.lblNewSnapshot.TabIndex = 7;
            this.lblNewSnapshot.Text = "Snapshot Name";
            // 
            // lblLoadSnapshot
            // 
            this.lblLoadSnapshot.AutoSize = true;
            this.lblLoadSnapshot.Location = new System.Drawing.Point(89, 19);
            this.lblLoadSnapshot.Name = "lblLoadSnapshot";
            this.lblLoadSnapshot.Size = new System.Drawing.Size(108, 15);
            this.lblLoadSnapshot.TabIndex = 7;
            this.lblLoadSnapshot.Text = "Choose a Snapshot";
            // 
            // btnLoadSnapshot
            // 
            this.btnLoadSnapshot.Location = new System.Drawing.Point(39, 66);
            this.btnLoadSnapshot.Name = "btnLoadSnapshot";
            this.btnLoadSnapshot.Size = new System.Drawing.Size(97, 23);
            this.btnLoadSnapshot.TabIndex = 4;
            this.btnLoadSnapshot.Text = "Load";
            this.btnLoadSnapshot.UseVisualStyleBackColor = true;
            this.btnLoadSnapshot.Click += new System.EventHandler(this.BtnLoadSnapshot_Click);
            // 
            // gboxLoadSnapshot
            // 
            this.gboxLoadSnapshot.Controls.Add(this.btnDeleteSnapshot);
            this.gboxLoadSnapshot.Controls.Add(this.cboxLoadSnapshot);
            this.gboxLoadSnapshot.Controls.Add(this.lblLoadSnapshot);
            this.gboxLoadSnapshot.Controls.Add(this.btnLoadSnapshot);
            this.gboxLoadSnapshot.Location = new System.Drawing.Point(12, 250);
            this.gboxLoadSnapshot.Name = "gboxLoadSnapshot";
            this.gboxLoadSnapshot.Size = new System.Drawing.Size(299, 100);
            this.gboxLoadSnapshot.TabIndex = 7;
            this.gboxLoadSnapshot.TabStop = false;
            this.gboxLoadSnapshot.Text = "Manage Snapshots";
            // 
            // btnDeleteSnapshot
            // 
            this.btnDeleteSnapshot.Location = new System.Drawing.Point(154, 66);
            this.btnDeleteSnapshot.Name = "btnDeleteSnapshot";
            this.btnDeleteSnapshot.Size = new System.Drawing.Size(97, 23);
            this.btnDeleteSnapshot.TabIndex = 4;
            this.btnDeleteSnapshot.Text = "Delete";
            this.btnDeleteSnapshot.UseVisualStyleBackColor = true;
            this.btnDeleteSnapshot.Click += new System.EventHandler(this.BtnDeleteSnapshot_Click);
            // 
            // cboxLoadSnapshot
            // 
            this.cboxLoadSnapshot.FormattingEnabled = true;
            this.cboxLoadSnapshot.Location = new System.Drawing.Point(6, 37);
            this.cboxLoadSnapshot.Name = "cboxLoadSnapshot";
            this.cboxLoadSnapshot.Size = new System.Drawing.Size(287, 23);
            this.cboxLoadSnapshot.TabIndex = 8;
            this.cboxLoadSnapshot.Click += new System.EventHandler(this.CboxLoadSnapshot_Click);
            // 
            // linkOpenSaveFolder
            // 
            this.linkOpenSaveFolder.AutoSize = true;
            this.linkOpenSaveFolder.Location = new System.Drawing.Point(183, 9);
            this.linkOpenSaveFolder.Name = "linkOpenSaveFolder";
            this.linkOpenSaveFolder.Size = new System.Drawing.Size(44, 15);
            this.linkOpenSaveFolder.TabIndex = 2;
            this.linkOpenSaveFolder.TabStop = true;
            this.linkOpenSaveFolder.Text = "(Open)";
            this.linkOpenSaveFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkOpenFolder_LinkClicked);
            // 
            // linkOpenSnapshotFolder
            // 
            this.linkOpenSnapshotFolder.AutoSize = true;
            this.linkOpenSnapshotFolder.Location = new System.Drawing.Point(183, 70);
            this.linkOpenSnapshotFolder.Name = "linkOpenSnapshotFolder";
            this.linkOpenSnapshotFolder.Size = new System.Drawing.Size(44, 15);
            this.linkOpenSnapshotFolder.TabIndex = 2;
            this.linkOpenSnapshotFolder.TabStop = true;
            this.linkOpenSnapshotFolder.Text = "(Open)";
            this.linkOpenSnapshotFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkOpenFolder_LinkClicked);
            // 
            // SaveManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 359);
            this.Controls.Add(this.linkOpenSnapshotFolder);
            this.Controls.Add(this.linkOpenSaveFolder);
            this.Controls.Add(this.gboxLoadSnapshot);
            this.Controls.Add(this.gboxNewSnapshot);
            this.Controls.Add(this.linkChangeSnapshotPath);
            this.Controls.Add(this.lblSnapshotFolderPath);
            this.Controls.Add(this.lblSnapshotFolder);
            this.Controls.Add(this.lblSaveFolderPath);
            this.Controls.Add(this.linkChangeSavePath);
            this.Controls.Add(this.lblSaveFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveManager";
            this.Text = "TUNIC Save Manager";
            this.gboxNewSnapshot.ResumeLayout(false);
            this.gboxNewSnapshot.PerformLayout();
            this.gboxLoadSnapshot.ResumeLayout(false);
            this.gboxLoadSnapshot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSaveFolder;
        private System.Windows.Forms.LinkLabel linkChangeSavePath;
        private System.Windows.Forms.Label lblSaveFolderPath;
        private System.Windows.Forms.Label lblSnapshotFolder;
        private System.Windows.Forms.Label lblSnapshotFolderPath;
        private System.Windows.Forms.LinkLabel linkChangeSnapshotPath;
        private System.Windows.Forms.Button btnCreateSnapshot;
        private System.Windows.Forms.TextBox txtNewSnapshot;
        private System.Windows.Forms.GroupBox gboxNewSnapshot;
        private System.Windows.Forms.Label lblNewSnapshot;
        private System.Windows.Forms.Label lblLoadSnapshot;
        private System.Windows.Forms.Button btnLoadSnapshot;
        private System.Windows.Forms.GroupBox gboxLoadSnapshot;
        private System.Windows.Forms.ComboBox cboxLoadSnapshot;
        private System.Windows.Forms.LinkLabel linkOpenSaveFolder;
        private System.Windows.Forms.LinkLabel linkOpenSnapshotFolder;
        private System.Windows.Forms.Button btnDeleteSnapshot;
    }
}


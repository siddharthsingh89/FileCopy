namespace FileCopy
{
    partial class FileGenerator
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
            this.Generate = new System.Windows.Forms.Button();
            this.fileFormatSelection = new System.Windows.Forms.CheckedListBox();
            this.numfiles = new System.Windows.Forms.Label();
            this.numberfiles = new System.Windows.Forms.TextBox();
            this.threads = new System.Windows.Forms.Label();
            this.threadbox = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.Label();
            this.outputloc = new System.Windows.Forms.TextBox();
            this.info = new System.Windows.Forms.Label();
            this.totalFilesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(58, 398);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(692, 42);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileFormatSelection
            // 
            this.fileFormatSelection.FormattingEnabled = true;
            this.fileFormatSelection.Location = new System.Drawing.Point(46, 47);
            this.fileFormatSelection.Name = "fileFormatSelection";
            this.fileFormatSelection.Size = new System.Drawing.Size(238, 151);
            this.fileFormatSelection.TabIndex = 1;
            // 
            // numfiles
            // 
            this.numfiles.AutoSize = true;
            this.numfiles.Location = new System.Drawing.Point(42, 216);
            this.numfiles.Name = "numfiles";
            this.numfiles.Size = new System.Drawing.Size(248, 20);
            this.numfiles.TabIndex = 2;
            this.numfiles.Text = "Number of Files  for each format : ";
            // 
            // numberfiles
            // 
            this.numberfiles.Location = new System.Drawing.Point(311, 216);
            this.numberfiles.Name = "numberfiles";
            this.numberfiles.Size = new System.Drawing.Size(100, 26);
            this.numberfiles.TabIndex = 3;
            this.numberfiles.Text = "10";
            this.numberfiles.TextChanged += new System.EventHandler(this.numberfiles_TextChanged);
            // 
            // threads
            // 
            this.threads.AutoSize = true;
            this.threads.Location = new System.Drawing.Point(119, 256);
            this.threads.Name = "threads";
            this.threads.Size = new System.Drawing.Size(145, 20);
            this.threads.TabIndex = 4;
            this.threads.Text = "Number of Threads";
            // 
            // threadbox
            // 
            this.threadbox.Location = new System.Drawing.Point(311, 256);
            this.threadbox.Name = "threadbox";
            this.threadbox.Size = new System.Drawing.Size(100, 26);
            this.threadbox.TabIndex = 5;
            this.threadbox.Text = "2";
            this.threadbox.TextChanged += new System.EventHandler(this.threadbox_TextChanged);
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(139, 299);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(125, 20);
            this.output.TabIndex = 6;
            this.output.Text = "Output Directory";
            // 
            // outputloc
            // 
            this.outputloc.Location = new System.Drawing.Point(311, 299);
            this.outputloc.Name = "outputloc";
            this.outputloc.Size = new System.Drawing.Size(418, 26);
            this.outputloc.TabIndex = 7;
            this.outputloc.TextChanged += new System.EventHandler(this.outputloc_TextChanged);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(42, 9);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(513, 20);
            this.info.TabIndex = 8;
            this.info.Text = "Below files are present in the \'Sample\'  folder in the Application directory";
            // 
            // totalFilesLabel
            // 
            this.totalFilesLabel.AutoSize = true;
            this.totalFilesLabel.Location = new System.Drawing.Point(101, 343);
            this.totalFilesLabel.Name = "totalFilesLabel";
            this.totalFilesLabel.Size = new System.Drawing.Size(183, 20);
            this.totalFilesLabel.TabIndex = 9;
            this.totalFilesLabel.Text = "Total Files to Generate : ";
            // 
            // FileGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 466);
            this.Controls.Add(this.totalFilesLabel);
            this.Controls.Add(this.info);
            this.Controls.Add(this.outputloc);
            this.Controls.Add(this.output);
            this.Controls.Add(this.threadbox);
            this.Controls.Add(this.threads);
            this.Controls.Add(this.numberfiles);
            this.Controls.Add(this.numfiles);
            this.Controls.Add(this.fileFormatSelection);
            this.Controls.Add(this.Generate);
            this.Name = "FileGenerator";
            this.Text = "File Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.CheckedListBox fileFormatSelection;
        private System.Windows.Forms.Label numfiles;
        private System.Windows.Forms.TextBox numberfiles;
        private System.Windows.Forms.Label threads;
        private System.Windows.Forms.TextBox threadbox;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.TextBox outputloc;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label totalFilesLabel;
    }
}


namespace ChanRip
{
    partial class BrowserForm
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
            this.threadListbox = new System.Windows.Forms.ListBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.postListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFullItemsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniqueFileNameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ripButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ripWorker = new System.ComponentModel.BackgroundWorker();
            this.updateWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // threadListbox
            // 
            this.threadListbox.FormattingEnabled = true;
            this.threadListbox.Location = new System.Drawing.Point(12, 25);
            this.threadListbox.Name = "threadListbox";
            this.threadListbox.Size = new System.Drawing.Size(341, 277);
            this.threadListbox.TabIndex = 0;
            this.threadListbox.SelectedValueChanged += new System.EventHandler(this.threadListbox_SelectedValueChanged);
            // 
            // imageBox
            // 
            this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox.Location = new System.Drawing.Point(359, 12);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(509, 629);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 1;
            this.imageBox.TabStop = false;
            this.imageBox.Click += new System.EventHandler(this.fullButton_Click);
            // 
            // postListBox
            // 
            this.postListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.postListBox.FormattingEnabled = true;
            this.postListBox.Location = new System.Drawing.Point(12, 308);
            this.postListBox.Name = "postListBox";
            this.postListBox.Size = new System.Drawing.Size(341, 251);
            this.postListBox.TabIndex = 2;
            this.postListBox.SelectedValueChanged += new System.EventHandler(this.imagesListbox_SelectedValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFullItemsMenuItem,
            this.uniqueFileNameMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // loadFullItemsMenuItem
            // 
            this.loadFullItemsMenuItem.CheckOnClick = true;
            this.loadFullItemsMenuItem.Name = "loadFullItemsMenuItem";
            this.loadFullItemsMenuItem.Size = new System.Drawing.Size(279, 22);
            this.loadFullItemsMenuItem.Text = "Load full images instead of thumbnails";
            // 
            // uniqueFileNameMenuItem
            // 
            this.uniqueFileNameMenuItem.CheckOnClick = true;
            this.uniqueFileNameMenuItem.Enabled = false;
            this.uniqueFileNameMenuItem.Name = "uniqueFileNameMenuItem";
            this.uniqueFileNameMenuItem.Size = new System.Drawing.Size(279, 22);
            this.uniqueFileNameMenuItem.Text = "Show uploaded filenames instead";
            // 
            // ripButton
            // 
            this.ripButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ripButton.Location = new System.Drawing.Point(12, 604);
            this.ripButton.Name = "ripButton";
            this.ripButton.Size = new System.Drawing.Size(260, 37);
            this.ripButton.TabIndex = 4;
            this.ripButton.Text = "RIP THAT SHIT NIGGA";
            this.ripButton.UseVisualStyleBackColor = true;
            this.ripButton.Click += new System.EventHandler(this.ripButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateButton.Location = new System.Drawing.Point(279, 605);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(74, 36);
            this.updateButton.TabIndex = 5;
            this.updateButton.Text = "Update Threads";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(13, 566);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(340, 33);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 6;
            // 
            // ripWorker
            // 
            this.ripWorker.WorkerReportsProgress = true;
            this.ripWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ripWorker_DoWork);
            this.ripWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.ripWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ripWorker_RunWorkerCompleted);
            // 
            // updateWorker
            // 
            this.updateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateWorker_DoWork);
            this.updateWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.updateWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateWorker_RunWorkerCompleted);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 653);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.ripButton);
            this.Controls.Add(this.postListBox);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.threadListbox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "BrowserForm";
            this.ShowIcon = false;
            this.Text = "4Chan Browser";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox threadListbox;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.ListBox postListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFullItemsMenuItem;
        private System.Windows.Forms.Button ripButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem uniqueFileNameMenuItem;
        private System.ComponentModel.BackgroundWorker ripWorker;
        private System.ComponentModel.BackgroundWorker updateWorker;
    }
}


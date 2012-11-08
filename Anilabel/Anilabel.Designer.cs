namespace Anilabel
{
    partial class Anilabel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anilabel));
            this.browser = new System.Windows.Forms.Button();
            this.browseDialog = new System.Windows.Forms.OpenFileDialog();
            this.browserResult = new System.Windows.Forms.DataGridView();
            this.enableOutput = new System.Windows.Forms.CheckBox();
            this.outputLocation = new System.Windows.Forms.Button();
            this.folderBrowseDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.progressBarGage = new System.Windows.Forms.ToolStripStatusLabel();
            this.optRelabelOptions = new System.Windows.Forms.GroupBox();
            this.optRawCheck = new System.Windows.Forms.CheckBox();
            this.optResolutionCheck = new System.Windows.Forms.CheckBox();
            this.optSubberCheck = new System.Windows.Forms.CheckBox();
            this.optFilePartsLbl = new System.Windows.Forms.Label();
            this.optFormatSelector = new System.Windows.Forms.ComboBox();
            this.optFormatLbl = new System.Windows.Forms.Label();
            this.relabelButton = new System.Windows.Forms.Button();
            this.browserResultCellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCellToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.browserResult)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.optRelabelOptions.SuspendLayout();
            this.browserResultCellMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(12, 8);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(123, 23);
            this.browser.TabIndex = 0;
            this.browser.Text = "Browse for Anime...";
            this.browser.UseVisualStyleBackColor = true;
            this.browser.Click += new System.EventHandler(this.browserOnClick);
            // 
            // browseDialog
            // 
            this.browseDialog.FileName = "browseDialog";
            this.browseDialog.Filter = "\"Video Files|*.avi;*.flv;*.mkv;*.mp4;*mpg\"";
            this.browseDialog.Multiselect = true;
            this.browseDialog.Title = "Browse all your anime that you want to rename...";
            // 
            // browserResult
            // 
            this.browserResult.AllowDrop = true;
            this.browserResult.AllowUserToResizeRows = false;
            this.browserResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserResult.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.browserResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.browserResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.browserResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.browserResult.Location = new System.Drawing.Point(12, 66);
            this.browserResult.Name = "browserResult";
            this.browserResult.RowHeadersVisible = false;
            this.browserResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.browserResult.Size = new System.Drawing.Size(660, 282);
            this.browserResult.TabIndex = 2;
            this.browserResult.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.updateTable);
            this.browserResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.browserResult_onFileDrop);
            this.browserResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.browserResult_onFileEnter);
            this.browserResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.browserResult_rightClick);
            // 
            // enableOutput
            // 
            this.enableOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enableOutput.AutoSize = true;
            this.enableOutput.Location = new System.Drawing.Point(224, 12);
            this.enableOutput.Name = "enableOutput";
            this.enableOutput.Size = new System.Drawing.Size(170, 17);
            this.enableOutput.TabIndex = 1;
            this.enableOutput.Text = "Move anime to another folder?";
            this.enableOutput.UseVisualStyleBackColor = true;
            this.enableOutput.CheckedChanged += new System.EventHandler(this.enableOutputOnChange);
            // 
            // outputLocation
            // 
            this.outputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputLocation.Location = new System.Drawing.Point(220, 37);
            this.outputLocation.Name = "outputLocation";
            this.outputLocation.Size = new System.Drawing.Size(123, 23);
            this.outputLocation.TabIndex = 3;
            this.outputLocation.Text = "Select Move Location";
            this.outputLocation.UseVisualStyleBackColor = true;
            this.outputLocation.Visible = false;
            this.outputLocation.Click += new System.EventHandler(this.outputLocationOnClick);
            // 
            // folderBrowseDialog
            // 
            this.folderBrowseDialog.Description = "Anilabel will rename your anime and put them in the folder your specify here.";
            this.folderBrowseDialog.RootFolder = System.Environment.SpecialFolder.MyVideos;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.outputTextBox.Location = new System.Drawing.Point(354, 39);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(318, 20);
            this.outputTextBox.TabIndex = 4;
            this.outputTextBox.Text = "Select Move Location";
            this.outputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.outputTextBox.Visible = false;
            this.outputTextBox.Click += new System.EventHandler(this.outputLocationOnClick);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(12, 37);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(123, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear Selected";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButtonOnClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.progressBarGage});
            this.statusStrip.Location = new System.Drawing.Point(0, 480);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(684, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // progressBarGage
            // 
            this.progressBarGage.Name = "progressBarGage";
            this.progressBarGage.Size = new System.Drawing.Size(0, 17);
            // 
            // optRelabelOptions
            // 
            this.optRelabelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optRelabelOptions.Controls.Add(this.optRawCheck);
            this.optRelabelOptions.Controls.Add(this.optResolutionCheck);
            this.optRelabelOptions.Controls.Add(this.optSubberCheck);
            this.optRelabelOptions.Controls.Add(this.optFilePartsLbl);
            this.optRelabelOptions.Controls.Add(this.optFormatSelector);
            this.optRelabelOptions.Controls.Add(this.optFormatLbl);
            this.optRelabelOptions.Controls.Add(this.relabelButton);
            this.optRelabelOptions.Location = new System.Drawing.Point(12, 354);
            this.optRelabelOptions.Name = "optRelabelOptions";
            this.optRelabelOptions.Size = new System.Drawing.Size(660, 117);
            this.optRelabelOptions.TabIndex = 9;
            this.optRelabelOptions.TabStop = false;
            this.optRelabelOptions.Text = "Relabel Options";
            // 
            // optRawCheck
            // 
            this.optRawCheck.AutoSize = true;
            this.optRawCheck.Checked = true;
            this.optRawCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optRawCheck.Location = new System.Drawing.Point(389, 50);
            this.optRawCheck.Name = "optRawCheck";
            this.optRawCheck.Size = new System.Drawing.Size(48, 17);
            this.optRawCheck.TabIndex = 7;
            this.optRawCheck.Text = "Raw";
            this.optRawCheck.UseVisualStyleBackColor = true;
            this.optRawCheck.CheckedChanged += new System.EventHandler(this.optRawCheck_OnChange);
            // 
            // optResolutionCheck
            // 
            this.optResolutionCheck.AutoSize = true;
            this.optResolutionCheck.Checked = true;
            this.optResolutionCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optResolutionCheck.Location = new System.Drawing.Point(271, 50);
            this.optResolutionCheck.Name = "optResolutionCheck";
            this.optResolutionCheck.Size = new System.Drawing.Size(76, 17);
            this.optResolutionCheck.TabIndex = 6;
            this.optResolutionCheck.Text = "Resolution";
            this.optResolutionCheck.UseVisualStyleBackColor = true;
            this.optResolutionCheck.CheckedChanged += new System.EventHandler(this.optResolutionCheck_OnChange);
            // 
            // optSubberCheck
            // 
            this.optSubberCheck.AutoSize = true;
            this.optSubberCheck.Checked = true;
            this.optSubberCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optSubberCheck.Location = new System.Drawing.Point(151, 50);
            this.optSubberCheck.Name = "optSubberCheck";
            this.optSubberCheck.Size = new System.Drawing.Size(77, 17);
            this.optSubberCheck.TabIndex = 5;
            this.optSubberCheck.Text = "Sub Group";
            this.optSubberCheck.UseVisualStyleBackColor = true;
            this.optSubberCheck.CheckedChanged += new System.EventHandler(this.optSubberCheck_OnChange);
            // 
            // optFilePartsLbl
            // 
            this.optFilePartsLbl.AutoSize = true;
            this.optFilePartsLbl.Location = new System.Drawing.Point(17, 50);
            this.optFilePartsLbl.Name = "optFilePartsLbl";
            this.optFilePartsLbl.Size = new System.Drawing.Size(113, 13);
            this.optFilePartsLbl.TabIndex = 3;
            this.optFilePartsLbl.Text = "Format Parts Included:";
            // 
            // optFormatSelector
            // 
            this.optFormatSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optFormatSelector.FormattingEnabled = true;
            this.optFormatSelector.Location = new System.Drawing.Point(151, 20);
            this.optFormatSelector.Name = "optFormatSelector";
            this.optFormatSelector.Size = new System.Drawing.Size(403, 21);
            this.optFormatSelector.TabIndex = 2;
            this.optFormatSelector.SelectedIndexChanged += new System.EventHandler(this.optFormatSelector_OnIndexChange);
            // 
            // optFormatLbl
            // 
            this.optFormatLbl.AutoSize = true;
            this.optFormatLbl.Location = new System.Drawing.Point(17, 23);
            this.optFormatLbl.Name = "optFormatLbl";
            this.optFormatLbl.Size = new System.Drawing.Size(81, 13);
            this.optFormatLbl.TabIndex = 1;
            this.optFormatLbl.Text = "Relabel Format:";
            // 
            // relabelButton
            // 
            this.relabelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.relabelButton.Location = new System.Drawing.Point(560, 19);
            this.relabelButton.Name = "relabelButton";
            this.relabelButton.Size = new System.Drawing.Size(94, 92);
            this.relabelButton.TabIndex = 0;
            this.relabelButton.Text = "Start Relabelling!";
            this.relabelButton.UseVisualStyleBackColor = true;
            this.relabelButton.Click += new System.EventHandler(this.relabelButton_OnClick);
            // 
            // browserResultCellMenu
            // 
            this.browserResultCellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAnimeToolStripMenuItem,
            this.copyCellToClipboardToolStripMenuItem});
            this.browserResultCellMenu.Name = "browserResultCellMenu";
            this.browserResultCellMenu.Size = new System.Drawing.Size(198, 48);
            // 
            // removeAnimeToolStripMenuItem
            // 
            this.removeAnimeToolStripMenuItem.Name = "removeAnimeToolStripMenuItem";
            this.removeAnimeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.removeAnimeToolStripMenuItem.Text = "Remove Anime";
            this.removeAnimeToolStripMenuItem.Click += new System.EventHandler(this.removeRow);
            // 
            // copyCellToClipboardToolStripMenuItem
            // 
            this.copyCellToClipboardToolStripMenuItem.Name = "copyCellToClipboardToolStripMenuItem";
            this.copyCellToClipboardToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyCellToClipboardToolStripMenuItem.Text = "Copy Cell To Clipboard";
            this.copyCellToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyCell);
            // 
            // Anilabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 502);
            this.Controls.Add(this.optRelabelOptions);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.outputLocation);
            this.Controls.Add(this.enableOutput);
            this.Controls.Add(this.browserResult);
            this.Controls.Add(this.browser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 540);
            this.Name = "Anilabel";
            this.Text = "Anilabel";
            this.Load += new System.EventHandler(this.anilabelOnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.browserResult)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.optRelabelOptions.ResumeLayout(false);
            this.optRelabelOptions.PerformLayout();
            this.browserResultCellMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browser;
        private System.Windows.Forms.OpenFileDialog browseDialog;
        private System.Windows.Forms.DataGridView browserResult;
        private System.Windows.Forms.CheckBox enableOutput;
        private System.Windows.Forms.Button outputLocation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowseDialog;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel progressBarGage;
        private System.Windows.Forms.GroupBox optRelabelOptions;
        private System.Windows.Forms.Button relabelButton;
        private System.Windows.Forms.Label optFormatLbl;
        private System.Windows.Forms.ContextMenuStrip browserResultCellMenu;
        private System.Windows.Forms.ToolStripMenuItem removeAnimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCellToClipboardToolStripMenuItem;
        private System.Windows.Forms.ComboBox optFormatSelector;
        private System.Windows.Forms.Label optFilePartsLbl;
        private System.Windows.Forms.CheckBox optRawCheck;
        private System.Windows.Forms.CheckBox optResolutionCheck;
        private System.Windows.Forms.CheckBox optSubberCheck;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}


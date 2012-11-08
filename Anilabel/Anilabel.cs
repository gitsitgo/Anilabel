using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anilabel
{
    public partial class Anilabel : Form
    {
        //DUMP - Designer keeps messing with the custom settings on build
        //this.optFormatSelector.Items.AddRange(new object[] {RelabelFormat.TitleBasedFormat.ToString(), RelabelFormat.SubberBasedFormat.ToString(), RelabelFormat.DetailBasedFormat.ToString()});
        //this.optFormatSelector.SelectedIndex = RelabelFormat.TitleBasedFormat.ToIndex();

        //Init UI Components
        public Anilabel()
        {
            InitializeComponent();
        }

        #region Initialize Program Settings

        //Private column name strings
        private static readonly string COLUMN0 = "File Name";
        private static readonly string COLUMN1 = "New File Name";
        private static readonly string COLUMN2 = "File Type";
        private static readonly string COLUMN3 = "Relabel Check";
        private static readonly string COLUMN4 = "Original Directory";

        //Private var dec
        private DataTable _dt = new DataTable();
        private int _dtrow;    //this track the selected grid cell
        private int _dtcol;    //this tracks the selected grid cell
        
        //Todo: mess around with settings file.
        private static List<string> acceptableFormats = new List<string>();

        //Main On Load Function
        private void anilabelOnLoad(object sender, EventArgs e)
        {
            _dt.Columns.Add(COLUMN0, typeof(string));
            _dt.Columns.Add(COLUMN1, typeof(string));
            _dt.Columns.Add(COLUMN2, typeof(string));
            _dt.Columns.Add(COLUMN3, typeof(bool));
            _dt.Columns.Add(COLUMN4, typeof(string));

            optFormatSelector.Items.AddRange(new object[] { RelabelFormat.TitleBasedFormat.ToString(), RelabelFormat.SubberBasedFormat.ToString(), RelabelFormat.DetailBasedFormat.ToString() });
            optFormatSelector.SelectedIndex = RelabelFormat.TitleBasedFormat.ToIndex();

            acceptableFormats.Add(".avi");
            acceptableFormats.Add(".mkv");
            acceptableFormats.Add(".mpg");
            acceptableFormats.Add(".flv");
            acceptableFormats.Add(".mp4");
        }
        #endregion

        #region Main Control Events
        
        private void browserOnClick(object sender, EventArgs e)
        {
            DialogResult result = browseDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                addRows(browseDialog.FileNames);
            }
        }

        private void enableOutputOnChange(object sender, EventArgs e)
        {
            if (enableOutput.Checked)
            {
                outputLocation.Visible = true;
                outputTextBox.Visible = true;
            }
            else
            {
                outputLocation.Visible = false;
                outputTextBox.Visible = false;
                outputTextBox.Text = "Select Move Location";
            }
        }

        private void outputLocationOnClick(object sender, EventArgs e)
        {
            DialogResult result = folderBrowseDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputTextBox.Text = folderBrowseDialog.SelectedPath;
            }
        }

        private void clearButtonOnClick(object sender, EventArgs e)
        {
            _dt.Clear();
            refreshBrowser();
        }

        #endregion 

        #region File Browser Handlers and Functions
        
        private string Relabel(string originalName, out bool makeTextRed)
        {
            AnimeVideo oName = new AnimeVideo(originalName);
            bool possibleError = false;

            RelabelFormat formatToUse = GetFormat(optFormatSelector.SelectedIndex);
            string newName = oName.RelabelFile(
                formatToUse,
                optSubberCheck.Checked,
                optResolutionCheck.Checked,
                optRawCheck.Checked,
                out possibleError
            );
            if (possibleError)
                makeTextRed = true;
            else
                makeTextRed = false;
            return newName;
        }

        private void browserResult_rightClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti;
            if (e.Button == MouseButtons.Right)
            {
                hti = browserResult.HitTest(e.X, e.Y);
                if (hti.Type == DataGridViewHitTestType.Cell)
                {
                    _dtrow = hti.RowIndex;
                    _dtcol = hti.ColumnIndex;
                    if (_dtrow != browserResult.RowCount-1)
                    {
                        browserResult.CurrentCell.Selected = false;
                        browserResultCellMenu.Show(browserResult, e.Location);
                        browserResult.CurrentCell = browserResult[_dtcol, _dtrow];
                    }
                }
            }
        }

        private void browserResult_onFileDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                addRows((string[])e.Data.GetData(DataFormats.FileDrop));
            }
        }


        private void browserResult_onFileEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void removeRow(object sender, EventArgs e)
        {
            _dt.Rows[_dtrow].Delete();
            refreshBrowser();
        }

        private void addRows(string[] files)
        {
            int total = files.Count();
            int added = 0;

            List<string> noAdds = new List<string>();
            foreach (string file in files)
            {
                if (acceptableFormats.Contains(Path.GetExtension(file)))
                {
                    bool red = false;
                    string relabeledName = Relabel(Path.GetFileNameWithoutExtension(file), out red);
                    _dt.Rows.Add(Path.GetFileNameWithoutExtension(file), relabeledName, Path.GetExtension(file), red, Path.GetFullPath(file));
                    added++;
                }
                else
                {
                    noAdds.Add(Path.GetFileName(file));
                }
            }

            refreshBrowser();

            if (added != total)
            {
                //build output string
                string noAddList = string.Empty;
                foreach (string filename in noAdds)
                {
                    noAddList = noAddList + filename + "\n";
                }
                MessageBox.Show("Some files were not added because they were either invalid or not accepted at this time:\n\n" + noAddList);
            }
        }

        private void updateTable(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (browserResult[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    _dt.Rows[e.RowIndex].SetField(e.ColumnIndex, browserResult[e.ColumnIndex, e.RowIndex].Value);
                    _dt.Rows[e.RowIndex].SetField(COLUMN3, false);
                    browserResult.Rows[e.RowIndex].Cells[COLUMN1].Style.ForeColor = Color.Black;
                }
                else
                {
                    MessageBox.Show("You must have a valid videoname.");
                }
            }
        }

        private void refreshBrowser()
        {
            if (_dt.Rows.Count == 0)
            {
                browserResult.DataSource = null;
                browserResult.Columns.Clear();
                browserResult.Rows.Clear();
            }
            else
            {
                browserResult.DataSource = null;
                BindingSource bs = new BindingSource();
                browserResult.AutoGenerateColumns = false;
                browserResult.ColumnCount = 2;
                browserResult.Columns[0].Name = COLUMN0;
                browserResult.Columns[0].DataPropertyName = COLUMN0;
                browserResult.Columns[0].HeaderText = COLUMN0;
                browserResult.Columns[1].Name = COLUMN1;
                browserResult.Columns[1].DataPropertyName = COLUMN1;
                browserResult.Columns[1].HeaderText = COLUMN1;
                bs.DataSource = _dt;
                browserResult.DataSource = bs;
                browserResult.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                browserResult.Columns.GetLastColumn(DataGridViewElementStates.Displayed, DataGridViewElementStates.Frozen).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (browserResult.Columns[0].Width > ((browserResult.Width - 2) / 2))
                {
                    //browserResult.Columns[0].MinimumWidth = browserResult.Columns[0].Width; //this line will ensure EVERYTHING is seen at all times but disables resizing
                    browserResult.Columns[1].MinimumWidth = browserResult.Columns[0].Width;
                }
                addHighlight();
                browserResult.Columns["File Name"].ReadOnly = true;
            }
        }

        private void addHighlight()
        {
            if (browserResult.RowCount > 0)
            {
                for (int i = 0; i < browserResult.RowCount - 1; i++) //minus one to account for extra blank row
                {
                    if((bool)_dt.Rows[i][COLUMN3] == true)
                    {
                        browserResult.Rows[i].Cells[COLUMN1].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void copyCell(object sender, EventArgs e)
        {
            Clipboard.SetText(_dt.Rows[_dtrow][_dtcol].ToString());
        }

        #endregion

        #region Relabeler Option Event Handlers
        
        private void optFormatSelector_OnIndexChange(object sender, EventArgs e)
        {
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                bool red = false;
                _dt.Rows[i].SetField(COLUMN1, Relabel(_dt.Rows[i][COLUMN0].ToString(), out red));
            }
            refreshBrowser();
        }

        private void optSubberCheck_OnChange(object sender, EventArgs e)
        {
            optFormatSelector_OnIndexChange(this, EventArgs.Empty);
        }

        private void optResolutionCheck_OnChange(object sender, EventArgs e)
        {
            optFormatSelector_OnIndexChange(this, EventArgs.Empty);
        }

        private void optRawCheck_OnChange(object sender, EventArgs e)
        {
            optFormatSelector_OnIndexChange(this, EventArgs.Empty);
        }

        #endregion

        #region Generic Format Handler
        
        private RelabelFormat GetFormat(int formatValue)
        {
            if (formatValue == RelabelFormat.TitleBasedFormat.ToIndex())
            {
                return RelabelFormat.TitleBasedFormat;
            }
            else if (formatValue == RelabelFormat.SubberBasedFormat.ToIndex())
            {
                return RelabelFormat.SubberBasedFormat;
            }
            else if (formatValue == RelabelFormat.DetailBasedFormat.ToIndex())
            {
                return RelabelFormat.DetailBasedFormat;
            }
            else
            {
                //Invalid format
                return RelabelFormat.InvalidFormat;
            }
        }

        #endregion
        
        #region Relabel Operations
        
        private void relabelButton_OnClick(object sender, EventArgs e)
        {
            Relabel();
        }
        
        private void Relabel()
        {
            int rowindex = 0;
            List<string> errorList = new List<string>();
            int total = _dt.Rows.Count;
            int processed = 0;
            foreach (DataRow file in _dt.Rows)
            {
                try
                {
                    //source directory
                    string sDirectory = Path.GetDirectoryName(file.Field<string>(COLUMN4));

                    //destination directory
                    string dDirectory;
                    if (enableOutput.Checked)
                    {
                        dDirectory = outputTextBox.Text;
                    }
                    else
                    {
                        //get the original directory if no output specified
                        dDirectory = sDirectory;
                    }

                    //get old name
                    string oldName = file.Field<string>(COLUMN0);

                    //get new name
                    string newName = file.Field<string>(COLUMN1);

                    //get the extension
                    string extension = file.Field<string>(COLUMN2);

                    //build source file path
                    string source = String.Format("{0}\\{1}{2}", sDirectory, oldName, extension);

                    //build destination file path
                    string destination = String.Format("{0}\\{1}{2}", dDirectory, newName, extension);

                    //test the file source, use the handler to see that we can physically interact with the source file
                    if (!File.Exists(source))
                        using (FileStream fs = File.Create(source)) {  } //don't actually do anything

                    //test the file destination
                    if (File.Exists(destination))
                        File.Delete(destination);

                    //Move the file. The method will rename if source = destination and actually move if different
                    File.Move(source, destination);

                    processed++;
                    browserResult.Rows[rowindex].DefaultCellStyle.BackColor = Color.FromArgb(204, 255, 204);

                    //implement logging later
                    
                }
                catch (Exception e)
                {
                    //implement logging later
                    MessageBox.Show(e.ToString());
                    if(enableOutput.Checked)
                        errorList.Add(file.Field<string>(COLUMN0) + "was not moved.");
                    else
                        errorList.Add(file.Field<string>(COLUMN0) + "was not relabelled.");
                }
                rowindex++;
            }

            //Summary and Error displaying
            string processmsg = "Processed " + processed + " out of " + total + " videos successfully.";
            if (errorList.Count > 0)
            {
                string errors = string.Empty;
                foreach (string errormsg in errorList)
                {
                    errors = errors + errormsg + "\n";
                }
                MessageBox.Show(processmsg + "\n\nErrors occured for the following:\n" + errors);
            }
            else
            {
                MessageBox.Show(processmsg);
            }
        }

        

        #endregion
    }
}

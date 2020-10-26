using ExcelDataReader;
using JsonFileUploadApp.Controllers;
using JsonFileUploadApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonFileUploadApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Search File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == string.Empty)
            {
                MessageBox.Show("Please choose a file to upload");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            string fileName = txtFileName.Text;

            //convert the excel file into a json string
            string JSONResult = GetJsonStringFromExcelFile(fileName);

            FileUploadController fileUploadController = new FileUploadController();
            // increase the max allow packets of mysql database to accomodate large files
            fileUploadController.SetMaxAllowedPackets();

            //import the contents of the file to the database
            ImportResult result = fileUploadController.ImportSalesFile(Regex.Unescape(JSONResult));

            //validate result of the upload operation
            if (result.Result == ActionResult.ACTION_SUCCESSFUL)
            {
                //log the result using you favorite logger
                //perform any operation you want

                //bubble mesagebox indicating file is suucessfully uploaded
                MessageBox.Show("Successfully imported filename:" + fileName);
            }
            else if (result.Result == ActionResult.ACTION_FAILED)
            {

                //log the result using you favorite logger
                //perform any operation you want

                //bubble mesagebox indicating file was not successfully uploaded
                MessageBox.Show("Failed to import filename:" + fileName);
            }
            else if (result.Result == ActionResult.EXCEPTION_ENCOUNTERED)
            {
                //log the error(string.Concat("Exception encounted while uploading filename: ", fileName, ", Exception:", result.ErrorMessage, ", ", result.ObjectException.ToString()));
                //perform any operation you want

                //bubble mesagebox indicating that exception occured while uploading the file.
                MessageBox.Show(string.Concat("Exception encounted while uploading filename: ", fileName, ". Please check the log for details of the exception"));
            }

        }

        ///<summary>
        ///<para>Reads the contents of the excel file as DataSet and converts it into a json string</para>
        ///<para>Returns the content of the excel file as a json string</para>
        ///</summary>
        private string GetJsonStringFromExcelFile(string fileName)
        {
            string JSONResult = string.Empty;
            try
            {
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            UseColumnDataType = true,
                            FilterSheet = (tableReader, sheetIndex) => true,
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                EmptyColumnNamePrefix = "Column",
                                UseHeaderRow = false,
                                ReadHeaderRow = (rowReader) =>
                                {
                                    rowReader.Read();
                                },

                                FilterRow = (rowReader) =>
                                {
                                    return true;
                                },

                                FilterColumn = (rowReader, columnIndex) =>
                                {
                                    return true;
                                }
                            }
                        });

                        // each sheet in the excel file is read as a DataTable
                        //Table[0]  = Sheet1
                        JSONResult = JsonConvert.SerializeObject(result.Tables[0]);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
                // log exception or do whatever you want to do with it   
            }

            return JSONResult;
        }
    }
}

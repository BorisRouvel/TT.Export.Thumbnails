﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using KD.SDK;
using KD.CatalogProperties;


namespace TT.WebisationStandalone
{
    public partial class MainForm : Form 
    {
        private Appli appli = new Appli(KD.InSitu.Ini.Const.FileNameSpaceIni);       
        private Reference reference = null;       

        string catalogFilePath = String.Empty;
        string catalogFileName = String.Empty;

        KD.CsvHelper.CsvFileWriter csvFile = null;
        KD.CsvHelper.CsvRow catalogRow = null;
        KD.CsvHelper.CsvRow sectionRow = null;
        KD.CsvHelper.CsvRow blocRow = null;
        KD.CsvHelper.CsvRow articleRow = null;


        public MainForm()
        {
            InitializeComponent();

            this.InitForm();            
        }

        //Event
        private void InitForm()
        {
            this.MainForm_GBX.Text = "Catalogue";
            this.CatalogName_LAB.Text = "Nom :";
            this.Status_TSPB.Maximum = 0;
            this.Accept_BTN.Enabled = false;
        }
        private void UpdateForm()
        { 
            this.MainForm_GBX.Text = catalogFilePath;
            this.CatalogName_LAB.Text = reference.CatalogName;
            this.Status_TSPB.Maximum = reference.SectionLinesNb - 1;
            this.Accept_BTN.Enabled = true;
        }
        private void InitMembers()
        {
            reference = null;
            csvFile = null;
            catalogFilePath = String.Empty;
            catalogFileName = String.Empty;
            catalogRow = null;
            sectionRow = null;
            blocRow = null;
            articleRow = null;           
            this.Status_TSPB.Value = 0;          
            this.Status_TSSL.Text = KD.StringTools.Const.Zero + KD.StringTools.Const.WhiteSpace + KD.StringTools.Const.Percent;            
        }
        private void SetMembers()
        {
            reference = new Reference(appli, catalogFilePath);
            csvFile = new KD.CsvHelper.CsvFileWriter("WebInfo.csv");
            catalogFileName = Path.GetFileName(catalogFilePath);
        }

        private bool OpenCatalog()
        {
            this.OpenCatalog_OFD.RestoreDirectory = true;
            this.OpenCatalog_OFD.Filter = "Fichiers Catalogue" + KD.StringTools.Const.WhiteSpace + 
                                                                 KD.StringTools.Const.Pipe + 
                                                                 KD.StringTools.Const.Wildcard + 
                                                                 KD.CatalogProperties.Const.catalogExtension;

            DialogResult dialogResult = this.OpenCatalog_OFD.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (File.Exists(this.OpenCatalog_OFD.FileName))
                {
                    catalogFilePath = this.OpenCatalog_OFD.FileName;
                    if (!String.IsNullOrEmpty(catalogFilePath))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsSectionValid(string sectionCode, string sectionName)
        {
            //!sectionCode.StartsWith(KD.CatalogProperties.Const.arobase) &&  && !sectionName.StartsWith(KD.CatalogProperties.Const.arobase)

            if (!String.IsNullOrEmpty(sectionName))
            {
                return true;
            }
            return false;
        }

        private void SetCatalogRow()
        {
            catalogRow = new KD.CsvHelper.CsvRow();
           
            catalogRow.Add(reference.CatalogName);
            catalogRow.Add(catalogFileName);

            csvFile.WriteRow(catalogRow);
        }
        private void SetSectionRow()
        {
            sectionRow = new KD.CsvHelper.CsvRow();
            
            sectionRow.Add(reference.Section_Name);
            sectionRow.Add(reference.Section_Code);

            csvFile.WriteRow(sectionRow);         
        }
        private void SetBlockRow()
        {
            blocRow = new KD.CsvHelper.CsvRow();
           
            blocRow.Add(reference.Block_Code);

            string script = reference.Block_Script.ToUpper();
            string url = String.Empty;
            if (script.Contains("@URL("))
            {
                url = KD.StringTools.Helper.SubString(script, "@URL(", ")");               
            }
            blocRow.Add(url);           

            blocRow.Add(reference.Block_Altitude.ToString());
            blocRow.Add(reference.Block_PoseOnorUnderIndex.ToString());
            blocRow.Add(reference.Section_Name);

            csvFile.WriteRow(blocRow);           
        }
        private void SetArticleRow()
        {
            articleRow = new KD.CsvHelper.CsvRow();

            articleRow.Add(reference.Article_Key);
            articleRow.Add(reference.Article_Hinge);
            articleRow.Add(reference.Article_Width.ToString());
            articleRow.Add(reference.Article_Depth.ToString());
            articleRow.Add(reference.Article_Height.ToString());

            csvFile.WriteRow(articleRow);
        }

        private object Main(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (this.Status_BGW.CancellationPending)
            {
                return 0;
            }
            else
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //this.SetMembers();
                this.Status_BGW.ReportProgress(0);              

                this.WriteCSVInformations();
            }
            return e.Result;
        }

        private void WriteCSVInformations()
        {
            for (int sectionRank = 0; sectionRank <= reference.SectionLinesNb - 1; sectionRank++)
            {
                reference = new Reference(appli, sectionRank, 0, 0);               
                int blockNb = reference.Section_BlockNb;
              
                for (int blockRank = 0; blockRank <= blockNb - 1; blockRank++)
                {
                    reference = new Reference(appli, sectionRank, blockRank, 0);                 
                    int articleNb = reference.Block_ArticleNb;

                    for (int articleRank = 0; articleRank <= articleNb - 1; articleRank++)
                    {
                        reference = new Reference(appli, sectionRank, blockRank, articleRank);

                        if (IsSectionValid(reference.Section_Code, reference.Section_Name))
                        {
                            this.SetCatalogRow();
                            this.SetSectionRow();
                            this.SetBlockRow();
                            this.SetArticleRow();
                        }
                    }
                }
                this.Status_BGW.ReportProgress(sectionRank);              
            }
            csvFile.Dispose();
        }


        //Form
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Accept_BTN_Click(object sender, EventArgs e)
        {           
            this.Status_BGW.RunWorkerAsync();
        }

        private void Cancel_BTN_Click(object sender, EventArgs e)
        {
            this.Status_BGW.CancelAsync();
            this.Close();
        }

        private void OpenCatalog_BTN_Click(object sender, EventArgs e)
        {
            this.InitMembers();

            if (this.OpenCatalog())
            {
                this.SetMembers();
                this.UpdateForm();
            }
        }

        private void Status_BGW_DoWork(object sender, DoWorkEventArgs e)
        {          
            e.Result = this.Main(this.Status_BGW, e); // do your long operation here   
        }

        private void Status_BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.Status_BGW.CancellationPending)
            {
               return;
            }
            else
            {               
                this.Status_TSPB.Value = e.ProgressPercentage;
                double reportPercent = (100.0 / this.Status_TSPB.Maximum);
                double currentPercent = (reportPercent * e.ProgressPercentage);
                this.Status_TSSL.Text = System.Math.Round(currentPercent, 0) + KD.StringTools.Const.WhiteSpace + KD.StringTools.Const.Percent;
            }
        }

        private void Status_BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;
            this.Accept_BTN.Enabled = false;

            DialogResult dialog = System.Windows.Forms.MessageBox.Show("Terminé.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

        }
    }
}

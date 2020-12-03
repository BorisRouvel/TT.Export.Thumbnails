using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

using KD.SDK;
using KD.CatalogProperties;
using KD.CsvHelper;
using KD.DicoHelper;


namespace TT.WebisationStandalone
{
    public partial class MainForm : Form 
    {       
        private Appli appli = new Appli(KD.InSitu.Ini.Const.FileNameSpaceIni);       
        private Reference reference = null; 
        private CsvManage csvManage = null;
        private CsvFileWriter csvFile = null;
        private SceneInfo sceneInfo = null;
       
        string catalogFilePath = String.Empty;
        string catalogFileName = String.Empty;
        string catalogFileDir = String.Empty;

        public static bool IsSceneCreate = false;


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
            if (csvFile != null)
            {
                csvFile.Dispose();
            }
            csvFile = null;
            csvManage = null;
            sceneInfo = null;
            catalogFilePath = String.Empty;
            catalogFileName = String.Empty;
            catalogFileDir = String.Empty;
            this.Status_TSPB.Value = 0;          
            this.Status_TSSL.Text = KD.StringTools.Const.Zero + KD.StringTools.Const.WhiteSpace + KD.StringTools.Const.Percent;            
        }
        private void SetMembers()
        {           
            reference = new Reference(appli, catalogFilePath);
            csvFile = new CsvFileWriter(CsvManage.Const.csvFileName);

            catalogFileName = Path.GetFileName(catalogFilePath);
            catalogFileDir = Path.GetDirectoryName(catalogFilePath);
        }

        private bool OpenCatalog()
        {
            this.OpenCatalog_OFD.RestoreDirectory = true;
            this.OpenCatalog_OFD.Filter = "Fichiers Catalogue" + KD.StringTools.Const.WhiteSpace + 
                                                                 KD.StringTools.Const.Pipe + 
                                                                 KD.StringTools.Const.Wildcard + 
                                                                 KD.CatalogProperties.Const.CatalogExtension;

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
        private void UpdateSpaceINI()
        {
            string iniPath = Path.Combine(Application.StartupPath, KD.InSitu.Ini.Const.FileNameSpaceIni);
            KD.Config.IniFile iniFile = new KD.Config.IniFile(iniPath);
            iniFile.WriteValue(KD.CatalogProperties.Const.SectionCatalogs, KD.CatalogProperties.Const.KeyDir, catalogFileDir);
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
                        int blockLineIndex = appli.Catalog.TableGetFirstLineRankFromClusterRank(CatalogEnum.TableId.BLOCKS, sectionRank);
                        reference = new Reference(appli, sectionRank, blockRank + blockLineIndex, articleRank);
                        sceneInfo = new SceneInfo(reference);
                        csvManage = new CsvManage(csvFile, reference, sceneInfo);

                        if (csvManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
                        {
                            csvManage.SetCatalogRow();
                            csvManage.SetSectionRow();
                            csvManage.SetBlockRow();
                            csvManage.SetArticleRow();
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
            this.Accept_BTN.Enabled = false;
            this.Status_BGW.RunWorkerAsync();
        }

        private void Cancel_BTN_Click(object sender, EventArgs e)
        {
            this.Status_BGW.CancelAsync();
            this.Close();
        }

        private void OpenCatalog_BTN_Click(object sender, EventArgs e)
        {
            this.InitForm();
            this.InitMembers();

            if (this.OpenCatalog())
            {
                this.SetMembers();
                this.UpdateForm();
                this.UpdateSpaceINI();
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

        private void Version_LNK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string[] assemblyFullName = System.Reflection.Assembly.GetExecutingAssembly().ToString().Split(KD.CharTools.Const.Comma);
            string[] assemblyVersion = assemblyFullName[1].Split(KD.CharTools.Const.EqualSign);
            MessageBox.Show("Version: " + assemblyVersion[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

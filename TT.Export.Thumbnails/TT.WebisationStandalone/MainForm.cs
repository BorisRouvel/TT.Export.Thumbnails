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
        private TT.Export.Thumbnails.Plugin export = null;

        private CsvManage sectionCSVManage = null;
        private CsvManage blocCSVManage = null;
        private CsvManage articleCSVManage = null;
        private CsvManage translateCSVManage = null;

        private CsvFileWriter sectionCSVFile = null;
        private CsvFileWriter blocCSVFile = null;
        private CsvFileWriter articleCSVFile = null;
        private CsvFileWriter translateCSVFile = null;

        private SceneInfo sceneInfo = null;
       
        private string catalogFilePath = String.Empty;
        private string catalogFileName = String.Empty;
        private string catalogFileDir = String.Empty;
        private string catalogStatus = String.Empty;

        public static bool IsSceneCreate = false;
        public static bool IsFirstPlaceObject = true;
        public static int SelectId = KD.Const.UnknownId;

        private int progessBarMax = 0;


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
            this.OpenCatalog_BTN.Enabled = true;
        }
        private void UpdateForm()
        { 
            this.MainForm_GBX.Text = catalogFilePath;
            this.CatalogName_LAB.Text = reference.CatalogName;
            //this.Status_TSPB.Maximum = 3; // reference.SectionLinesNb - 1;
            this.Accept_BTN.Enabled = true;
           
        }

        private void InitCSVFile(CsvFileWriter file)
        {
            if (file != null)
            {
                file.Dispose();
            }
            file = null;
        }
        private void InitMembers()
        {
            reference = null;
            this.InitCSVFile(sectionCSVFile);
            this.InitCSVFile(blocCSVFile);
            this.InitCSVFile(articleCSVFile);
            this.InitCSVFile(translateCSVFile);

            sectionCSVManage = null;
            blocCSVManage = null;
            articleCSVManage = null;
            translateCSVManage = null;

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
            catalogFileName = Path.GetFileName(catalogFilePath);
            string catalogFileNameWithoutExtension = Path.GetFileNameWithoutExtension(catalogFilePath);
            //catalogFileNameWithoutExtension + KD.StringTools.Const.Underscore +
            sectionCSVFile = new CsvFileWriter(CsvManage.Const.sectionCSVFileName);
            blocCSVFile = new CsvFileWriter( CsvManage.Const.blocCSVFileName);
            articleCSVFile = new CsvFileWriter( CsvManage.Const.articleCSVFileName);
            translateCSVFile = new CsvFileWriter( CsvManage.Const.translateCSVFileName);

            catalogFileDir = Path.GetDirectoryName(catalogFilePath);
        }
        private void DisposeCSVFile()
        {
            sectionCSVFile.Dispose();
            blocCSVFile.Dispose();
            articleCSVFile.Dispose();
            translateCSVFile.Dispose();
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
               
                this.Status_BGW.ReportProgress(0);
                
                this.WriteSectionInformations();
                this.WriteBlocInformations();
                this.WriteArticleInformations();

                //this.WriteCSVInformations();
            }
            return e.Result;
        }

        private void WriteSectionInformations()
        {
            this.catalogStatus = "Sections";
            this.progessBarMax = reference.SectionLinesNb - 1;
            this.Status_BGW.ReportProgress(0);

            for (int sectionRank = 0; sectionRank <= reference.SectionLinesNb - 1; sectionRank++)//
            {
                reference = new Reference(appli, sectionRank, 0, 0);
                sceneInfo = new SceneInfo(reference);
                sectionCSVManage = new CsvManage(sectionCSVFile, reference, sceneInfo);

                if (sectionCSVManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
                {                  
                    sectionCSVManage.SetSectionRow();
                    sectionCSVFile.Flush();
                }
                this.Status_BGW.ReportProgress(sectionRank);
            }
            sectionCSVFile.Dispose();
        }
        private void WriteBlocInformations()
        {
            this.catalogStatus = "Blocs";
            this.progessBarMax = reference.BlockLinesNb - 1;
            this.Status_BGW.ReportProgress(0);
            int lineIndex = 0;

            for (int sectionRank = 0; sectionRank <= reference.SectionLinesNb - 1; sectionRank++)//
            {
                reference = new Reference(appli, sectionRank, 0, 0);
                int blockNb = reference.Section_BlockNb;

                for (int blockRank = 0; blockRank <= blockNb - 1; blockRank++)//
                {
                    reference = new Reference(appli, sectionRank, blockRank, 0);
                    sceneInfo = new SceneInfo(reference);
                    blocCSVManage = new CsvManage(blocCSVFile, reference, sceneInfo);                   

                    if (blocCSVManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
                    {
                        blocCSVManage.SetBlockRow();
                        blocCSVFile.Flush();
                    }
                    this.Status_BGW.ReportProgress(lineIndex);
                    lineIndex++;
                }
                
            }          
            blocCSVFile.Dispose();           
        }
        private void WriteArticleInformations()
        {
            this.catalogStatus = "Articles";
            this.progessBarMax = reference.ReferenceLinesNb - 1;
            this.Status_BGW.ReportProgress(0);
            int lineIndex = 0;

            for (int sectionRank = 0; sectionRank <= reference.SectionLinesNb - 1; sectionRank++)//
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
                        articleCSVManage = new CsvManage(articleCSVFile, reference, sceneInfo);
                        //translateCSVManage = new CsvManage(translateCSVFile, reference, sceneInfo);

                        if (articleCSVManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
                        {                            
                            articleCSVManage.SetArticlePlacedRow();
                            articleCSVFile.Flush();

                            //translateCSVManage.SetTranslateRow();
                            //translateCSVFile.Flush();
                        }
                        this.Status_BGW.ReportProgress(lineIndex);
                        lineIndex++;
                    }
                }               
            }
           
            articleCSVFile.Dispose();
           // translateCSVFile.Dispose();
        }

        //private void WriteCSVInformations()
        //{
        //    for (int sectionRank = 0; sectionRank <= reference.SectionLinesNb - 1; sectionRank++)//
        //    {
        //        reference = new Reference(appli, sectionRank, 0, 0);               
        //        int blockNb = reference.Section_BlockNb;                

        //        for (int blockRank = 0; blockRank <= blockNb - 1; blockRank++)
        //        {
        //            reference = new Reference(appli, sectionRank, blockRank, 0);                 
        //            int articleNb = reference.Block_ArticleNb;

        //            for (int articleRank = 0; articleRank <= articleNb - 1; articleRank++)
        //            {
        //                int blockLineIndex = appli.Catalog.TableGetFirstLineRankFromClusterRank(CatalogEnum.TableId.BLOCKS, sectionRank);
        //                reference = new Reference(appli, sectionRank, blockRank + blockLineIndex, articleRank);
        //                sceneInfo = new SceneInfo(reference);
        //                sectionCSVManage = new CsvManage(sectionCSVFile, reference, sceneInfo);
        //                blocCSVManage = new CsvManage(blocCSVFile, reference, sceneInfo);
        //                articleCSVManage = new CsvManage(articleCSVFile, reference, sceneInfo);

        //                if (sectionCSVManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
        //                {
        //                    //sectionCSVManage.SetCatalogRow();
        //                    sectionCSVManage.SetSectionRow();
        //                    blocCSVManage.SetBlockRow();
        //                    articleCSVManage.SetArticleRow();
        //                }
        //                this.Status_BGW.ReportProgress(blockRank + blockLineIndex);
        //            }
        //        }
        //        //this.Status_BGW.ReportProgress(sectionRank);              
        //    }
        //    this.DisposeCSVFile();
        //}
      
        private void ExecuteThumbnails()
        {
            if (export == null)
            {
                export = new TT.Export.Thumbnails.Plugin();
            }

            //this.ExportThumbnail_LAB.Text = TT.Export.Thumbnails.MainForm.ThumbnailNb.ToString() + " / " + TT.Export.Thumbnails.MainForm.ThumbnailNbs.ToString();
            this.ExportThumbnail_LAB.Text = "En cours : 84 x 84";
            this.Refresh();

            export.ExecuteWebThumbnailExport("3D", "84", "84", "3", true, true, catalogFilePath);
            this.ExportThumbnail_LAB.Text = "En cours : 220 x 220";
            this.Refresh();

            //this.ExportThumbnail_LAB.Text = TT.Export.Thumbnails.MainForm.ThumbnailNb.ToString() + " / " + TT.Export.Thumbnails.MainForm.ThumbnailNbs.ToString();
            export.ExecuteWebThumbnailExport("3D", "220", "220", "3", true, true, catalogFilePath);
            this.ExportThumbnail_LAB.Text = "Terminé";
            this.Refresh();
        }
     

        // Form
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Accept_BTN_Click(object sender, EventArgs e)
        {
            this.Accept_BTN.Enabled = false;
            this.OpenCatalog_BTN.Enabled = false;

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
                this.Name_TSSL.Text = this.catalogStatus;
                this.Status_TSPB.Maximum = this.progessBarMax;
                this.Status_TSPB.Value = e.ProgressPercentage;
                double reportPercent = (100.0 / this.Status_TSPB.Maximum);
                double currentPercent = (reportPercent * e.ProgressPercentage);
                this.Status_TSSL.Text = System.Math.Round(currentPercent, 0) + KD.StringTools.Const.WhiteSpace + KD.StringTools.Const.Percent;
            }
        }

        private void Status_BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            this.Accept_BTN.Enabled = false;
            this.OpenCatalog_BTN.Enabled = true;

            DialogResult dialog = System.Windows.Forms.MessageBox.Show("Terminé.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void Version_LNK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string[] assemblyFullName = System.Reflection.Assembly.GetExecutingAssembly().ToString().Split(KD.CharTools.Const.Comma);
            string[] assemblyVersion = assemblyFullName[1].Split(KD.CharTools.Const.EqualSign);
            MessageBox.Show("Version: " + assemblyVersion[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportThumbnails_BTN_Click(object sender, EventArgs e)
        {
            this.ExecuteThumbnails();
        }
    }
}

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
        private Appli appli = null;  
        private Reference reference = null;
        private TT.Export.Thumbnails.Plugin thumbnailPlug = null;        

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

            this.OpenCatalog_BTN.Enabled = true;
            this.GenerateCSVFile_BTN.Enabled = false;
            this.GenerateThumbnails_BTN.Enabled = false;
            this.GenerateTranslate_CHB.Enabled = false;
        }
        private void UpdateForm()
        { 
            this.MainForm_GBX.Text = catalogFilePath;
            this.CatalogName_LAB.Text = reference.CatalogName;

            this.OpenCatalog_BTN.Enabled = false;
            this.GenerateCSVFile_BTN.Enabled = true;
            this.GenerateThumbnails_BTN.Enabled = true;
            this.GenerateTranslate_CHB.Enabled = true;
        }

        private void DisposeCSVFile(CsvFileWriter file)
        {
            if (file != null)
            {
                file.Dispose();
            }
            file = null;
        }
        private void InitMembers()
        {
            appli = null;
            reference = null;
            this.DisposeCSVFile(sectionCSVFile);
            this.DisposeCSVFile(blocCSVFile);
            this.DisposeCSVFile(articleCSVFile);
            this.DisposeCSVFile(translateCSVFile);

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
           
            string exportDir = Path.Combine(catalogFileDir, catalogFileNameWithoutExtension);

            if (!Directory.Exists(exportDir))
            {
                Directory.CreateDirectory(exportDir);
            }
            //catalogFileNameWithoutExtension + KD.StringTools.Const.Underscore +
            sectionCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.sectionCSVFileName));
            blocCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.blocCSVFileName));
            articleCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.articleCSVFileName));
            translateCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.translateCSVFileName));
           
        }
        private void DisposeAllCSVFile()
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
            catalogFileDir = Path.GetDirectoryName(catalogFilePath);

            string spaceIniPath = Path.Combine(Application.StartupPath, KD.InSitu.Ini.Const.FileNameSpaceIni);
            KD.Config.IniFile spaceIniFile = new KD.Config.IniFile(spaceIniPath);
            spaceIniFile.WriteValue(KD.CatalogProperties.Const.SectionCatalogs, KD.CatalogProperties.Const.KeyDir, catalogFileDir);

            string kdsdkIniPath = Path.Combine(Application.StartupPath, "KDSDK.ini");
            KD.Config.IniFile kdsdkIniFile = new KD.Config.IniFile(kdsdkIniPath);
            kdsdkIniFile.WriteValue("Debug", KD.CatalogProperties.Const.CatalogsDir, catalogFileDir);
        }
        private void UpdateAppli()
        {          
            appli = new Appli(KD.InSitu.Ini.Const.FileNameSpaceIni);         
        }

        private object Main(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                return 0;
            }
            else
            {

                worker.ReportProgress(0);
                
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

            if (GenerateTranslate_CHB.Checked)
            {
                this.catalogStatus += " et Traductions";
            }

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
                        translateCSVManage = new CsvManage(translateCSVFile, reference, sceneInfo);

                        if (articleCSVManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
                        {                            
                            articleCSVManage.SetArticlePlacedRow();
                            articleCSVFile.Flush();

                            if (GenerateTranslate_CHB.Checked)
                            {
                                translateCSVManage.SetTranslatePlacedRow();
                                translateCSVFile.Flush();
                            }
                        }
                        this.Status_BGW.ReportProgress(lineIndex);
                        lineIndex++;
                    }
                }               
            }
           
            articleCSVFile.Dispose();
            translateCSVFile.Dispose();
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
            if (thumbnailPlug == null)
            {
                thumbnailPlug = new TT.Export.Thumbnails.Plugin();
            }
                     
            thumbnailPlug.ExecuteWebThumbnailExport(String.Empty, String.Empty, String.Empty, String.Empty, true, true, false, catalogFilePath);          
        }
     

        // Form
        private void MainForm_Load(object sender, EventArgs e)
        {

        }         

        private void OpenCatalog_BTN_Click(object sender, EventArgs e)
        {
            this.InitForm();
            this.InitMembers();

            if (this.OpenCatalog())
            {
                this.UpdateSpaceINI();
                this.UpdateAppli();
                this.SetMembers();
                this.UpdateForm();               
            }
        }

        private void Close_BTN_Click(object sender, EventArgs e)
        {
            this.Status_BGW.CancelAsync();
            this.Close();
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
            this.OpenCatalog_BTN.Enabled = true;
            this.GenerateCSVFile_BTN.Enabled = true;
            this.GenerateThumbnails_BTN.Enabled = true;
            this.GenerateTranslate_CHB.Enabled = true;

            DialogResult dialog = System.Windows.Forms.MessageBox.Show("Fichier CSV Terminé.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void Version_LNK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string[] assemblyFullName = System.Reflection.Assembly.GetExecutingAssembly().ToString().Split(KD.CharTools.Const.Comma);
            string[] assemblyVersion = assemblyFullName[1].Split(KD.CharTools.Const.EqualSign);
            MessageBox.Show("Version: " + assemblyVersion[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerateThumbnails_BTN_Click(object sender, EventArgs e)
        {
            this.ExecuteThumbnails();
        }

        private void GenerateCSVFile_BTN_Click(object sender, EventArgs e)
        {
            this.OpenCatalog_BTN.Enabled = false;
            this.GenerateCSVFile_BTN.Enabled = false;
            this.GenerateThumbnails_BTN.Enabled = false;
            this.GenerateTranslate_CHB.Enabled = false;

            this.Status_BGW.RunWorkerAsync();
        }
    }
}

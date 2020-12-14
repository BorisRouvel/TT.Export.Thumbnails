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
        private const string SectionExport = "Export";
        private const string SectionDebug = "Debug";

        private Appli appli = null;  
        private Reference reference = null;
        private TT.Export.Thumbnails.Plugin thumbnailPlug = null;

        private string spaceIniPath = Path.Combine(Application.StartupPath, KD.InSitu.Ini.Const.FileNameSpaceIni);
        private KD.Config.IniFile spaceIniFile = null;
        private string kdsdkIniPath = Path.Combine(Application.StartupPath, "KDSDK.ini");        
        private KD.Config.IniFile kdsdkIniFile = null;

        private CsvManage sectionCSVManage = null;
        private CsvManage blockCSVManage = null;
        private CsvManage articleCSVManage = null;
        private CsvManage translateCSVManage = null;       

        private CsvFileWriter sectionCSVFile = null;
        private CsvFileWriter blockCSVFile = null;
        private CsvFileWriter articleCSVFile = null;
        private CsvFileWriter translateCSVFile = null;
        private CsvFileWriter errorCSVFile = null;

        private SceneInfo sceneInfo = null;
       
        private string catalogFilePath = String.Empty;
        private string catalogFileName = String.Empty;
        private string catalogFileDir = String.Empty;
        private string catalogStatus = String.Empty;

        public static bool IsSceneCreate = false;
        public static bool IsFirstPlaceObject = true;
        public static int SelectId = KD.Const.UnknownId;
        public static string exportDir = String.Empty;

        private int progessBarMax = 0;


        public MainForm()
        {
            InitializeComponent();

            this.InitForm();            
        }

        //Event       
        private void InitForm()
        {
            this.MainForm_GBX.Text = "Emplacement fichier";
            this.CatalogName_LAB.Text = "Catalogue :";            

            this.OpenCatalog_BTN.Enabled = true;
            this.SaveFilesDirectory_BTN.Enabled = true;
            this.SaveFilesDirectory_TBX.Enabled = true;
            this.GenerateCSVFile_BTN.Enabled = false;
            this.GenerateThumbnails_BTN.Enabled = false;
            this.GenerateTranslate_CHB.Enabled = false;
        }
        private void InitMembers()
        {
            appli = null;
            reference = null;

            this.DisposeAllCSVFile();

            sectionCSVManage = null;
            blockCSVManage = null;
            articleCSVManage = null;
            translateCSVManage = null;

            sceneInfo = null;
            catalogFilePath = String.Empty;
            catalogFileName = String.Empty;
            catalogFileDir = String.Empty;
            this.Status_TSPB.Value = 0;
            this.Status_TSSL.Text = KD.StringTools.Const.Zero + KD.StringTools.Const.WhiteSpace + KD.StringTools.Const.Percent;

            spaceIniFile = new KD.Config.IniFile(spaceIniPath);
            kdsdkIniFile = new KD.Config.IniFile(kdsdkIniPath);

            exportDir = spaceIniFile.ReadValue(MainForm.SectionExport, KD.CatalogProperties.Const.KeyDir);
            this.SaveFilesDirectory_TBX.Text = exportDir;
        }

        private void SetMembers()
        {
            reference = new Reference(appli, catalogFilePath);         

            catalogFileName = Path.GetFileName(catalogFilePath);
            string catalogFileNameWithoutExtension = Path.GetFileNameWithoutExtension(catalogFilePath);

            if (!String.IsNullOrEmpty(exportDir))
            {
                catalogFileDir = exportDir;
                exportDir = Path.Combine(catalogFileDir, catalogFileNameWithoutExtension);
                if (!Directory.Exists(catalogFileDir))
                {
                    Directory.CreateDirectory(catalogFileDir);
                }                
            }
            else
            {
                exportDir = Path.Combine(catalogFileDir, catalogFileNameWithoutExtension);                
            }
            if (!Directory.Exists(exportDir))
            {
                Directory.CreateDirectory(exportDir);
            }
            //catalogFileNameWithoutExtension + KD.StringTools.Const.Underscore +
            sectionCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.SectionCSVFileName));
            blockCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.BlockCSVFileName));
            articleCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.ArticleCSVFileName));
            translateCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.TranslateCSVFileName));
            errorCSVFile = new CsvFileWriter(Path.Combine(exportDir, CsvManage.Const.ErrorCSVFileName));

            this.WriteSectionHeader(sectionCSVFile);
            this.WriteBlockHeader(blockCSVFile);
            this.WriteArticleHeader(articleCSVFile);
            this.WriteTranslateHeader(translateCSVFile);
            this.WriteErrorHeader(errorCSVFile);
        }

        private void UpdateForm()
        { 
            this.MainForm_GBX.Text = catalogFilePath;
            this.CatalogName_LAB.Text = "Catalogue : " + reference.CatalogName;

            this.OpenCatalog_BTN.Enabled = false;
            this.SaveFilesDirectory_BTN.Enabled = false;
            this.SaveFilesDirectory_TBX.Enabled = false;
            this.GenerateCSVFile_BTN.Enabled = true;
            this.GenerateThumbnails_BTN.Enabled = true;
            this.GenerateTranslate_CHB.Enabled = true;
            
        }
        private void UpdateSpaceINI()
        {
            catalogFileDir = Path.GetDirectoryName(catalogFilePath);            
           
            spaceIniFile.WriteValue(KD.CatalogProperties.Const.SectionCatalogs, KD.CatalogProperties.Const.KeyDir, catalogFileDir);
            spaceIniFile.WriteValue(MainForm.SectionExport, KD.CatalogProperties.Const.KeyDir, exportDir);            
            
            kdsdkIniFile.WriteValue(MainForm.SectionDebug, KD.CatalogProperties.Const.CatalogsDir, catalogFileDir);
        }
        private void UpdateAppli()
        {
            appli = new Appli(KD.InSitu.Ini.Const.FileNameSpaceIni);
        }

        private void DisposeCSVFile(CsvFileWriter file)
        {
            if (file != null)
            {
                file.Dispose();
            }
            file = null;
        }
        private void DisposeAllCSVFile()
        {
            this.DisposeCSVFile(sectionCSVFile);
            this.DisposeCSVFile(blockCSVFile);
            this.DisposeCSVFile(articleCSVFile);
            this.DisposeCSVFile(translateCSVFile);
            this.DisposeCSVFile(errorCSVFile);
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
        private bool SaveFilesDirectory()
        {
            DialogResult dialogResult = this.SaveFilesDirectory_FBD.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (Directory.Exists(this.SaveFilesDirectory_FBD.SelectedPath))
                {
                    exportDir  = this.SaveFilesDirectory_FBD.SelectedPath;
                    if (!String.IsNullOrEmpty(exportDir))
                    {
                        this.SaveFilesDirectory_TBX.Text = exportDir;
                        return true;
                    }
                }
            }
            return false;
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
                this.WriteBlockInformations();             
                this.WriteArticleInformations();               
            }
            return e.Result;
        }

        private void WriteSectionHeader(CsvFileWriter file)
        {
            CsvManage hearderCSVManage = new CsvManage(file);
            hearderCSVManage.SetSectionHeader();
            file.Flush();          
        }
        private void WriteBlockHeader(CsvFileWriter file)
        {
            CsvManage hearderCSVManage = new CsvManage(file);            
            hearderCSVManage.SetBlockHeader();
            file.Flush();
        }
        private void WriteArticleHeader(CsvFileWriter file)
        {
            CsvManage hearderCSVManage = new CsvManage(file);           
            hearderCSVManage.SetArticleHeader();
            file.Flush();
        }
        private void WriteTranslateHeader(CsvFileWriter file)
        {
            CsvManage hearderCSVManage = new CsvManage(file);
            hearderCSVManage.SetTranslateHeader();
            file.Flush();
        }
        private void WriteErrorHeader(CsvFileWriter file)
        {
            CsvManage hearderCSVManage = new CsvManage(file);
            hearderCSVManage.SetErrorHeader();
            file.Flush();
        }

        private void WriteSectionInformations()
        {
            this.catalogStatus = "Chapitres";
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
            this.DisposeCSVFile(sectionCSVFile);
        }
        private void WriteBlockInformations()
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
                    blockCSVManage = new CsvManage(blockCSVFile, reference, sceneInfo);                   

                    if (blockCSVManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
                    {
                        blockCSVManage.SetBlockRow();
                        blockCSVFile.Flush();
                    }
                    this.Status_BGW.ReportProgress(lineIndex);
                    lineIndex++;
                }
                
            }
            this.DisposeCSVFile(blockCSVFile);           
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
                        //errorCSVManage = new CsvManage(errorCSVFile);

                        if (articleCSVManage.IsSectionValid(reference.Section_Code, reference.Section_Name))
                        {                            
                            articleCSVManage.SetArticlePlacedRow(errorCSVFile);
                            articleCSVFile.Flush();

                            if (GenerateTranslate_CHB.Checked)
                            {
                                translateCSVManage.SetTranslatePlacedRow(errorCSVFile);
                                translateCSVFile.Flush();
                            }
                        }
                        this.Status_BGW.ReportProgress(lineIndex);
                        lineIndex++;
                    }
                }               
            }

            this.DisposeCSVFile(articleCSVFile);
            this.DisposeCSVFile(translateCSVFile);
            this.DisposeCSVFile(errorCSVFile);
        }
      
        private void ExecuteThumbnails()
        {
            if (thumbnailPlug == null)
            {
                thumbnailPlug = new TT.Export.Thumbnails.Plugin();
            }
                     
            thumbnailPlug.ExecuteWebThumbnailExport(String.Empty, String.Empty, String.Empty, String.Empty, true, true, false, catalogFilePath, catalogFileDir);          
        }
     

        // Form
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.InitForm();
            this.InitMembers();
        }         

        private void OpenCatalog_BTN_Click(object sender, EventArgs e)
        {
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
            //this.OpenCatalog_BTN.Enabled = true;
            //this.SaveFilesDirectory_BTN.Enabled = true;
            //this.SaveFilesDirectory_TBX.Enabled = true;
            //this.GenerateCSVFile_BTN.Enabled = true;
            this.GenerateThumbnails_BTN.Enabled = true;
            //this.GenerateTranslate_CHB.Enabled = true;

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
            this.SaveFilesDirectory_BTN.Enabled = false;
            this.SaveFilesDirectory_TBX.Enabled = false;
            this.GenerateCSVFile_BTN.Enabled = false;
            this.GenerateThumbnails_BTN.Enabled = false;
            this.GenerateTranslate_CHB.Enabled = false;

            this.Status_BGW.RunWorkerAsync();
        }

        private void SaveFilesDirectory_BTN_Click(object sender, EventArgs e)
        {
            this.SaveFilesDirectory();
        }

        private void SaveFilesDirectory_TBX_TextChanged(object sender, EventArgs e)
        {
            exportDir = this.SaveFilesDirectory_TBX.Text;
            spaceIniFile.WriteValue(MainForm.SectionExport, KD.CatalogProperties.Const.KeyDir, exportDir);            
        }
    }
}

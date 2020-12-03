using System;
using System.Windows.Forms;
using System.Windows.Input;
using System.ComponentModel;

using KD.CatalogProperties;

namespace TT.Export.Thumbnails
{
    public partial class MainForm : Form
    {
        private KD.SDKComponent.AppliComponent _appli = null;
        private Reference _reference = null;
        //MyKeyboard escapeKey = new MyKeyboard(Key.Space);
        private string _webCatalogURL = String.Empty;

        private string _viewMode;
        private string _xRes;
        private string _yRes;
        private string _backGroundColor;
        private string _antiAliasing;
        private bool _opened;
        private bool _transparency;
        private bool _loopAll;
        private string _loopRefs;

        private int _thumbnailNbs = 0;
        private int _thumbnailNb = 0;

        public string ViewMode
        {
            get { return _viewMode; }
            set { _viewMode = value; }
        }
        public string Xres
        {
            get { return _xRes; }
            set { _xRes = value; }
        }
        public string Yres
        {
            get { return _yRes; }
            set { _yRes = value; }
        }
        public string BackGroundColor
        {
            get { return _backGroundColor; }
            set { _backGroundColor = value; }
        }
        public string AntiAliasing
        {
            get { return _antiAliasing; }
            set { _antiAliasing = value; }
        }
        public bool Opened
        {
            get { return _opened; }
            set { _opened = value; }
        }
        public bool Transparency
        {
            get { return _transparency; }
            set { _transparency = value; }
        }

        public bool LoopAll
        {
            get { return _loopAll; }
            set { _loopAll = value; }
        }

        public string LoopRefs
        {
            get { return _loopRefs; }
            set { _loopRefs = value; }
        }

        public int ThumbnailNbs
        {
            get { return _thumbnailNbs; }
            set { _thumbnailNbs = value; }
        }
        public int ThumbnailNb
        {
            get { return _thumbnailNb; }
            set { _thumbnailNb = value; }
        }

        // ctor
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(KD.SDKComponent.AppliComponent appli, Reference reference, 
                        string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool loopAll, bool executeFromExt = true)
        {
            InitializeComponent();

            _appli = appli;
            _reference = reference;
            InitForm(_reference.CatalogFilePath);
            InitMembers(viewMode, xRes, yRes, antiAliasing, opened, loopAll, executeFromExt);
        }


        // Event
        private void InitForm(string catalogFileName)
        {
            this.Text += KD.StringTools.Const.WhiteSpace + catalogFileName;
            //string[] assemblyFullNameSplit = System.Reflection.Assembly.GetCallingAssembly().ToString().Split(KD.CharTools.Const.Comma);
            //this.version_LAB.Text = assemblyFullNameSplit[1]; // "Version : " + System.Reflection.Assembly.GetCallingAssembly(); //this.ProductVersion;
            this.transparency_CHB.CheckState = CheckState.Checked;
        }
        private void InitMembers(string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool loopAll, bool executeFromExt = true)
        {
            _viewMode = "3D";
            _xRes = "84";
            _yRes = "84";
            _backGroundColor = "255,255,255";
            _antiAliasing = "3";
            _opened = true;
            _transparency = true;
            _loopAll = true;
            _loopRefs = String.Empty;
            _webCatalogURL = _appli.Catalog.GetInfo(KD.SDK.CatalogEnum.InfoId.WEBCATALOG_URL);


            if (executeFromExt)
            {
                _viewMode = viewMode;
                _xRes = xRes;
                _yRes = yRes;                
                _antiAliasing = antiAliasing;
                _opened = opened; 
                _loopAll = loopAll;
            }

            this.DialogResult = DialogResult.None;
        }

        private long Main(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (this.status_BGW.CancellationPending)
            {               
                return 100;
            }
            else
            {
                this.SetParameters();
                //this.UpdateForm(0);
               
                this.status_BGW.ReportProgress(0);
                this.Export(_reference.CatalogFilePath);
                //if (this.Terminate())
                //{
                //    this.UploadToServer();
                //}
                this.DialogCanceled();
                this.EndExport();
            }
            return 100;
        }

        //public void UpdateForm(int thumbnailNb)
        //{
        //    this._thumbnailNb = thumbnailNb;
        //    this.Status_LAB2.Text = "Export Nb: " + this.ThumbnailNb.ToString() + KD.StringTools.Format.Spaced(KD.StringTools.Const.Slatch) + this.ThumbnailNbs.ToString();

        //    //this.Parameters_GBX.Refresh();
        //    this.status_SST.Refresh();
        //    this.Update();
        //    this.Refresh();
        //}

        private void SetParameters()
        {
            if (this.Viewmode2D_RBT.Checked)
            {
                _viewMode = "2D";
            }
            else if (this.Viewmode3D_RBT.Checked)
            {
                _viewMode = "3D";
            }

            _xRes = this.XRes_TBX.Text;
            _yRes = this.YRes_TBX.Text;
            _backGroundColor = this.backGround_TBX.Text;
            _antiAliasing = this.AntiAliasing_TBX.Text;
            _opened = this.Open_RBT.Checked;
            _transparency = this.transparency_CHB.Checked;
            _loopAll = this.LoopAll_RBT.Checked;
            _loopRefs = this.LoopRefs_TBX.Text;
        }

        public void Export(string catalogFileName)
        {
            try
            {
                Export export = new Export(_appli, _reference, catalogFileName, this); 
             
                export.CreateExportDirectory();
                export.ExtractPresentationScene();
                export.LoadPresentationScene(); 

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                this._thumbnailNbs = _reference.BlockLinesNb;

                for (int k = 1; k <= this.ThumbnailNbs; k++)//
                {
                    if (this.status_BGW.CancellationPending)
                    {
                        return;
                    }
                    else
                    {
                        int clusterRank = k - KD.CatalogProperties.Const.ValueToBaseIndex;
                        _reference = new Reference(_appli, clusterRank, 0);

                        for (int m = 1; m <= _reference.Block_ArticleNb; m++)
                        {
                            //this.UpdateForm(k);
                            this.status_BGW.ReportProgress(k);

                            int lineRank = m - KD.CatalogProperties.Const.ValueToBaseIndex;
                            _reference = new Reference(_appli, clusterRank, lineRank);

                            export = new Export(_reference);

                            if (export.IsValid(this.ViewMode) && export.IsGraphic())
                            {
                                if (!this.LoopAll)
                                {
                                    if (!String.IsNullOrEmpty(this.LoopRefs))
                                    {
                                        _loopRefs = _loopRefs.Replace("\r", String.Empty);
                                        _loopRefs = _loopRefs.Replace("\n", String.Empty);

                                        string[] loopRefs = this.LoopRefs.Split(KD.CharTools.Const.SemiColon);
                                        if (loopRefs.Length > 0)
                                        {
                                            foreach (string loopRef in loopRefs)
                                            {
                                                if (_reference.Article_Key == loopRef)
                                                {
                                                    export.ExportDirectImage();
                                                    _loopRefs = _loopRefs.Replace(loopRef, String.Empty);
                                                    _loopRefs = _loopRefs.Replace(";;", ";");
                                                    _loopRefs = _loopRefs.Trim(';');
                                                    _loopRefs = _loopRefs.Trim();
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    export.ExportDirectImage();
                                }
                            }
                        }
                    }
                }

                //this.UpdateForm(this.ThumbnailNbs);  
                this.status_BGW.ReportProgress(this.ThumbnailNbs);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);             
            }
        }

        //private bool Terminate()
        //{
        //    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;

        //    DialogResult dialog = System.Windows.Forms.MessageBox.Show("Terminé." + Environment.NewLine + "Voulez-vous Uploader les vignettes à l'URL suivante ?" +
        //        Environment.NewLine + _webCatalogURL, "Information", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);

        //    if (dialog == DialogResult.Yes && !String.IsNullOrEmpty(_webCatalogURL))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private bool Terminate()
        //{
        //    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;

        //    DialogResult dialog = System.Windows.Forms.MessageBox.Show("Terminé.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

        //    return false;
        //}

        private void UploadToServer()
        {
            string[] webCatUrl = _webCatalogURL.Split(KD.CharTools.Const.QuestionMark);

            try
            {
                //copy not to a url
                System.IO.File.Copy(TT.Export.Thumbnails.Export.exportDir, webCatUrl[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de transfert: " + ex.Message);
                
            }
            
        }

        public void DialogCanceled()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void EndExport()
        {            
            this.Dispose();
            this.Close();
        }

        // Form
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.XRes_TBX.Text = this.Xres;
            this.YRes_TBX.Text = this.Yres;
            this.backGround_TBX.Text = this.BackGroundColor;
            this.AntiAliasing_TBX.Text = this.AntiAliasing;
            this.Open_RBT.Checked = this.Opened;
            this.transparency_CHB.Checked = this.Transparency;

            this.Ok_BTN.Enabled = true;
        }

        private void Ok_BTN_Click(object sender, EventArgs e)
        {
            //this.Main();
            this.Ok_BTN.Enabled = false;
            this.status_BGW.RunWorkerAsync();
        }

        private void Cancel_BTN_Click(object sender, EventArgs e)
        {
            this.status_BGW.CancelAsync();
            this.DialogCanceled();
            this.EndExport();
        }

        private void Transparency_CHB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.transparency_CHB.Checked)
            {
                this.backGround_TBX.Enabled = true;
                this._transparency = false;
            }
            else
            {
                this.backGround_TBX.Enabled = false;
                this._transparency = true;
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)(int)Keys.Escape:
                    {
                        this.CancelForm();
                        break;
                    }
               
            }
        }

        private void Parameters_GBX_Enter(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Escape))
            {
                this.CancelForm();
            }
        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown( Key.Escape))
            {
                this.CancelForm();
            }
        }

        private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (int)Keys.Escape:
                    {
                        this.CancelForm();
                        break;
                    }

            }
        }

        private void CancelForm()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("KD_Voulez-vous vraiment arrêter ?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                this.Cancel_BTN.PerformClick();
            }
        }

        private void Version_LNK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string[] assemblyFullName = System.Reflection.Assembly.GetExecutingAssembly().ToString().Split(KD.CharTools.Const.Comma);
            string[] assemblyVersion = assemblyFullName[1].Split(KD.CharTools.Const.EqualSign);
            MessageBox.Show("Version: " + assemblyVersion[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoopAll_RBT_CheckedChanged(object sender, EventArgs e)
        {
            if (LoopAll_RBT.Checked)
            {
                _loopAll = true;
                this.LoopRefs_TBX.Enabled = false;              
            }
            else
            {
                _loopAll = false;
                this.LoopRefs_TBX.Enabled = true;
            }
        }

        private void status_BGW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            e.Result = this.Main(worker, e); // do your long operation here   
        }

        private void status_BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.status_BGW.CancellationPending)
            {
                this.status_BGW.CancelAsync();
            }
            else
            {
                this._thumbnailNbs = this.ThumbnailNbs;
                this._thumbnailNb = e.ProgressPercentage;//  thumbnailNb;
                this.Status_LAB2.Text = "Export Nb: " + this.ThumbnailNb.ToString() + KD.StringTools.Format.Spaced(KD.StringTools.Const.Slatch) + this.ThumbnailNbs.ToString();
                              
                this.status_SST.Refresh();              
            }
        }

        private void status_BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;

            DialogResult dialog = System.Windows.Forms.MessageBox.Show("Terminé.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

        }

    }

    
    //public class MyKeyboard
    //{
    //    private Key _mykey;
    //    public Key MyKey
    //    {
    //        get
    //        {
    //            return _mykey;
    //        }
    //        set
    //        {
    //            _mykey = value;
    //        }
    //    }

    //    public MyKeyboard(Key mkey)
    //    {
    //        this._mykey = mkey;
    //    }

    //    public bool IsKeyDown()
    //    {
    //        if (Keyboard.IsKeyDown(MyKey)) // || Keyboard.IsKeyUp(MyKey))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //}
}

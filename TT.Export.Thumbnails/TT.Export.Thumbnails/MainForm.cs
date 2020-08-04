using System;
using System.Windows.Forms;
using System.Windows.Input;

using KD.CatalogProperties;

namespace TT.Export.Thumbnails
{
    public partial class MainForm : Form
    {
        private KD.SDKComponent.AppliComponent _appli = null;
        private Reference _reference = null;
        //MyKeyboard escapeKey = new MyKeyboard(Key.Space);

        private string _viewMode;
        private string _xRes;
        private string _yRes;
        private string _backGroundColor;
        private string _antiAliasing;
        private bool _opened;
        private bool _transparency;

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
        public MainForm(KD.SDKComponent.AppliComponent appli, Reference reference, string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool executeFromExt = true)
        {
            InitializeComponent();

            _appli = appli;
            _reference = reference;
            InitForm(_reference.CatalogFileName);
            InitMembers(viewMode, xRes, yRes, antiAliasing, opened, executeFromExt);
        }


        // Event
        private void InitForm(string catalogFileName)
        {
            this.Text += KD.StringTools.Const.WhiteSpace + catalogFileName;
            string[] assemblyFullNameSplit = System.Reflection.Assembly.GetCallingAssembly().ToString().Split(KD.CharTools.Const.Comma);
            this.version_LAB.Text = assemblyFullNameSplit[1]; // "Version : " + System.Reflection.Assembly.GetCallingAssembly(); //this.ProductVersion;
            this.transparency_CHB.CheckState = CheckState.Checked;
        }
        private void InitMembers(string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool executeFromExt = true)
        {
            _viewMode = "3D";
            _xRes = "84";
            _yRes = "84";
            _backGroundColor = "255,255,255";
            _antiAliasing = "3";
            _opened = true;
            _transparency = true;

            if (executeFromExt)
            {
                _viewMode = viewMode;
                _xRes = xRes;
                _yRes = yRes;                
                _antiAliasing = antiAliasing;
                _opened = opened;                
            }


            this.DialogResult = DialogResult.None;
        }

        public void UpdateForm(int thumbnailNb)
        {
            this._thumbnailNb = thumbnailNb;
            this.status_LAB.Text = "Export Nb: " + this.ThumbnailNb.ToString() + KD.StringTools.Format.Spaced(KD.StringTools.Const.Slatch) + this.ThumbnailNbs.ToString();          
            this.Focus();            
            this.Refresh();
          
        }
        
        private void SetParameters()
        {
            if (this.viewmode2D_RBT.Checked)
            {
                _viewMode = "2D";
            }
            else if (this.viewmode3D_RBT.Checked)
            {
                _viewMode = "3D";
            }

            _xRes = this.xRes_TBX.Text;
            _yRes = this.yRes_TBX.Text;
            _backGroundColor = this.backGround_TBX.Text;
            _antiAliasing = this.antiAliasing_TBX.Text;
            _opened = this.open_RBT.Checked;
            _transparency = this.transparency_CHB.Checked;
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
                    int clusterRank = k - KD.CatalogProperties.Const.valueToBaseIndex;
                    _reference = new Reference(_appli, clusterRank, 0);
                                       
                    for (int m = 1; m <= _reference.Block_ArticleNb; m++)
                    {
                        this.UpdateForm(k);

                        int lineRank = m - KD.CatalogProperties.Const.valueToBaseIndex;
                        _reference = new Reference(_appli, clusterRank, lineRank);

                        export = new Export(_reference);

                        if (export.IsValid(this.ViewMode) && export.IsGraphic())
                        {
                            export.ExportDirectImage();
                        }                       
                    }                   

                }

                this.UpdateForm(_thumbnailNbs);
               
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Arrow;

                System.Windows.Forms.MessageBox.Show("Terminé.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //throw;
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
            this.xRes_TBX.Text = this.Xres;
            this.yRes_TBX.Text = this.Yres;
            this.backGround_TBX.Text = this.BackGroundColor;
            this.antiAliasing_TBX.Text = this.AntiAliasing;
            this.open_RBT.Checked = this.Opened;
            this.transparency_CHB.Checked = this.Transparency;
        }

        private void ok_BTN_Click(object sender, EventArgs e)
        {
            this.SetParameters();
            this.UpdateForm(0);
            this.Export(_reference.CatalogFileName);
            this.DialogCanceled();
            this.EndExport();
        }

        private void cancel_BTN_Click(object sender, EventArgs e)
        {
            this.DialogCanceled();
            this.EndExport();
        }

        private void transparency_CHB_CheckedChanged(object sender, EventArgs e)
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

        private void parameters_GBX_Enter(object sender, EventArgs e)
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
                this.cancel_BTN.PerformClick();
            }
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

// ---------------------------------------
// for KD self registration via RegAsm
using System.Runtime.InteropServices;
// ---------------------------------------

using KD.DataHelper;
using KD.Model;
using KD.FilterBuilder;
using KD.Plugin;
using KD.SDKComponent;
using KD.Analysis;
using KD.StringTools;
using KD.CatalogProperties;

namespace TT.Export.Thumbnails
{
    public class Plugin : KD.Plugin.PluginBase
    { 
        
        Reference reference = null;
        string exportDir = String.Empty;

        public MainForm mainForm = null;        

        #region // properties
        private KD.Plugin.MobiscriptMenuItem _thumbnailExportMenu = null;
        public KD.Plugin.MobiscriptMenuItem ThumbnailExportMenu
        {
            get
            {
                return _thumbnailExportMenu;
            }
            set
            {
                _thumbnailExportMenu = value;
            }
        }

        
        #endregion

        public Plugin()
            : base(true)
        {
            
        }

        new public bool OnAppStartAfter(int iCallParamsBlock)
        {
            this.Start(iCallParamsBlock);
            return true;
        }

        protected override bool Start(int iCallParamsBlock)
        {
            bool bStart = base.Start(iCallParamsBlock);
            this.AddMenus();

            return bStart;
        }
        private bool AddMenus()
        {

            this.ThumbnailExportMenu = new KD.Plugin.MobiscriptMenuItem((int)KD.SDK.AppliEnum.MobiScriptCatalogMenuItemsId.DRAW ,
                                                                                        "Web Catalogue",
                                                                                        base.AssemblyFileName,
                                                                                        KD.Plugin.Const.PluginClassName,
                                                                                        "Main");
            //this.ThumbnailExportMenu.AccelControlKey = KD.SDK.AppliEnum.ControlKey.;
            //this.ThumbnailExportMenu.AccelKeyCode = KD.SDK.AppliEnum.VirtualKeyCode.;

            this.ThumbnailExportMenu.Insert(this.CurrentAppli);
            //this.ThumbnailExportMenu.Enable(this.CurrentAppli, false); //IT DOESNT WORK FOR MOBISCRIPT BUT OK FOR INSITU          

            return true;
        }

        public bool Main(int iCallParamsBlock)
        {
            this.ExecuteWebThumbnailExportInside(String.Empty, String.Empty, String.Empty, String.Empty, true, true);

            return true;
        }       
       
        public bool ExecuteWebThumbnailExportInside(string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool loopAll)
        {
            this.ExecuteWebThumbnail(viewMode, xRes, yRes, antiAliasing, opened, loopAll, false, String.Empty, String.Empty);
            return true;
        }
        public bool ExecuteWebThumbnailExport(string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool loopAll, bool executeFromExt, string catalogFilePath = "", string path = "")
        {
            this.ExecuteWebThumbnail(viewMode, xRes, yRes, antiAliasing, opened, loopAll, executeFromExt, catalogFilePath, path);
            return true;
        }
        public bool ExecuteWebThumbnail(string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool loopAll, bool executeFromExt, string catalogFilePath = "", string path = "")
        {
            if (String.IsNullOrEmpty(catalogFilePath))
            {
                reference = new KD.CatalogProperties.Reference(this.CurrentAppli, this.CurrentAppli.MobiScriptCatalogGetInfo(KD.SDK.AppliEnum.MSCatalogInfoId.FILENAME));
            }
            else
            {
                reference = new KD.CatalogProperties.Reference(this.CurrentAppli, catalogFilePath);
            }

            if (string.IsNullOrEmpty(reference.CatalogFilePath))
            {
                System.Windows.Forms.MessageBox.Show("Vous devez ouvrir un catalogue !", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                //System.Windows.Forms.MessageBox.Show(MessageFormTranslate.TranslateText(PlugTextConst.PLUGMSG02TEXT),
                //    MessageFormTranslate.TranslateText(PlugTextConst.PLUGMSG01TEXT), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                this.InitializeMainForm(viewMode, xRes, yRes, antiAliasing, opened, loopAll, executeFromExt, path);
                this.ShowMainForm(executeFromExt);
            }
            return true;
        }

        private void InitializeMainForm(string viewMode, string xRes, string yRes, string antiAliasing, bool opened, bool loopAll, bool executeFromExt = true, string path = "")
        {
            if (this.mainForm == null)
            {
                this.mainForm = new MainForm(this.CurrentAppli, reference, viewMode, xRes, yRes, antiAliasing, opened, loopAll, executeFromExt, path);
            }           
        }
        private void ShowMainForm(bool executeFromExt = true )
        {
            if (!executeFromExt)
            {
                this.mainForm.ShowDialog();    // this.CurrentAppli.GetNativeIWin32Window()           
            }
            else
            {
                this.mainForm.Export(reference.CatalogFilePath);
                this.mainForm.DialogCanceled();
            }

            if (this.mainForm.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                this.mainForm = null;
            }
        }      
        
    }
  
}

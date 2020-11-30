using System;
using System.Drawing;
using System.Collections.Generic;

using KD.CatalogProperties;

namespace TT.Export.Thumbnails
{
    public class Export// : KD.Plugin.PluginBase
    {
        private const string SceneExtension = ".scn";
        private const string leftHanding = "G";
        private const string rightHanding = "D";
        private const string _2D = "2D";
        private const string _3D = "3D";
        private const string _2DEqual = "2D=";
        private const string _3DEqual = "3D=";
        private const string moy_Vignette = "moy1";
        private const string big_Vignette = "big1";

        private static KD.SDKComponent.AppliComponent _appli = null;
        
        public static string exportDir = String.Empty;
        private static string _exportByResDir = String.Empty;
        private static int jpegQuality = 100;
        private static string extension = KD.IO.File.Extension.Png;
        private static int handing = (int)KD.SDK.SceneEnum.HandingType.NONE;
        private static KD.SDK.SceneEnum.ViewMode viewMode = KD.SDK.SceneEnum.ViewMode.OGLREAL;

        private static string _viewModeAsString;
        private static int _xRes; //440; //188;
        private static int _yRes; //440; //188;
        private static string _backGroundColor; //= "255,255,255";        
        private static int _antiAliasing; // = 2;        
        private static bool _opened; // = true;
        private static bool _transparency; // = true;

        private List<string> imageDoneList = new List<string>();

        #region // properties
        private Reference _reference;
        public Reference Reference
        {
            get
            {
                return _reference;
            }
            set
            {
                _reference = value;
            }
        }

        private static string _catalogFileName;
        public static string CatalogFileName
        {
            get
            {
                return _catalogFileName;
            }
            set
            {
                _catalogFileName = value;
            }
        }
        #endregion

        #region // ctor
        public Export(KD.SDKComponent.AppliComponent appli, Reference reference, string catalogFileName, MainForm mainForm) 
        {
            _appli = appli;
            _reference = reference;
            _catalogFileName = catalogFileName;

            this.InitMembers(mainForm);
        }
        public Export(Reference reference)
        {
            this.imageDoneList.Clear();
            this._reference = reference;
        }
        private void InitMembers(MainForm mainForm)
        {
            _viewModeAsString = mainForm.ViewMode;
            if (_viewModeAsString.ToUpper() == Export._2D)
            {
                Export.viewMode = KD.SDK.SceneEnum.ViewMode.TOP;
            }
            else if (_viewModeAsString.ToUpper() == Export._3D)
            {
                Export.viewMode = KD.SDK.SceneEnum.ViewMode.OGLREAL;
            }

            _xRes = System.Convert.ToInt32(mainForm.Xres);
            _yRes = System.Convert.ToInt32(mainForm.Yres);
            _backGroundColor = mainForm.BackGroundColor;
            _antiAliasing = System.Convert.ToInt32(mainForm.AntiAliasing);
            _opened = mainForm.Opened;
            _transparency = mainForm.Transparency;

            //_exportByResDir = CatalogFileName + KD.StringTools.Const.Underscore + _xRes + "x" + _yRes;
            string bigOrmoy = _xRes + "x" + _yRes;

            if (_xRes == 84 && _yRes == 84)
            {
                bigOrmoy = moy_Vignette;
            }
            else if (_xRes == 220 && _yRes == 220)
            {
                bigOrmoy = big_Vignette;
            }
            _exportByResDir = System.IO.Path.Combine(CatalogFileName, bigOrmoy);
        }
        #endregion
       
        public bool ExtractPresentationScene()
        {
            string CatalogFileNamePath = System.IO.Path.Combine(_appli.CatalogDir, CatalogFileName) + KD.CatalogProperties.Const.catalogExtension;
            string SceneFileNamePath = System.IO.Path.Combine(_appli.CatalogDir, CatalogFileName) + SceneExtension;
            bool ok = _appli.CatalogExportResourceFromName(CatalogFileNamePath, SceneFileNamePath, true);
            //bool ok = _appli.Catalog.FileExportResourceFromName(SceneFileNamePath, true);

            return ok;
        }

        public bool LoadPresentationScene()
        {
            bool ok = false;
            string CatalogFileNamePath = System.IO.Path.Combine(_appli.CatalogDir, CatalogFileName) + KD.CatalogProperties.Const.catalogExtension;
            if (System.IO.File.Exists(CatalogFileNamePath))
            {
                ok = _appli.Scene.FileLoadCatalogScene(CatalogFileNamePath);
            }
            return ok;
        }


        public bool ExportDirectImage() //int clusterRank, int lineRank
        {
            bool result = false;
            string reference = this.Reference.Article_Key;
            string referenceKey = this.ReplaceProhibitedCharacter(reference);
            string file = System.IO.Path.Combine(exportDir, referenceKey + extension);

            int articleRank = _appli.Catalog.TableGetLineRankFromName(KD.SDK.CatalogEnum.TableId.ARTICLES, (int)KD.SDK.CatalogEnum.ClusterRankType.CLUSTER_FROM_ITEM, 0, reference, false);

            if (!imageDoneList.Contains(reference + KD.StringTools.Const.SemiColon + Export.leftHanding))
            {
                result = (_appli.Catalog.FileExportImage(articleRank,
                                                            _opened,
                                                            viewMode,
                                                            file,
                                                            _xRes,
                                                            _yRes,
                                                            _backGroundColor,
                                                            _transparency,
                                                            jpegQuality,
                                                            _antiAliasing));

                this.imageDoneList.Add(reference + KD.StringTools.Const.SemiColon + this.Reference.Article_Hinge);
            }            


            if (_viewModeAsString.ToUpper() == Export._2D)
            {
                try
                {
                    Bitmap bitmap = (Bitmap)Bitmap.FromFile(file);
                    if (bitmap != null)
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(file);
                        //PictureBox1.Image = bitmap1;
                    }

                }
                catch (System.IO.FileNotFoundException)
                {
                    //System.Windows.Forms.MessageBox.Show("There was an error." +
                    //    "Check the path to the bitmap.");
                }
            }

            return result;
        }

        public bool IsValid(string form)
        {
            if (this.Reference.Section_Name.StartsWith(KD.CatalogProperties.Const.arobase))
            {
                return false;
            }
            if (form == Export._3D && (this.Reference.Article_Width == 0 || this.Reference.Article_Depth == 0 || this.Reference.Article_Height == 0))
            {
                return false;
            }
            if (form == Export._2D && (this.Reference.Article_Width == 0 || this.Reference.Article_Depth == 0))
            {
                return false;
            }
            if (String.IsNullOrEmpty(this.Reference.Article_Key))
            {
                return false;
            }
            return true;
        }
        public bool IsGraphic()
        {
            string script = this.Reference.Block_Script;
           
            // begin a script with exclamation will not do a graphic
            if (script.StartsWith(KD.StringTools.Const.ExclamationMark) && !script.ToUpper().Contains(KD.StringTools.Const.Ampersand))
            {
                return false;
            }

            // begin a script with Ampersand will do a graphic
            //if (script.StartsWith(KD.StringTools.Const.Ampersand))
            //{
            //    return false;
            //}

            //// begin a script with "Text" will do a graphic if the next contain 2D or 3D or &
            //if ((script.ToUpper().StartsWith("TEXT") && !script.ToUpper().Contains(KD.StringTools.Const.Ampersand)) &&
            //    (script.ToUpper().StartsWith("TEXT") && !script.ToUpper().Contains(Export._2DEqual.ToUpper())) &&
            //    (script.ToUpper().StartsWith("TEXT") && !script.ToUpper().Contains(Export._3DEqual.ToUpper())))
            //{
            //    return false;
            //}

            return true;
        }

        public void CreateExportDirectory()
        {
            if (!this.IsDirectoryExist())
            {
                exportDir = this.CreateDirectory();
            }
            else
            {
                exportDir = System.IO.Path.Combine(_appli.CatalogDir, _exportByResDir);
            }
        }
        private bool IsDirectoryExist()
        {
            
            if (System.IO.Directory.Exists(System.IO.Path.Combine(_appli.CatalogDir, _exportByResDir)))
            {
                return true;
            }
            return false;
        }
        private string CreateDirectory()
        {
            string dir = System.IO.Path.Combine(_appli.CatalogDir, _exportByResDir);
            System.IO.Directory.CreateDirectory(dir);

            return dir;
        }

        private string ReplaceProhibitedCharacter(string nameToCheck) // "\\", "/", ":", "\"", "*", "?", "<", ">", "|", "=", ".", ","   KD.StringTools.Const.Dot,
        {
            string[] ProhibitedCharacterList = new string[] { KD.StringTools.Const.BackSlatch, KD.StringTools.Const.Slatch, KD.StringTools.Const.Colon, KD.StringTools.Const.DoubleQuote,
                KD.StringTools.Const.Wildcard, "?", KD.StringTools.Const.StrictlyInferiorSign, KD.StringTools.Const.StrictlySuperiorSign, KD.StringTools.Const.Pipe, KD.StringTools.Const.EqualSign,
                KD.StringTools.Const.Comma };

            try
            {
                foreach (string car in ProhibitedCharacterList)
                {
                    if (nameToCheck.Contains(car))
                    {
                        nameToCheck = nameToCheck.Replace(car, KD.StringTools.Const.Underscore);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            return nameToCheck;
        }

    }
}

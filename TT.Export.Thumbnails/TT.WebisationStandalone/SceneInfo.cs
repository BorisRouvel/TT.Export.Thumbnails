using System;
using System.Collections.Generic;
using System.IO;

using KD.CatalogProperties;
using KD.DicoHelper;
using KD.CsvHelper;

namespace TT.WebisationStandalone
{
    public class SceneInfo
    {
        private Reference _reference = null;       

        private string isDimXvar = String.Empty;
        private string isDimYvar = String.Empty;
        private string isDimZvar = String.Empty;
        private string topic = String.Empty;
        private string layer = String.Empty;
        private string type = String.Empty;
        private string blockCode = String.Empty;
        private string name = String.Empty;

        private string nameLng = String.Empty;
        private string[] lngSRC = new string[DicoRow.AllLanguagesCode.Count + 1];
        private string[] lngENG = new string[DicoRow.AllLanguagesCode.Count + 1];

        private string translateCatalogName = String.Empty;
        private string translateSectionName = String.Empty;
        private string translateBlockName = String.Empty;
        private string translateBlockDescription = String.Empty;
        private string translateModelName = String.Empty;
        private string translateModelFinishName = String.Empty;
        private string translateFamilyName = String.Empty;
        private string translateFamilyFinishName = String.Empty;

        public SceneInfo(Reference reference)
        {
            _reference = reference;
        }

        private void InitSceneObjectInfo()
        {
            isDimXvar = String.Empty;
            isDimYvar = String.Empty;
            isDimZvar = String.Empty;
            topic = String.Empty;
            layer = String.Empty;
            type = String.Empty;
            blockCode = String.Empty;
            name = String.Empty;
        }
        private void InitSceneLanguageObjectInfo()
        {
            translateCatalogName = String.Empty;
            translateSectionName = String.Empty;
            translateBlockName = String.Empty;
            translateBlockDescription = String.Empty;
            translateModelName = String.Empty;
            translateModelFinishName = String.Empty;
            translateFamilyName = String.Empty;
            translateFamilyFinishName = String.Empty;

            nameLng = String.Empty;
        }
        private void SetSceneObjectInfo(int objId)
        {
            isDimXvar = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.ISDIMXVAR);
            isDimYvar = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.ISDIMYVAR);
            isDimZvar = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.ISDIMZVAR);
            topic = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.TOPIC);
            layer = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.LAYER);
            type = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.TYPE);
            blockCode = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.BLOCKCODE);
            name = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.NAME);
        }

        private string SetTranslate(int index, string language, string src, string tmp)
        {
            string lang = String.Empty;

            if (language == _reference.CatalogLanguage) //Source catalog language
            {
                lngSRC[index] = src;
                lang = src;
            }

            if (language == DicoRow.AllLanguagesCode[2]) //ENG
            {
                lngENG[index] = tmp;
                if (lngSRC[index] != lngENG[index])
                {
                    lang = tmp;
                }
            }

            if (lngSRC[index] != src || lngENG[index] != tmp)
            {
                lang = tmp;
            }
            return lang;
        }
        private void SetSceneLanguageObjectInfo(int objId, string language)
        {
            translateCatalogName = this.SetTranslate(0, language, SetTranslateCatalogName(objId, _reference.CatalogLanguage), SetTranslateCatalogName(objId, language));
            translateSectionName = this.SetTranslate(1, language, SetTranslateSectionName(objId, _reference.CatalogLanguage), SetTranslateSectionName(objId, language));
            translateBlockName = this.SetTranslate(2, language, SetTranslateBlockName(objId, _reference.CatalogLanguage), SetTranslateBlockName(objId, language));
            translateBlockDescription = this.SetTranslate(3, language, SetTranslateBlockDescription(objId, _reference.CatalogLanguage), SetTranslateBlockDescription(objId, language));
        }

        private string SetTranslateCatalogName(int objId, string language)
        {
            bool bLng = _reference.CurrentAppli.SetLanguage(language);
            return _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.CATALOGNAME);        
        }
        private string SetTranslateSectionName(int objId, string language)
        {
            bool bLng = _reference.CurrentAppli.SetLanguage(language);
            return _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.SECTIONNAME);
        }
        private string SetTranslateBlockName(int objId, string language)
        {
            bool bLng = _reference.CurrentAppli.SetLanguage(language);
            return _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.NAME);           
        }
        private string SetTranslateBlockDescription(int objId, string language)
        {
            bool bLng = _reference.CurrentAppli.SetLanguage(language);
            return _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.DESCRIPTION);        
        }

        private void CreateScene()
        {
            MainForm.IsSceneCreate = _reference.CurrentAppli.Scene.FileNew((int)KD.SDK.CatalogEnum.UnitId.MILLIMETRE, 1000, 1000, 2500);

            if (MainForm.IsSceneCreate)
            {
                string lng = _reference.CatalogLanguage;
                bool bLng = _reference.CurrentAppli.SetLanguage(lng);
            }
        }
        private int PlaceObject()
        {
            int objId = KD.Const.UnknownId;
            int select = 0;            

            if (MainForm.IsFirstPlaceObject)
            {
                MainForm.IsFirstPlaceObject = false;

                int thickNess = _reference.Article_Depth;
                if (thickNess <= 1)
                {
                    thickNess = 150;
                }
                int wallId = _reference.CurrentAppli.Scene.EditPlaceWalls(thickNess, 4000, "-5000,0,0,0;5000,0,0,0"); // "x1,y1,z1,t1;x2,y2,z2,t2"

                objId = _reference.CurrentAppli.Scene.EditPlaceObject(_reference.CatalogFileName,
                                                                  _reference.Article_Key,
                                                                  _reference.GetHinge(),
                                                                  _reference.Article_Width,
                                                                  _reference.Article_Depth,
                                                                  _reference.Article_Height,
                                                                  0,
                                                                  0,
                                                                  (int)_reference.Block_Altitude,
                                                                  _reference.Block_PoseOnorUnderIndex,
                                                                  0.0,
                                                                  false,
                                                                  false,
                                                                  false);
                if (objId != KD.Const.UnknownId)
                {
                    select = _reference.CurrentAppli.Scene.ObjectSelect(objId, false);
                    if (select == KD.Const.True)
                    {
                        MainForm.SelectId = objId;
                    }
                }               
            }
            else
            {
                if (MainForm.SelectId != KD.Const.UnknownId)
                {
                    select = _reference.CurrentAppli.Scene.ObjectSelect(MainForm.SelectId, false);
                }

                if (select == KD.Const.True)
                {
                    bool bReplace = _reference.CurrentAppli.Scene.EditReplaceSelection(_reference.CatalogFileName,
                                                                              _reference.Article_Key,
                                                                              _reference.GetHinge(),
                                                                              _reference.Article_Width,
                                                                              _reference.Article_Depth,
                                                                              _reference.Article_Height,
                                                                              false);

                    if (bReplace)
                    {
                        objId = _reference.CurrentAppli.Scene.GetActiveObject();
                        select = _reference.CurrentAppli.Scene.ObjectSelect(objId, false);
                        if (select == KD.Const.True)
                        {
                            MainForm.SelectId = objId;
                        }
                    }
                    else
                    {
                        MainForm.IsFirstPlaceObject = true;
                        objId = this.PlaceObject();
                    }
                }
            }

            if (objId == -1)
            {
                bool bSave = _reference.CurrentAppli.Scene.FileSave(@"d:\ic90dev\bmp\webscene.scn");
            }
            return objId;
        }

        public bool GenerateSceneInformations(string language = "")
        {
            this.InitSceneObjectInfo();

            if (!MainForm.IsSceneCreate)
            {
                this.CreateScene();
            }

            if (MainForm.IsSceneCreate)
            {
                bool bLng = _reference.CurrentAppli.SetLanguage(DicoRow.AllLanguagesCode[1]); //FRA

                int objId = this.PlaceObject();

                if (objId != KD.Const.UnknownId)
                {
                    if (String.IsNullOrEmpty(language))
                    {
                        this.SetSceneObjectInfo(objId);
                    }
                    else
                    {
                        this.InitSceneLanguageObjectInfo();
                        this.SetSceneLanguageObjectInfo(objId, language);
                    }
                    return true;
                }
            }
            return false;
        }
        public List<string> ArticleRow()
        {
            List<string> list = new List<string>(0);

            list.Add(isDimXvar);
            list.Add(isDimYvar);
            list.Add(isDimZvar);
            list.Add(topic);
            list.Add(layer);
            list.Add(type);
            list.Add(blockCode);
            list.Add(name);

            return list;
        }
        public List<string> TranslateCatalogNameRow()
        {
            List<string> list = new List<string>(0);

            list.Add(translateCatalogName);
            //list.Add(translateModelName);
            //list.Add(translateModelFinishName);
            //list.Add(translateFamilyName);
            //list.Add(translateFamilyFinishName);  

            return list;
        }
        public List<string> TranslateSectionNameRow()
        {
            List<string> list = new List<string>(0);

            list.Add(translateSectionName);

            return list;
        }
        public List<string> TranslateBlockNameRow()
        {
            List<string> list = new List<string>(0);

            list.Add(translateBlockName);

            return list;
        }
        public List<string> TranslateBlockDescriptionRow()
        {
            List<string> list = new List<string>(0);

            translateBlockDescription = translateBlockDescription.Replace("\r\n", "///");
            list.Add(translateBlockDescription);

            return list;
        }

    }
}

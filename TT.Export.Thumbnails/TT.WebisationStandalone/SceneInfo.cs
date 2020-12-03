using System;

using KD.CatalogProperties;
using KD.CsvHelper;
using KD.DicoHelper;

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
        private string blocCode = String.Empty;
        private string name = String.Empty;

        private string lngSRCName = String.Empty;
        private string lngENGName = String.Empty;

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
            blocCode = String.Empty;
            name = String.Empty;
            
        }
        private void SetSceneObjectInfo(int objId)
        {
            isDimXvar = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.ISDIMXVAR);
            isDimYvar = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.ISDIMYVAR);
            isDimZvar = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.ISDIMZVAR);
            topic = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.TOPIC);
            layer = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.LAYER);
            type = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.TYPE);
            blocCode = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.BLOCKCODE);
           
        }
        private void SetSceneLanguageObjectInfo(int objId, string language)
        {
            bool bLngSrc = _reference.CurrentAppli.SetLanguage(_reference.CatalogLanguage);
            string nameSrc = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.NAME);

            bool bLng = _reference.CurrentAppli.SetLanguage(language);
            string nameTmp = _reference.CurrentAppli.Scene.ObjectGetInfo(objId, KD.SDK.SceneEnum.ObjectInfo.NAME);

            if (language == _reference.CatalogLanguage) //Source catalog language
            {
                lngSRCName = nameSrc;
                name = nameSrc;
            }

            if (language == DicoRow.AllLanguagesCode[2]) //ENG
            {
                lngENGName = nameTmp;
                if (lngSRCName != lngENGName)
                {
                    name = nameTmp;
                }
            }
           
            if (lngSRCName != nameSrc || lngENGName != nameTmp)
            {
                name = nameTmp;
            }            
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
            return _reference.CurrentAppli.Scene.EditPlaceObject(_reference.CatalogFileName,
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
        }

        public void GenerateSceneInformations(string language = "")
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
                        this.SetSceneLanguageObjectInfo(objId, language);
                    }
                }
            }
        }
        public CsvRow SetForArticleRow(CsvRow row)
        {
            row.Add(isDimXvar);
            row.Add(isDimYvar);
            row.Add(isDimZvar);
            row.Add(topic);
            row.Add(layer);
            row.Add(type);
            row.Add(blocCode);           

            return row;
        }
        public CsvRow SetLanguageForArticleRow(CsvRow row)
        {           
            row.Add(name);

            return row;
        }

    }
}

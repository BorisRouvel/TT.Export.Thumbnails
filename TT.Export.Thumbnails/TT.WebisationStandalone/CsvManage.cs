using System;
using System.Collections.Generic;

using KD.CatalogProperties;
using KD.CsvHelper;
using KD.DicoHelper;

namespace TT.WebisationStandalone
{
    public class CsvManage
    {
        public class Const
        {
            public const string sectionCSVFileName = "SECTION.csv";
            public const string blocCSVFileName = "BLOC.csv";
            public const string articleCSVFileName = "ARTICLE.csv";
            public const string translateCSVFileName = "TRANSLATE.csv";

            public const string scriptCode_URL = "@URL";
        }

        private static List<string> langSourceList = new List<string>();

        private Reference _reference = null;
        private CsvFileWriter _csvFile = null;
        private SceneInfo _sceneInfo = null;
     
        private CsvRow catalogRow = null;
        private CsvRow sectionRow = null;
        private CsvRow blocRow = null;
        private CsvRow articleRow = null;
        //private CsvRow translateRow = null;
        private CsvRow translateCatalogNameRow = null;
        private CsvRow translateSectionNameRow = null;
        private CsvRow translateBlocNameRow = null;
        private CsvRow translateBlocDescriptionRow = null;


        public CsvManage(CsvFileWriter csvFile, Reference reference, SceneInfo sceneInfo)
        {
            _csvFile = csvFile;
            _reference = reference;
            _sceneInfo = sceneInfo;
           
            this.InitMembers();
        }

        private void InitMembers()
        {             
            catalogRow = null;
            sectionRow = null;
            blocRow = null;
            articleRow = null;
            //translateRow = null;
            translateCatalogNameRow = null;
            translateSectionNameRow = null;
            translateBlocNameRow = null;
            translateBlocDescriptionRow = null;
        }       

         public bool IsSectionValid(string sectionCode, string sectionName)
        {
            //!sectionCode.StartsWith(KD.CatalogProperties.Const.arobase) &&  && !sectionName.StartsWith(KD.CatalogProperties.Const.arobase)

            if (!String.IsNullOrEmpty(sectionName))
            {
                return true;
            }
            return false;
        }

        public void SetCatalogRow()
        {
            catalogRow = new CsvRow();

            catalogRow.Add(_reference.CatalogName);
            catalogRow.Add(_reference.CatalogFileName);

            _csvFile.WriteRow(catalogRow);
        }
        public void SetSectionRow()
        {
            sectionRow = new CsvRow();

            sectionRow.Add(_reference.Section_Name);
            sectionRow.Add(_reference.Section_Code);

            _csvFile.WriteRow(sectionRow);
        }
        public void SetBlockRow()
        {
            blocRow = new CsvRow();

            blocRow.Add(_reference.Block_Code);

            string script = _reference.Block_Script;
            string url = String.Empty;
            if (script.ToLower().Contains(CsvManage.Const.scriptCode_URL.ToLower()))
            {
                url = KD.StringTools.Helper.Extract(script.ToLower(), CsvManage.Const.scriptCode_URL.ToLower(), KD.StringTools.Const.BraceOpen, KD.StringTools.Const.BraceClose);
            }
            blocRow.Add(url);

            blocRow.Add(_reference.Block_Altitude.ToString());
            blocRow.Add(_reference.Block_PoseOnorUnderIndex.ToString());
            blocRow.Add(_reference.Section_Name);

            _csvFile.WriteRow(blocRow);
        }
        public void SetArticlePlacedRow()
        {
            articleRow = new CsvRow();

            articleRow.Add(_reference.Article_Key);
            articleRow.Add(_reference.Article_Hinge);
            articleRow.Add(_reference.Article_Width.ToString());
            articleRow.Add(_reference.Article_Depth.ToString());
            articleRow.Add(_reference.Article_Height.ToString());

            _sceneInfo.GenerateSceneInformations();
            articleRow.AddRange(_sceneInfo.ArticleRow());
            
            _csvFile.WriteRow(articleRow);
        }
        public void SetTranslatePlacedRow()
        {
            translateCatalogNameRow = new CsvRow();
            translateSectionNameRow = new CsvRow();
            translateBlocNameRow = new CsvRow();
            translateBlocDescriptionRow = new CsvRow();

            foreach (string language in DicoRow.AllLanguagesCode)
            {
                if (language != DicoRow.AllLanguagesCode[0])
                {
                    _sceneInfo.GenerateSceneInformations(language);
                    translateCatalogNameRow.AddRange(_sceneInfo.TranslateCatalogNameRow());
                    translateSectionNameRow.AddRange(_sceneInfo.TranslateSectionNameRow());
                    translateBlocNameRow.AddRange(_sceneInfo.TranslateBlocNameRow());
                    translateBlocDescriptionRow.AddRange(_sceneInfo.TranslateBlocDescriptionRow());                    
                }
            }

            this.WriteTranslateRow(translateCatalogNameRow);
            this.WriteTranslateRow(translateSectionNameRow);
            this.WriteTranslateRow(translateBlocNameRow);
            this.WriteTranslateRow(translateBlocDescriptionRow);
        }
        private void WriteTranslateRow(CsvRow row)
        {
            if (!langSourceList.Contains(row[0]))
            {
                langSourceList.Add(row[0]);
                _csvFile.WriteRow(row);
            }
        }

    }

}

using System;
using System.IO;

using KD.CatalogProperties;
using KD.CsvHelper;
using KD.DicoHelper;

namespace TT.WebisationStandalone
{
    public class CsvManage
    {
        public class Const
        {
            public const string csvFileName = "WebInfo.csv";
            public const string scriptCode_URL = "@URL";
        }

        private Reference _reference = null;
        private CsvFileWriter _csvFile = null;
        private SceneInfo _sceneInfo = null;
     
        private CsvRow catalogRow = null;
        private CsvRow sectionRow = null;
        private CsvRow blocRow = null;
        private CsvRow articleRow = null;
        

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
        public void SetArticleRow()
        {
            articleRow = new CsvRow();

            articleRow.Add(_reference.Article_Key);
            articleRow.Add(_reference.Article_Hinge);
            articleRow.Add(_reference.Article_Width.ToString());
            articleRow.Add(_reference.Article_Depth.ToString());
            articleRow.Add(_reference.Article_Height.ToString());

            _sceneInfo.GenerateSceneInformations();
            articleRow = _sceneInfo.SetForArticleRow(articleRow);

            foreach (string language in DicoRow.AllLanguagesCode)
            {
                if (language != DicoRow.AllLanguagesCode[0])
                {
                    _sceneInfo.GenerateSceneInformations(language);
                    articleRow = _sceneInfo.SetLanguageForArticleRow(articleRow);                  
                }
            }
            _csvFile.WriteRow(articleRow);
        }

    }

}

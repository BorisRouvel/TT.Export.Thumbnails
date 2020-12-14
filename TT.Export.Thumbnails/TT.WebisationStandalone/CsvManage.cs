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
            public const string SectionCSVFileName = "SECTION.csv";
            public const string BlockCSVFileName = "BLOCK.csv";
            public const string ArticleCSVFileName = "ARTICLE.csv";
            public const string TranslateCSVFileName = "TRANSLATE.csv";
            public const string ErrorCSVFileName = "ERROR.csv";

            public const string ScriptCode_URL = "@URL";
        }

        public class SectionHeader
        {
            public const string Name = "Name";
            public const string Code = "Code";
        }
        public class BlockHeader
        {            
            public const string Code = "Code";
            public const string Url = "Url";
            public const string PositionZ = "PositionZ";
            public const string On_Or_Under = "On_Or_Under";
            public const string Section = "Section";
        }
        public class ArticleHeader
        {
            public const string KeyRef = "KeyRef";
            public const string Handing = "Handing";
            public const string DimensionX = "DimensionX";
            public const string DimensionY = "DimensionY";
            public const string DimensionZ = "DimensionZ";

            public const string IsDimensionXVariable = "IsDimensionXVariable";
            public const string IsDimensionYVariable = "IsDimensionYVariable";
            public const string IsDimensionZVariable = "IsDimensionZVariable";
            public const string Topic = "Topic";
            public const string Layer = "Layer";
            public const string Type = "Type";
            public const string BlockCode = "BlockCode";
            public const string Name = "Name";
        }
        public class TranslateHeader
        {
            public const string CatalogName = "CatalogName";
            public const string SectionName = "SectionName";
            public const string BlockName = "BlockName";
            public const string BlockDescription = "BlockDescription";
        }

        private static List<string> langSourceList = new List<string>();

        private Reference _reference = null;
        private CsvFileWriter _csvFile = null;
        private SceneInfo _sceneInfo = null;
     
        private CsvRow catalogRow = null;
        private CsvRow sectionRow = null;
        private CsvRow blockRow = null;
        private CsvRow articleRow = null;       
        private CsvRow translateCatalogNameRow = null;
        private CsvRow translateSectionNameRow = null;
        private CsvRow translateBlockNameRow = null;
        private CsvRow translateBlockDescriptionRow = null;


        public CsvManage(CsvFileWriter csvFile)
        {
            _csvFile = csvFile;

            this.InitMembers();
        }
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
            blockRow = null;
            articleRow = null;           
            translateCatalogNameRow = null;
            translateSectionNameRow = null;
            translateBlockNameRow = null;
            translateBlockDescriptionRow = null;
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

        public void SetCatalogHeader()
        {
            catalogRow = new CsvRow();

            catalogRow.Add(_reference.CatalogName);
            catalogRow.Add(_reference.CatalogFileName);

            _csvFile.WriteRow(catalogRow);
        }
        public void SetCatalogRow()
        {
            catalogRow = new CsvRow();

            catalogRow.Add(_reference.CatalogName);
            catalogRow.Add(_reference.CatalogFileName);

            _csvFile.WriteRow(catalogRow);
        }

        public void SetSectionHeader()
        {
            sectionRow = new CsvRow();

            sectionRow.Add(SectionHeader.Name);
            sectionRow.Add(SectionHeader.Code);

            _csvFile.WriteRow(sectionRow);
        }
        public void SetSectionRow()
        {
            sectionRow = new CsvRow();

            sectionRow.Add(_reference.Section_Name);
            sectionRow.Add(_reference.Section_Code);

            _csvFile.WriteRow(sectionRow);
        }

        public void SetBlockHeader()
        {
            blockRow = new CsvRow();

            blockRow.Add(BlockHeader.Code);          
            blockRow.Add(BlockHeader.Url);
            blockRow.Add(BlockHeader.PositionZ);
            blockRow.Add(BlockHeader.On_Or_Under);
            blockRow.Add(BlockHeader.Section);

            _csvFile.WriteRow(blockRow);
        }
        public void SetBlockRow()
        {
            blockRow = new CsvRow();

            blockRow.Add(_reference.Block_Code);

            string script = _reference.Block_Script;
            string url = String.Empty;
            if (script.ToLower().Contains(CsvManage.Const.ScriptCode_URL.ToLower()))
            {
                url = KD.StringTools.Helper.Extract(script.ToLower(), CsvManage.Const.ScriptCode_URL.ToLower(), KD.StringTools.Const.BraceOpen, KD.StringTools.Const.BraceClose);
            }
            blockRow.Add(url);

            blockRow.Add(_reference.Block_Altitude.ToString());
            blockRow.Add(_reference.Block_PoseOnorUnderIndex.ToString());
            blockRow.Add(_reference.Section_Name);

            _csvFile.WriteRow(blockRow);
        }

        public void SetArticleHeader()
        {
            articleRow = new CsvRow();

            articleRow.Add(ArticleHeader.KeyRef);
            articleRow.Add(ArticleHeader.Handing);
            articleRow.Add(ArticleHeader.DimensionX);
            articleRow.Add(ArticleHeader.DimensionY);
            articleRow.Add(ArticleHeader.DimensionZ);

            articleRow.Add(ArticleHeader.IsDimensionXVariable);
            articleRow.Add(ArticleHeader.IsDimensionYVariable);
            articleRow.Add(ArticleHeader.IsDimensionZVariable);
            articleRow.Add(ArticleHeader.Topic);
            articleRow.Add(ArticleHeader.Layer);
            articleRow.Add(ArticleHeader.Type);
            articleRow.Add(ArticleHeader.BlockCode);
            articleRow.Add(ArticleHeader.Name);

            _csvFile.WriteRow(articleRow);
        }
        public void SetArticlePlacedRow(CsvFileWriter csvError)
        {
            articleRow = new CsvRow();

            articleRow.Add(_reference.Article_Key);
            articleRow.Add(_reference.Article_Hinge);
            articleRow.Add(_reference.Article_Width.ToString());
            articleRow.Add(_reference.Article_Depth.ToString());
            articleRow.Add(_reference.Article_Height.ToString());

            if (_sceneInfo.GenerateSceneInformations())
            {
                articleRow.AddRange(_sceneInfo.ArticleRow());
            }
            else
            {
                this.SetErrorRow(csvError, _reference.Article_Key);               
                csvError.Flush();
            }
            
            _csvFile.WriteRow(articleRow);
        }

        public void SetTranslateHeader()
        {
            CsvRow translateRow = new CsvRow();

            foreach (string language in DicoRow.AllLanguagesCode)
            {
                if (language != DicoRow.AllLanguagesCode[0])
                {
                    translateRow.Add(language);
                }
            }

            _csvFile.WriteRow(translateRow);
        }
        public void SetTranslatePlacedRow(CsvFileWriter csvError)
        {
            translateCatalogNameRow = new CsvRow();
            translateSectionNameRow = new CsvRow();
            translateBlockNameRow = new CsvRow();
            translateBlockDescriptionRow = new CsvRow();

            foreach (string language in DicoRow.AllLanguagesCode)
            {
                if (language != DicoRow.AllLanguagesCode[0])
                {
                    if (_sceneInfo.GenerateSceneInformations(language))
                    {
                        translateCatalogNameRow.AddRange(_sceneInfo.TranslateCatalogNameRow());
                        translateSectionNameRow.AddRange(_sceneInfo.TranslateSectionNameRow());
                        translateBlockNameRow.AddRange(_sceneInfo.TranslateBlockNameRow());
                        translateBlockDescriptionRow.AddRange(_sceneInfo.TranslateBlockDescriptionRow());
                    }
                    else
                    {
                        this.SetErrorRow(csvError, _reference.Article_Key);
                        csvError.Flush();
                    }
                }
            }

            this.WriteTranslateRow(translateCatalogNameRow);
            this.WriteTranslateRow(translateSectionNameRow);
            this.WriteTranslateRow(translateBlockNameRow);
            this.WriteTranslateRow(translateBlockDescriptionRow);
        }
        private void WriteTranslateRow(CsvRow row)
        {
            if (!langSourceList.Contains(row[0]))
            {
                langSourceList.Add(row[0]);
                _csvFile.WriteRow(row);
            }
        }

        public void SetErrorHeader()
        {
            CsvRow errorRow = new CsvRow();
            errorRow.Add(ArticleHeader.KeyRef);

            _csvFile.WriteRow(errorRow);
        }
        public void SetErrorRow(CsvFileWriter csvError, string keyRef)
        {
            CsvRow errorRow = new CsvRow();
            errorRow.Add(keyRef);

            csvError.WriteRow(errorRow);
        }       
    }

}

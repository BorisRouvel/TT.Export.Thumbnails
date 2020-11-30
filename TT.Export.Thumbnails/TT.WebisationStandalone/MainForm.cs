using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using KD.SDK;
using KD.CatalogProperties;


namespace TT.WebisationStandalone
{
    public partial class MainForm : Form 
    {
        private Appli appli = new Appli(KD.InSitu.Ini.Const.FileNameSpaceIni);       
        private Reference reference = null;

        string catalogFileName = String.Empty;

        List<string> sectionCodeList = new List<string>();
        List<string> sectionNameList = new List<string>();
        List<int> sectionBlockNbList = new List<int>();


        public MainForm()
        {
            InitializeComponent();

            this.InitializeForm();
        }

        //Event
        private void InitializeForm()
        {          
           
        }
        private void UpdateForm()
        {          
            reference = new Reference(appli, catalogFileName);             

            MainForm_GBX.Text = catalogFileName;
            CatalogName_LAB.Text = reference.CatalogName;
        }
        private void InitMembers()
        {
            sectionCodeList.Clear();
            sectionNameList.Clear();
            sectionBlockNbList.Clear();
        }

        private bool OpenCatalog()
        {
            this.OpenCatalog_OFD.RestoreDirectory = true;
            this.OpenCatalog_OFD.Filter = "Fichiers Catalogue" + KD.StringTools.Const.WhiteSpace + 
                                                                 KD.StringTools.Const.Pipe + 
                                                                 KD.StringTools.Const.Wildcard + 
                                                                 KD.CatalogProperties.Const.catalogExtension;

            DialogResult dialogResult = this.OpenCatalog_OFD.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (File.Exists(this.OpenCatalog_OFD.FileName))
                {
                    catalogFileName = this.OpenCatalog_OFD.FileName;
                    if (!String.IsNullOrEmpty(catalogFileName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void Main()
        {
            this.InitMembers();
            this.GenerateSectionsInformations();

            this.WriteCSVInformations();
        }

        private void GenerateSectionsInformations()
        {
            sectionCodeList = reference.Sections_Code;
            sectionNameList = reference.Sections_Name;
            sectionBlockNbList = reference.Sections_BlockNb;

            for (int sectionRank = 0; sectionRank < reference.SectionLinesNb; sectionRank++)
            {
                string code = sectionCodeList[sectionRank];
                string name = sectionNameList[sectionRank];
                int blockNb = sectionBlockNbList[sectionRank];

                if (blockNb != 0 && !code.StartsWith(KD.CatalogProperties.Const.arobase) &&
                    !String.IsNullOrEmpty(name) && !name.StartsWith(KD.CatalogProperties.Const.arobase))
                {
                    SectionCode_LBX.Items.Add(code);
                    SectionName_LBX.Items.Add(name);
                }
            }
        }

        private void WriteCSVInformations()
        {
            KD.CsvHelper.CsvFileWriter csvFile = new KD.CsvHelper.CsvFileWriter("WebInfo.csv");
            KD.CsvHelper.CsvRow row = null;

            for (int sectionRank = 0; sectionRank < reference.SectionLinesNb; sectionRank++)
            {
                string code = sectionCodeList[sectionRank];
                string name = sectionNameList[sectionRank];
                int blockNb = sectionBlockNbList[sectionRank];

                if (blockNb != 0 && !code.StartsWith(KD.CatalogProperties.Const.arobase) &&
                    !String.IsNullOrEmpty(name) && !name.StartsWith(KD.CatalogProperties.Const.arobase))
                {
                    row = new KD.CsvHelper.CsvRow();
                    row.Add(code + ";" + name);
                    csvFile.WriteRow(row);                    
                }               
            }
            csvFile.Dispose();
        }

        //Form
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Accept_BTN_Click(object sender, EventArgs e)
        {
            this.Main();
        }

        private void Cancel_BTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenCatalog_BTN_Click(object sender, EventArgs e)
        {
            if (this.OpenCatalog())
            {
                this.UpdateForm();
            }
        }

        

        

       
    }
}

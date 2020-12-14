namespace TT.WebisationStandalone
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainForm_GBX = new System.Windows.Forms.GroupBox();
            this.SaveFilesDirectory_TBX = new System.Windows.Forms.TextBox();
            this.GenerateTranslate_CHB = new System.Windows.Forms.CheckBox();
            this.GenerateCSVFile_BTN = new System.Windows.Forms.Button();
            this.GenerateThumbnails_BTN = new System.Windows.Forms.Button();
            this.CatalogName_LAB = new System.Windows.Forms.Label();
            this.SaveFilesDirectory_BTN = new System.Windows.Forms.Button();
            this.OpenCatalog_BTN = new System.Windows.Forms.Button();
            this.Close_BTN = new System.Windows.Forms.Button();
            this.OpenCatalog_OFD = new System.Windows.Forms.OpenFileDialog();
            this.StatusStrip_SST = new System.Windows.Forms.StatusStrip();
            this.Status_TSPB = new System.Windows.Forms.ToolStripProgressBar();
            this.Status_TSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.Name_TSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_BGW = new System.ComponentModel.BackgroundWorker();
            this.Version_LNK = new System.Windows.Forms.LinkLabel();
            this.SaveFilesDirectory_FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.MainForm_GBX.SuspendLayout();
            this.StatusStrip_SST.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainForm_GBX
            // 
            this.MainForm_GBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainForm_GBX.Controls.Add(this.label1);
            this.MainForm_GBX.Controls.Add(this.SaveFilesDirectory_TBX);
            this.MainForm_GBX.Controls.Add(this.GenerateTranslate_CHB);
            this.MainForm_GBX.Controls.Add(this.GenerateCSVFile_BTN);
            this.MainForm_GBX.Controls.Add(this.GenerateThumbnails_BTN);
            this.MainForm_GBX.Controls.Add(this.CatalogName_LAB);
            this.MainForm_GBX.Controls.Add(this.SaveFilesDirectory_BTN);
            this.MainForm_GBX.Controls.Add(this.OpenCatalog_BTN);
            this.MainForm_GBX.Location = new System.Drawing.Point(12, 12);
            this.MainForm_GBX.Name = "MainForm_GBX";
            this.MainForm_GBX.Size = new System.Drawing.Size(340, 145);
            this.MainForm_GBX.TabIndex = 0;
            this.MainForm_GBX.TabStop = false;
            this.MainForm_GBX.Text = "Emplacement fichier :";
            // 
            // SaveFilesDirectory_TBX
            // 
            this.SaveFilesDirectory_TBX.Location = new System.Drawing.Point(98, 31);
            this.SaveFilesDirectory_TBX.Name = "SaveFilesDirectory_TBX";
            this.SaveFilesDirectory_TBX.Size = new System.Drawing.Size(210, 20);
            this.SaveFilesDirectory_TBX.TabIndex = 6;
            this.SaveFilesDirectory_TBX.TextChanged += new System.EventHandler(this.SaveFilesDirectory_TBX_TextChanged);
            // 
            // GenerateTranslate_CHB
            // 
            this.GenerateTranslate_CHB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GenerateTranslate_CHB.AutoSize = true;
            this.GenerateTranslate_CHB.Location = new System.Drawing.Point(5, 115);
            this.GenerateTranslate_CHB.Name = "GenerateTranslate_CHB";
            this.GenerateTranslate_CHB.Size = new System.Drawing.Size(77, 17);
            this.GenerateTranslate_CHB.TabIndex = 5;
            this.GenerateTranslate_CHB.Text = "Traduction";
            this.GenerateTranslate_CHB.UseVisualStyleBackColor = true;
            // 
            // GenerateCSVFile_BTN
            // 
            this.GenerateCSVFile_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GenerateCSVFile_BTN.Location = new System.Drawing.Point(91, 105);
            this.GenerateCSVFile_BTN.Name = "GenerateCSVFile_BTN";
            this.GenerateCSVFile_BTN.Size = new System.Drawing.Size(75, 34);
            this.GenerateCSVFile_BTN.TabIndex = 4;
            this.GenerateCSVFile_BTN.Text = "Générer CSV";
            this.GenerateCSVFile_BTN.UseVisualStyleBackColor = true;
            this.GenerateCSVFile_BTN.Click += new System.EventHandler(this.GenerateCSVFile_BTN_Click);
            // 
            // GenerateThumbnails_BTN
            // 
            this.GenerateThumbnails_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateThumbnails_BTN.Location = new System.Drawing.Point(172, 105);
            this.GenerateThumbnails_BTN.Name = "GenerateThumbnails_BTN";
            this.GenerateThumbnails_BTN.Size = new System.Drawing.Size(75, 34);
            this.GenerateThumbnails_BTN.TabIndex = 2;
            this.GenerateThumbnails_BTN.Text = "Générer Vignettes";
            this.GenerateThumbnails_BTN.UseVisualStyleBackColor = true;
            this.GenerateThumbnails_BTN.Click += new System.EventHandler(this.GenerateThumbnails_BTN_Click);
            // 
            // CatalogName_LAB
            // 
            this.CatalogName_LAB.AutoSize = true;
            this.CatalogName_LAB.Location = new System.Drawing.Point(44, 72);
            this.CatalogName_LAB.Name = "CatalogName_LAB";
            this.CatalogName_LAB.Size = new System.Drawing.Size(61, 13);
            this.CatalogName_LAB.TabIndex = 1;
            this.CatalogName_LAB.Text = "Catalogue :";
            // 
            // SaveFilesDirectory_BTN
            // 
            this.SaveFilesDirectory_BTN.BackgroundImage = global::TT.WebisationStandalone.Properties.Resources._2002;
            this.SaveFilesDirectory_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveFilesDirectory_BTN.Location = new System.Drawing.Point(6, 24);
            this.SaveFilesDirectory_BTN.Name = "SaveFilesDirectory_BTN";
            this.SaveFilesDirectory_BTN.Size = new System.Drawing.Size(32, 32);
            this.SaveFilesDirectory_BTN.TabIndex = 0;
            this.SaveFilesDirectory_BTN.UseVisualStyleBackColor = true;
            this.SaveFilesDirectory_BTN.Click += new System.EventHandler(this.SaveFilesDirectory_BTN_Click);
            // 
            // OpenCatalog_BTN
            // 
            this.OpenCatalog_BTN.BackgroundImage = global::TT.WebisationStandalone.Properties.Resources._2002;
            this.OpenCatalog_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenCatalog_BTN.Location = new System.Drawing.Point(6, 62);
            this.OpenCatalog_BTN.Name = "OpenCatalog_BTN";
            this.OpenCatalog_BTN.Size = new System.Drawing.Size(32, 32);
            this.OpenCatalog_BTN.TabIndex = 0;
            this.OpenCatalog_BTN.UseVisualStyleBackColor = true;
            this.OpenCatalog_BTN.Click += new System.EventHandler(this.OpenCatalog_BTN_Click);
            // 
            // Close_BTN
            // 
            this.Close_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Close_BTN.Location = new System.Drawing.Point(145, 163);
            this.Close_BTN.Name = "Close_BTN";
            this.Close_BTN.Size = new System.Drawing.Size(75, 23);
            this.Close_BTN.TabIndex = 1;
            this.Close_BTN.Text = "Fermer";
            this.Close_BTN.UseVisualStyleBackColor = true;
            this.Close_BTN.Click += new System.EventHandler(this.Close_BTN_Click);
            // 
            // StatusStrip_SST
            // 
            this.StatusStrip_SST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_TSPB,
            this.Status_TSSL,
            this.Name_TSSL});
            this.StatusStrip_SST.Location = new System.Drawing.Point(0, 189);
            this.StatusStrip_SST.Name = "StatusStrip_SST";
            this.StatusStrip_SST.Size = new System.Drawing.Size(364, 22);
            this.StatusStrip_SST.TabIndex = 3;
            this.StatusStrip_SST.Text = "statusStrip1";
            // 
            // Status_TSPB
            // 
            this.Status_TSPB.Margin = new System.Windows.Forms.Padding(1, 3, 10, 3);
            this.Status_TSPB.Name = "Status_TSPB";
            this.Status_TSPB.Size = new System.Drawing.Size(170, 16);
            this.Status_TSPB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // Status_TSSL
            // 
            this.Status_TSSL.Name = "Status_TSSL";
            this.Status_TSSL.Size = new System.Drawing.Size(26, 17);
            this.Status_TSSL.Text = "0 %";
            // 
            // Name_TSSL
            // 
            this.Name_TSSL.Name = "Name_TSSL";
            this.Name_TSSL.Size = new System.Drawing.Size(47, 17);
            this.Name_TSSL.Text = "Fichiers";
            // 
            // Status_BGW
            // 
            this.Status_BGW.WorkerReportsProgress = true;
            this.Status_BGW.WorkerSupportsCancellation = true;
            this.Status_BGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Status_BGW_DoWork);
            this.Status_BGW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Status_BGW_ProgressChanged);
            this.Status_BGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Status_BGW_RunWorkerCompleted);
            // 
            // Version_LNK
            // 
            this.Version_LNK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Version_LNK.AutoSize = true;
            this.Version_LNK.Location = new System.Drawing.Point(9, 168);
            this.Version_LNK.Name = "Version_LNK";
            this.Version_LNK.Size = new System.Drawing.Size(13, 13);
            this.Version_LNK.TabIndex = 4;
            this.Version_LNK.TabStop = true;
            this.Version_LNK.Text = "?";
            this.Version_LNK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Version_LNK_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dossier :";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 211);
            this.Controls.Add(this.Version_LNK);
            this.Controls.Add(this.StatusStrip_SST);
            this.Controls.Add(this.Close_BTN);
            this.Controls.Add(this.MainForm_GBX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(560, 420);
            this.MinimumSize = new System.Drawing.Size(380, 250);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webisation Autonome";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainForm_GBX.ResumeLayout(false);
            this.MainForm_GBX.PerformLayout();
            this.StatusStrip_SST.ResumeLayout(false);
            this.StatusStrip_SST.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MainForm_GBX;
        private System.Windows.Forms.Button OpenCatalog_BTN;
        private System.Windows.Forms.Button Close_BTN;
        private System.Windows.Forms.OpenFileDialog OpenCatalog_OFD;
        private System.Windows.Forms.StatusStrip StatusStrip_SST;
        private System.Windows.Forms.ToolStripProgressBar Status_TSPB;
        private System.Windows.Forms.ToolStripStatusLabel Status_TSSL;
        private System.Windows.Forms.Label CatalogName_LAB;
        private System.ComponentModel.BackgroundWorker Status_BGW;
        private System.Windows.Forms.LinkLabel Version_LNK;
        private System.Windows.Forms.ToolStripStatusLabel Name_TSSL;
        private System.Windows.Forms.Button GenerateThumbnails_BTN;
        private System.Windows.Forms.Button GenerateCSVFile_BTN;
        private System.Windows.Forms.CheckBox GenerateTranslate_CHB;
        private System.Windows.Forms.TextBox SaveFilesDirectory_TBX;
        private System.Windows.Forms.Button SaveFilesDirectory_BTN;
        private System.Windows.Forms.FolderBrowserDialog SaveFilesDirectory_FBD;
        private System.Windows.Forms.Label label1;
    }
}


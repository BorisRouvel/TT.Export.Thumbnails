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
            this.CatalogName_LAB = new System.Windows.Forms.Label();
            this.Accept_BTN = new System.Windows.Forms.Button();
            this.Cancel_BTN = new System.Windows.Forms.Button();
            this.OpenCatalog_OFD = new System.Windows.Forms.OpenFileDialog();
            this.StatusStrip_SST = new System.Windows.Forms.StatusStrip();
            this.Status_TSPB = new System.Windows.Forms.ToolStripProgressBar();
            this.Status_TSSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_BGW = new System.ComponentModel.BackgroundWorker();
            this.Version_LNK = new System.Windows.Forms.LinkLabel();
            this.OpenCatalog_BTN = new System.Windows.Forms.Button();
            this.MainForm_GBX.SuspendLayout();
            this.StatusStrip_SST.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainForm_GBX
            // 
            this.MainForm_GBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainForm_GBX.Controls.Add(this.CatalogName_LAB);
            this.MainForm_GBX.Controls.Add(this.OpenCatalog_BTN);
            this.MainForm_GBX.Location = new System.Drawing.Point(12, 12);
            this.MainForm_GBX.Name = "MainForm_GBX";
            this.MainForm_GBX.Size = new System.Drawing.Size(280, 75);
            this.MainForm_GBX.TabIndex = 0;
            this.MainForm_GBX.TabStop = false;
            this.MainForm_GBX.Text = "Catalogue :";
            // 
            // CatalogName_LAB
            // 
            this.CatalogName_LAB.AutoSize = true;
            this.CatalogName_LAB.Location = new System.Drawing.Point(58, 35);
            this.CatalogName_LAB.Name = "CatalogName_LAB";
            this.CatalogName_LAB.Size = new System.Drawing.Size(35, 13);
            this.CatalogName_LAB.TabIndex = 1;
            this.CatalogName_LAB.Text = "Nom :";
            // 
            // Accept_BTN
            // 
            this.Accept_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Accept_BTN.Location = new System.Drawing.Point(73, 93);
            this.Accept_BTN.Name = "Accept_BTN";
            this.Accept_BTN.Size = new System.Drawing.Size(75, 23);
            this.Accept_BTN.TabIndex = 1;
            this.Accept_BTN.Text = "Ok";
            this.Accept_BTN.UseVisualStyleBackColor = true;
            this.Accept_BTN.Click += new System.EventHandler(this.Accept_BTN_Click);
            // 
            // Cancel_BTN
            // 
            this.Cancel_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Cancel_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_BTN.Location = new System.Drawing.Point(154, 93);
            this.Cancel_BTN.Name = "Cancel_BTN";
            this.Cancel_BTN.Size = new System.Drawing.Size(75, 23);
            this.Cancel_BTN.TabIndex = 2;
            this.Cancel_BTN.Text = "Annuler";
            this.Cancel_BTN.UseVisualStyleBackColor = true;
            this.Cancel_BTN.Click += new System.EventHandler(this.Cancel_BTN_Click);
            // 
            // StatusStrip_SST
            // 
            this.StatusStrip_SST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_TSPB,
            this.Status_TSSL});
            this.StatusStrip_SST.Location = new System.Drawing.Point(0, 119);
            this.StatusStrip_SST.Name = "StatusStrip_SST";
            this.StatusStrip_SST.Size = new System.Drawing.Size(304, 22);
            this.StatusStrip_SST.TabIndex = 3;
            this.StatusStrip_SST.Text = "statusStrip1";
            // 
            // Status_TSPB
            // 
            this.Status_TSPB.Margin = new System.Windows.Forms.Padding(1, 3, 10, 3);
            this.Status_TSPB.Name = "Status_TSPB";
            this.Status_TSPB.Size = new System.Drawing.Size(230, 16);
            // 
            // Status_TSSL
            // 
            this.Status_TSSL.Name = "Status_TSSL";
            this.Status_TSSL.Size = new System.Drawing.Size(26, 17);
            this.Status_TSSL.Text = "0 %";
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
            this.Version_LNK.AutoSize = true;
            this.Version_LNK.Location = new System.Drawing.Point(9, 98);
            this.Version_LNK.Name = "Version_LNK";
            this.Version_LNK.Size = new System.Drawing.Size(13, 13);
            this.Version_LNK.TabIndex = 4;
            this.Version_LNK.TabStop = true;
            this.Version_LNK.Text = "?";
            this.Version_LNK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Version_LNK_LinkClicked);
            // 
            // OpenCatalog_BTN
            // 
            this.OpenCatalog_BTN.Image = global::TT.WebisationStandalone.Properties.Resources._2002;
            this.OpenCatalog_BTN.Location = new System.Drawing.Point(6, 27);
            this.OpenCatalog_BTN.Name = "OpenCatalog_BTN";
            this.OpenCatalog_BTN.Size = new System.Drawing.Size(46, 32);
            this.OpenCatalog_BTN.TabIndex = 0;
            this.OpenCatalog_BTN.UseVisualStyleBackColor = true;
            this.OpenCatalog_BTN.Click += new System.EventHandler(this.OpenCatalog_BTN_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.Cancel_BTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_BTN;
            this.ClientSize = new System.Drawing.Size(304, 141);
            this.Controls.Add(this.Version_LNK);
            this.Controls.Add(this.StatusStrip_SST);
            this.Controls.Add(this.Cancel_BTN);
            this.Controls.Add(this.Accept_BTN);
            this.Controls.Add(this.MainForm_GBX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(560, 420);
            this.MinimumSize = new System.Drawing.Size(320, 180);
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
        private System.Windows.Forms.Button Accept_BTN;
        private System.Windows.Forms.Button Cancel_BTN;
        private System.Windows.Forms.OpenFileDialog OpenCatalog_OFD;
        private System.Windows.Forms.StatusStrip StatusStrip_SST;
        private System.Windows.Forms.ToolStripProgressBar Status_TSPB;
        private System.Windows.Forms.ToolStripStatusLabel Status_TSSL;
        private System.Windows.Forms.Label CatalogName_LAB;
        private System.ComponentModel.BackgroundWorker Status_BGW;
        private System.Windows.Forms.LinkLabel Version_LNK;
    }
}


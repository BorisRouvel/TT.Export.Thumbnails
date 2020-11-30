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
            this.MainForm_GBX = new System.Windows.Forms.GroupBox();
            this.CatalogName_LAB = new System.Windows.Forms.Label();
            this.OpenCatalog_BTN = new System.Windows.Forms.Button();
            this.Accept_BTN = new System.Windows.Forms.Button();
            this.Cancel_BTN = new System.Windows.Forms.Button();
            this.OpenCatalog_OFD = new System.Windows.Forms.OpenFileDialog();
            this.StatusStrip_SST = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SectionCode_LBX = new System.Windows.Forms.ListBox();
            this.SectionName_LBX = new System.Windows.Forms.ListBox();
            this.MainForm_GBX.SuspendLayout();
            this.StatusStrip_SST.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainForm_GBX
            // 
            this.MainForm_GBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainForm_GBX.Controls.Add(this.SectionName_LBX);
            this.MainForm_GBX.Controls.Add(this.SectionCode_LBX);
            this.MainForm_GBX.Controls.Add(this.CatalogName_LAB);
            this.MainForm_GBX.Controls.Add(this.OpenCatalog_BTN);
            this.MainForm_GBX.Location = new System.Drawing.Point(12, 12);
            this.MainForm_GBX.Name = "MainForm_GBX";
            this.MainForm_GBX.Size = new System.Drawing.Size(378, 267);
            this.MainForm_GBX.TabIndex = 0;
            this.MainForm_GBX.TabStop = false;
            this.MainForm_GBX.Text = "Catalogue :";
            // 
            // CatalogName_LAB
            // 
            this.CatalogName_LAB.AutoSize = true;
            this.CatalogName_LAB.Location = new System.Drawing.Point(87, 32);
            this.CatalogName_LAB.Name = "CatalogName_LAB";
            this.CatalogName_LAB.Size = new System.Drawing.Size(35, 13);
            this.CatalogName_LAB.TabIndex = 1;
            this.CatalogName_LAB.Text = "Nom :";
            // 
            // OpenCatalog_BTN
            // 
            this.OpenCatalog_BTN.Location = new System.Drawing.Point(6, 27);
            this.OpenCatalog_BTN.Name = "OpenCatalog_BTN";
            this.OpenCatalog_BTN.Size = new System.Drawing.Size(75, 23);
            this.OpenCatalog_BTN.TabIndex = 0;
            this.OpenCatalog_BTN.Text = "Ouvrir";
            this.OpenCatalog_BTN.UseVisualStyleBackColor = true;
            this.OpenCatalog_BTN.Click += new System.EventHandler(this.OpenCatalog_BTN_Click);
            // 
            // Accept_BTN
            // 
            this.Accept_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Accept_BTN.Location = new System.Drawing.Point(122, 285);
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
            this.Cancel_BTN.Location = new System.Drawing.Point(203, 285);
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
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.StatusStrip_SST.Location = new System.Drawing.Point(0, 311);
            this.StatusStrip_SST.Name = "StatusStrip_SST";
            this.StatusStrip_SST.Size = new System.Drawing.Size(402, 22);
            this.StatusStrip_SST.TabIndex = 3;
            this.StatusStrip_SST.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel1.Text = "0 %";
            // 
            // SectionCode_LBX
            // 
            this.SectionCode_LBX.FormattingEnabled = true;
            this.SectionCode_LBX.Location = new System.Drawing.Point(6, 56);
            this.SectionCode_LBX.Name = "SectionCode_LBX";
            this.SectionCode_LBX.Size = new System.Drawing.Size(86, 199);
            this.SectionCode_LBX.TabIndex = 2;
            // 
            // SectionName_LBX
            // 
            this.SectionName_LBX.FormattingEnabled = true;
            this.SectionName_LBX.Location = new System.Drawing.Point(98, 56);
            this.SectionName_LBX.Name = "SectionName_LBX";
            this.SectionName_LBX.Size = new System.Drawing.Size(158, 199);
            this.SectionName_LBX.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AcceptButton = this.Cancel_BTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_BTN;
            this.ClientSize = new System.Drawing.Size(402, 333);
            this.Controls.Add(this.StatusStrip_SST);
            this.Controls.Add(this.Cancel_BTN);
            this.Controls.Add(this.Accept_BTN);
            this.Controls.Add(this.MainForm_GBX);
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
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label CatalogName_LAB;
        private System.Windows.Forms.ListBox SectionName_LBX;
        private System.Windows.Forms.ListBox SectionCode_LBX;
    }
}


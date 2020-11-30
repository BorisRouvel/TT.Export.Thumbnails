namespace TT.Export.Thumbnails
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ok_BTN = new System.Windows.Forms.Button();
            this.Parameters_GBX = new System.Windows.Forms.GroupBox();
            this.State_GBX = new System.Windows.Forms.GroupBox();
            this.Open_RBT = new System.Windows.Forms.RadioButton();
            this.Close_RBT = new System.Windows.Forms.RadioButton();
            this.AntiAliasing_GBX = new System.Windows.Forms.GroupBox();
            this.AntiAliasing_TBX = new System.Windows.Forms.TextBox();
            this.Resolution_GBX = new System.Windows.Forms.GroupBox();
            this.XRes_TBX = new System.Windows.Forms.TextBox();
            this.YRes_TBX = new System.Windows.Forms.TextBox();
            this.X_LAB = new System.Windows.Forms.Label();
            this.Y_LAB = new System.Windows.Forms.Label();
            this.Loop_GBX = new System.Windows.Forms.GroupBox();
            this.LoopRefs_TBX = new System.Windows.Forms.TextBox();
            this.LoopRef_RBT = new System.Windows.Forms.RadioButton();
            this.LoopAll_RBT = new System.Windows.Forms.RadioButton();
            this.Viewmode_GBX = new System.Windows.Forms.GroupBox();
            this.Viewmode2D_RBT = new System.Windows.Forms.RadioButton();
            this.Viewmode3D_RBT = new System.Windows.Forms.RadioButton();
            this.transparency_CHB = new System.Windows.Forms.CheckBox();
            this.backGround_TBX = new System.Windows.Forms.TextBox();
            this.backGround_LAB = new System.Windows.Forms.Label();
            this.Cancel_BTN = new System.Windows.Forms.Button();
            this.status_SST = new System.Windows.Forms.StatusStrip();
            this.Status_LAB2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Version_LNK = new System.Windows.Forms.LinkLabel();
            this.status_BGW = new System.ComponentModel.BackgroundWorker();
            this.Parameters_GBX.SuspendLayout();
            this.State_GBX.SuspendLayout();
            this.AntiAliasing_GBX.SuspendLayout();
            this.Resolution_GBX.SuspendLayout();
            this.Loop_GBX.SuspendLayout();
            this.Viewmode_GBX.SuspendLayout();
            this.status_SST.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ok_BTN
            // 
            this.Ok_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Ok_BTN.Location = new System.Drawing.Point(81, 213);
            this.Ok_BTN.Name = "Ok_BTN";
            this.Ok_BTN.Size = new System.Drawing.Size(75, 23);
            this.Ok_BTN.TabIndex = 6;
            this.Ok_BTN.Text = "Ok";
            this.Ok_BTN.UseVisualStyleBackColor = true;
            this.Ok_BTN.Click += new System.EventHandler(this.Ok_BTN_Click);
            // 
            // Parameters_GBX
            // 
            this.Parameters_GBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Parameters_GBX.Controls.Add(this.State_GBX);
            this.Parameters_GBX.Controls.Add(this.AntiAliasing_GBX);
            this.Parameters_GBX.Controls.Add(this.Resolution_GBX);
            this.Parameters_GBX.Controls.Add(this.Loop_GBX);
            this.Parameters_GBX.Controls.Add(this.Viewmode_GBX);
            this.Parameters_GBX.Controls.Add(this.transparency_CHB);
            this.Parameters_GBX.Controls.Add(this.backGround_TBX);
            this.Parameters_GBX.Controls.Add(this.backGround_LAB);
            this.Parameters_GBX.Location = new System.Drawing.Point(12, 12);
            this.Parameters_GBX.Name = "Parameters_GBX";
            this.Parameters_GBX.Size = new System.Drawing.Size(300, 195);
            this.Parameters_GBX.TabIndex = 3;
            this.Parameters_GBX.TabStop = false;
            this.Parameters_GBX.Text = "Paramètres";
            this.Parameters_GBX.Enter += new System.EventHandler(this.Parameters_GBX_Enter);
            // 
            // State_GBX
            // 
            this.State_GBX.Controls.Add(this.Open_RBT);
            this.State_GBX.Controls.Add(this.Close_RBT);
            this.State_GBX.Location = new System.Drawing.Point(99, 31);
            this.State_GBX.Name = "State_GBX";
            this.State_GBX.Size = new System.Drawing.Size(67, 74);
            this.State_GBX.TabIndex = 17;
            this.State_GBX.TabStop = false;
            this.State_GBX.Text = "Etat";
            // 
            // Open_RBT
            // 
            this.Open_RBT.AutoSize = true;
            this.Open_RBT.Checked = true;
            this.Open_RBT.Location = new System.Drawing.Point(6, 19);
            this.Open_RBT.Name = "Open_RBT";
            this.Open_RBT.Size = new System.Drawing.Size(51, 17);
            this.Open_RBT.TabIndex = 4;
            this.Open_RBT.TabStop = true;
            this.Open_RBT.Text = "Open";
            this.Open_RBT.UseVisualStyleBackColor = true;
            // 
            // Close_RBT
            // 
            this.Close_RBT.AutoSize = true;
            this.Close_RBT.Location = new System.Drawing.Point(6, 42);
            this.Close_RBT.Name = "Close_RBT";
            this.Close_RBT.Size = new System.Drawing.Size(51, 17);
            this.Close_RBT.TabIndex = 5;
            this.Close_RBT.Text = "Close";
            this.Close_RBT.UseVisualStyleBackColor = true;
            // 
            // AntiAliasing_GBX
            // 
            this.AntiAliasing_GBX.Controls.Add(this.AntiAliasing_TBX);
            this.AntiAliasing_GBX.Location = new System.Drawing.Point(6, 111);
            this.AntiAliasing_GBX.Name = "AntiAliasing_GBX";
            this.AntiAliasing_GBX.Size = new System.Drawing.Size(87, 72);
            this.AntiAliasing_GBX.TabIndex = 3;
            this.AntiAliasing_GBX.TabStop = false;
            this.AntiAliasing_GBX.Text = "Antialiasing";
            // 
            // AntiAliasing_TBX
            // 
            this.AntiAliasing_TBX.Location = new System.Drawing.Point(32, 28);
            this.AntiAliasing_TBX.Name = "AntiAliasing_TBX";
            this.AntiAliasing_TBX.Size = new System.Drawing.Size(24, 20);
            this.AntiAliasing_TBX.TabIndex = 2;
            this.AntiAliasing_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Resolution_GBX
            // 
            this.Resolution_GBX.Controls.Add(this.XRes_TBX);
            this.Resolution_GBX.Controls.Add(this.YRes_TBX);
            this.Resolution_GBX.Controls.Add(this.X_LAB);
            this.Resolution_GBX.Controls.Add(this.Y_LAB);
            this.Resolution_GBX.Location = new System.Drawing.Point(6, 31);
            this.Resolution_GBX.Name = "Resolution_GBX";
            this.Resolution_GBX.Size = new System.Drawing.Size(87, 74);
            this.Resolution_GBX.TabIndex = 16;
            this.Resolution_GBX.TabStop = false;
            this.Resolution_GBX.Text = "Résolution";
            // 
            // XRes_TBX
            // 
            this.XRes_TBX.Location = new System.Drawing.Point(32, 19);
            this.XRes_TBX.Name = "XRes_TBX";
            this.XRes_TBX.Size = new System.Drawing.Size(46, 20);
            this.XRes_TBX.TabIndex = 0;
            this.XRes_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // YRes_TBX
            // 
            this.YRes_TBX.Location = new System.Drawing.Point(32, 45);
            this.YRes_TBX.Name = "YRes_TBX";
            this.YRes_TBX.Size = new System.Drawing.Size(46, 20);
            this.YRes_TBX.TabIndex = 1;
            this.YRes_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // X_LAB
            // 
            this.X_LAB.AutoSize = true;
            this.X_LAB.Location = new System.Drawing.Point(6, 22);
            this.X_LAB.Name = "X_LAB";
            this.X_LAB.Size = new System.Drawing.Size(20, 13);
            this.X_LAB.TabIndex = 3;
            this.X_LAB.Text = "X :";
            // 
            // Y_LAB
            // 
            this.Y_LAB.AutoSize = true;
            this.Y_LAB.Location = new System.Drawing.Point(6, 48);
            this.Y_LAB.Name = "Y_LAB";
            this.Y_LAB.Size = new System.Drawing.Size(20, 13);
            this.Y_LAB.TabIndex = 3;
            this.Y_LAB.Text = "Y :";
            // 
            // Loop_GBX
            // 
            this.Loop_GBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Loop_GBX.Controls.Add(this.LoopRefs_TBX);
            this.Loop_GBX.Controls.Add(this.LoopRef_RBT);
            this.Loop_GBX.Controls.Add(this.LoopAll_RBT);
            this.Loop_GBX.Location = new System.Drawing.Point(172, 31);
            this.Loop_GBX.Name = "Loop_GBX";
            this.Loop_GBX.Size = new System.Drawing.Size(122, 152);
            this.Loop_GBX.TabIndex = 15;
            this.Loop_GBX.TabStop = false;
            this.Loop_GBX.Text = "Lots";
            // 
            // LoopRefs_TBX
            // 
            this.LoopRefs_TBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoopRefs_TBX.Enabled = false;
            this.LoopRefs_TBX.Location = new System.Drawing.Point(6, 73);
            this.LoopRefs_TBX.Multiline = true;
            this.LoopRefs_TBX.Name = "LoopRefs_TBX";
            this.LoopRefs_TBX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LoopRefs_TBX.Size = new System.Drawing.Size(110, 73);
            this.LoopRefs_TBX.TabIndex = 2;
            // 
            // LoopRef_RBT
            // 
            this.LoopRef_RBT.AutoSize = true;
            this.LoopRef_RBT.Location = new System.Drawing.Point(6, 50);
            this.LoopRef_RBT.Name = "LoopRef_RBT";
            this.LoopRef_RBT.Size = new System.Drawing.Size(79, 17);
            this.LoopRef_RBT.TabIndex = 1;
            this.LoopRef_RBT.TabStop = true;
            this.LoopRef_RBT.Text = "Par Réf ( ; )";
            this.LoopRef_RBT.UseVisualStyleBackColor = true;
            // 
            // LoopAll_RBT
            // 
            this.LoopAll_RBT.AutoSize = true;
            this.LoopAll_RBT.Checked = true;
            this.LoopAll_RBT.Location = new System.Drawing.Point(6, 24);
            this.LoopAll_RBT.Name = "LoopAll_RBT";
            this.LoopAll_RBT.Size = new System.Drawing.Size(47, 17);
            this.LoopAll_RBT.TabIndex = 0;
            this.LoopAll_RBT.TabStop = true;
            this.LoopAll_RBT.Text = "Tout";
            this.LoopAll_RBT.UseVisualStyleBackColor = true;
            this.LoopAll_RBT.CheckedChanged += new System.EventHandler(this.LoopAll_RBT_CheckedChanged);
            // 
            // Viewmode_GBX
            // 
            this.Viewmode_GBX.Controls.Add(this.Viewmode2D_RBT);
            this.Viewmode_GBX.Controls.Add(this.Viewmode3D_RBT);
            this.Viewmode_GBX.Location = new System.Drawing.Point(99, 111);
            this.Viewmode_GBX.Name = "Viewmode_GBX";
            this.Viewmode_GBX.Size = new System.Drawing.Size(67, 72);
            this.Viewmode_GBX.TabIndex = 14;
            this.Viewmode_GBX.TabStop = false;
            this.Viewmode_GBX.Text = "Vue";
            // 
            // Viewmode2D_RBT
            // 
            this.Viewmode2D_RBT.AutoSize = true;
            this.Viewmode2D_RBT.Location = new System.Drawing.Point(16, 19);
            this.Viewmode2D_RBT.Name = "Viewmode2D_RBT";
            this.Viewmode2D_RBT.Size = new System.Drawing.Size(39, 17);
            this.Viewmode2D_RBT.TabIndex = 12;
            this.Viewmode2D_RBT.Text = "2D";
            this.Viewmode2D_RBT.UseVisualStyleBackColor = true;
            // 
            // Viewmode3D_RBT
            // 
            this.Viewmode3D_RBT.AutoSize = true;
            this.Viewmode3D_RBT.Checked = true;
            this.Viewmode3D_RBT.Location = new System.Drawing.Point(16, 42);
            this.Viewmode3D_RBT.Name = "Viewmode3D_RBT";
            this.Viewmode3D_RBT.Size = new System.Drawing.Size(39, 17);
            this.Viewmode3D_RBT.TabIndex = 13;
            this.Viewmode3D_RBT.TabStop = true;
            this.Viewmode3D_RBT.Text = "3D";
            this.Viewmode3D_RBT.UseVisualStyleBackColor = true;
            // 
            // transparency_CHB
            // 
            this.transparency_CHB.AutoSize = true;
            this.transparency_CHB.Checked = true;
            this.transparency_CHB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.transparency_CHB.Location = new System.Drawing.Point(340, 300);
            this.transparency_CHB.Name = "transparency_CHB";
            this.transparency_CHB.Size = new System.Drawing.Size(91, 17);
            this.transparency_CHB.TabIndex = 11;
            this.transparency_CHB.Text = "Transparency";
            this.transparency_CHB.UseVisualStyleBackColor = true;
            this.transparency_CHB.Visible = false;
            this.transparency_CHB.CheckedChanged += new System.EventHandler(this.Transparency_CHB_CheckedChanged);
            // 
            // backGround_TBX
            // 
            this.backGround_TBX.Location = new System.Drawing.Point(367, 341);
            this.backGround_TBX.Name = "backGround_TBX";
            this.backGround_TBX.Size = new System.Drawing.Size(74, 20);
            this.backGround_TBX.TabIndex = 3;
            this.backGround_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.backGround_TBX.Visible = false;
            // 
            // backGround_LAB
            // 
            this.backGround_LAB.AutoSize = true;
            this.backGround_LAB.Location = new System.Drawing.Point(364, 320);
            this.backGround_LAB.Name = "backGround_LAB";
            this.backGround_LAB.Size = new System.Drawing.Size(67, 13);
            this.backGround_LAB.TabIndex = 9;
            this.backGround_LAB.Text = "BackGround";
            this.backGround_LAB.Visible = false;
            // 
            // Cancel_BTN
            // 
            this.Cancel_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Cancel_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_BTN.Location = new System.Drawing.Point(162, 213);
            this.Cancel_BTN.Name = "Cancel_BTN";
            this.Cancel_BTN.Size = new System.Drawing.Size(75, 23);
            this.Cancel_BTN.TabIndex = 11;
            this.Cancel_BTN.Text = "Cancel";
            this.Cancel_BTN.UseVisualStyleBackColor = true;
            this.Cancel_BTN.Click += new System.EventHandler(this.Cancel_BTN_Click);
            // 
            // status_SST
            // 
            this.status_SST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_LAB2});
            this.status_SST.Location = new System.Drawing.Point(0, 239);
            this.status_SST.Name = "status_SST";
            this.status_SST.Size = new System.Drawing.Size(324, 22);
            this.status_SST.TabIndex = 12;
            this.status_SST.Text = "statusStrip1";
            // 
            // Status_LAB2
            // 
            this.Status_LAB2.Name = "Status_LAB2";
            this.Status_LAB2.Size = new System.Drawing.Size(92, 17);
            this.Status_LAB2.Text = "Export Nb : 0 / 0";
            // 
            // Version_LNK
            // 
            this.Version_LNK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Version_LNK.AutoSize = true;
            this.Version_LNK.Location = new System.Drawing.Point(5, 218);
            this.Version_LNK.Name = "Version_LNK";
            this.Version_LNK.Size = new System.Drawing.Size(13, 13);
            this.Version_LNK.TabIndex = 13;
            this.Version_LNK.TabStop = true;
            this.Version_LNK.Text = "?";
            this.Version_LNK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Version_LNK_LinkClicked);
            // 
            // status_BGW
            // 
            this.status_BGW.WorkerReportsProgress = true;
            this.status_BGW.WorkerSupportsCancellation = true;
            this.status_BGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.status_BGW_DoWork);
            this.status_BGW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.status_BGW_ProgressChanged);
            this.status_BGW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.status_BGW_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AcceptButton = this.Ok_BTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_BTN;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.ControlBox = false;
            this.Controls.Add(this.Version_LNK);
            this.Controls.Add(this.status_SST);
            this.Controls.Add(this.Cancel_BTN);
            this.Controls.Add(this.Parameters_GBX);
            this.Controls.Add(this.Ok_BTN);
            this.MinimumSize = new System.Drawing.Size(340, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Catalogue";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Enter += new System.EventHandler(this.MainForm_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.Parameters_GBX.ResumeLayout(false);
            this.Parameters_GBX.PerformLayout();
            this.State_GBX.ResumeLayout(false);
            this.State_GBX.PerformLayout();
            this.AntiAliasing_GBX.ResumeLayout(false);
            this.AntiAliasing_GBX.PerformLayout();
            this.Resolution_GBX.ResumeLayout(false);
            this.Resolution_GBX.PerformLayout();
            this.Loop_GBX.ResumeLayout(false);
            this.Loop_GBX.PerformLayout();
            this.Viewmode_GBX.ResumeLayout(false);
            this.Viewmode_GBX.PerformLayout();
            this.status_SST.ResumeLayout(false);
            this.status_SST.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Ok_BTN;
        private System.Windows.Forms.GroupBox Parameters_GBX;
        private System.Windows.Forms.TextBox backGround_TBX;
        private System.Windows.Forms.TextBox AntiAliasing_TBX;
        private System.Windows.Forms.RadioButton Close_RBT;
        private System.Windows.Forms.RadioButton Open_RBT;
        private System.Windows.Forms.Label backGround_LAB;
        private System.Windows.Forms.Label Y_LAB;
        private System.Windows.Forms.Label X_LAB;
        private System.Windows.Forms.TextBox YRes_TBX;
        private System.Windows.Forms.TextBox XRes_TBX;
        private System.Windows.Forms.Button Cancel_BTN;
        private System.Windows.Forms.CheckBox transparency_CHB;
        private System.Windows.Forms.GroupBox Viewmode_GBX;
        private System.Windows.Forms.RadioButton Viewmode2D_RBT;
        private System.Windows.Forms.RadioButton Viewmode3D_RBT;
        private System.Windows.Forms.StatusStrip status_SST;
        private System.Windows.Forms.ToolStripStatusLabel Status_LAB2;
        private System.Windows.Forms.LinkLabel Version_LNK;
        private System.Windows.Forms.GroupBox Loop_GBX;
        private System.Windows.Forms.TextBox LoopRefs_TBX;
        private System.Windows.Forms.RadioButton LoopRef_RBT;
        private System.Windows.Forms.RadioButton LoopAll_RBT;
        private System.Windows.Forms.GroupBox State_GBX;
        private System.Windows.Forms.GroupBox AntiAliasing_GBX;
        private System.Windows.Forms.GroupBox Resolution_GBX;
        private System.ComponentModel.BackgroundWorker status_BGW;
    }
}
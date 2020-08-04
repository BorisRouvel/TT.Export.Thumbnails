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
            this.ok_BTN = new System.Windows.Forms.Button();
            this.parameters_GBX = new System.Windows.Forms.GroupBox();
            this.viewmode_GBX = new System.Windows.Forms.GroupBox();
            this.viewmode2D_RBT = new System.Windows.Forms.RadioButton();
            this.viewmode3D_RBT = new System.Windows.Forms.RadioButton();
            this.transparency_CHB = new System.Windows.Forms.CheckBox();
            this.backGround_TBX = new System.Windows.Forms.TextBox();
            this.antiAliasing_TBX = new System.Windows.Forms.TextBox();
            this.close_RBT = new System.Windows.Forms.RadioButton();
            this.open_RBT = new System.Windows.Forms.RadioButton();
            this.backGround_LAB = new System.Windows.Forms.Label();
            this.antiAliasing_LAB = new System.Windows.Forms.Label();
            this.resolution_LAB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yRes_TBX = new System.Windows.Forms.TextBox();
            this.xRes_TBX = new System.Windows.Forms.TextBox();
            this.cancel_BTN = new System.Windows.Forms.Button();
            this.status_SST = new System.Windows.Forms.StatusStrip();
            this.status_LAB2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.version_LNK = new System.Windows.Forms.LinkLabel();
            this.parameters_GBX.SuspendLayout();
            this.viewmode_GBX.SuspendLayout();
            this.status_SST.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok_BTN
            // 
            this.ok_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ok_BTN.Location = new System.Drawing.Point(30, 219);
            this.ok_BTN.Name = "ok_BTN";
            this.ok_BTN.Size = new System.Drawing.Size(75, 23);
            this.ok_BTN.TabIndex = 6;
            this.ok_BTN.Text = "Ok";
            this.ok_BTN.UseVisualStyleBackColor = true;
            this.ok_BTN.Click += new System.EventHandler(this.ok_BTN_Click);
            // 
            // parameters_GBX
            // 
            this.parameters_GBX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parameters_GBX.Controls.Add(this.viewmode_GBX);
            this.parameters_GBX.Controls.Add(this.transparency_CHB);
            this.parameters_GBX.Controls.Add(this.backGround_TBX);
            this.parameters_GBX.Controls.Add(this.antiAliasing_TBX);
            this.parameters_GBX.Controls.Add(this.close_RBT);
            this.parameters_GBX.Controls.Add(this.open_RBT);
            this.parameters_GBX.Controls.Add(this.backGround_LAB);
            this.parameters_GBX.Controls.Add(this.antiAliasing_LAB);
            this.parameters_GBX.Controls.Add(this.resolution_LAB);
            this.parameters_GBX.Controls.Add(this.label2);
            this.parameters_GBX.Controls.Add(this.label1);
            this.parameters_GBX.Controls.Add(this.yRes_TBX);
            this.parameters_GBX.Controls.Add(this.xRes_TBX);
            this.parameters_GBX.Location = new System.Drawing.Point(12, 12);
            this.parameters_GBX.Name = "parameters_GBX";
            this.parameters_GBX.Size = new System.Drawing.Size(190, 201);
            this.parameters_GBX.TabIndex = 3;
            this.parameters_GBX.TabStop = false;
            this.parameters_GBX.Text = "Paramètres";
            this.parameters_GBX.Enter += new System.EventHandler(this.parameters_GBX_Enter);
            // 
            // viewmode_GBX
            // 
            this.viewmode_GBX.Controls.Add(this.viewmode2D_RBT);
            this.viewmode_GBX.Controls.Add(this.viewmode3D_RBT);
            this.viewmode_GBX.Location = new System.Drawing.Point(99, 103);
            this.viewmode_GBX.Name = "viewmode_GBX";
            this.viewmode_GBX.Size = new System.Drawing.Size(67, 74);
            this.viewmode_GBX.TabIndex = 14;
            this.viewmode_GBX.TabStop = false;
            // 
            // viewmode2D_RBT
            // 
            this.viewmode2D_RBT.AutoSize = true;
            this.viewmode2D_RBT.Location = new System.Drawing.Point(16, 19);
            this.viewmode2D_RBT.Name = "viewmode2D_RBT";
            this.viewmode2D_RBT.Size = new System.Drawing.Size(39, 17);
            this.viewmode2D_RBT.TabIndex = 12;
            this.viewmode2D_RBT.Text = "2D";
            this.viewmode2D_RBT.UseVisualStyleBackColor = true;
            // 
            // viewmode3D_RBT
            // 
            this.viewmode3D_RBT.AutoSize = true;
            this.viewmode3D_RBT.Checked = true;
            this.viewmode3D_RBT.Location = new System.Drawing.Point(16, 42);
            this.viewmode3D_RBT.Name = "viewmode3D_RBT";
            this.viewmode3D_RBT.Size = new System.Drawing.Size(39, 17);
            this.viewmode3D_RBT.TabIndex = 13;
            this.viewmode3D_RBT.TabStop = true;
            this.viewmode3D_RBT.Text = "3D";
            this.viewmode3D_RBT.UseVisualStyleBackColor = true;
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
            this.transparency_CHB.CheckedChanged += new System.EventHandler(this.transparency_CHB_CheckedChanged);
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
            // antiAliasing_TBX
            // 
            this.antiAliasing_TBX.Location = new System.Drawing.Point(54, 131);
            this.antiAliasing_TBX.Name = "antiAliasing_TBX";
            this.antiAliasing_TBX.Size = new System.Drawing.Size(24, 20);
            this.antiAliasing_TBX.TabIndex = 2;
            this.antiAliasing_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // close_RBT
            // 
            this.close_RBT.AutoSize = true;
            this.close_RBT.Location = new System.Drawing.Point(113, 80);
            this.close_RBT.Name = "close_RBT";
            this.close_RBT.Size = new System.Drawing.Size(51, 17);
            this.close_RBT.TabIndex = 5;
            this.close_RBT.Text = "Close";
            this.close_RBT.UseVisualStyleBackColor = true;
            // 
            // open_RBT
            // 
            this.open_RBT.AutoSize = true;
            this.open_RBT.Checked = true;
            this.open_RBT.Location = new System.Drawing.Point(113, 57);
            this.open_RBT.Name = "open_RBT";
            this.open_RBT.Size = new System.Drawing.Size(51, 17);
            this.open_RBT.TabIndex = 4;
            this.open_RBT.TabStop = true;
            this.open_RBT.Text = "Open";
            this.open_RBT.UseVisualStyleBackColor = true;
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
            // antiAliasing_LAB
            // 
            this.antiAliasing_LAB.AutoSize = true;
            this.antiAliasing_LAB.Location = new System.Drawing.Point(6, 115);
            this.antiAliasing_LAB.Name = "antiAliasing_LAB";
            this.antiAliasing_LAB.Size = new System.Drawing.Size(60, 13);
            this.antiAliasing_LAB.TabIndex = 8;
            this.antiAliasing_LAB.Text = "Antialiasing";
            // 
            // resolution_LAB
            // 
            this.resolution_LAB.AutoSize = true;
            this.resolution_LAB.Location = new System.Drawing.Point(6, 33);
            this.resolution_LAB.Name = "resolution_LAB";
            this.resolution_LAB.Size = new System.Drawing.Size(57, 13);
            this.resolution_LAB.TabIndex = 7;
            this.resolution_LAB.Text = "Resolution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X :";
            // 
            // yRes_TBX
            // 
            this.yRes_TBX.Location = new System.Drawing.Point(32, 80);
            this.yRes_TBX.Name = "yRes_TBX";
            this.yRes_TBX.Size = new System.Drawing.Size(46, 20);
            this.yRes_TBX.TabIndex = 1;
            this.yRes_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xRes_TBX
            // 
            this.xRes_TBX.Location = new System.Drawing.Point(32, 54);
            this.xRes_TBX.Name = "xRes_TBX";
            this.xRes_TBX.Size = new System.Drawing.Size(46, 20);
            this.xRes_TBX.TabIndex = 0;
            this.xRes_TBX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cancel_BTN
            // 
            this.cancel_BTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancel_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_BTN.Location = new System.Drawing.Point(111, 219);
            this.cancel_BTN.Name = "cancel_BTN";
            this.cancel_BTN.Size = new System.Drawing.Size(75, 23);
            this.cancel_BTN.TabIndex = 11;
            this.cancel_BTN.Text = "Cancel";
            this.cancel_BTN.UseVisualStyleBackColor = true;
            this.cancel_BTN.Click += new System.EventHandler(this.cancel_BTN_Click);
            // 
            // status_SST
            // 
            this.status_SST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_LAB2});
            this.status_SST.Location = new System.Drawing.Point(0, 249);
            this.status_SST.Name = "status_SST";
            this.status_SST.Size = new System.Drawing.Size(214, 22);
            this.status_SST.TabIndex = 12;
            this.status_SST.Text = "statusStrip1";
            // 
            // status_LAB2
            // 
            this.status_LAB2.Name = "status_LAB2";
            this.status_LAB2.Size = new System.Drawing.Size(92, 17);
            this.status_LAB2.Text = "Export Nb : 0 / 0";
            // 
            // version_LNK
            // 
            this.version_LNK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.version_LNK.AutoSize = true;
            this.version_LNK.Location = new System.Drawing.Point(9, 224);
            this.version_LNK.Name = "version_LNK";
            this.version_LNK.Size = new System.Drawing.Size(13, 13);
            this.version_LNK.TabIndex = 13;
            this.version_LNK.TabStop = true;
            this.version_LNK.Text = "?";
            this.version_LNK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.version_LNK_LinkClicked);
            // 
            // MainForm
            // 
            this.AcceptButton = this.ok_BTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_BTN;
            this.ClientSize = new System.Drawing.Size(214, 271);
            this.ControlBox = false;
            this.Controls.Add(this.version_LNK);
            this.Controls.Add(this.status_SST);
            this.Controls.Add(this.cancel_BTN);
            this.Controls.Add(this.parameters_GBX);
            this.Controls.Add(this.ok_BTN);
            this.MinimumSize = new System.Drawing.Size(230, 310);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Catalogue";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Enter += new System.EventHandler(this.MainForm_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.parameters_GBX.ResumeLayout(false);
            this.parameters_GBX.PerformLayout();
            this.viewmode_GBX.ResumeLayout(false);
            this.viewmode_GBX.PerformLayout();
            this.status_SST.ResumeLayout(false);
            this.status_SST.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ok_BTN;
        private System.Windows.Forms.GroupBox parameters_GBX;
        private System.Windows.Forms.TextBox backGround_TBX;
        private System.Windows.Forms.TextBox antiAliasing_TBX;
        private System.Windows.Forms.RadioButton close_RBT;
        private System.Windows.Forms.RadioButton open_RBT;
        private System.Windows.Forms.Label backGround_LAB;
        private System.Windows.Forms.Label antiAliasing_LAB;
        private System.Windows.Forms.Label resolution_LAB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox yRes_TBX;
        private System.Windows.Forms.TextBox xRes_TBX;
        private System.Windows.Forms.Button cancel_BTN;
        private System.Windows.Forms.CheckBox transparency_CHB;
        private System.Windows.Forms.GroupBox viewmode_GBX;
        private System.Windows.Forms.RadioButton viewmode2D_RBT;
        private System.Windows.Forms.RadioButton viewmode3D_RBT;
        private System.Windows.Forms.StatusStrip status_SST;
        private System.Windows.Forms.ToolStripStatusLabel status_LAB2;
        private System.Windows.Forms.LinkLabel version_LNK;
    }
}
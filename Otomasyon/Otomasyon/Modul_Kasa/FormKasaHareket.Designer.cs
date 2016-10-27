namespace Otomasyon.Modul_Kasa
{
    partial class FormKasaHareket
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKasaHareket));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grid = new DevExpress.XtraEditors.GroupControl();
            this.g = new DevExpress.XtraGrid.GridControl();
            this.sagtik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.devirKartıİşlemleriniDüzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.tahsilatÖdemeİşlemleriniDüzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.gridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BelgeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EvrakTur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GIRIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CIKIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Evrakiid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtBakiye = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCikis = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtGiris = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKasaAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtKasaKod = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.grid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g)).BeginInit();
            this.sagtik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBakiye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiris.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaKod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtBakiye);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtCikis);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtGiris);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtKasaAd);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtKasaKod);
            this.groupControl1.Controls.Add(this.grid);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1193, 457);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Banka Bilgileri";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // grid
            // 
            this.grid.Controls.Add(this.g);
            this.grid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grid.Location = new System.Drawing.Point(2, 87);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1189, 368);
            this.grid.TabIndex = 20;
            this.grid.Text = "Hareket Listesi";
            // 
            // g
            // 
            this.g.ContextMenuStrip = this.sagtik;
            this.g.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g.Location = new System.Drawing.Point(2, 20);
            this.g.MainView = this.gridview;
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(1185, 346);
            this.g.TabIndex = 0;
            this.g.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridview});
            // 
            // sagtik
            // 
            this.sagtik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devirKartıİşlemleriniDüzenle,
            this.tahsilatÖdemeİşlemleriniDüzenle});
            this.sagtik.Name = "sagtik";
            this.sagtik.Size = new System.Drawing.Size(261, 48);
            this.sagtik.Opening += new System.ComponentModel.CancelEventHandler(this.sagtik_Opening);
            // 
            // devirKartıİşlemleriniDüzenle
            // 
            this.devirKartıİşlemleriniDüzenle.Enabled = false;
            this.devirKartıİşlemleriniDüzenle.Name = "devirKartıİşlemleriniDüzenle";
            this.devirKartıİşlemleriniDüzenle.Size = new System.Drawing.Size(260, 22);
            this.devirKartıİşlemleriniDüzenle.Text = "Devir Kartı İşlemlerini Düzenle";
            this.devirKartıİşlemleriniDüzenle.Click += new System.EventHandler(this.devirKartıİşlemleriniDüzenle_Click);
            // 
            // tahsilatÖdemeİşlemleriniDüzenle
            // 
            this.tahsilatÖdemeİşlemleriniDüzenle.Enabled = false;
            this.tahsilatÖdemeİşlemleriniDüzenle.Name = "tahsilatÖdemeİşlemleriniDüzenle";
            this.tahsilatÖdemeİşlemleriniDüzenle.Size = new System.Drawing.Size(260, 22);
            this.tahsilatÖdemeİşlemleriniDüzenle.Text = "Tahsilat/Ödeme İşlemlerini Düzenle";
            this.tahsilatÖdemeİşlemleriniDüzenle.Click += new System.EventHandler(this.tahsilatÖdemeİşlemleriniDüzenle_Click);
            // 
            // gridview
            // 
            this.gridview.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.White;
            this.gridview.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.White;
            this.gridview.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridview.Appearance.Row.BackColor2 = System.Drawing.Color.White;
            this.gridview.Appearance.Row.BorderColor = System.Drawing.Color.White;
            this.gridview.Appearance.Row.ForeColor = System.Drawing.Color.White;
            this.gridview.Appearance.Row.Options.UseBackColor = true;
            this.gridview.Appearance.Row.Options.UseBorderColor = true;
            this.gridview.Appearance.Row.Options.UseForeColor = true;
            this.gridview.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.gridview.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.gridview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.BelgeNo,
            this.EvrakTur,
            this.GIRIS,
            this.CIKIS,
            this.Aciklama,
            this.Tarih,
            this.Evrakiid});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.EvrakTur;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[EvrakTur] = \'Kasa Tahsilat\'";
            formatConditionRuleExpression1.PredefinedName = "Yellow Fill, Yellow Text";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule1.StopIfTrue = true;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.EvrakTur;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Expression = "[EvrakTur] = \'Kasa Ödeme\'";
            formatConditionRuleExpression2.PredefinedName = "Green Fill, Green Text";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            gridFormatRule2.StopIfTrue = true;
            this.gridview.FormatRules.Add(gridFormatRule1);
            this.gridview.FormatRules.Add(gridFormatRule2);
            this.gridview.GridControl = this.g;
            this.gridview.Name = "gridview";
            this.gridview.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // BelgeNo
            // 
            this.BelgeNo.Caption = "Belge No";
            this.BelgeNo.FieldName = "BelgeNo";
            this.BelgeNo.Name = "BelgeNo";
            this.BelgeNo.OptionsColumn.AllowEdit = false;
            this.BelgeNo.OptionsColumn.AllowFocus = false;
            this.BelgeNo.OptionsColumn.FixedWidth = true;
            this.BelgeNo.Visible = true;
            this.BelgeNo.VisibleIndex = 0;
            this.BelgeNo.Width = 50;
            // 
            // EvrakTur
            // 
            this.EvrakTur.Caption = "Evrak Türü";
            this.EvrakTur.FieldName = "EvrakTur";
            this.EvrakTur.MinWidth = 10;
            this.EvrakTur.Name = "EvrakTur";
            this.EvrakTur.OptionsColumn.AllowEdit = false;
            this.EvrakTur.OptionsColumn.AllowFocus = false;
            this.EvrakTur.OptionsColumn.FixedWidth = true;
            this.EvrakTur.Visible = true;
            this.EvrakTur.VisibleIndex = 1;
            this.EvrakTur.Width = 50;
            // 
            // GIRIS
            // 
            this.GIRIS.Caption = "Giriş";
            this.GIRIS.FieldName = "GIRIS";
            this.GIRIS.Name = "GIRIS";
            this.GIRIS.OptionsColumn.AllowEdit = false;
            this.GIRIS.OptionsColumn.AllowFocus = false;
            this.GIRIS.OptionsColumn.FixedWidth = true;
            this.GIRIS.Visible = true;
            this.GIRIS.VisibleIndex = 3;
            this.GIRIS.Width = 50;
            // 
            // CIKIS
            // 
            this.CIKIS.Caption = "Çıkış";
            this.CIKIS.FieldName = "CIKIS";
            this.CIKIS.Name = "CIKIS";
            this.CIKIS.OptionsColumn.AllowEdit = false;
            this.CIKIS.OptionsColumn.AllowFocus = false;
            this.CIKIS.OptionsColumn.FixedWidth = true;
            this.CIKIS.Visible = true;
            this.CIKIS.VisibleIndex = 4;
            this.CIKIS.Width = 50;
            // 
            // Aciklama
            // 
            this.Aciklama.Caption = "Açıklama";
            this.Aciklama.FieldName = "Aciklama";
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.OptionsColumn.AllowEdit = false;
            this.Aciklama.OptionsColumn.AllowFocus = false;
            this.Aciklama.OptionsColumn.FixedWidth = true;
            this.Aciklama.Visible = true;
            this.Aciklama.VisibleIndex = 5;
            this.Aciklama.Width = 120;
            // 
            // Tarih
            // 
            this.Tarih.Caption = "Tarih";
            this.Tarih.FieldName = "Tarih";
            this.Tarih.Name = "Tarih";
            this.Tarih.OptionsColumn.AllowEdit = false;
            this.Tarih.OptionsColumn.AllowFocus = false;
            this.Tarih.OptionsColumn.FixedWidth = true;
            this.Tarih.Visible = true;
            this.Tarih.VisibleIndex = 2;
            this.Tarih.Width = 50;
            // 
            // Evrakiid
            // 
            this.Evrakiid.Caption = "EvrakID";
            this.Evrakiid.FieldName = "Evrakiid";
            this.Evrakiid.Name = "Evrakiid";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 101);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Giriş :";
            // 
            // txtBakiye
            // 
            this.txtBakiye.Location = new System.Drawing.Point(499, 45);
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.Properties.ReadOnly = true;
            this.txtBakiye.Size = new System.Drawing.Size(73, 20);
            this.txtBakiye.TabIndex = 30;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(455, 48);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Bakiye :";
            // 
            // txtCikis
            // 
            this.txtCikis.Location = new System.Drawing.Point(373, 62);
            this.txtCikis.Name = "txtCikis";
            this.txtCikis.Properties.ReadOnly = true;
            this.txtCikis.Size = new System.Drawing.Size(73, 20);
            this.txtCikis.TabIndex = 28;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(339, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Çıkış :";
            // 
            // txtGiris
            // 
            this.txtGiris.Location = new System.Drawing.Point(373, 32);
            this.txtGiris.Name = "txtGiris";
            this.txtGiris.Properties.ReadOnly = true;
            this.txtGiris.Size = new System.Drawing.Size(73, 20);
            this.txtGiris.TabIndex = 26;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(339, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Giriş :";
            // 
            // txtKasaAd
            // 
            this.txtKasaAd.Location = new System.Drawing.Point(98, 58);
            this.txtKasaAd.Name = "txtKasaAd";
            this.txtKasaAd.Properties.ReadOnly = true;
            this.txtKasaAd.Size = new System.Drawing.Size(220, 20);
            this.txtKasaAd.TabIndex = 24;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Kasa Ad:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 35);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 13);
            this.labelControl6.TabIndex = 21;
            this.labelControl6.Text = "Kasa Kod :";
            // 
            // txtKasaKod
            // 
            this.txtKasaKod.Location = new System.Drawing.Point(98, 32);
            this.txtKasaKod.Name = "txtKasaKod";
            this.txtKasaKod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtKasaKod.Size = new System.Drawing.Size(220, 20);
            this.txtKasaKod.TabIndex = 22;
            this.txtKasaKod.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtKasaKod_ButtonClick_1);
            // 
            // FormKasaHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 457);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKasaHareket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa Hareketleri";
            this.Load += new System.EventHandler(this.FormKasaHareket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.grid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g)).EndInit();
            this.sagtik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBakiye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiris.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaKod.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ContextMenuStrip sagtik;
        private System.Windows.Forms.ToolStripMenuItem devirKartıİşlemleriniDüzenle;
        private System.Windows.Forms.ToolStripMenuItem tahsilatÖdemeİşlemleriniDüzenle;
        private DevExpress.XtraEditors.GroupControl grid;
        private DevExpress.XtraGrid.GridControl g;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn BelgeNo;
        private DevExpress.XtraGrid.Columns.GridColumn EvrakTur;
        private DevExpress.XtraGrid.Columns.GridColumn GIRIS;
        private DevExpress.XtraGrid.Columns.GridColumn CIKIS;
        private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
        private DevExpress.XtraGrid.Columns.GridColumn Tarih;
        private DevExpress.XtraGrid.Columns.GridColumn Evrakiid;
        private DevExpress.XtraEditors.TextEdit txtBakiye;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCikis;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtGiris;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtKasaAd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ButtonEdit txtKasaKod;
    }
}
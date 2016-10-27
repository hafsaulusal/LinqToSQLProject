namespace Otomasyon.Modul_Banka
{
    partial class FormBankaHareketleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBankaHareketleri));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtBakiye = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCikis = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtGiris = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapAd = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.g = new DevExpress.XtraGrid.GridControl();
            this.sagtik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bankaİşleminiDüzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaParaTransferiniDüzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.gridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BelgeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EvrakTur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GİRİS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CİKİS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBakiye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiris.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g)).BeginInit();
            this.sagtik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtBakiye);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtCikis);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtGiris);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtHesapNo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtHesapAd);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1145, 495);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Banka Bilgileri";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // txtBakiye
            // 
            this.txtBakiye.Location = new System.Drawing.Point(499, 36);
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.Properties.ReadOnly = true;
            this.txtBakiye.Size = new System.Drawing.Size(73, 20);
            this.txtBakiye.TabIndex = 13;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(455, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Bakiye :";
            // 
            // txtCikis
            // 
            this.txtCikis.Location = new System.Drawing.Point(373, 53);
            this.txtCikis.Name = "txtCikis";
            this.txtCikis.Properties.ReadOnly = true;
            this.txtCikis.Size = new System.Drawing.Size(73, 20);
            this.txtCikis.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(339, 56);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Çıkış :";
            // 
            // txtGiris
            // 
            this.txtGiris.Location = new System.Drawing.Point(373, 23);
            this.txtGiris.Name = "txtGiris";
            this.txtGiris.Properties.ReadOnly = true;
            this.txtGiris.Size = new System.Drawing.Size(73, 20);
            this.txtGiris.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(339, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Giriş :";
            // 
            // txtHesapNo
            // 
            this.txtHesapNo.Location = new System.Drawing.Point(98, 49);
            this.txtHesapNo.Name = "txtHesapNo";
            this.txtHesapNo.Properties.ReadOnly = true;
            this.txtHesapNo.Size = new System.Drawing.Size(220, 20);
            this.txtHesapNo.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Hesap No :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Hesap Türü/Adı :";
            // 
            // txtHesapAd
            // 
            this.txtHesapAd.Location = new System.Drawing.Point(98, 23);
            this.txtHesapAd.Name = "txtHesapAd";
            this.txtHesapAd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtHesapAd.Size = new System.Drawing.Size(220, 20);
            this.txtHesapAd.TabIndex = 1;
            this.txtHesapAd.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtHesapAd_ButtonClick);
            this.txtHesapAd.Click += new System.EventHandler(this.txtHesapAd_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.g);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 79);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1145, 416);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Hareket Listesi";
            // 
            // g
            // 
            this.g.ContextMenuStrip = this.sagtik;
            this.g.Dock = System.Windows.Forms.DockStyle.Fill;
            this.g.Location = new System.Drawing.Point(2, 20);
            this.g.MainView = this.gridview;
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(1141, 394);
            this.g.TabIndex = 1;
            this.g.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridview});
            // 
            // sagtik
            // 
            this.sagtik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bankaİşleminiDüzenle,
            this.bankaParaTransferiniDüzenle});
            this.sagtik.Name = "sagtik";
            this.sagtik.Size = new System.Drawing.Size(249, 48);
            this.sagtik.Opening += new System.ComponentModel.CancelEventHandler(this.sagtik_Opening);
            // 
            // bankaİşleminiDüzenle
            // 
            this.bankaİşleminiDüzenle.Enabled = false;
            this.bankaİşleminiDüzenle.Name = "bankaİşleminiDüzenle";
            this.bankaİşleminiDüzenle.Size = new System.Drawing.Size(248, 22);
            this.bankaİşleminiDüzenle.Text = "Banka İşlemlerini Düzenle";
            this.bankaİşleminiDüzenle.Click += new System.EventHandler(this.bankaİşleminiDüzenle_Click_1);
            // 
            // bankaParaTransferiniDüzenle
            // 
            this.bankaParaTransferiniDüzenle.Enabled = false;
            this.bankaParaTransferiniDüzenle.Name = "bankaParaTransferiniDüzenle";
            this.bankaParaTransferiniDüzenle.Size = new System.Drawing.Size(248, 22);
            this.bankaParaTransferiniDüzenle.Text = "Banka Para Transferlerini Düzenle";
            this.bankaParaTransferiniDüzenle.Click += new System.EventHandler(this.bankaParaTransferiniDüzenle_Click_1);
            // 
            // gridview
            // 
            this.gridview.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.White;
            this.gridview.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.White;
            this.gridview.Appearance.Row.BackColor = System.Drawing.Color.Lime;
            this.gridview.Appearance.Row.BackColor2 = System.Drawing.Color.Lime;
            this.gridview.Appearance.Row.BorderColor = System.Drawing.Color.White;
            this.gridview.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridview.Appearance.Row.Options.UseBackColor = true;
            this.gridview.Appearance.Row.Options.UseBorderColor = true;
            this.gridview.Appearance.Row.Options.UseForeColor = true;
            this.gridview.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.gridview.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.gridview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.BelgeNo,
            this.EvrakTur,
            this.GİRİS,
            this.CİKİS,
            this.Aciklama,
            this.Tarih});
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
            // GİRİS
            // 
            this.GİRİS.Caption = "Giriş";
            this.GİRİS.FieldName = "GİRİS";
            this.GİRİS.Name = "GİRİS";
            this.GİRİS.OptionsColumn.AllowEdit = false;
            this.GİRİS.OptionsColumn.AllowFocus = false;
            this.GİRİS.OptionsColumn.FixedWidth = true;
            this.GİRİS.Visible = true;
            this.GİRİS.VisibleIndex = 3;
            this.GİRİS.Width = 50;
            // 
            // CİKİS
            // 
            this.CİKİS.Caption = "Çıkış";
            this.CİKİS.FieldName = "CİKİS";
            this.CİKİS.Name = "CİKİS";
            this.CİKİS.OptionsColumn.AllowEdit = false;
            this.CİKİS.OptionsColumn.AllowFocus = false;
            this.CİKİS.OptionsColumn.FixedWidth = true;
            this.CİKİS.Visible = true;
            this.CİKİS.VisibleIndex = 4;
            this.CİKİS.Width = 50;
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
            // FormBankaHareketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 495);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBankaHareketleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka Hareketleri";
            this.Load += new System.EventHandler(this.FormBankaHareketleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBakiye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiris.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g)).EndInit();
            this.sagtik.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtGiris;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtHesapNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBakiye;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCikis;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit txtHesapAd;
        private System.Windows.Forms.ContextMenuStrip sagtik;
        private System.Windows.Forms.ToolStripMenuItem bankaİşleminiDüzenle;
        private System.Windows.Forms.ToolStripMenuItem bankaParaTransferiniDüzenle;
        private DevExpress.XtraGrid.GridControl g;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn BelgeNo;
        private DevExpress.XtraGrid.Columns.GridColumn EvrakTur;
        private DevExpress.XtraGrid.Columns.GridColumn GİRİS;
        private DevExpress.XtraGrid.Columns.GridColumn CİKİS;
        private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
        private DevExpress.XtraGrid.Columns.GridColumn Tarih;
    }
}
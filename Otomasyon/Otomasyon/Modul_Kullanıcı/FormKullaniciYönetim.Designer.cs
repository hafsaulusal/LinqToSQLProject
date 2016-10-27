namespace Otomasyon.Modul_Kullanıcı
{
    partial class FormKullaniciYönetim
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnguncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnyeni = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Kullanici = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KullaniciAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KullaniciSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aktif = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Kodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton3);
            this.layoutControl1.Controls.Add(this.btnguncelle);
            this.layoutControl1.Controls.Add(this.btnyeni);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(709, 48);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Image = global::Otomasyon.Properties.Resources.deletegroupfooter_16x16;
            this.simpleButton3.Location = new System.Drawing.Point(468, 12);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(229, 22);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Seçili Kullanıcıyı Sil";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // btnguncelle
            // 
            this.btnguncelle.Image = global::Otomasyon.Properties.Resources.addgroupfooter_16x16;
            this.btnguncelle.Location = new System.Drawing.Point(226, 12);
            this.btnguncelle.Name = "btnguncelle";
            this.btnguncelle.Size = new System.Drawing.Size(238, 22);
            this.btnguncelle.StyleController = this.layoutControl1;
            this.btnguncelle.TabIndex = 5;
            this.btnguncelle.Text = "Seçili Kullanıcıyı Güncelle";
            this.btnguncelle.Click += new System.EventHandler(this.btnguncelle_Click);
            // 
            // btnyeni
            // 
            this.btnyeni.Image = global::Otomasyon.Properties.Resources.customer_16x16;
            this.btnyeni.Location = new System.Drawing.Point(12, 12);
            this.btnyeni.Name = "btnyeni";
            this.btnyeni.Size = new System.Drawing.Size(210, 22);
            this.btnyeni.StyleController = this.layoutControl1;
            this.btnyeni.TabIndex = 4;
            this.btnyeni.Text = "Yeni Kullanıcı Girişi";
            this.btnyeni.Click += new System.EventHandler(this.btnyeni_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(709, 48);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnyeni;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(214, 28);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton3;
            this.layoutControlItem3.Location = new System.Drawing.Point(456, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(233, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnguncelle;
            this.layoutControlItem2.Location = new System.Drawing.Point(214, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(242, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(709, 381);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Kullanici,
            this.KullaniciAd,
            this.KullaniciSoyad,
            this.Aktif,
            this.Kodu});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // Kullanici
            // 
            this.Kullanici.Caption = "Kullanıcı";
            this.Kullanici.FieldName = "Kullanici";
            this.Kullanici.Name = "Kullanici";
            this.Kullanici.OptionsColumn.AllowEdit = false;
            this.Kullanici.OptionsColumn.AllowFocus = false;
            this.Kullanici.OptionsColumn.FixedWidth = true;
            this.Kullanici.Visible = true;
            this.Kullanici.VisibleIndex = 0;
            // 
            // KullaniciAd
            // 
            this.KullaniciAd.Caption = "Ad";
            this.KullaniciAd.FieldName = "KullaniciAd";
            this.KullaniciAd.Name = "KullaniciAd";
            this.KullaniciAd.OptionsColumn.AllowEdit = false;
            this.KullaniciAd.OptionsColumn.AllowFocus = false;
            this.KullaniciAd.OptionsColumn.FixedWidth = true;
            this.KullaniciAd.Visible = true;
            this.KullaniciAd.VisibleIndex = 1;
            // 
            // KullaniciSoyad
            // 
            this.KullaniciSoyad.Caption = "Soyad";
            this.KullaniciSoyad.FieldName = "KullaniciSoyad";
            this.KullaniciSoyad.Name = "KullaniciSoyad";
            this.KullaniciSoyad.OptionsColumn.AllowEdit = false;
            this.KullaniciSoyad.OptionsColumn.AllowFocus = false;
            this.KullaniciSoyad.OptionsColumn.FixedWidth = true;
            this.KullaniciSoyad.Visible = true;
            this.KullaniciSoyad.VisibleIndex = 2;
            // 
            // Aktif
            // 
            this.Aktif.Caption = "Durum";
            this.Aktif.FieldName = "Aktif";
            this.Aktif.Name = "Aktif";
            this.Aktif.OptionsColumn.AllowEdit = false;
            this.Aktif.OptionsColumn.AllowFocus = false;
            this.Aktif.OptionsColumn.FixedWidth = true;
            this.Aktif.Visible = true;
            this.Aktif.VisibleIndex = 3;
            // 
            // Kodu
            // 
            this.Kodu.Caption = "Kullanıcı Kod";
            this.Kodu.FieldName = "Kodu";
            this.Kodu.Name = "Kodu";
            this.Kodu.OptionsColumn.AllowEdit = false;
            this.Kodu.OptionsColumn.AllowFocus = false;
            this.Kodu.OptionsColumn.FixedWidth = true;
            this.Kodu.Visible = true;
            this.Kodu.VisibleIndex = 4;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // FormKullaniciYönetim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 429);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormKullaniciYönetim";
            this.Text = "Kullanıcı Yönetim";
            this.Load += new System.EventHandler(this.FormKullaniciYönetim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnguncelle;
        private DevExpress.XtraEditors.SimpleButton btnyeni;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn Kullanici;
        private DevExpress.XtraGrid.Columns.GridColumn KullaniciAd;
        private DevExpress.XtraGrid.Columns.GridColumn KullaniciSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn Aktif;
        private DevExpress.XtraGrid.Columns.GridColumn Kodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;


    }
}
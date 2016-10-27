using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Stok
{
    public partial class FormStokGruplari : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        public bool Secim = false;
        int SecimId = -1;
        bool Edit = false;

        public FormStokGruplari()
        {
            InitializeComponent();
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormStokGruplari_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.tbl_StokGrups
                      select s;
            Liste.DataSource = lst;
        
        }

        void Temizle() {
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
            Edit = false;
            Listele();
        }

        void Kaydet() {

            try
            {
                Fonksiyonlar.tbl_StokGrup Grup = new Fonksiyonlar.tbl_StokGrup();
                Grup.GrupAd = txtGrupAdi.Text;
                Grup.GrupKod = txtGrupKodu.Text;
                Grup.GrupSaveDate = DateTime.Now;
                Grup.GrupSaveUser = AnaForm.USERID;
                DB.tbl_StokGrups.InsertOnSubmit(Grup);
                DB.SubmitChanges();
                mesaj.YeniKayit("Yeni Grup Kaydı Oluşturuldu");
                Temizle();
            }
            catch (Exception e)
            {
                
                mesaj.Hata(e);
            }     
        }

        void Guncelle() 
        {
            try
            {
                Fonksiyonlar.tbl_StokGrup grup = DB.tbl_StokGrups.First(s => s.ID == SecimId);
                grup.GrupKod = txtGrupKodu.Text;
                grup.GrupAd = txtGrupAdi.Text;
                grup.GrupEditUser = AnaForm.USERID;
                grup.GrupEditDate = DateTime.Now;
                DB.SubmitChanges();
                mesaj.Guncelle(true);
                Temizle();

            }
            catch (Exception e)
            {
                
                mesaj.Hata(e);
            }
        
        }

        void Sil() {

            try
            {
                DB.tbl_StokGrups.DeleteOnSubmit(DB.tbl_StokGrups.First(s => s.ID == SecimId));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                
                mesaj.Hata(e);
            }
        
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && SecimId > 0 && mesaj.Silme() == DialogResult.Yes)
                Sil();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && SecimId > 0 && mesaj.Guncelle() == DialogResult.Yes)
                Guncelle();
            else
                Kaydet();
        }

        void Sec() {

            try
            {
                Edit = true;
                SecimId = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtGrupAdi.Text = gridView1.GetFocusedRowCellValue("GrupAd").ToString();
                txtGrupKodu.Text = gridView1.GetFocusedRowCellValue("GrupKod").ToString();
            }
            catch (Exception)
            {
               Edit=false;
               SecimId = -1;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && SecimId > 0)
            {
                AnaForm.Aktarma = SecimId;
                this.Close();
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Cari
{
    public partial class FormCariGrup : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        public bool Secim=false;
        int SecimId = -1;
        bool Edit = false;

        public FormCariGrup()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && SecimId > 0 && mesaj.Guncelle() == DialogResult.Yes)
                Guncelle();
            else
                Kaydet();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && SecimId > 0 && mesaj.Silme() == DialogResult.Yes)
                Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Listele()
        {
            var lst = from s in DB.tbl_CariGrups
                      select s;
            Liste.DataSource = lst;
        }

        void Temizle()
        {
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
            Edit = false;
            Listele();
        
        }

        void Kaydet()
        {

            try
            {
                Fonksiyonlar.tbl_CariGrup grup = new Fonksiyonlar.tbl_CariGrup();
                if (txtGrupAdi.Text != "" && txtGrupKodu.Text != "")
                {
                    grup.GrupAd = txtGrupAdi.Text;
                    grup.GrupKod = txtGrupKodu.Text;
                    grup.SaveDate = DateTime.Now;
                    grup.SaveUser = AnaForm.USERID;
                    DB.tbl_CariGrups.InsertOnSubmit(grup);
                    DB.SubmitChanges();
                    mesaj.YeniKayit("Yeni Grup Kaydı Oluşturuldu");
                    Temizle();
                }
                else {
                    mesaj.Uyari("Lütfen Tüm Alanları Doldurun.");
                }
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
                Fonksiyonlar.tbl_CariGrup grup = DB.tbl_CariGrups.First(s => s.ID == SecimId);
                if (txtGrupAdi.Text != "" && txtGrupKodu.Text != "")
                {
                    grup.GrupKod = txtGrupKodu.Text;
                    grup.GrupAd = txtGrupAdi.Text;
                    grup.EditUser = AnaForm.USERID;
                    grup.EditDate = DateTime.Now;
                    DB.SubmitChanges();
                    mesaj.Guncelle(true);
                    Temizle();
                }
                else {
                    mesaj.Uyari("Lütfen Tüm Alanları Doldurun.");
                }
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }

        }

        void Sil() 
        {
            try
            {
                DB.tbl_CariGrups.DeleteOnSubmit(DB.tbl_CariGrups.First(s => s.ID == SecimId));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        
        }

        void Sec()
        {
            try
            {
                Edit = true;
                SecimId = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                txtGrupAdi.Text = gridView1.GetFocusedRowCellValue("GrupAd").ToString();
                txtGrupKodu.Text = gridView1.GetFocusedRowCellValue("GrupKod").ToString();
            }
            catch (Exception)
            {
                Edit = false;
                SecimId = -1;
            }
        }

        private void FormCariGrup_Load(object sender, EventArgs e)
        {
            Listele();

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
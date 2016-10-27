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

namespace Otomasyon.Modul_Kasa
{
    public partial class FormKasaAcilisKarti : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara numara = new Fonksiyonlar.Numara();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        bool Edit = false;
        int SecimId = -1;

        public FormKasaAcilisKarti()
        {
            InitializeComponent();
        }

        private void FormKasaAcilisKarti_Load(object sender, EventArgs e)
        {
            txtKasaKod.Text = numara.KasaKodNumarasi();
            Listele();
        }

        void Temizle()
        {
            txtKasaKod.Text = "";
            txtKasaAd.Text = "";
            txtAciklama.Text = "";

            Edit = false;
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.tbl_KasaKartis
                      select s;
            Liste.DataSource = lst;
        }

        void Kaydet()
        {
            try
            {
                Fonksiyonlar.tbl_KasaKarti kasakart = new Fonksiyonlar.tbl_KasaKarti();
                if (txtKasaKod.Text != "" && txtKasaAd.Text != "" && txtAciklama.Text != "")
                {
                    kasakart.KasaKod = txtKasaKod.Text;
                    kasakart.KasaAd = txtKasaAd.Text;
                    kasakart.Aciklama = txtAciklama.Text;
                    kasakart.SaveDate = DateTime.Now;
                    kasakart.SaveUser = AnaForm.USERID;
                    DB.tbl_KasaKartis.InsertOnSubmit(kasakart);
                    DB.SubmitChanges();
                    mesaj.YeniKayit("Yeni Kasa Kaydı Oluşturuldu");
                    Temizle();
                }
                else
                {
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
            Fonksiyonlar.tbl_KasaKarti kasakart = DB.tbl_KasaKartis.First(s => s.ID == SecimId);
            try
            {
                if (txtKasaKod.Text != "" && txtKasaAd.Text != "" && txtAciklama.Text != "")
                {
                    kasakart.KasaKod = txtKasaKod.Text;
                    kasakart.KasaAd = txtKasaAd.Text;
                    kasakart.Aciklama = txtAciklama.Text;
                    kasakart.EditDate = DateTime.Now;
                    kasakart.EditUser = AnaForm.USERID;
                    DB.SubmitChanges();
                    mesaj.Guncelle(true);
                    Temizle();
                }
                else
                {
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
                DB.tbl_KasaKartis.DeleteOnSubmit(DB.tbl_KasaKartis.First(s => s.ID == SecimId));
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
                txtKasaKod.Text = gridView1.GetFocusedRowCellValue("KasaKod").ToString();
                txtKasaAd.Text = gridView1.GetFocusedRowCellValue("KasaAd").ToString();
                txtAciklama.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();
            }
            catch (Exception)
            {
                Edit = false;
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && SecimId > 0 && mesaj.Guncelle() == DialogResult.Yes)
            {
                Guncelle();
            }
            else 
            {
                Kaydet();
            }

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

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
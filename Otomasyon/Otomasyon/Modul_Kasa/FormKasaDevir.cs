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
    public partial class FormKasaDevir : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        bool Edit = false;
        int KasaId = -1;
        int IslemId = -1;

        public FormKasaDevir()
        {
            InitializeComponent();
        }

        private void FormKasaDevir_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        void Temizle()
        
        {
            radiogiris.Checked = true;
            txtBelgeNo.Text = "";
            txtKasaKod.Text = "";
            txtKasaAd.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";
            txtAciklama.Text = "";

            Edit = false;
            KasaId = -1;
            IslemId = -1;
            AnaForm.Aktarma = -1;
        }

        void Kaydet()
        {
            Fonksiyonlar.tbl_KasaHareketleri kasa = new Fonksiyonlar.tbl_KasaHareketleri();
          

            try
            {
                if (txtBelgeNo.Text != "" && txtKasaAd.Text != "" && txtKasaKod.Text != ""
                        && txtAciklama.Text != "" && txtTutar.Text != "" && txtTarih.Text != "")
                {
                    kasa.BelgeNo = txtBelgeNo.Text;
                    kasa.Aciklama = txtAciklama.Text;
                    kasa.EvrakTur = "Kasa Hareket Kartı";
                    if (radiogiris.Checked) kasa.GCKod = "G";
                    if (radiocikis.Checked) kasa.GCKod = "Ç";
                    kasa.KasaId = KasaId;
                    kasa.Tarih = DateTime.Parse(txtTarih.Text);
                    kasa.Tutar = decimal.Parse(txtTutar.Text);
                    kasa.SaveUser = AnaForm.USERID;
                    kasa.SaveDate = DateTime.Now;

                    DB.tbl_KasaHareketleris.InsertOnSubmit(kasa);
                    DB.SubmitChanges();
                    mesaj.YeniKayit("Yeni Kayıt Oluşturuldu");
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
            Fonksiyonlar.tbl_KasaHareketleri kasa = DB.tbl_KasaHareketleris.First(s => s.ID == IslemId);
            try
            {
                if (txtBelgeNo.Text != "" && txtKasaAd.Text != "" && txtKasaKod.Text != ""
                        && txtAciklama.Text != "" && txtTutar.Text != "" && txtTarih.Text != "")
                {
                    kasa.BelgeNo = txtBelgeNo.Text;
                    kasa.Aciklama = txtAciklama.Text;
                    kasa.EvrakTur = "Kasa Hareket Kartı";
                    if (radiogiris.Checked) kasa.GCKod = "G";
                    if (radiocikis.Checked) kasa.GCKod = "Ç";
                    kasa.KasaId = KasaId;
                    kasa.Tarih = DateTime.Parse(txtTarih.Text);
                    kasa.Tutar = decimal.Parse(txtTutar.Text);
                    kasa.EditUser = AnaForm.USERID;
                    kasa.EditDate = DateTime.Now;

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
                DB.tbl_KasaHareketleris.DeleteOnSubmit(DB.tbl_KasaHareketleris.First(s => s.ID == IslemId));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        }

        void KasaAc(int ID)
        {
            try
            {
                KasaId = ID;
                Fonksiyonlar.tbl_KasaKarti kasa = DB.tbl_KasaKartis.First(s => s.ID == KasaId);
                txtKasaAd.Text = kasa.KasaAd;
                txtKasaKod.Text = kasa.KasaKod;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        }

       public void Ac(int ID)
        {
            try
            {
                Edit = true;
                IslemId = ID;
                Fonksiyonlar.tbl_KasaHareketleri kasa = DB.tbl_KasaHareketleris.First(s => s.ID == IslemId);
                txtBelgeNo.Text = kasa.BelgeNo;
                txtAciklama.Text = kasa.Aciklama;
                txtTarih.Text = kasa.Tarih.Value.ToShortDateString();
                txtTutar.Text = kasa.Tutar.Value.ToString();
                if (kasa.GCKod == "G") radiogiris.Checked = true;
                if (kasa.GCKod == "Ç") radiocikis.Checked = true;
                KasaAc(kasa.KasaId.Value);
            }
            catch (Exception)
            {
                Edit = false;
                IslemId = -1;
                KasaId = -1;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && IslemId > 0 && mesaj.Guncelle() == DialogResult.Yes)
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
            if (Edit && IslemId > 0 && mesaj.Silme() == DialogResult.Yes)
                Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtKasaKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.KasaKarti(true);
            if (ID > 0)
            {
                KasaAc(ID);
            }
            AnaForm.Aktarma = -1;
        }


    }
}
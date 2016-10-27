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

namespace Otomasyon.Modul_Banka
{
    public partial class FormBankaİslemi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();

        public bool Secim = false;
        bool Edit = false;
        int IslemID = -1;
        int BankaID = -1;

        public FormBankaİslemi()
        {
            InitializeComponent();
        }

        void Temizle()
        {
            radioGelen.Checked=true;
            txtAciklama.Text = "";
            txtBelgeNo.Text = "";
            txtHesapAd.Text = "";
            txtHesapNo.Text = "";
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";

            Edit = false;
            IslemID=-1;
            BankaID = -1;
            AnaForm.Aktarma = -1;
        }

        void Kaydet()
        {
            try
            {
                Fonksiyonlar.tbl_BankaHareketleri banka = new Fonksiyonlar.tbl_BankaHareketleri();
                if (txtAciklama.Text != "" && txtBelgeNo.Text != "" && txtTarih.Text != "" && txtTutar.Text != "" && txtHesapAd.Text != "" && txtHesapNo.Text != "")
                {
                    banka.BelgeNo = txtBelgeNo.Text;
                    banka.EvrakTur = "Banka İşlemi";
                    banka.Aciklama = txtAciklama.Text;
                    banka.BankaId = BankaID;
                    banka.Tarih = DateTime.Parse(txtTarih.Text);
                    banka.Tutar = decimal.Parse(txtTutar.Text);
                    if (radioGelen.Checked) banka.GCKod = "G";
                    if (radioGiden.Checked) banka.GCKod = "Ç";
                    banka.SaveDate = DateTime.Now;
                    banka.SaveUser = AnaForm.USERID;
                    DB.tbl_BankaHareketleris.InsertOnSubmit(banka);
                    DB.SubmitChanges();
                    mesaj.YeniKayit("Yeni Kayıt Oluşturuldu.");
                    Temizle();
                }
                else
                {
                    mesaj.Uyari("Tüm Alanları Doldurun.");
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
                Fonksiyonlar.tbl_BankaHareketleri banka = DB.tbl_BankaHareketleris.First(s => s.ID == IslemID);
                if (txtAciklama.Text != "" && txtBelgeNo.Text != "" && txtTarih.Text != "" && txtTutar.Text != "" && txtHesapAd.Text != "" && txtHesapNo.Text != "")
                {
                    banka.BelgeNo = txtBelgeNo.Text;
                    banka.EvrakTur = "Banka İşlemi";
                    banka.BankaId = BankaID;
                    banka.Aciklama = txtAciklama.Text;
                    banka.Tarih = DateTime.Parse(txtTarih.Text);
                    banka.Tutar = decimal.Parse(txtTutar.Text);
                    if (radioGelen.Checked) banka.GCKod = "G";
                    if (radioGiden.Checked) banka.GCKod = "Ç";
                    banka.SaveDate = DateTime.Now;
                    banka.SaveUser = AnaForm.USERID;              
                    DB.SubmitChanges();
                    mesaj.Guncelle(true);
                    Temizle();
                }
                else
                {
                    mesaj.Uyari("Tüm Alanları Doldurun.");
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
                DB.tbl_BankaHareketleris.DeleteOnSubmit(DB.tbl_BankaHareketleris.First(s => s.ID == IslemID));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        }

        void HesapAc(int ID)
        {
            BankaID = ID;
            Fonksiyonlar.tbl_BankaKarti kart = DB.tbl_BankaKartis.First(s => s.ID == BankaID);
            txtHesapAd.Text = kart.HesapAd;
            txtHesapNo.Text = kart.HesapNo;

        }

        public void Ac(int ID)
        {
            try
            {
                Edit = true;
                IslemID = ID;
                Fonksiyonlar.tbl_BankaHareketleri kart = DB.tbl_BankaHareketleris.First(s => s.ID == IslemID);
                txtBelgeNo.Text = kart.BelgeNo;
                txtAciklama.Text = kart.Aciklama;
                txtTarih.Text = kart.Tarih.Value.ToShortDateString();
                txtTutar.Text = kart.Tutar.Value.ToString();
                if (kart.GCKod == "G") radioGelen.Checked = true;
                if (kart.GCKod == "Ç") radioGiden.Checked = true;
                HesapAc(kart.BankaId.Value);
            }
            catch (Exception)
            {
                Edit = false;
                BankaID = -1;
                IslemID = -1;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 && mesaj.Guncelle() == DialogResult.Yes)
            {
                Guncelle();
            }
            else
            {
                Kaydet();
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBankaİslemi_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void txtHesapAd_Click(object sender, EventArgs e)
        {
            int ID = form.BankaListe(true);
            if (ID > 0)
            {
                HesapAc(ID);
            }
            AnaForm.Aktarma = -1;
        }

        private void btnSil_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 && mesaj.Silme() == DialogResult.Yes)
                Sil();
        }

    }
}
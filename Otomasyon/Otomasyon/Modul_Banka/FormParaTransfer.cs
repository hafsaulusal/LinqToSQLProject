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
    public partial class FormParaTransfer : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        bool Edit = false;
        int CariID = -1;
        int HesapID = -1;
        int islemID = -1;


        public FormParaTransfer()
        {
            InitializeComponent();
        }

        private void FormParaTransfer_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void txtTransferTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTransferTur.SelectedIndex == 0)
            { 
                radioGelen.Text = "Gelen Havale";
                radioGiden.Text = "Giden Havale";
            }
            else if (txtTransferTur.SelectedIndex == 1)
            {
                radioGelen.Text = "Gelen EFT";
                radioGiden.Text = "Giden EFT";
 
            }

        }

        void Temizle()
        {
            txtBelgeNo.Text = "";
            txtHesapAd.Text = "";
            txtHesapNo.Text = "";
            txtCariAd.Text = "";
            txtCariKod.Text = "";
            txtTransferTur.SelectedIndex=0;
            txtTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";
            txtAciklama.Text = "";
            radioGelen.Checked= true;

            Edit = false;
            CariID = -1;
            HesapID = -1;
            islemID = -1;
            AnaForm.Aktarma = -1;
        }

        void HesapAc(int ID)
        {
            try
            {
                HesapID = ID;
                Fonksiyonlar.tbl_BankaKarti banka = DB.tbl_BankaKartis.First(s => s.ID == HesapID);
                txtHesapAd.Text = banka.HesapAd;
                txtHesapNo.Text = banka.HesapNo;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }

        }

        void CariAc(int ID)
        {
            try
            {
                CariID = ID;
                Fonksiyonlar.tbl_CariKarti cari = DB.tbl_CariKartis.First(s => s.ID == CariID);
                txtCariKod.Text = cari.CariKod;
                txtCariAd.Text = cari.CariAd;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        }

        void Kaydet()
        {
            try
            {
                if (txtBelgeNo.Text != "" && txtAciklama.Text != "" && txtCariAd.Text != "" && txtCariKod.Text != "" &&
                        txtHesapAd.Text != "" && txtHesapNo.Text != "" && txtTutar.Text != "")
                {
                    Fonksiyonlar.tbl_BankaHareketleri banka = new Fonksiyonlar.tbl_BankaHareketleri();
                    banka.BelgeNo = txtBelgeNo.Text;
                    banka.Aciklama = txtAciklama.Text;
                    banka.BankaId = HesapID;
                    banka.CariId = CariID;
                    banka.EvrakTur = txtTransferTur.SelectedItem.ToString();
                    if (radioGelen.Checked) banka.GCKod = "G";
                    if (radioGiden.Checked) banka.GCKod = "Ç";
                    banka.Tarih = DateTime.Parse(txtTarih.Text);
                    banka.Tutar = decimal.Parse(txtTutar.Text);
                    banka.SaveDate = DateTime.Now;
                    banka.SaveUser = AnaForm.USERID;
                    DB.tbl_BankaHareketleris.InsertOnSubmit(banka);
                    DB.SubmitChanges();
                    mesaj.YeniKayit(txtTransferTur.SelectedItem.ToString() + " " + "yeni banka hareketi olarak işlenmiştir.");

                    Fonksiyonlar.tbl_CariHareketleri cari = new Fonksiyonlar.tbl_CariHareketleri();
                    cari.Aciklama = txtAciklama.Text;
                    if (radioGelen.Checked) cari.Alacak = decimal.Parse(txtTutar.Text);
                    if (radioGiden.Checked) cari.Borc = decimal.Parse(txtTutar.Text);
                    cari.EvrakId = banka.ID;
                    cari.CariId = CariID;
                    cari.EvrakTur = txtTransferTur.SelectedItem.ToString();
                    if (txtTransferTur.SelectedIndex == 0) cari.Tipi = "Havale";
                    if (txtTransferTur.SelectedIndex == 1) cari.Tipi = "EFT";
                    cari.SaveDate = DateTime.Now;
                    cari.SaveUser = AnaForm.USERID;
                    DB.tbl_CariHareketleris.InsertOnSubmit(cari);
                    DB.SubmitChanges();
                    mesaj.YeniKayit(txtTransferTur.SelectedItem.ToString() + " " + "yeni cari hareketi olarak işlenmiştir.");
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
            try
            {
                if (txtBelgeNo.Text != "" && txtAciklama.Text != "" && txtCariAd.Text != "" && txtCariKod.Text != "" &&
                        txtHesapAd.Text != "" && txtHesapNo.Text != "" && txtTutar.Text != "")
                {
                    Fonksiyonlar.tbl_BankaHareketleri banka = DB.tbl_BankaHareketleris.First(s => s.ID == islemID);
                    banka.BelgeNo = txtBelgeNo.Text;
                    banka.Aciklama = txtAciklama.Text;
                    banka.BankaId = HesapID;
                    banka.CariId = CariID;
                    banka.EvrakTur = txtTransferTur.SelectedItem.ToString();
                    banka.Aciklama = txtAciklama.Text;
                    if (radioGelen.Checked) banka.GCKod = "G";
                    if (radioGiden.Checked) banka.GCKod = "Ç";
                    banka.Tarih = DateTime.Parse(txtTarih.Text);
                    banka.Tutar = decimal.Parse(txtTutar.Text);
                    banka.EditDate = DateTime.Now;
                    banka.EditUser = AnaForm.USERID;
                    DB.SubmitChanges();
                    Fonksiyonlar.tbl_CariHareketleri cari = DB.tbl_CariHareketleris.First(s => s.EvrakTur==txtTransferTur.SelectedItem.ToString() && s.EvrakId==islemID);
                    cari.Aciklama = txtAciklama.Text;
                    if (radioGelen.Checked) cari.Alacak = decimal.Parse(txtTutar.Text);
                    if (radioGiden.Checked) cari.Borc = decimal.Parse(txtTutar.Text);
                    cari.EvrakId = banka.ID;
                    cari.CariId = CariID;
                    cari.EvrakTur = txtTransferTur.SelectedItem.ToString();
                    if (txtTransferTur.SelectedIndex == 0) cari.Tipi = "Havale";
                    if (txtTransferTur.SelectedIndex == 1) cari.Tipi = "EFT";
                    cari.EditDate = DateTime.Now;
                    cari.EditUser = AnaForm.USERID;
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
                DB.tbl_BankaHareketleris.DeleteOnSubmit(DB.tbl_BankaHareketleris.First(s => s.ID == HesapID));
                DB.tbl_CariHareketleris.DeleteOnSubmit(DB.tbl_CariHareketleris.First(s => s.ID == CariID));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
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

        private void txtCariKod_Click(object sender, EventArgs e)
        {
            int ID = form.CariListe(true);
            if (ID > 0)
            {
                CariAc(ID);
            }
            AnaForm.Aktarma = -1;

        }

        public void Ac(int ID)
        {
            try
            {
                Edit = true;
                islemID = ID;
                Fonksiyonlar.tbl_BankaHareketleri hareket = DB.tbl_BankaHareketleris.First(s => s.ID == islemID);
                txtAciklama.Text = hareket.Aciklama;
                txtBelgeNo.Text = hareket.BelgeNo;
                txtTransferTur.Text = hareket.EvrakTur;
                txtTarih.Text = hareket.Tarih.Value.ToShortDateString();
                txtTutar.Text = hareket.Tutar.Value.ToString();
                HesapAc(hareket.BankaId.Value);
                CariAc(hareket.CariId.Value);
            }
            catch (Exception e)
            {
                Edit = false;
                islemID = -1;
                CariID = -1;
                HesapID = -1;
                mesaj.Hata(e);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && islemID > 0 && mesaj.Guncelle() == DialogResult.Yes)
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
            if (Edit && islemID > 0 && mesaj.Silme() == DialogResult.Yes)
                Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
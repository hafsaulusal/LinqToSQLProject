using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Cek
{
    public partial class FormMusteriCek : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar frm = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();

        bool Edit = false;
        int CariID = -1;
        int CekID = -1;

        public FormMusteriCek()
        {
            InitializeComponent();
        }

        private void FormMusteriCek_Load(object sender, EventArgs e)
        {
            txtVadeTarih.Text = DateTime.Now.ToShortDateString();
        }

        void Temizle()
        {
            txtAciklama.Text = "";
            txtAsilBorclu.Text = "";
            txtBanka.Text = "";
            txtBelgeNo.Text = "";
            txtCariAd.Text = "";
            txtCariKod.Text = "";
            txtCekNo.Text = "";
            txtCekTur.SelectedIndex = 0;
            txtHesapNo.Text = "";
            txtSube.Text = "";
            txtTutar.Text = "0";
            txtVadeTarih.Text = DateTime.Now.ToShortDateString();

            CekID = -1;
            CariID = -1;
            Edit = false;
            AnaForm.Aktarma = -1;
        }

        void Kaydet()
        {
            try
            {
                Fonksiyonlar.tbl_Cekler cek = new Fonksiyonlar.tbl_Cekler();
                cek.Aciklama = txtAciklama.Text;
                if (txtCekTur.SelectedIndex == 0) cek.AcKod = "A";
                if (txtCekTur.SelectedIndex == 1) cek.AcKod = "C";
                cek.AlinanCariId = CariID;
                cek.AsilBorclu = txtAsilBorclu.Text;
                cek.Banka = txtBanka.Text;
                cek.BelgeNo = txtBelgeNo.Text;
                cek.CekNo = txtCekNo.Text;
                cek.Durum = "Portföy";
                cek.HesapNo = txtHesapNo.Text;
                cek.Sube = txtSube.Text;
                cek.Tahsil = "Hayır";
                cek.Tipi = "Müşteri Çeki";
                cek.VadeTarih = DateTime.Parse(txtVadeTarih.Text);
                cek.Tutar = decimal.Parse(txtTutar.Text);
                cek.SaveUser = AnaForm.USERID;
                cek.SaveDate = DateTime.Now;

                DB.tbl_Ceklers.InsertOnSubmit(cek);
                DB.SubmitChanges();
                mesaj.YeniKayit(txtCekNo.Text + " nolu müşteri çeki kaydı gerçekleşmiştir.");
                /////////////////////////////////////////////////////////////////////////////////////////////////////
                Fonksiyonlar.tbl_CariHareketleri cari = new Fonksiyonlar.tbl_CariHareketleri();
                cari.Aciklama = txtBelgeNo.Text + " nolu belge no ve" + txtCekNo.Text + " nolu müşteri çeki";
                cari.CariId = CariID;
                cari.EvrakId = cek.ID;
                cari.EvrakTur = "Müşteri Çeki";
                cari.Tipi = "MÇ";
                cari.Tarih = DateTime.Now;
                cari.SaveDate = DateTime.Now;
                cari.SaveUser = AnaForm.USERID;

                DB.tbl_CariHareketleris.InsertOnSubmit(cari);
                DB.SubmitChanges();
                mesaj.YeniKayit(txtCekNo + " nolu müşteri çeki cari kaydı gerçekleşmiştir.");
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
                Fonksiyonlar.tbl_Cekler cek = DB.tbl_Ceklers.First(s => s.ID == CekID);
                cek.Aciklama = txtAciklama.Text;
                if (txtCekTur.SelectedIndex == 0) cek.AcKod = "A";
                if (txtCekTur.SelectedIndex == 1) cek.AcKod = "C";
                cek.AlinanCariId = CariID;
                cek.Banka = txtBanka.Text;
                cek.BelgeNo = txtBelgeNo.Text;
                cek.CekNo = txtCekNo.Text;
                cek.Durum = "Portföy";
                cek.HesapNo = txtHesapNo.Text;
                cek.Sube = txtSube.Text;
                cek.Tahsil = "Hayır";
                cek.Tipi = "Müşteri Çeki";
                cek.VadeTarih = DateTime.Parse(txtVadeTarih.Text);
                cek.Tutar = decimal.Parse(txtTutar.Text);
                cek.EditUser = AnaForm.USERID;
                cek.EditDate = DateTime.Now;

                DB.SubmitChanges();
                mesaj.Guncelle(true);
                /////////////////////////////////////////////////////////////////////////////////////////////////////
                Fonksiyonlar.tbl_CariHareketleri cari = DB.tbl_CariHareketleris.First(s => s.ID == CekID && s.EvrakTur == "Müşteri Çeki" && s.Tipi == "MÇ");
                cari.Aciklama = txtBelgeNo.Text + " nolu belge no ve" + txtCekNo.Text + " nolu müşteri çeki";
                cari.CariId = CariID;
                cari.EvrakId = cek.ID;
                cari.EvrakTur = "Müşteri Çeki";
                cari.Tipi = "MÇ";
                cari.Tarih = DateTime.Now;
                cari.EditDate = DateTime.Now;
                cari.EditUser = AnaForm.USERID;

                DB.SubmitChanges();
                mesaj.Guncelle(true);
                Temizle();
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        }

        void CariAc(int ID) 
        {
            CariID = ID;
            Fonksiyonlar.tbl_CariKarti cari = DB.tbl_CariKartis.First(s => s.ID == CariID);
            txtCariKod.Text = cari.CariKod;
            txtCariAd.Text = cari.CariAd;
        }

        void Ac(int ID)
        {
            try
            {
                CekID = ID;
                Fonksiyonlar.tbl_Cekler cek = DB.tbl_Ceklers.First(s => s.ID == CekID);
                txtAciklama.Text = cek.Aciklama;
                if (cek.AcKod == "A") txtCekTur.SelectedIndex = 0;
                if (cek.AcKod == "C") txtCekTur.SelectedIndex = 1;
                txtAsilBorclu.Text = cek.AsilBorclu;
                txtBelgeNo.Text = cek.BelgeNo;
                txtCekNo.Text = cek.CekNo;
                txtHesapNo.Text = cek.HesapNo;
                txtSube.Text = cek.Sube;
                txtTutar.Text = cek.Tutar.Value.ToString();
                txtVadeTarih.Text = cek.Tarih.Value.ToShortDateString();
                CariAc(cek.AlinanCariId.Value);
                Edit = true;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
                Temizle();
            }
 
        }

        private void txtCariKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int id = frm.CariListe(true);
            if (id > 0)
            {
                CariAc(id);
                AnaForm.Aktarma = -1;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtBelgeNo.Text != "")
            {
                if (Edit && CariID > 0 && mesaj.Guncelle() == DialogResult.Yes)
                    Guncelle();
                else
                    Kaydet();
            }
            else
                mesaj.Uyari("Lütfen Tüm Alanları Doldurun");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
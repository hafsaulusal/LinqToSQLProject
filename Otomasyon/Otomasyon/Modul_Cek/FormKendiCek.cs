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
    public partial class FormKendiCek : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        bool Edit = false;
        int BankaID = -1;
        int CekID = -1;

        public FormKendiCek()
        {
            InitializeComponent();
        }

        private void FormKendiCek_Load(object sender, EventArgs e)
        {
            txtVadeTarih.Text = DateTime.Now.ToShortDateString();
        }

        void Temizle()
        {
            txtBelgeNo.Text = "";
            txtCekNo.Text = "";
            txtHesapNo.Text = "";
            txtSube.Text = "";
            txtVadeTarih.Text = DateTime.Now.ToShortDateString();
            txtTutar.Text = "0";
            txtAciklama.Text = "";
            txtBanka.Text = "";

            Edit = false;
            CekID = -1;
            BankaID = -1;
            AnaForm.Aktarma = -1;
        }

        void Sil()
        {
            try
            {
                DB.tbl_Ceklers.DeleteOnSubmit(DB.tbl_Ceklers.First(s => s.ID == CekID));
                DB.tbl_BankaHareketleris.DeleteOnSubmit(DB.tbl_BankaHareketleris.First(s => s.EvrakId == CekID && s.EvrakTur == "Kendi Çekimiz"));
            }
            catch ( Exception e)
            {
                mesaj.Hata(e);
            }

        }

        void Kaydet()
        {
            try
            {
                Fonksiyonlar.tbl_Cekler cek = new Fonksiyonlar.tbl_Cekler();
                cek.Aciklama = txtAciklama.Text;
                cek.AcKod = "A";
                cek.Banka = txtBanka.Text;
                cek.BelgeNo = txtBelgeNo.Text;
                cek.CekNo = txtCekNo.Text;
                cek.HesapNo = txtHesapNo.Text;
                cek.Durum = "Portföy";
                cek.Tahsil = "Hayır";
                cek.Sube = txtSube.Text;
                cek.Tipi = "Kendi Çekimiz";
                cek.Tarih = DateTime.Now;
                cek.SaveDate = DateTime.Now;
                cek.SaveUser = AnaForm.USERID;
                cek.Tutar = decimal.Parse(txtTutar.Text);
                cek.VadeTarih = DateTime.Parse(txtVadeTarih.Text);

                DB.tbl_Ceklers.InsertOnSubmit(cek);
                DB.SubmitChanges();
                mesaj.YeniKayit(txtCekNo.Text + " nolu çekimizin çek kaydı yapılmıştır.");
                //////////////////////////////////////////////////////////////////////////////////////
                Fonksiyonlar.tbl_BankaHareketleri hareket = new Fonksiyonlar.tbl_BankaHareketleri();
                hareket.Aciklama = txtCekNo.Text + " nolu çek no ve" + txtVadeTarih.Text + " vadeli kendi çekimiz";
                hareket.BankaId = BankaID;
                hareket.BelgeNo = txtBelgeNo.Text;
                hareket.EvrakId = cek.ID;
                hareket.EvrakTur = "Kendi Çekimiz";
                hareket.GCKod = "Ç";
                hareket.Tarih = DateTime.Now;
                hareket.Tutar = 0;
                hareket.SaveDate = DateTime.Now;
                hareket.SaveUser = AnaForm.USERID;

                DB.tbl_BankaHareketleris.InsertOnSubmit(hareket);
                DB.SubmitChanges();
                mesaj.YeniKayit(txtCekNo.Text + " nolu çekimizin banka kaydı yapılmıştır.");
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
                cek.AcKod = "A";
                cek.Banka = txtBanka.Text;
                cek.BelgeNo = txtBelgeNo.Text;
                cek.CekNo = txtCekNo.Text;
                cek.HesapNo = txtHesapNo.Text;
                cek.Durum = "Portföy";
                cek.Tahsil = "Hayır";
                cek.Sube = txtSube.Text;
                cek.Tipi = "Kendi Çekimiz";
                cek.Tarih = DateTime.Now;
                cek.EditDate = DateTime.Now;
                cek.EditUser = AnaForm.USERID;
                cek.Tutar = decimal.Parse(txtTutar.Text);
                cek.VadeTarih = DateTime.Parse(txtVadeTarih.Text);

                DB.tbl_Ceklers.InsertOnSubmit(cek);
                DB.SubmitChanges();
                mesaj.Guncelle(true);
                //////////////////////////////////////////////////////////////////////////////////////
                Fonksiyonlar.tbl_BankaHareketleri hareket = DB.tbl_BankaHareketleris.First(s => s.EvrakId == CekID && s.EvrakTur == "Kendi Çekimiz");
                hareket.Aciklama = txtCekNo.Text + " nolu çek no ve" + txtVadeTarih.Text + " vadeli kendi çekimiz";
                hareket.BankaId = BankaID;
                hareket.BelgeNo = txtBelgeNo.Text;
                hareket.EvrakId = cek.ID;
                hareket.EvrakTur = "Kendi Çekimiz";
                hareket.GCKod = "Ç";
                hareket.Tarih = DateTime.Now;
                hareket.Tutar = 0;
                hareket.EditDate = DateTime.Now;
                hareket.EditUser = AnaForm.USERID;

                DB.tbl_BankaHareketleris.InsertOnSubmit(hareket);
                DB.SubmitChanges();
                mesaj.Guncelle(true);
                Temizle();
            }
            catch ( Exception e)
            {
                mesaj.Hata(e);
            }
        }

        void HesapAc(int ID)
        {
            try
            {
                BankaID = ID;
                Fonksiyonlar.tbl_BankaKarti bank = DB.tbl_BankaKartis.First(s => s.ID == BankaID);
                txtBanka.Text = bank.BankaAd;
                txtHesapNo.Text = bank.HesapNo;
                txtSube.Text = bank.Sube;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        }

        void Ac(int ID)
        {
            try
            {
                CekID = ID;
                Fonksiyonlar.tbl_Cekler cek = DB.tbl_Ceklers.First(s => s.ID == CekID);
                txtAciklama.Text = cek.Aciklama;
                txtBelgeNo.Text = cek.BelgeNo;
                txtCekNo.Text = cek.CekNo;
                txtBanka.Text = cek.Banka;
                txtSube.Text = cek.Sube;
                txtVadeTarih.Text = cek.VadeTarih.Value.ToShortDateString();
                HesapAc(cek.AlinanCariId.Value);
                Edit = true;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
                Temizle();
            }
          
        }

        private void txtHesapNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int id = form.BankaListe(true);
            if (id > 0)
            {
                HesapAc(id);
                AnaForm.Aktarma = -1;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtBelgeNo.Text != "")
            {
                if (Edit && CekID > 0 && mesaj.Guncelle() == DialogResult.Yes)
                    Guncelle();
                else
                    Kaydet();
            }
            else
                mesaj.Uyari("Lütfen Tüm Alanları Doldurun.");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && CekID > 0 && mesaj.Silme() == DialogResult.Yes) Guncelle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBanka_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void txtSube_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}




















































































































































































































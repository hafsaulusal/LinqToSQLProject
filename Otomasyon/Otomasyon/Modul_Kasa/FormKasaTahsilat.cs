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
    public partial class FormKasaTahsilat : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        bool Edit = false;
        int KasaID = -1;
        int CariID = -1;
        int IslemID = -1;
        int CariHareketID = -1;
        string IslemTur = "Kasa Tahsilat";

        public FormKasaTahsilat()
        {
            InitializeComponent();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (Edit && IslemID > 0 && mesaj.Silme() == DialogResult.Yes)
                Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormKasaTahsilat_Load(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void txtIslemTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            IslemTur = txtIslemTur.SelectedItem.ToString();
        }

        void Temizle()
        {
            foreach(Control ct in groupControl1.Controls)
                if(ct is DevExpress.XtraEditors.TextEdit || ct is DevExpress.XtraEditors.ButtonEdit) ct.Text="";
            foreach(Control ce in groupControl2.Controls)
                if (ce is DevExpress.XtraEditors.TextEdit)
                {
                    ce.Text = "";
                    txtTarih.Text = DateTime.Now.ToShortTimeString();
                    txtIslemTur.SelectedIndex = 0;
                }

            Edit = false;
            KasaID = -1;
            CariID = -1;
            CariHareketID = -1;
            AnaForm.Aktarma = -1;

        }

        void Sil()
        {
            try
            {
                DB.tbl_KasaHareketleris.DeleteOnSubmit(DB.tbl_KasaHareketleris.First(s => s.ID == IslemID));
                DB.tbl_CariHareketleris.DeleteOnSubmit(DB.tbl_CariHareketleris.First(s => s.ID == CariHareketID));
                DB.SubmitChanges();
                Temizle();
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
                if (txtBelgeNo.Text != "" && txtCariAd.Text != "" && txtCariKod.Text != "" && txtAciklama.Text != "" && txtTutar.Text != "" && txtKasaAd.Text != "" && txtKasaKod.Text!= "")
                {
                    Fonksiyonlar.tbl_KasaHareketleri kasahareket = new Fonksiyonlar.tbl_KasaHareketleri();
                    kasahareket.Aciklama = txtAciklama.Text;
                    kasahareket.BelgeNo = txtBelgeNo.Text;
                    kasahareket.CariId = CariID;
                    kasahareket.KasaId = KasaID;
                    kasahareket.EvrakTur = txtIslemTur.SelectedItem.ToString();
                    if (txtIslemTur.SelectedIndex == 0) kasahareket.GCKod = "G";
                    if (txtIslemTur.SelectedIndex == 1) kasahareket.GCKod = "Ç";
                    kasahareket.Tarih = DateTime.Parse(txtTarih.Text);
                    kasahareket.Tutar = decimal.Parse(txtTutar.Text);
                    kasahareket.SaveDate = DateTime.Now;
                    kasahareket.SaveUser = AnaForm.USERID;
                    DB.tbl_KasaHareketleris.InsertOnSubmit(kasahareket);
                    DB.SubmitChanges();
                    mesaj.YeniKayit(txtIslemTur.SelectedItem.ToString() + " " + "yeni kasa hareketi olarak işlenmiştir.");
                   
                    Fonksiyonlar.tbl_CariHareketleri carihareket = new Fonksiyonlar.tbl_CariHareketleri();
                    carihareket.Aciklama = txtBelgeNo.Text + " "+"belge numaralı"+" " + txtIslemTur.SelectedItem.ToString() +" "+ "işlemi";
                    if (txtIslemTur.SelectedIndex == 0) carihareket.Alacak = decimal.Parse(txtTutar.Text);
                    if (txtIslemTur.SelectedIndex == 1) carihareket.Borc = decimal.Parse(txtTutar.Text);
                    carihareket.CariId = CariID;
                    carihareket.EvrakId = kasahareket.ID;
                    carihareket.EvrakTur = txtIslemTur.SelectedItem.ToString();
                    carihareket.Tarih = DateTime.Parse(txtTarih.Text);
                    if (txtIslemTur.SelectedIndex == 0) carihareket.Tipi = "KT";
                    if (txtIslemTur.SelectedIndex == 1) carihareket.Tipi = "KÖ";
                    carihareket.SaveDate = DateTime.Now;
                    carihareket.SaveUser = AnaForm.USERID;
                    DB.tbl_CariHareketleris.InsertOnSubmit(carihareket);
                    DB.SubmitChanges();
                    mesaj.YeniKayit(txtIslemTur.SelectedItem.ToString() + " " + "yeni cari hareketi olarak işlenmiştir.");
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
            Fonksiyonlar.tbl_KasaHareketleri kasahareket = DB.tbl_KasaHareketleris.First(s => s.ID == KasaID);
            kasahareket.Aciklama = txtAciklama.Text;
            kasahareket.BelgeNo = txtBelgeNo.Text;
            kasahareket.CariId = CariID;
            kasahareket.KasaId = KasaID;
            kasahareket.EvrakTur = txtIslemTur.SelectedItem.ToString();
            if (txtIslemTur.SelectedIndex == 0) kasahareket.GCKod = "G";
            if (txtIslemTur.SelectedIndex == 1) kasahareket.GCKod = "Ç";
            kasahareket.Tarih = DateTime.Parse(txtTarih.Text);
            kasahareket.Tutar = decimal.Parse(txtTutar.Text);
            kasahareket.EditDate = DateTime.Now;
            kasahareket.EditUser = AnaForm.USERID;
           
            DB.SubmitChanges();
            mesaj.YeniKayit(txtIslemTur.SelectedItem.ToString() + "yeni kasa hareketi olarak işlenmiştir.");

            Fonksiyonlar.tbl_CariHareketleri carihareket = new Fonksiyonlar.tbl_CariHareketleri();
            carihareket.Aciklama = txtBelgeNo.Text + "belge numaralı" + txtIslemTur.SelectedItem.ToString() + "işlemi";
            if (txtIslemTur.SelectedIndex == 0) carihareket.Alacak = decimal.Parse(txtTutar.Text);
            if (txtIslemTur.SelectedIndex == 1) carihareket.Borc = decimal.Parse(txtTutar.Text);
            carihareket.CariId = CariID;
            carihareket.EvrakId = kasahareket.ID;
            carihareket.EvrakTur = txtIslemTur.SelectedItem.ToString();
            carihareket.Tarih = DateTime.Parse(txtTarih.Text);
            if (txtIslemTur.SelectedIndex == 0) carihareket.Tipi = "KT";
            if (txtIslemTur.SelectedIndex == 1) carihareket.Tipi = "KÖ";
            carihareket.SaveDate = DateTime.Now;
            carihareket.SaveUser = AnaForm.USERID;
            DB.tbl_CariHareketleris.InsertOnSubmit(carihareket);
            DB.SubmitChanges();
            mesaj.YeniKayit(txtIslemTur.SelectedItem.ToString() + "yeni cari hareketi olarak işlenmiştir.");
            Temizle();
 
        }

        void KasaAc(int ID) 
        {
            try
            {
                KasaID = ID;
                Fonksiyonlar.tbl_KasaKarti kasa = DB.tbl_KasaKartis.First(s => s.ID == KasaID);
                txtKasaAd.Text = kasa.KasaAd;
                txtKasaKod.Text = kasa.KasaKod;
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
                txtCariAd.Text = cari.CariAd;
                txtCariKod.Text = cari.CariKod;
            }
            catch ( Exception e)
            {
                mesaj.Hata(e);
            }
        }

        public void Ac(int ID)
        {
            try
            {
                Edit = true;
                IslemID = ID;
                Fonksiyonlar.tbl_KasaHareketleri hareket = DB.tbl_KasaHareketleris.First(s => s.ID == IslemID);
                CariHareketID = DB.tbl_CariHareketleris.First(s => s.EvrakTur == hareket.EvrakTur && s.EvrakId == IslemID).ID;
                txtAciklama.Text = hareket.Aciklama;
                txtBelgeNo.Text = hareket.BelgeNo;
                if (hareket.EvrakTur == "Kasa Tahsilat") txtIslemTur.SelectedIndex = 0;
                if (hareket.EvrakTur == "Kasa Ödeme") txtIslemTur.SelectedIndex = 1;
                txtTarih.Text = hareket.Tarih.Value.ToShortDateString();
                txtTutar.Text = hareket.Tutar.Value.ToString();
                KasaAc(hareket.KasaId.Value);
                CariAc(hareket.CariId.Value);
            }
            catch (Exception e)
            {
                Edit = false;
                IslemID = -1;
                KasaID = -1;
                CariID = -1;
                CariHareketID = -1;
                mesaj.Hata(e);
            }
        }

        private void txtKasaKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.KasaListe(true);
            if (ID > 0)
            {
                KasaAc(ID);
            }
            AnaForm.Aktarma = -1;
        }

        private void txtCariKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.CariListe(true);
            if (ID > 0)
            {
                CariAc(ID);
            }
            AnaForm.Aktarma = -1;

        }

        private void txtKasaKod_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}
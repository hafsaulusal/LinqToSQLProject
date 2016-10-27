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
    public partial class FormBankaAcilisKart : DevExpress.XtraEditors.XtraForm
    {

        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        bool Edit = false;
        int SecimID = -1;

        public FormBankaAcilisKart()
        {
            InitializeComponent();
        }

        private void FormBankaAcilisKart_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.View_BankaBakiyes
                      select s;
            Liste.DataSource = lst;

        }

        void Temizle()
        {
            foreach (Control CT in groupControl1.Controls)
                if (CT is DevExpress.XtraEditors.TextEdit || CT is DevExpress.XtraEditors.MemoEdit) CT.Text = "";

            Edit = false;
            Listele();
        }

        void Kaydet()
        {
            Fonksiyonlar.tbl_BankaKarti bank = new Fonksiyonlar.tbl_BankaKarti();
            try
            {
                if (txtBankaAd.Text != "" && txtBankaSube.Text != "" && txtAdres.Text != "" && txtHesapNo.Text != ""
                       && txtHesapTur.Text != "" && txtIBAN.Text != "" && txtSubeTel.Text != "" && txtYetkili.Text != ""
                       && txtYetkiliEmail.Text != "")
                {
                    bank.Adres = txtAdres.Text;
                    bank.BankaAd = txtBankaAd.Text;
                    bank.HesapAd = txtHesapTur.Text;
                    bank.HesapNo = txtHesapNo.Text;
                    bank.IBAN = txtIBAN.Text;
                    bank.Sube = txtBankaSube.Text;
                    bank.Tel = txtSubeTel.Text;
                    bank.Yetkili = txtYetkili.Text;
                    bank.YetkiliMail = txtYetkiliEmail.Text;
                    bank.SaveDate = DateTime.Now;
                    bank.SaveUser = AnaForm.USERID;
                    DB.tbl_BankaKartis.InsertOnSubmit(bank);
                    DB.SubmitChanges();
                    mesaj.YeniKayit("Yeni Banka Kaydı Oluşturuldu.");
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
            Fonksiyonlar.tbl_BankaKarti bank = DB.tbl_BankaKartis.First(s => s.ID == SecimID);
            try
            {
                if (txtBankaAd.Text != "" && txtBankaSube.Text != "" && txtAdres.Text != "" && txtHesapNo.Text != ""
                       && txtHesapTur.Text != "" && txtIBAN.Text != "" && txtSubeTel.Text != "" && txtYetkili.Text != ""
                       && txtYetkiliEmail.Text != "")
                {
                    bank.Adres = txtAdres.Text;
                    bank.BankaAd = txtBankaAd.Text;
                    bank.HesapAd= txtHesapTur.Text;
                    bank.HesapNo = txtHesapNo.Text;
                    bank.IBAN = txtIBAN.Text;
                    bank.Sube = txtBankaSube.Text;
                    bank.Tel = txtSubeTel.Text;
                    bank.Yetkili = txtYetkili.Text;
                    bank.YetkiliMail = txtYetkiliEmail.Text;
                    bank.EditDate = DateTime.Now;
                    bank.EditUser = AnaForm.USERID;
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
                DB.tbl_BankaKartis.DeleteOnSubmit(DB.tbl_BankaKartis.First(s => s.ID == SecimID));
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
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                if (SecimID > 0) Ac();
            }
            catch (Exception)
            {
                Edit = false;
                SecimID = -1;
            }
        }

        void Ac()
        {
            try
            {
                Fonksiyonlar.tbl_BankaKarti bank = DB.tbl_BankaKartis.First(s => s.ID == SecimID);
                txtAdres.Text = bank.Adres;
                txtBankaAd.Text = bank.BankaAd;
                txtBankaSube.Text = bank.Sube;
                txtHesapNo.Text = bank.HesapNo;
                txtHesapTur.Text = bank.HesapAd;
                txtIBAN.Text = bank.IBAN;
                txtSubeTel.Text = bank.Tel;
                txtYetkili.Text = bank.Yetkili;
                txtYetkiliEmail.Text = bank.YetkiliMail;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && SecimID > 0)
            {
                AnaForm.Aktarma = SecimID;
                this.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && SecimID > 0 && mesaj.Guncelle() == DialogResult.Yes)
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
            if (Edit && SecimID > 0 && mesaj.Silme() == DialogResult.Yes)
                Sil();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAdres_EditValueChanged(object sender, EventArgs e)
        {

        }


    }
}
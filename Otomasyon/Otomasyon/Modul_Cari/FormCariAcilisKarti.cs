using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Cari
{
    public partial class FormCariAcilisKarti : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara numara = new Fonksiyonlar.Numara();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        bool Edit = false;
        int CariId = -1;
        int GrupId = -1;

        public FormCariAcilisKarti()
        {
            InitializeComponent();
        }

        private void FormCariAcilisKarti_Load(object sender, EventArgs e)
        {
            txtCariKodu.Text = numara.CariKodNumarasi();
        }

        void Temizle()
        {
            foreach (Control CT in groupControl1.Controls)
                if (CT is DevExpress.XtraEditors.TextEdit || CT is DevExpress.XtraEditors.ButtonEdit) CT.Text = "";

            foreach (Control CE in groupControl2.Controls)
                if (CE is DevExpress.XtraEditors.TextEdit || CE is DevExpress.XtraEditors.ButtonEdit || CE is DevExpress.XtraEditors.MemoEdit) CE.Text = "";

            Edit = false;
            CariId = -1;
            GrupId = -1;
            AnaForm.Aktarma=-1;

   /*     
            txtCariKodu.Text = numara.CariKodNumarasi();
            txtCariAdı.Text = "";
            txtVergiDairesi.Text = "";
            txtVergiNo.Text = "";
            txtCariGrupKodu.Text = "";
            txtCariGrupAdı.Text = "";
            txtÜlke.Text = "";
            txtİl.Text = "";
            txtİlce.Text = "";
            txtAdres.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtWebAdresi.Text = "";
            txtMailInfo.Text = "";
            txtYetkili1.Text = "";
            txtYetkili1Mail.Text = "";
            txtYetkili2.Text = "";
            txtYetkili2Mail.Text = "";
            txtFax1.Text = "";
            txtFax2.Text = ""; 
            
*/ 
        
        }

        void Kaydet() {
            try
            {

                Fonksiyonlar.tbl_CariKarti carikart = new Fonksiyonlar.tbl_CariKarti();

                if (txtCariAdı.Text != "" && txtCariKodu.Text != "" && txtCariGrupAdı.Text != "" && txtVergiDairesi.Text != "" && txtVergiNo.Text!="" &&
                   txtÜlke.Text != "" && txtİl.Text != "" && txtİlce.Text != "" && txtAdres.Text != "" && txtTel1.Text!="" && txtTel2.Text!="" && txtWebAdresi.Text!="" &&
                txtMailInfo.Text!="" && txtYetkili1.Text!="" && txtYetkili1Mail.Text!="" && txtYetkili2.Text!="" && txtYetkili2Mail.Text!="" &&
                    txtFax1.Text!=""  && txtFax2.Text!="")
                {
                    carikart.CariKod = txtCariKodu.Text;
                    carikart.CariAd = txtCariAdı.Text;
                    carikart.GrupId = GrupId;
                    carikart.GrupAd = txtCariGrupAdı.Text;
                    carikart.VergiDaire = txtVergiDairesi.Text;
                    carikart.VergiNo = txtVergiNo.Text;
                    carikart.Ulke = txtÜlke.Text;
                    carikart.İl = txtİl.Text;
                    carikart.İlce = txtİlce.Text;
                    carikart.Adres = txtAdres.Text;
                    carikart.Tel1 = txtTel1.Text;
                    carikart.Tel2 = txtTel2.Text;
                    carikart.WebAdres = txtWebAdresi.Text;
                    carikart.MailInfo = txtMailInfo.Text;
                    carikart.Yetkili1 = txtYetkili1.Text;
                    carikart.Yetkili1Mail = txtYetkili1Mail.Text;
                    carikart.Yetkili2 = txtYetkili2.Text;
                    carikart.Yetkili2Mail = txtYetkili2Mail.Text;
                    carikart.Fax1 = txtFax1.Text;
                    carikart.Fax2 = txtFax2.Text;
                    carikart.SaveUser = AnaForm.USERID;
                    carikart.SaveDate = DateTime.Now;
                    DB.tbl_CariKartis.InsertOnSubmit(carikart);
                    DB.SubmitChanges();
                    mesaj.YeniKayit("Yeni Cari Kartı Oluşturuldu");
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

        void Guncelle() {
            try
            {

                Fonksiyonlar.tbl_CariKarti carikart = DB.tbl_CariKartis.First(s => s.ID == CariId);
                if (txtCariAdı.Text != "" && txtCariKodu.Text != "" && txtCariGrupAdı.Text != "" && txtVergiDairesi.Text != "" && txtVergiNo.Text != "" &&
                                  txtÜlke.Text != "" && txtİl.Text != "" && txtİlce.Text != "" && txtAdres.Text != "" && txtTel1.Text != "" && txtTel2.Text != "" && txtWebAdresi.Text != "" &&
                               txtMailInfo.Text != "" && txtYetkili1.Text != "" && txtYetkili1Mail.Text != "" && txtYetkili2.Text != "" && txtYetkili2Mail.Text != "" &&
                                   txtFax1.Text != "" && txtFax2.Text != "")
                {
                    carikart.CariKod = txtCariKodu.Text;
                    carikart.CariAd = txtCariAdı.Text;
                    carikart.GrupId = GrupId;
                    carikart.GrupAd = txtCariGrupAdı.Text;
                    carikart.VergiDaire = txtVergiDairesi.Text;
                    carikart.VergiNo = txtVergiNo.Text;
                    carikart.Ulke = txtÜlke.Text;
                    carikart.İl = txtİl.Text;
                    carikart.İlce = txtİlce.Text;
                    carikart.Adres = txtAdres.Text;
                    carikart.Tel1 = txtTel1.Text;
                    carikart.Tel2 = txtTel2.Text;
                    carikart.WebAdres = txtWebAdresi.Text;
                    carikart.MailInfo = txtMailInfo.Text;
                    carikart.Yetkili1 = txtYetkili1.Text;
                    carikart.Yetkili1Mail = txtYetkili1Mail.Text;
                    carikart.Yetkili2 = txtYetkili2.Text;
                    carikart.Yetkili2Mail = txtYetkili2Mail.Text;
                    carikart.Fax1 = txtFax1.Text;
                    carikart.Fax2 = txtFax2.Text;
                    carikart.EditUser = AnaForm.USERID;
                    carikart.EditDate = DateTime.Now;
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

        void Sil() {
            try
            {
                DB.tbl_CariKartis.DeleteOnSubmit(DB.tbl_CariKartis.First(s => s.ID == CariId));
                DB.SubmitChanges();
                Temizle();
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }

        }

        void GrupAc(int ID)
        {
            GrupId = ID;
            /*
           Fonksiyonlar.tbl_CariGrup grup = DB.tbl_CariGrups.First(s => s.ID == GrupId);
           txtCariGrupKodu.Text=grup.GrupKod ;
           txtCariGrupAdı.Text = grup.GrupAd;
            */
            txtCariGrupAdı.Text = DB.tbl_CariGrups.First(s => s.ID == GrupId).GrupAd;
           txtCariGrupKodu.Text = DB.tbl_CariGrups.First(s => s.ID == GrupId).GrupKod;
          
        }

        public void Ac(int ID)
        {
            try
            {
                Edit = true;
                CariId = ID;
                Fonksiyonlar.tbl_CariKarti carikart = DB.tbl_CariKartis.First(s => s.ID == CariId);
                txtCariAdı.Text = carikart.CariAd;
                txtCariKodu.Text = carikart.CariKod;
                txtVergiNo.Text = carikart.VergiNo;
                txtVergiDairesi.Text = carikart.VergiDaire;
                txtÜlke.Text = carikart.Ulke;
                txtİl.Text = carikart.İl;
                txtİlce.Text = carikart.İlce;
                txtAdres.Text = carikart.Adres;
                txtTel1.Text = carikart.Tel1;
                txtTel2.Text = carikart.Tel2;
                txtWebAdresi.Text = carikart.WebAdres;
                txtMailInfo.Text = carikart.MailInfo;
                txtYetkili1.Text = carikart.Yetkili1;
                txtYetkili1Mail.Text = carikart.Yetkili1Mail;
                txtYetkili2.Text = carikart.Yetkili2;
                txtYetkili2Mail.Text = carikart.Yetkili2Mail;
                txtFax1.Text = carikart.Fax1;
                txtFax2.Text = carikart.Fax2;
                GrupAc(carikart.GrupId.Value);
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtVergiNo.Text.Length != 10)
            {
                mesaj.Uyari("Vergi No 10 karakterli olmalıdır");
            }
            else
            {
                if (Edit && CariId > 0 && mesaj.Guncelle() == DialogResult.Yes)
                    Guncelle();
                else
                    Kaydet();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void txtCariGrupKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.CariGrup(true);
            if (ID > 0)
            {
                GrupAc(ID);
            }
            AnaForm.Aktarma = -1;
        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.CariListe(true);
            if (ID > 0)
            {
                Ac(ID);
            }
            AnaForm.Aktarma = -1;
        }
    }
}
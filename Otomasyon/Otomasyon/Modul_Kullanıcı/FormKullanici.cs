using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Kullanıcı
{
    public partial class FormKullanici : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Log log = new Fonksiyonlar.Log();

        int KullaniciID = -1;
        bool Edit = false;

        public FormKullanici(int ID,bool Ac)
        {
            InitializeComponent();
            Edit = Ac;
            KullaniciID = ID;

        }

        void Temizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtKullaniciAd.Text = "";
            txtKullaniciTur.SelectedIndex = 0;
            txtParola.Text = "";
            txtParolaT.Text = "";
            radioPasif.Checked = true;

            Edit = false;
            KullaniciID = -1;

        }

        void KullaniciGetir(int ID)
        {
            KullaniciID = ID;
            try
            {
                Fonksiyonlar.tbl_Kullanici kullanici = DB.tbl_Kullanicis.First(s => s.ID == KullaniciID);
                txtKullaniciAd.Text = kullanici.Kullanici;
                txtAd.Text = kullanici.KullaniciAd;
                txtSoyad.Text = kullanici.KullaniciSoyad;
                txtParola.Text = kullanici.Parola;
                txtParolaT.Text = kullanici.Parola;
                if (kullanici.Kodu == "Normal") txtKullaniciTur.SelectedIndex = 0;
                if (kullanici.Kodu == "Admin") txtKullaniciTur.SelectedIndex = 1;
                if (kullanici.Aktif.Value) radioAktif.Checked = true;
                if (!kullanici.Aktif.Value) radioPasif.Checked = true;
            }
            catch (Exception ex)
            {
                log.HataMesajiYaz(ex);
            }
        }

        void Kaydet()
        {
            if(txtAd.Text!="" && txtKullaniciAd.Text!="" && txtParola.Text!="" && txtParolaT.Text!="")
            {
            if (txtParola.Text.Trim() == txtParolaT.Text.Trim())
            {
                Fonksiyonlar.tbl_Kullanici kullanici;
                if(!Edit) kullanici=new Fonksiyonlar.tbl_Kullanici();
                else kullanici=DB.tbl_Kullanicis.First(s=>s.ID==KullaniciID);
                if(radioAktif.Checked) kullanici.Aktif=true;
                if(radioPasif.Checked) kullanici.Aktif=false;
                kullanici.Kullanici = txtKullaniciAd.Text;
                kullanici.KullaniciAd=txtAd.Text;
                kullanici.KullaniciSoyad=txtSoyad.Text;
                kullanici.Parola=txtParola.Text;
                kullanici.Kodu=txtKullaniciTur.Text;
                if(Edit) kullanici.EditDate=DateTime.Now;
                else kullanici.SaveDate=DateTime.Now;
                if(!Edit) DB.tbl_Kullanicis.InsertOnSubmit(kullanici);
                DB.SubmitChanges();
                if(Edit) mesaj.Guncelle(true);
                else mesaj.YeniKayit(txtKullaniciAd.Text +" kullanıcı kaydı açılmıştır.");
                Temizle();
            }
            else
            {
                mesaj.Uyari("Parola girişi hatalı!");
            }
            }
            else
            {
                mesaj.Uyari("Lütfen tüm alanların dolu olduğundan emin olun");
            }
        }

        private void FormKullanici_Load(object sender, EventArgs e)
        {
            KullaniciGetir(KullaniciID);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (DB.tbl_Kullanicis.Where(s => s.Kullanici == txtKullaniciAd.Text).Count()>1)
            {
                mesaj.Uyari("Bu kullanıcı sistemde kayıtlı!");
                return;
            }
            else
            Kaydet();  
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
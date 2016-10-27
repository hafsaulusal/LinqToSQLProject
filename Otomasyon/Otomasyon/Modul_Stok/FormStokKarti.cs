using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Stok
{
    public partial class FormStokKarti : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Numara numara = new Fonksiyonlar.Numara();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Resim resim = new Fonksiyonlar.Resim();

        bool Edit = false;
        bool Resim = false;
        OpenFileDialog Dosya = new OpenFileDialog();
        int Grupid = -1;
        int Stokid = -1;

        public FormStokKarti()
        {
            InitializeComponent();
        }

        private void txtStokKodu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FormStokKarti_Load(object sender, EventArgs e)
        {
            mesaj.FormAc(this.Text);
           txtStokKodu.Text= numara.StokKodNumarasi();
        }

        void Temizle() 
        {
            txtStokKodu.Text = numara.StokKodNumarasi() ;
            txtStokAdi.Text = "";
            txtAlisFiyat.Text = "0";
            txtSatisFiyat.Text = "0";
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
            txtBirim.SelectedIndex = 0;
            txtBarkod.Text = "";
            txtAlisKDV.Text = "0";
            txtSatisKDV.Text = "0";
            Edit = false;
            Resim = false;
            Stokid = -1;
            Grupid = -1;
            AnaForm.Aktarma = -1;
        
         }

        void ResimSec() {

            Dosya.Filter = "Jpg(*.jpg)|*.jpg|Jpeg(*.jpeg)|*.jpeg";
            if (Dosya.ShowDialog() == DialogResult.OK) {
                pictureBox1.ImageLocation = Dosya.FileName;
                Resim = true;
            }


        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            ResimSec();
        }

        public void Ac(int ID)
        {
            Edit = true;
            Stokid = ID;
            Fonksiyonlar.tbl_Stok stok = DB.tbl_Stoks.First(s => s.ID == Stokid);
            pictureBox1.Image = resim.ResimGetir(stok.StokResim.ToArray());
            txtAlisFiyat.Text = stok.StokAlisFiyat.ToString();
            txtAlisKDV.Text = stok.StokAlisKDV.ToString();
            txtBarkod.Text = stok.StokBarkod;
            txtBirim.Text = stok.StokBirim;
            txtSatisFiyat.Text = stok.StokSatisFiyat.ToString();
            txtSatisKDV.Text = stok.StokSatisKDV.ToString();
            txtStokAdi.Text = stok.StokAd;
            txtStokKodu.Text = stok.StokKodu;
            GrupAc(stok.StokGrupID.Value);

        }

        void Kaydet() {
            try
            {
                Fonksiyonlar.tbl_Stok stok = new Fonksiyonlar.tbl_Stok();
                stok.StokAd = txtStokAdi.Text;
                stok.StokAlisFiyat = decimal.Parse(txtAlisFiyat.Text);
                stok.StokAlisKDV = decimal.Parse(txtAlisKDV.Text);
                stok.StokBarkod = txtBarkod.Text;
                stok.StokBirim = txtBirim.Text;
                stok.StokGrupID = Grupid;
                stok.StokKodu = txtStokKodu.Text;
                stok.StokResim = new System.Data.Linq.Binary(resim.ResimYukleme(pictureBox1.Image));
                stok.StokSatisFiyat = decimal.Parse(txtSatisFiyat.Text);
                stok.StokSatisKDV = decimal.Parse(txtSatisKDV.Text);
                stok.StokSaveDate = DateTime.Now;
                stok.StokSaveUser = AnaForm.USERID;
                DB.tbl_Stoks.InsertOnSubmit(stok);
                DB.SubmitChanges();
                mesaj.YeniKayit("Yeni Grup Kaydı Oluşturuldu");
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
                Fonksiyonlar.tbl_Stok stok =DB.tbl_Stoks.First(s => s.ID == Stokid);
                stok.StokAd = txtStokAdi.Text;
                stok.StokAlisFiyat = decimal.Parse(txtAlisFiyat.Text);
                stok.StokAlisKDV = decimal.Parse(txtAlisKDV.Text);
                stok.StokGrupID = Grupid;
                stok.StokKodu = txtStokKodu.Text;
                if(Resim) stok.StokResim = new System.Data.Linq.Binary(resim.ResimYukleme(pictureBox1.Image));
                stok.StokSatisFiyat = decimal.Parse(txtSatisFiyat.Text);
                stok.StokSatisKDV = decimal.Parse(txtSatisKDV.Text);
                stok.StokEditDate = DateTime.Now;
                stok.StokEditUser = AnaForm.USERID;
                DB.SubmitChanges();
                mesaj.Guncelle(true);
                Temizle();
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
                DB.tbl_Stoks.DeleteOnSubmit(DB.tbl_Stoks.First(s => s.ID == Stokid));
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
            Grupid = ID;
            txtGrupAdi.Text = DB.tbl_StokGrups.First(s => s.ID == Grupid).GrupAd;
            txtGrupKodu.Text = DB.tbl_StokGrups.First(s => s.ID == Grupid).GrupKod;
        }

        private void txtStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.StokListesi(true);
            if (ID > 0) {
                Ac(ID);     
            }
            AnaForm.Aktarma = -1;
        }

        private void txtGrupKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.StokGruplari(true);
            if (ID > 0)
            {
                GrupAc(ID);
            }
            AnaForm.Aktarma = -1;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Edit && Stokid > 0 && mesaj.Guncelle() == DialogResult.Yes)
                Guncelle();
            else
                Kaydet();
        }

        private void FormStokKarti_FormClosed(object sender, FormClosedEventArgs e)
        {
            mesaj.FormKapat(this.Text);
        }

        private void textCommand1_Execute(DevExpress.CodeRush.Core.ExecuteTextCommandEventArgs ea)
        {

        } 
    }
}
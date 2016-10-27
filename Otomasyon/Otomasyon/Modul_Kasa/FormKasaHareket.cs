using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Data.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Kasa
{
    public partial class FormKasaHareket : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        int EvrakID = -1;
        int SecimID = -1;
        int KasaID = -1;
        string EvrakTuru;

        public FormKasaHareket()
        {
            InitializeComponent();
        }

        void Listele()
        {
            var lst = from s in DB.View_KasaHareketleris
                      where s.KasaId == KasaID
                      select s;
            g.DataSource = lst;
        }

        public void Ac(int ID)
        {
            try
            {
                KasaID = ID;
                Fonksiyonlar.tbl_KasaKarti kasa = DB.tbl_KasaKartis.First(s => s.ID == KasaID);
                txtKasaAd.Text = kasa.KasaKod;
                txtKasaKod.Text = kasa.KasaAd;
                DurumGetir();
                Listele();
            }
            catch ( Exception e)
            {
                mesaj.Hata(e);
            }
        }

        void DurumGetir()
        {
            Fonksiyonlar.View_KasaDurum kasa = DB.View_KasaDurums.First(s => s.KasaId == KasaID);
            txtGiris.Text = kasa.GIRIS.Value.ToString();
            txtCikis.Text = kasa.CIKIS.Value.ToString();
            txtBakiye.Text = kasa.BAKIYE.Value.ToString();
        }

        private void FormKasaHareket_Load(object sender, EventArgs e)
        {
           
        }

        private void txtKasaKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        void Sec()
        {
            try
            {
                SecimID = int.Parse(gridview.GetFocusedRowCellValue("ID").ToString());
                try
                {
                    EvrakID = int.Parse(gridview.GetFocusedRowCellValue("Evrakiid").ToString());
                }
                catch (Exception)
                {
                    EvrakID = -1;
                }
                EvrakTuru = gridview.GetFocusedRowCellValue("EvrakTur").ToString();
            }
            catch (Exception)
            {
                SecimID = -1;
                EvrakID = -1;
                EvrakTuru = "";
            }
        }

        private void Grid_Click(object sender, EventArgs e)
        {

        }

        private void sagtik_Opening(object sender, CancelEventArgs e)
        {
            Sec();
            if (EvrakTuru == "Kasa Hareket Kartı")
            {
                devirKartıİşlemleriniDüzenle.Enabled = true;
                tahsilatÖdemeİşlemleriniDüzenle.Enabled = false;
            }
            else if (EvrakTuru == "Kasa Tahsilat" || EvrakTuru == "Kasa Ödeme")
            {
                devirKartıİşlemleriniDüzenle.Enabled = false;
                tahsilatÖdemeİşlemleriniDüzenle.Enabled = true;
            }
        }

        private void devirKartıİşlemleriniDüzenle_Click(object sender, EventArgs e)
        {
            form.Ac(true,SecimID);
            Listele();
        }

        private void tahsilatÖdemeİşlemleriniDüzenle_Click(object sender, EventArgs e)
        {
            form.KasaTahsilat(true,SecimID);
            Listele();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void txtBakiye_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtKasaKod_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.KasaListe(true); //kasaliste açar
            if (ID > 0)
            {
                Ac(ID);
            }
            AnaForm.Aktarma = -1;
        }



    }
}
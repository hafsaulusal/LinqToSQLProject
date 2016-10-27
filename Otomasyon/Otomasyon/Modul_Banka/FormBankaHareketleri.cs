using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Banka
{
    public partial class FormBankaHareketleri : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();

        public bool Secim = false;
        int BankaID = -1;
        int islemID = -1;
        string EvrakTuru;

        public FormBankaHareketleri()
        {
            InitializeComponent();
        }

        private void FormBankaHareketleri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.View_BankaHareketleris
                      where s.BankaId == BankaID
                      select s;
            g.DataSource = lst;

        }

        void DurumGetir()
        {
            try
            {
               
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
        }

        public void Ac(int ID)
        {
            try
            {
                BankaID = ID;
                Fonksiyonlar.View_BankaBakiye banka = DB.View_BankaBakiyes.First(s => s.ID == BankaID);
                txtGiris.Text = banka.GİRİS.Value.ToString();
                txtCikis.Text = banka.CİKİS.Value.ToString();
                txtBakiye.Text = banka.BAKIYE.Value.ToString();
                txtHesapAd.Text = banka.HesapAd;
                txtHesapNo.Text = banka.HesapNo;
                Listele();
            }
            catch ( Exception e)
            {
                mesaj.Hata(e);
            }
        
        }

        private void txtHesapAd_Click(object sender, EventArgs e)
        {
           
        }

        void Sec()
        {
            
                try
                {
                    islemID = int.Parse(gridview.GetFocusedRowCellValue("ID").ToString());
                  
                    EvrakTuru = gridview.GetFocusedRowCellValue("EvrakTur").ToString();
                    
                }
                catch (Exception)
                {
                    islemID = -1;
                 
                    EvrakTuru = "";
                }
            

        }

        private void sagtik_Opening(object sender, CancelEventArgs e)
        {
            Sec();
            if (EvrakTuru == "Banka İşlemi")
            {
                bankaİşleminiDüzenle.Enabled = true;
                bankaParaTransferiniDüzenle.Enabled = false;
            }
            else if (EvrakTuru == "Banka EFT" || EvrakTuru == "Banka Havale")
            {
                bankaParaTransferiniDüzenle.Enabled = true;
                bankaİşleminiDüzenle.Enabled = false;
            }

        }



        private void txtHesapAd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.BankaListe(true);
            if (ID > 0)
            {
                Ac(ID);
            }
            AnaForm.Aktarma = -1;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void bankaİşleminiDüzenle_Click_1(object sender, EventArgs e)
        {
            form.Bankaİslem(true, islemID);
            Listele();
        }

        private void bankaParaTransferiniDüzenle_Click_1(object sender, EventArgs e)
        {
            form.ParaTransfer(true, islemID);
            Listele();
        }

    }
}
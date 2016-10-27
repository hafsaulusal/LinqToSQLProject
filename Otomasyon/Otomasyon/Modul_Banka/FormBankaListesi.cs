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
    public partial class FormBankaListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        public bool Secim = false;
        int SecimId = -1;

        public FormBankaListesi()
        {
            InitializeComponent();
        }

        private void FormBankaListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            var lst = from s in DB.View_BankaBakiyes
                      where s.HesapAd.Contains(txtHesapAd.Text) && s.HesapNo.Contains(txtHesapNo.Text) && s.IBAN.Contains(txtIBAN.Text)
                      select s;
            Liste.DataSource = lst;
        }

        void Sec()
        {
            try
            {
                SecimId = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            }
            catch (Exception)
            {
                SecimId = -1;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && SecimId > 0)
            {
                AnaForm.Aktarma = SecimId;
                this.Close();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtHesapAd.Text = "";
            txtHesapNo.Text = "";
            txtIBAN.Text = "";
        }



    }
}
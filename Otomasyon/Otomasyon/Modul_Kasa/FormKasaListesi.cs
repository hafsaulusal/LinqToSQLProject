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
    public partial class FormKasaListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();

        public bool Secim = false;
        int SecimId = -1;

        public FormKasaListesi()
        {
            InitializeComponent();
        }

        void Listele()
        {
            var lst = from s in DB.View_KasaBakiyes
                      where s.KasaAd.Contains(txtKasaAd.Text) &&
                      s.KasaKod.Contains(txtKasaKod.Text)
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

        private void Liste_Click(object sender, EventArgs e)
        {

        }


        private void FormKasaListesi_Load(object sender, EventArgs e)
        {
            Listele();
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
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtKasaAd.Text = "";
            txtKasaKod.Text = "";
            Listele();
        }

    }
}
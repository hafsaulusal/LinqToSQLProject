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

namespace Otomasyon.Modul_Stok
{
    public partial class FormStokListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();

        public bool Secim = false;
        int SecimID = -1;

        public FormStokListesi()
        {
            InitializeComponent();
        }

        private void FormStokListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele() 
        { 
                       
            var lst = from s in DB.tbl_Stoks
                      where s.StokAd.Contains(txtStokAdi.Text) && s.StokBarkod.Contains(txtBarkod.Text)  &&   s.StokKodu.Contains(txtStokKodu.Text)
                      select s;
            Liste.DataSource = lst;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            txtStokAdi.Text = "";
            txtBarkod.Text = "";
            txtStokKodu.Text = "";
            Listele();
        }

        void Sec() 
        {

            try
            {
                SecimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            }
            catch (Exception)
            {

                SecimID = -1;
            }
        
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Sec();
            if (Secim && SecimID > 0) {

                AnaForm.Aktarma = SecimID;
                this.Close();

            }
        }

        private void Liste_Click(object sender, EventArgs e)
        {

        }
    }
}
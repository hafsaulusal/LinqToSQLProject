using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Otomasyon.Modul_Fatura
{
    public partial class FormFaturaListesi : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar frm = new Fonksiyonlar.Formlar();

        bool Secimm = false; 

        public FormFaturaListesi(bool Secim)
        {
            InitializeComponent();
            Secimm = Secim;
        }

        private void FormFaturaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst=from s in DB.tbl_Faturalars
                    where s.FaturaTur.Contains(txtfaturatur.Text ) && s.FaturaTur.Contains(txtfaturano.Text) && s.FaturaTur.Contains(txttarih.Text)
                    select s;
            Liste.DataSource=lst;
        }

        private void Liste_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
          
           int ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
          /* FormSatisFaturasi fsf = new FormSatisFaturasi();
           fsf.txtCariKodu.Text = gridView1.GetFocusedRowCellValue("CariKod").ToString();
           fsf.secimID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
           fsf.ShowDialog();
          */
           frm.Fatura(true, ID, false);
           
         
        }

        private void txtfaturatur_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
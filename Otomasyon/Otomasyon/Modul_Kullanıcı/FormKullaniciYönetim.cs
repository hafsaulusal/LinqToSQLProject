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
    public partial class FormKullaniciYönetim : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar frm = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();

        int id = -1;

        public FormKullaniciYönetim()
        {
            InitializeComponent();
        }

        private void FormKullaniciYönetim_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            var lst = from s in DB.tbl_Kullanicis
                      select s;
            gridControl1.DataSource = lst;
        }

        void FormKullaniciYönetim_Shown(object sender,EventArgs e)
        {
            Listele();
        }

        private void btnyeni_Click(object sender, EventArgs e)
        {
            frm.Kullanici();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            frm.Kullanici(true, id);
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if(id>0 && mesaj.Silme()==DialogResult.Yes)
            {
            DB.tbl_Kullanicis.DeleteOnSubmit(DB.tbl_Kullanicis.First(s => s.ID == id));
            DB.SubmitChanges();
            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Data.ConnectionUI;
using System.Configuration;

namespace Otomasyon
{
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Log log = new Fonksiyonlar.Log();
        Fonksiyonlar.tbl_Kullanici kullanici;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                kullanici= DB.tbl_Kullanicis.First(s => s.Kullanici == txtKullanici.Text.Trim() && s.Parola == txtParola.Text.Trim());
                kullanici.SonGiris = DateTime.Now;
                DB.SubmitChanges();
                this.Hide();
                AnaForm frm = new AnaForm(kullanici);
                frm.Show();

            }
            catch (Exception ex)
            {
                mesaj.Uyari("Hatalı kullanıcı adı veya parola girişi ");
                log.HataMesajiYaz(ex);
            }
         
        }

        private void btnBaglanti_Click(object sender, EventArgs e)
        {
            Baglanti();           
        }
        public void Baglanti()
        {
            DataConnectionDialog Bilgi = new DataConnectionDialog();
            Bilgi.DataSources.Add(DataSource.SqlDataSource); // Sql Server
            Bilgi.SelectedDataSource = DataSource.SqlDataSource;
            Bilgi.SelectedDataProvider = DataProvider.SqlDataProvider;
            //Bilgi.ConnectionString = baglanti;
            if (DataConnectionDialog.Show(Bilgi) == DialogResult.OK)
            {
                try
                {
                    Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    conf.AppSettings.Settings["BAGLANTI"].Value = Bilgi.ConnectionString;
                    conf.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    XtraMessageBox.Show("Bağlantı Ayarlarınız Kaydedildi. Lütfen Programı Tekrar Başlatınız...", "Bağlantı Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { XtraMessageBox.Show(ex.Message, "Hata !", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
            }
        }
    }
}
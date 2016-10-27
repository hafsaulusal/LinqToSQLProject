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

namespace Otomasyon.Modul_Fatura
{
    public partial class FormSatisFaturasi : DevExpress.XtraEditors.XtraForm
    {
       
        Fonksiyonlar.DatabaseDataContext DB = new Fonksiyonlar.DatabaseDataContext();
        Fonksiyonlar.Formlar form = new Fonksiyonlar.Formlar();
        Fonksiyonlar.Mesajlar mesaj = new Fonksiyonlar.Mesajlar();
        Fonksiyonlar.Resim resim = new Fonksiyonlar.Resim();
        Fonksiyonlar.Log log = new Fonksiyonlar.Log();

        int CariID = -1;
        int OdemeID = -1;
        int FaturaID = -1;
        int IrsaliyeID = -1;
        string OdemeYer = string.Empty;
        bool Edit = false;
        bool IrsaliyeAc = false;

        int KasaID = -1;
        int BankaID = -1;

        public FormSatisFaturasi()
        {
            InitializeComponent();     
        }

        public FormSatisFaturasi(bool Ac,int ID,bool Irsaliye)
        {
            InitializeComponent();
            Edit = Ac;
            if (Irsaliye) IrsaliyeID = ID;
            else FaturaID = ID;
            IrsaliyeAc = Irsaliye;
            
            //this.Shown+=FormSatisFaturasi_Shown;  //////////////////////////////////2 defa çalıştırdı 
        }

        void FormSatisFaturasi_Shown(object sender,EventArgs e)
        {
           if (Edit) 
               FaturaGetir();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        void StokSec(int id)
        {
            Fonksiyonlar.tbl_Stok stok = DB.tbl_Stoks.First(s => s.ID == id);
            gridView1.AddNewRow();
            gridView1.SetFocusedRowCellValue("Miktar", "0");
            gridView1.SetFocusedRowCellValue("Barkod", stok.StokBarkod);
            gridView1.SetFocusedRowCellValue("StokKod", stok.StokKodu);
            gridView1.SetFocusedRowCellValue("StokAd", stok.StokAd);
            gridView1.SetFocusedRowCellValue("Birim", stok.StokBirim);
            gridView1.SetFocusedRowCellValue("BirimFiyat", stok.StokSatisFiyat);
            gridView1.SetFocusedRowCellValue("KDV", stok.StokSatisKDV);
        }

        void FaturaGetir()
        {
            Fonksiyonlar.tbl_Faturalar ftr = DB.tbl_Faturalars.First(s => s.ID == FaturaID);
            txtAciklama.Text = ftr.Aciklama;
            txtFaturaNo.Text = ftr.FaturaNo;

            if (ftr.OdemeYeriId > 0)
            {
                txtFaturaTur.SelectedIndex = 1;

                if (ftr.OdemeYeri == "Kasa")
                {
                    txtOdemeYer.SelectedIndex = 0;
                    OdemeYer = ftr.OdemeYeri;
                    txtKasaAd.Text = DB.tbl_KasaKartis.First(s => s.ID == ftr.OdemeYeriId.Value).KasaAd;
                    txtKasaKod.Text = DB.tbl_KasaKartis.First(s => s.ID == ftr.OdemeYeriId.Value).KasaKod;
                }
                else if (ftr.OdemeYeri == "Banka")
                {
                    txtOdemeYer.SelectedIndex = 1;
                    OdemeYer = ftr.OdemeYeri;
                    txtHesapNo.Text = DB.tbl_BankaKartis.First(s => s.ID == ftr.OdemeYeriId.Value).HesapNo;
                    txtHesapAd.Text = DB.tbl_BankaKartis.First(s => s.ID == ftr.OdemeYeriId.Value).HesapAd;
                }

                OdemeID = ftr.OdemeYeriId.Value;

            }
            else if (ftr.OdemeYeriId < 0) txtFaturaTur.SelectedIndex = 0;

            txtFaturaTarih.EditValue = ftr.Tarih.Value.ToShortDateString();

            txtIrsaliyeNo.Text = DB.tbl_Irsaliyes.First(s => s.ID == ftr.IrsaliyeId).IrsaliyeNo;
            txtIrsaliyeTarih.EditValue = DB.tbl_Irsaliyes.First(s => s.ID == ftr.IrsaliyeId).Tarih.Value.ToShortDateString();

            txtCariAdi.Text = DB.tbl_CariKartis.First(s => s.CariKod == ftr.CariKod).CariAd;
            txtCariKodu.Text = ftr.CariKod;



            var lst = from s in DB.view_Kalemlers
                      where s.FaturaId == FaturaID
                      select s;

            foreach (Fonksiyonlar.view_Kalemler k in lst)
            {
                gridView1.AddNewRow();
                gridView1.SetFocusedRowCellValue("Miktar", k.Miktar);
                gridView1.SetFocusedRowCellValue("BirimFiyat", k.BirimFiyat);
                gridView1.SetFocusedRowCellValue("Barkod", k.StokBarkod);
                gridView1.SetFocusedRowCellValue("StokKod", k.StokKodu);
                gridView1.SetFocusedRowCellValue("StokAd", k.StokAd);
                gridView1.SetFocusedRowCellValue("Birim", k.StokBirim);
                gridView1.SetFocusedRowCellValue("KDV", k.KDV);
           
                gridView1.UpdateCurrentRow();
            }

        }

        private void btnStokSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtCariAdi.Text !=string.Empty && txtCariKodu.Text !=string.Empty && txtFaturaNo.Text != string.Empty && txtIrsaliyeNo.Text !=string.Empty)
            {
                int StokId = form.StokListesi(true);
                if (StokId > 0)
                {
                    StokSec(StokId);
                }
            }
            else
                mesaj.Uyari("Lütfen Fatura Bilgilerini Giriniz..");
            AnaForm.Aktarma = -1;

        }

        private void panelControl7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSatisFaturasi_Load(object sender, EventArgs e)
        {
            txtFaturaTarih.Text = DateTime.Now.ToShortDateString();
            txtIrsaliyeTarih.Text = DateTime.Now.ToShortDateString();

            txtKasaAd.Enabled = false;
            txtKasaKod.Enabled = false;
            txtHesapAd.Enabled = false;
            txtHesapNo.Enabled = false;

            txtOdemeYer.Enabled = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {

                decimal Miktar = 0, BirimFiyat = 0, Toplam = 0;
                if (e.Column.Name != "colToplam")
                {
                    Miktar = decimal.Parse(gridView1.GetFocusedRowCellValue("Miktar").ToString());
                    if (gridView1.GetFocusedRowCellValue("BirimFiyat").ToString() != "")
                        BirimFiyat = decimal.Parse(gridView1.GetFocusedRowCellValue("BirimFiyat").ToString());
                    Toplam = Miktar * BirimFiyat;

                    gridView1.SetFocusedRowCellValue("Toplam", Toplam);
                    Hesapla();
                }
            }
            catch (Exception ex)
            {
                mesaj.Hata(ex);
            }

        }
        //AYRILDIĞINDA

        void Hesapla()
        {
            try
            {
                decimal BirimFiyat = 0, Miktar = 0, AraToplam = 0, GenelToplam = 0, KDV = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    BirimFiyat = decimal.Parse(gridView1.GetRowCellValue(i, "BirimFiyat").ToString());
                    Miktar = decimal.Parse(gridView1.GetRowCellValue(i, "Miktar").ToString());
                    KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString()) / 100 + 1;
                    AraToplam += Miktar * BirimFiyat;
                    GenelToplam += decimal.Parse(gridView1.GetRowCellValue(i, "Toplam").ToString()) * KDV;
                }

                txtAraToplam.Text = AraToplam.ToString("0.00");
                txtKDV.Text = (GenelToplam - AraToplam).ToString("0.00");
                txtGenelToplam.Text = GenelToplam.ToString("0.00");
            }
            catch (Exception ex)
            {
                log.HataMesajiYaz(ex);
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.CariListe(true);
            if (ID > 0) CariAc(ID);
            AnaForm.Aktarma = -1;
        } 

        void CariAc(int ID)
        {
            try
            {
                CariID = ID;
                Fonksiyonlar.tbl_CariKarti kart = DB.tbl_CariKartis.First(s => s.ID == CariID);
                txtCariKodu.Text = kart.CariKod;
                txtCariAdi.Text = kart.CariAd;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }

        }

        void BankaAc(int ID)
        {
            try
            {
                BankaID = ID;
                Fonksiyonlar.tbl_BankaKarti kart = DB.tbl_BankaKartis.First(s => s.ID == BankaID);
                txtHesapAd.Text = kart.HesapAd;
                txtHesapNo.Text = kart.HesapNo;
            }
            catch (Exception e)
            {
                mesaj.Hata(e);
            }
 
        }

        void KasaAc(int ID)
        {
            try
            {
                KasaID = ID;
                Fonksiyonlar.tbl_KasaKarti kart = DB.tbl_KasaKartis.First(s => s.ID == KasaID);
                txtKasaAd.Text = kart.KasaAd;
                txtKasaKod.Text = kart.KasaKod;
            }
            catch (Exception e) 
            {
                mesaj.Hata(e);
            }
 
        }

        private void txtFaturaTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFaturaTur.SelectedIndex == 0)
            {
                txtOdemeYer.Enabled = false;
                txtKasaAd.Enabled = false;
                txtKasaKod.Enabled =false;
                txtHesapAd.Enabled = false;
                txtHesapNo.Enabled = false;
            }

            else if (txtFaturaTur.SelectedIndex == 1)
            {
                txtOdemeYer.Enabled = true;
                txtOdemeYer_SelectedIndexChanged(sender,e);
        
            }
        }

        private void txtOdemeYer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtOdemeYer.SelectedIndex == 0)
            {
                txtKasaAd.Enabled = true;
                txtKasaKod.Enabled = true;

                txtHesapAd.Enabled = false;
                txtHesapNo.Enabled = false;
            }
            else if (txtOdemeYer.SelectedIndex == 1)
            {

                txtKasaAd.Enabled = false;
                txtKasaKod.Enabled = false;
                
                txtHesapAd.Enabled = true;
                txtHesapNo.Enabled = true;
            }

        }

        private void btnKapat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        void Kaydet()
        {
            try
            {
                Fonksiyonlar.tbl_Faturalar ftr = new Fonksiyonlar.tbl_Faturalar();
               // IrsaliyeID = ftr.IrsaliyeId;
                ftr.Aciklama = txtAciklama.Text;

                if (txtFaturaTur.SelectedIndex == 0)
                {
                    ftr.FaturaTur = "Açık Satış Faturası";
                    ftr.OdemeYeri = null;
                    ftr.OdemeYeriId = null;
                }
                if (txtFaturaTur.SelectedIndex == 1)
                {
                    ftr.FaturaTur = "Kapalı Satış Faturası";
                    if (txtOdemeYer.SelectedIndex == 0)
                    {
                        ftr.OdemeYeriId = OdemeID;
                        ftr.OdemeYeri =txtKasaKod.Text + " "+" nolu Kasa" ;
                    }
                    if (txtOdemeYer.SelectedIndex == 1)
                    {
                        ftr.OdemeYeriId =OdemeID;
                        ftr.OdemeYeri =txtHesapNo.Text + " "+ "nolu Banka" ;
                    }
                }
                

                ftr.FaturaNo = txtFaturaNo.Text;
                ftr.CariKod = txtCariKodu.Text;
                ftr.Tarih = DateTime.Parse(txtFaturaTarih.Text);
                ftr.IrsaliyeId = IrsaliyeID;
                //ftr.OdemeYeri = OdemeYer;
                //ftr.OdemeYeriId = OdemeID;
                ftr.GenelToplam = decimal.Parse(txtGenelToplam.Text);
                ftr.SaveUser = AnaForm.USERID;
                ftr.SaveDate = DateTime.Now;
                DB.tbl_Faturalars.InsertOnSubmit(ftr);
                DB.SubmitChanges();
                try
                {

                    if (IrsaliyeID < 0)
                    {
                        Fonksiyonlar.tbl_Irsaliye irs = new Fonksiyonlar.tbl_Irsaliye();
                        irs.IrsaliyeNo = txtIrsaliyeNo.Text;
                        irs.Aciklama = txtAciklama.Text;
                        irs.Tarih = DateTime.Parse(txtIrsaliyeTarih.Text);
                        irs.FaturaId = ftr.ID;
                        irs.CariKod = txtCariKodu.Text;
                        irs.SaveUser = AnaForm.USERID = -1;
                        irs.SaveDate = DateTime.Now;
                        DB.tbl_Irsaliyes.InsertOnSubmit(irs);
                        DB.SubmitChanges();
                        IrsaliyeID = irs.ID;
                        ftr.IrsaliyeId = IrsaliyeID;
                    }
                }
                catch (Exception ex)
                {
                    mesaj.Hata(ex);
                }
                Fonksiyonlar.tbl_StokHareket[] stokhar = new Fonksiyonlar.tbl_StokHareket[gridView1.RowCount];
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    try
                    {
                        stokhar[i] = new Fonksiyonlar.tbl_StokHareket();
                        stokhar[i].BirimFiyat = decimal.Parse(gridView1.GetRowCellValue(i, "BirimFiyat").ToString());
                        stokhar[i].FaturaId = ftr.ID;
                        stokhar[i].GCKOD = "Ç";
                        stokhar[i].IrsaliyeId = IrsaliyeID;
                        stokhar[i].Miktar = int.Parse(gridView1.GetRowCellValue(i, "Miktar").ToString());
                        stokhar[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                        stokhar[i].StokKod = gridView1.GetRowCellValue(i, "StokKod").ToString();
                        stokhar[i].Tipi = "Satış Faturası";
                        stokhar[i].SaveUser = AnaForm.USERID;
                        stokhar[i].SaveDate = DateTime.Now;

                        DB.tbl_StokHarekets.InsertOnSubmit(stokhar[i]);
                    }
                    catch (Exception ex)
                    {
                        mesaj.Hata(ex);
                        log.HataMesajiYaz(ex);
                    }
                }

                DB.SubmitChanges();

                
                    Fonksiyonlar.tbl_CariHareketleri carihar = new Fonksiyonlar.tbl_CariHareketleri();
                    carihar.Aciklama = txtFaturaNo.Text + " nolu satış faturası tutarı";
                    if (txtFaturaTur.SelectedIndex == 0)
                    {
                        carihar.Alacak = 0;
                        carihar.Borc = decimal.Parse(txtGenelToplam.Text);
                    }
                    else if (txtFaturaTur.SelectedIndex == 1)
                    {
                        carihar.Alacak = decimal.Parse(txtGenelToplam.Text);
                        carihar.Borc = decimal.Parse(txtGenelToplam.Text);

                    }
                    carihar.CariId = CariID;
                    carihar.Tarih = DateTime.Now;
                    carihar.Tipi = "SF";
                    carihar.EvrakTur ="Satış Faturası";
                    carihar.EvrakId = ftr.ID;
                    carihar.SaveUser = AnaForm.USERID;
                    carihar.SaveDate = DateTime.Now;
                    DB.tbl_CariHareketleris.InsertOnSubmit(carihar);
                    DB.SubmitChanges();
                    
                
                mesaj.YeniKayit("Yeni Fatura Kaydı Oluşturuldu.");
                Temizle();
               

            }
            catch (Exception ex)
            {
                mesaj.Hata(ex);
                log.HataMesajiYaz(ex);

            }
        }

        void Guncelle()
        {
            Fonksiyonlar.tbl_Faturalar ftr = DB.tbl_Faturalars.First(s=>s.ID==FaturaID);
            ftr.Aciklama = txtAciklama.Text;
            ftr.FaturaNo = txtFaturaNo.Text;
            ftr.CariKod = txtCariKodu.Text;
            ftr.Tarih = DateTime.Parse(txtFaturaTarih.Text);
            if (txtFaturaTur.SelectedIndex == 0)
            {
                ftr.FaturaTur = "Açık Satış Faturası";
                ftr.OdemeYeri = null;
            }
            else if (txtFaturaTur.SelectedIndex == 1)
            {
                ftr.FaturaTur = "Kapalı Satış Faturası";
                if (txtOdemeYer.SelectedIndex == 0)
                {

                    ftr.OdemeYeri = txtKasaKod.Text + " " + " nolu Kasa";
                }
                if (txtOdemeYer.SelectedIndex == 1)
                {
                    ftr.OdemeYeri = txtHesapNo.Text + " " + " nolu Banka";
                }
            }
                
            ftr.OdemeYeriId = OdemeID;
            ftr.GenelToplam = decimal.Parse(txtGenelToplam.Text);
            ftr.EditUser = AnaForm.USERID;
            ftr.EditDate = DateTime.Now;
            DB.SubmitChanges();
            mesaj.Guncelle(true);


            Fonksiyonlar.tbl_Irsaliye irs =DB.tbl_Irsaliyes.First(s=>s.ID==ftr.IrsaliyeId);
            irs.IrsaliyeNo = txtIrsaliyeNo.Text;
            irs.Tarih = DateTime.Parse(txtIrsaliyeTarih.Text);
            irs.CariKod = txtCariKodu.Text;
            irs.EditUser = AnaForm.USERID = -1;
            irs.EditDate = DateTime.Now;
            DB.tbl_StokHarekets.DeleteAllOnSubmit(DB.tbl_StokHarekets.Where(s => s.ID == FaturaID));
            DB.SubmitChanges();
            mesaj.Guncelle(true);

            Fonksiyonlar.tbl_StokHareket[] stokhar = new Fonksiyonlar.tbl_StokHareket[gridView1.RowCount];
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                try
                {
                    stokhar[i] = new Fonksiyonlar.tbl_StokHareket();
                    stokhar[i].BirimFiyat = decimal.Parse(gridView1.GetRowCellValue(i, "BirimFiyat").ToString());
                    stokhar[i].FaturaId = ftr.ID;
                    stokhar[i].GCKOD = "Ç";
                    stokhar[i].IrsaliyeId = IrsaliyeID;
                    stokhar[i].Miktar = int.Parse(gridView1.GetRowCellValue(i, "Miktar").ToString());
                    stokhar[i].KDV = decimal.Parse(gridView1.GetRowCellValue(i, "KDV").ToString());
                    stokhar[i].StokKod = gridView1.GetRowCellValue(i, "StokKod").ToString();
                    stokhar[i].Tipi = "Satış Faturası";
                    stokhar[i].SaveUser = AnaForm.USERID;
                    stokhar[i].SaveDate = DateTime.Now;

                    DB.tbl_StokHarekets.InsertOnSubmit(stokhar[i]);
                }
                catch (Exception ex)
                {
                    mesaj.Hata(ex);
                }
            }

            Temizle();

        }

        void Temizle()
        {
            CariID = -1;
            OdemeID = -1;
            FaturaID = -1;
            IrsaliyeID = -1;
            OdemeYer = "";
            Edit = false;
            IrsaliyeAc = false;
            txtCariKodu.Text = "";
            txtCariAdi.Text = "";
            txtFaturaTur.SelectedIndex = 0;
            txtOdemeYer.SelectedIndex = 0;
            txtFaturaNo.Text = "";
            txtFaturaTarih.Text = DateTime.Now.ToShortDateString();
            txtIrsaliyeNo.Text = "";
            txtIrsaliyeTarih.Text = DateTime.Now.ToShortDateString();
            txtHesapNo.Text = "";
            txtHesapAd.Text = "";
            txtKasaAd.Text = "";
            txtKasaKod.Text = "";
            txtAraToplam.Text = "0.00";
            txtGenelToplam.Text = "0.00";
            txtKDV.Text = "0.00";
            AnaForm.Aktarma = -1;

            //for (int i = 0; i < gridView1.RowCount + 1; i++)
            //{
            //    gridView1.DeleteRow(0);
            //}

            for (int i = gridView1.RowCount; i > -1; i--)
            {
                gridView1.DeleteRow(i);
            }
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if(txtCariAdi.Text!=string.Empty && txtCariKodu.Text!=string.Empty && txtAciklama.Text!=string.Empty && txtFaturaNo.Text!=string.Empty && txtIrsaliyeNo.Text!=string.Empty)
            {
            if (Edit && mesaj.Guncelle() == DialogResult.Yes)
            {
                Guncelle();
            }
            else
            {
                Kaydet();
            }
            }
            else
            {
                mesaj.Uyari("Lütfen İlgi Alanları Doldurun");
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtHesapNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.BankaListe(true);
            if (ID > 0) BankaAc(ID);
            AnaForm.Aktarma = -1;
        }

        private void txtKasaKod_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int ID = form.KasaListe(true);
            if (ID > 0) KasaAc(ID);
            AnaForm.Aktarma = -1;
        }
    }
}
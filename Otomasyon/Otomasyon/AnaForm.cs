using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Microsoft.Data.ConnectionUI;
using System.Configuration;
using DevExpress.XtraEditors;

namespace Otomasyon
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        Fonksiyonlar.Formlar Formlar = new Fonksiyonlar.Formlar();
        public static Fonksiyonlar.tbl_Kullanici kullanicis;
        public static int USERID = -1;
        public static int Aktarma = -1;


        public AnaForm()
        {
            InitializeComponent();
        }

        public AnaForm(Fonksiyonlar.tbl_Kullanici kullanici)
        {
            InitializeComponent();
            kullanicis = kullanici;
            USERID = kullanici.ID;
            txtAlt.Caption = kullanici.Kullanici;
            if (kullanici.Kodu == "Normal")
            {
                barBtnKullanici.Visibility = BarItemVisibility.Never;
            }
        }


        private void barBtnStokKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.StokKarti();
        }

        private void barBtnStokListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.StokListesi();
        }

        private void barBtnStokGruplari_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.StokGruplari();
        }

        private void barBtnStokHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.StokHareketleri();
        }

        private void barBtnCariAcilisKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.CariKarti();
        }

        private void barBtnCariGruplari_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.CariGrup();
        }

        private void barBtnCariListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.CariListe();
        }

        private void barBtnCariHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.CariHareket();
        }

        private void barBtnBankaAcilisKart_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.BankaKarti();
        }

        private void barBtnParaTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.ParaTransfer();
        }

        private void barBtnBankaListe_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.BankaListe();
        }

        private void barBtnBankaİslem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.Bankaİslem();
        }

        private void barBtnBankaHareket_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.BankaHareketleri();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
           
        }
        
        public void Mesaj(string baslik, string mesaj)
        {
            ALC.Show(this,baslik,mesaj);
        }

        #region NavBarButonları
        private void barBtnKasaAcilisKarti_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.KasaKarti();
        }

        private void barBtnKasaListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.KasaListe();
        }

        private void barBtnKasaDevir_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.Ac();
        }

        private void barBtnAlisIrsaliye_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barBtnSatisFatura_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.Fatura();
        }

        private void barBtnKasaTahsilat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.KasaTahsilat();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.KasaHareketleri();
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void navbarStokKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.StokKarti();
        }

        private void navbarStokListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.StokListesi();
        }

        private void navbarStokGrup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.StokGruplari();
        }

        private void navbarStokHareketleri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.StokHareketleri();
        }

        private void navbarCariKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.CariKarti();
        }

        private void navbarCariGruplari_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.CariGrup();
        }

        private void navbarCariListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.CariListe();
        }

        private void navbarCariHareketleri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.CariHareket();
        }

        private void navbarBankaKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.BankaKarti();
        }

        private void navbarParaTransferi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.ParaTransfer();
        }

        private void navbarBankaListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.BankaListe();
        }

        private void navbarBankaİslemi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.Bankaİslem();
        }

        private void navbarBankaHareket_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.BankaHareketleri();
        }

        private void navbarKasaKarti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.KasaKarti();
        }

        private void navbarKasaListesi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.KasaListe();
        }

        private void navbarKasaDevir_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.Ac();
        }

        private void navbarKasaTahsilat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.KasaTahsilat();
        }

        private void navbarKasaHareketleri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Formlar.KasaHareketleri();
        }
        #endregion

        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonMusteriCek_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.MusteriCek();
        }

        private void barButtonKendiCek_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.KendiCeklerimiz();
        }

        private void barButtonBankayaCek_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.BankayaCekCik();
        }

        private void barButtonCariyeCek_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.CariyeCekCik();
        }

        private void barBtnSatisIadeFatura_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.FaturaListesi();
        }

        private void barBtnKullanici_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.KullaniciYönetim();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otomasyon.Fonksiyonlar
{
    class Formlar
    {
        #region Stok Formları
        public int StokListesi(bool Secim = false)
        {

            Modul_Stok.FormStokListesi frm = new Modul_Stok.FormStokListesi();

            if (Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }
        public int StokGruplari(bool Secim = false)
        {
            Modul_Stok.FormStokGruplari frm = new Modul_Stok.FormStokGruplari();
            if (Secim) frm.Secim = Secim;
            frm.ShowDialog();
            return AnaForm.Aktarma;

        }
        public void StokHareketleri(bool Ac = false) { }
        public void StokKarti(bool Ac = false)
        {
            Modul_Stok.FormStokKarti frm = new Modul_Stok.FormStokKarti();
            frm.ShowDialog();
        }
        #endregion

        #region Cari Formları
        public int CariGrup(bool Secim = false)
        {
            Modul_Cari.FormCariGrup form = new Modul_Cari.FormCariGrup();
            if (Secim) form.Secim = Secim;
            form.ShowDialog();
            return AnaForm.Aktarma;
        }
        public int CariListe(bool Secim = false)
        {
            Modul_Cari.FromCariListesi form = new Modul_Cari.FromCariListesi();

            if (Secim)
            {
                form.Secim = Secim;
                form.ShowDialog();
            }
            else
            {
                form.MdiParent = AnaForm.ActiveForm;
                form.Show();
            }
            return AnaForm.Aktarma;
        }
        public void CariKarti(bool Ac = false)
        {
            Modul_Cari.FormCariAcilisKarti frm = new Modul_Cari.FormCariAcilisKarti();
            frm.ShowDialog();
        }

       public int CariHareket(bool Secim=false)
            {
                Modul_Cari.FormCariHareketler form=new Modul_Cari.FormCariHareketler();
                  if (Secim)
            {
                form.Secim = Secim;
                form.ShowDialog();
            }
            else
            {
                form.MdiParent = AnaForm.ActiveForm;
                form.Show();
            }
            return AnaForm.Aktarma;


            }
        
        #endregion      
    
        #region Kasa Formları

        public int KasaKarti(bool Secim = false)
        {
            Modul_Kasa.FormKasaAcilisKarti form = new Modul_Kasa.FormKasaAcilisKarti();
            if (Secim) form.Secim = Secim;
            form.ShowDialog();
            return AnaForm.Aktarma;
        }

        public void Ac(bool Acis = false, int IslemId = -1)
        {
            Modul_Kasa.FormKasaDevir frm = new Modul_Kasa.FormKasaDevir();
            if (Acis) frm.Ac(IslemId);
            frm.ShowDialog();
        }

        public int KasaListe(bool Secim = false)
        {
            Modul_Kasa.FormKasaListesi form = new Modul_Kasa.FormKasaListesi();
            if (Secim)
            {
                form.Secim = Secim;
                form.ShowDialog();
            }
            else
            {
                form.MdiParent = AnaForm.ActiveForm;
                form.Show();
            }
            return AnaForm.Aktarma;
        }

        public int KasaHareketleri(bool Secim = false)
        {
            Modul_Kasa.FormKasaHareket form = new Modul_Kasa.FormKasaHareket();
            if (Secim)
            {
                form.Secim = Secim;
                form.ShowDialog();
            }
            else
            {
                form.MdiParent = AnaForm.ActiveForm;
                form.Show();
            }
            return AnaForm.Aktarma;
        }

        public void KasaTahsilat(bool Acis = false,int IslemId=-1)
        {
            Modul_Kasa.FormKasaTahsilat form = new Modul_Kasa.FormKasaTahsilat();
            if (Acis) form.Ac(IslemId);
            form.ShowDialog();
        }

        #endregion

        #region Banka Formları

        public int BankaKarti(bool Secim = false)
        {
            Modul_Banka.FormBankaAcilisKart form = new Modul_Banka.FormBankaAcilisKart();
            if (Secim) form.Secim = Secim;
            form.ShowDialog();
            return AnaForm.Aktarma;
        }

        public void Bankaİslem(bool Secim = false,int IslemID=-1)
        {
            Modul_Banka.FormBankaİslemi form = new Modul_Banka.FormBankaİslemi();
            if (Secim) form.Ac(IslemID);
            form.ShowDialog();
          
        }

        public int BankaListe(bool Secim = false)
        {
            Modul_Banka.FormBankaListesi frm = new Modul_Banka.FormBankaListesi();
            if (Secim)
            {
                frm.Secim = Secim;
                frm.ShowDialog();
            }
            else 
            {
                frm.MdiParent = AnaForm.ActiveForm;
                frm.Show();
            }
            return AnaForm.Aktarma;
        }

        public void ParaTransfer(bool Acis = false, int islemID = -1)
        {
            Modul_Banka.FormParaTransfer form = new Modul_Banka.FormParaTransfer();
            if (Acis) form.Ac(islemID);
            form.ShowDialog();
        }

        public int BankaHareketleri(bool Secim = false)
        {
            Modul_Banka.FormBankaHareketleri form = new Modul_Banka.FormBankaHareketleri();
            if (Secim)
            {
                form.Secim = Secim;
                form.ShowDialog();
            }
            else 
            {
                form.MdiParent = AnaForm.ActiveForm;
                form.Show();

            }
            return AnaForm.Aktarma;
        }

        #endregion

        #region Çek Formları

        public void KendiCeklerimiz(bool Secim = false, int IslemID = -1)
        {
            Modul_Cek.FormKendiCek frm = new Modul_Cek.FormKendiCek();
            frm.ShowDialog();
        }

        public void MusteriCek(bool Secim = false, int IslemID = -1)
        {
            Modul_Cek.FormMusteriCek frm = new Modul_Cek.FormMusteriCek();
            ///
            frm.ShowDialog();
        }

        public void BankayaCekCik(bool Secim = false, int IslemId = -1)
        {
            Modul_Cek.FormBankayaCekCik frm = new Modul_Cek.FormBankayaCekCik();
            frm.ShowDialog();
        }

        public void CariyeCekCik(bool Secim = false, int IslemID = -1)
        {
            Modul_Cek.FormCariyeCekCik frm = new Modul_Cek.FormCariyeCekCik();
            frm.ShowDialog();
        }

        #endregion

        #region Fatura Formları
        
        public void Fatura(bool Ac = false, int islemid = -1,bool Irsaliye=false)
        {
            Modul_Fatura.FormSatisFaturasi frm = new Modul_Fatura.FormSatisFaturasi(Ac, islemid, Irsaliye);
            frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();
        }

        public int FaturaListesi(bool Secim = false)
        {
            Modul_Fatura.FormFaturaListesi frm = new Modul_Fatura.FormFaturaListesi(Secim);
            if (Secim) frm.ShowDialog();
            else
                frm.MdiParent = AnaForm.ActiveForm;
            frm.Show();

            return AnaForm.Aktarma;
        }

        #endregion

        #region Kullanıcı Formları

        public void KullaniciYönetim()
        {
            Modul_Kullanıcı.FormKullaniciYönetim frm = new Modul_Kullanıcı.FormKullaniciYönetim();
            frm.ShowDialog();
        }

        public void Kullanici(bool Edit=false,int ID=-1)
    {
        Modul_Kullanıcı.FormKullanici frm = new Modul_Kullanıcı.FormKullanici(ID,Edit);
        frm.ShowDialog();

    }
        #endregion

    }
}

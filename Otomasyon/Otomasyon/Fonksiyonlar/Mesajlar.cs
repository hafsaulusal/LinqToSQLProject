using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otomasyon.Fonksiyonlar
{
    class Mesajlar
    {
        AnaForm mesajform = new AnaForm(); 

        public void YeniKayit(string Mesaj) {

            mesajform.Mesaj("Yeni Kayıt Girişi",Mesaj);
        }

        public void Uyari(string Mesaj) {
            MessageBox.Show(Mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult Guncelle() 
        {
            return MessageBox.Show("Seçili kayıt kalıcı olarak değiştirilecektir\n onaylıyor musunuz?", "Güncelleme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public void Guncelle(bool Guncelleme) 
        {
            mesajform.Mesaj("Kayıt Güncelleme","Kayıt güncellenmiştir");
        }

        public DialogResult Silme() {
            return MessageBox.Show("Seçili kayıt kalıcı olarak silinecektir\n onaylıyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void Hata(Exception Hata) 
        {
            mesajform.Mesaj("Hata Oluştu", Hata.Message);
           // MessageBox.Show(Hata.Message, "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void FormAc(string FormAd)
        {
            mesajform.Mesaj("", FormAd + " formu açıldı.");
        }

        public void FormKapat(string FormAd)
        {
            mesajform.Mesaj("", FormAd + " form kapatıldı.");
        }

    }
}

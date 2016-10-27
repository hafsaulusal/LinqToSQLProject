using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otomasyon.Fonksiyonlar
{
    class Numara
    {
        DatabaseDataContext DB = new DatabaseDataContext();
        Mesajlar mesaj = new Mesajlar();

        public string StokKodNumarasi() {
            try
            {
                int Numara = int.Parse((from s in DB.tbl_Stoks
                                        orderby s.ID descending
                                        select s).First().StokKodu);
                Numara++;
                string Num = Numara.ToString().PadLeft(9, '0');
                return Num;
            }
            catch (Exception)
            {
                return "000000001";
            }
        
        }

        public string CariKodNumarasi()
        {
            try
            {
                int Numara = int.Parse((from s in DB.tbl_CariKartis
                                        orderby s.ID descending
                                        select s).First().CariKod);
                Numara++;
                string Num = Numara.ToString().PadLeft(9, '0');
                return Num;
            }
            catch (Exception)
            {
                return "000000001";
            }

        }

        public string KasaKodNumarasi()
        {
            try
            {
                int Numara = int.Parse((from s in DB.tbl_KasaKartis
                                        orderby s.ID descending
                                        select s).First().KasaKod);
                Numara++;
                string Num = Numara.ToString().PadLeft(9, '0');
                return Num;
            }
            catch (Exception)
            {
                return "000000001";
            }
        }



    }
}

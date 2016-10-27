using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otomasyon.Fonksiyonlar
{
    class Resim
    {
        public byte[] ResimYukleme(System.Drawing.Image resim) {
            using (MemoryStream ms = new MemoryStream()) {
                resim.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public Image ResimGetir(byte[] gelenbytearray){
            using (MemoryStream ms = new MemoryStream(gelenbytearray))
            {
                Image resim = Image.FromStream(ms);
                return resim;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KORDSA_UTP
{
    internal class Islem
    {
        VeriTabaniBaglantiDataContext baglanti;
        public Islem()
        {
            baglanti = new VeriTabaniBaglantiDataContext();
        }
        public bool loginGiris(string username,string password)
       {
            Login bulunankayit=baglanti.Logins.Where(u => u.LoginKullaniciAdi == username && u.LoginSifre == password).FirstOrDefault();
            if (bulunankayit != null)
                return true;
            else
                return false;
       }
        public void stokEkle(string stokisim,string stokadet,string stokrafno,string stokmodel,string stokserino,DateTime stoktarih,string elemanisim,
           string aciklama)
        {
            Stok eklenecekkayit = new Stok()
            {
                StokIsim=stokisim,
                StokAdet=stokadet,
                StokRafNo=stokrafno,
                StokModel=stokmodel,
                StokSeriNo=stokserino,
                StokTarih=stoktarih,
                ElemanIsim=elemanisim,
                Aciklama=aciklama
            };
            baglanti.Stoks.InsertOnSubmit(eklenecekkayit);
            baglanti.SubmitChanges();
        }
        public bool seriNoAynimi(string serino)
        {
            if (baglanti.Stoks.Select(u => u.StokSeriNo).Contains(serino))
                return false;
            else
                return true;
        }
        public void stokHurdayaCikar(string serino)
        {
          string stokisim, stokadet, stokrafno, stokmodel, stokserino, elemanisim,aciklama;
          Stok bulunankayit= baglanti.Stoks.Where(u => u.StokSeriNo == serino).FirstOrDefault();
          DateTime stoktarih;
            if(bulunankayit!=null)
            {
                stokisim = bulunankayit.StokIsim;
                stokadet = bulunankayit.StokAdet;
                stokrafno = bulunankayit.StokRafNo;
                stokmodel = bulunankayit.StokModel;
                stokserino = bulunankayit.StokSeriNo;
                stoktarih = bulunankayit.StokTarih;
                elemanisim = bulunankayit.ElemanIsim;
                aciklama = bulunankayit.Aciklama;
                baglanti.Stoks.DeleteOnSubmit(bulunankayit);
                baglanti.SubmitChanges();
                Hurda h = new Hurda()
                {
                    HurdaIsim = stokisim,
                    HurdaAdet = stokadet,
                    HurdaRafNo = stokrafno,
                    HurdaModel = stokmodel,
                    HurdaSeriNo = stokserino,
                    HurdaStokGirisTarih=stoktarih,
                    HurdaOlusTarih = DateTime.Now,
                    Aciklama=aciklama,
                    ElemanIsim=elemanisim
                };
                baglanti.Hurdas.InsertOnSubmit(h);
                baglanti.SubmitChanges();
            }
        }
        public void stokGuncelle(int id,string stokisim, string stokadet, string stokrafno, string stokmodel, string stokserino, DateTime stoktarih, string elemanisim,
           string aciklama)
        {
            Stok guncellenecekpersonel=baglanti.Stoks.Where(u => u.StokID == id).FirstOrDefault();
            if(guncellenecekpersonel!=null)
            {
                guncellenecekpersonel.StokIsim = stokisim;
                guncellenecekpersonel.StokAdet = stokadet;
                guncellenecekpersonel.StokRafNo = stokrafno;
                guncellenecekpersonel.StokModel = stokmodel;
                guncellenecekpersonel.StokSeriNo = stokserino;
                guncellenecekpersonel.StokTarih = stoktarih;
                guncellenecekpersonel.ElemanIsim = elemanisim;
                guncellenecekpersonel.Aciklama = aciklama;
                baglanti.SubmitChanges();
            }
        }
        public bool adetKontrol(string adet)
        {
            int sayac = 0;
            List<string> icermeyecekler = new List<string>();
            icermeyecekler.Add(",");
            icermeyecekler.Add("?");
            icermeyecekler.Add("*");
            icermeyecekler.Add(";");
            icermeyecekler.Add(".");
            icermeyecekler.Add("/");
            icermeyecekler.Add("+");
            icermeyecekler.Add("-");
            for (char i = 'a'; i < 'z'; i++)
                icermeyecekler.Add(i.ToString());
            for(char i='A';i<'Z';i++)
                icermeyecekler.Add(i.ToString());
            for (int i = 0; i < icermeyecekler.Count; i++)
            {
                if (adet.Contains(icermeyecekler[i]))
                    sayac++;
            }
            if (sayac > 0)
                return false;
            else
                return true;
        }
        public bool rafNoKontrol(string rafno)
        {
            int rafnosinir = 36;
            int sayac = 0;
            List<string> icerecekler = new List<string>();
           for(int i=1;i<=rafnosinir;i++)
            {
                icerecekler.Add("A"+ i.ToString());
                icerecekler.Add("B" + i.ToString());
            }
            for (int i = 0; i < icerecekler.Count; i++)
            {
                if (rafno.Contains(icerecekler[i]))
                    sayac++;
            }
            if (sayac > 0)
                return true;
            else
                return false;
        }
        public bool guncellemeKontrol(int id, string serino)
        {  
            Stok bulunankayit = baglanti.Stoks.Where(u => u.StokID == id).FirstOrDefault();
            if (bulunankayit!=null&& (bulunankayit.StokSeriNo == serino||baglanti.Stoks.Select(u=>u.StokSeriNo).Contains(serino)!=true))
                return true;
            else
                return false;

        }
        public IQueryable stokListe()
        {
           return baglanti.Stoks.Select(u => u);
        }
        public IQueryable hurdaListe()
        {
            return baglanti.Hurdas.Select(u => u);
        }
        public IQueryable stokAraIsim(string ad)
        {
          return baglanti.Stoks.Where(u => u.StokIsim.Contains(ad));
        }
        public IQueryable stokAraModel(string model)
        {
            return baglanti.Stoks.Where(u => u.StokModel.Contains(model));
        }
        public IQueryable stokAraRafNo(string rafno)
        {
            return baglanti.Stoks.Where(u => u.StokRafNo.Contains(rafno));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathDev.Core.Model.Base.Helper
{
    public class MongoDbHelper
    {
        public static string _cnnStr = "mongodb://192.168.10.10:27017";
        public static string _dbName = "AnaVeriSQL";
        public static string _tblPlatformIcerik = "BEKTicariPlatformIcerikleri";
        public static string _tblFirma = "Firma";
        public static string _tblPersonel = "Personel";
        public static string _tblKisi = "Kisi";
        public static string _tblIletisim = "Iletisim";
        public static string _tblIl = "Il";
        public static string _tblIlce = "Ilce";
        public static string _tblSube = "Sube";
        public static string _tblKurulus = "Kurulus";
        public static string _tblBolumler = "SiziDinliyoruzBolumler";
        public static string _tblSiziDinliyoruzGeriBildirimKonulari = "SiziDinliyoruzGeriBildirimKonulari";
        public static string _tblAkademiEtkinlik = "AkademiEtkinlik";
        public static string _tblAkademiKatilimTalepleri = "AkademiKatilimTalepleri";
    }
}

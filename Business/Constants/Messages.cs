using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string CarAdded = "Araç Eklendi";
        public static string CarDeleted = "Araç Silindi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarNameInvalid = "Araç ismi Geçersiz";
        public static string CarListed = "Araç Listelendi";
        public static string MaintenanceTime = "Sistem Bakkımda";



        public static string BrandAdded = "Araç Modeli Eklendi";
        public static string BrandNameInvalid = "Araç Modeli Geçersiz";
        public static string BrandDeleted = "Araç Modeli Silindi";
        public static string BrandListed = "Araç Modeli Listelendi";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorNameInvalid = "Renk İsmi Geçersiz";
        public static string  ColorDeleted = "Renk  Silindi";
        public static string ColorListed = "Araç Rengi  Listelendi";



        public static string UserPassWrong = "Kullanıcı şifresi minimum 6 karakter olmalıdır";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserListed = "Kullanıcı Listelendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        

        public static string CustomerAdded = "Müşteri EKlendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerListed = "Müşteri Lİstelendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";

        public static string RentalAdded = "Araç Kiralandı";
        public static string RentalDeleted = "Araç kiralama bilgisi Silindi";
        public static string RentalListed = "Araç kiralama bilgisi Listelendi";
        public static string RentalUpdated = "Araç kiralama bilgisi güncellendi Güncellendi";
        public static string CarNotRentaled = "Araba kiralama işlemi başarısız oldu";
        public static string CarRentaled = "Araba kiralama işlemi başarılı oldu";

        public static string CarBrandCountOfCategoryEror = "Her Araç modelinde en fazla 15 araba eklenebilir";

        public static string ImageLimitExceded = "Araç Resim Ekleme limitini aştınız sadece 5 tane resim eklene bilir";
    }
}

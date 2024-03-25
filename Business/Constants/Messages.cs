using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarDailyPriceMinimumValue = "Arabanın günlük fiyatı 0'dan büyük olmalıdır";
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarNotFoundWithId = "İlgili Id'ye sahip araba bulunamadı";

        public static string BrandNameMinimumLength = "Marka ismi en az 2 karakter olmalı";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNotFoundWithId = "İlgili Id'ye sahip marka bulunamadı";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNotFoundWithId = "İlgili Id'ye sahip renk bulunamadı";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserNotFoundWithId = "İlgili Id'ye sahip kullanıcı bulunamadı";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerNotFoundWithId = "İlgili Id'ye sahip müşteri bulunamadı";

        public static string RentalAdded = "Araç kiralandı";
        public static string RentalDeleted = "Araç kiralama silindi";
        public static string RentalUpdated = "Araç kiralama güncellendi";
        public static string RentalReturn = "Araç teslim edildi";
        public static string RentalExist = "Araç zaten kiralanmış";
        public static string RentalCustomerExist = "Müşteri zaten başka bir araç kiralanmış";
        public static string RentalNotFound = "Araç kiralama bulunamadı";
        public static string RentalNotFoundWithId = "İlgili Id'ye sahip kiralama bulunamadı";
    }
}

namespace Business.Constants
{
    public static class Messages
    {
        // Car
        public static string CarDailyPriceMinimumValue = "Arabanın günlük fiyatı 0'dan büyük olmalıdır";
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarNotFoundWithId = "İlgili Id'ye sahip araba bulunamadı";

        // Brand
        public static string BrandNameMinimumLength = "Marka ismi en az 2 karakter olmalı";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNotFoundWithId = "İlgili Id'ye sahip marka bulunamadı";

        // Color
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNotFoundWithId = "İlgili Id'ye sahip renk bulunamadı";

        // User
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserNotFoundWithId = "İlgili Id'ye sahip kullanıcı bulunamadı";
        public static string PasswordNotBeNullOrEmpty = "Şifre boş olamaz";

        // Customer
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerNotFoundWithId = "İlgili Id'ye sahip müşteri bulunamadı";

        // Rental
        public static string RentalAdded = "Araç kiralandı";
        public static string RentalDeleted = "Araç kiralama silindi";
        public static string RentalUpdated = "Araç kiralama güncellendi";
        public static string RentalReturn = "Araç teslim edildi";
        public static string RentalNotFound = "Araç kiralama bulunamadı";
        public static string RentalNotFoundWithId = "İlgili Id'ye sahip kiralama bulunamadı";
        public static string CustomerHasUnreturnedCar = "Şu anda başka bir araba kiraladığınız için yeni bir araba kiralayamazsınız";
        public static string CarAlreadyRented = "Araba zaten kiralanmış";

        // CarImage
        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageUpdated = "Araç resmi güncellendi";
        public static string CarImageNotFoundWithId = "İlgili Id'ye sahip araç resmi bulunamadı";
        public static string CarImageCountOfCarError = "En fazla 5 resim yükleyebilirsiniz";

        // Auth
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Aynı e-postaya sahip kullanıcı zaten var";
        public static string UserRegistered = "Kayıt başarılı";
        public static string AccessTokenCreated = "Access token oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";

        // Payment
        public static string PaymentSuccess = "Ödeme başarılı";

        // Credit Card
        public static string CreditCardAdded = "Kredi kartı eklendi";
        public static string CreditCardDeleted = "Kredi kartı silindi";
        public static string CreditCardUpdated = "Kredi kartı güncellendi";
        public static string CreditCardNotFoundWithId = "İlgili Id'ye sahip kredi kartı bulunamadı";
        public static string CreditCardNotFoundByUserId = "İlgili kullanıcının kredi kartı bulunamadı";
        public static string CreditCardExists = "Kredi kartı zaten eklenmiş";
    }
}

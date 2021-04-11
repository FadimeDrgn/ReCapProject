using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    //static olmasının sebebi newleme gerekmiyor.
    public static class Messages 
    {
        public static string CarUpdated = "Araba başarıyla güncellendi";
        public static string CarAdded = "Araba eklendi";
        public static string BrandNameInvalid = "Araba açıklaması geçersiz.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CheckCarImageLımıtError = "Bir arabanın en fazla beş resmi olabilir.";
        public static string CheckCarForDeleteImageError = "Verdiğiniz id de resim bulunamadı.";
        public static string ListOfCarImageListError = "Listelenecek araba resmi yok";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string CarImageUpdated = "Araba resmi başarıyla güncellendi.";
        public static string RentalListed = "Kiralamalar listelendi.";
    }
}

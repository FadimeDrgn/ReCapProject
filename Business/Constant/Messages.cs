using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    //static olmasının sebebi newleme gerekmiyor.
    public static class Messages 
    {
        public static string CarAdded = "Araba eklendi";
        public static string BrandNameInvalid = "Araba açıklaması geçersiz.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CheckCarImageLımıtError = "Bir arabanın en fazla beş resmi olabilir.";
        public static string CheckCarForDeleteImageError = "Verdiğiniz id de resim bulunamadı.";
        public static string ListOfCarImageListError = "Listelenecek araba resmi yok";
    }
}

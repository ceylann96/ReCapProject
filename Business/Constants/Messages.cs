using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = " Araç listelendi";
        public static string CarUptated = "Araç güncellendi";
        public static string CarDeleted = "Araç silindi";
        public static string BrandAdded = "Model Eklendi";
        public static string BrandDeleted = "Model Silindi";
        public static string BrandUpdated = "Model Güncellendi";
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string UserRegistered = "kullanıcı kaydedildi";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "parola hatası";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "access token oluşturuldu";
    }
}

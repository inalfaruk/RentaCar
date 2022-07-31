using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Araç ismi geçersizdir";
        public static string CarDeleted="Araç Silindi";
        public static string CarUpdated="Güncellendi";
        public static string CarCountOfColorError="Aynı renkte daha fazla araç olamaz.";
        public static string CarNameAlreadyExists ="Aynı İsimde araç eklenmiş";
        public static string ColorLimitExceded = "renk sayısı fazla";

        public static string CarCountOfImageError = "En fazla 5 adet resim eklenebilir.";
        public static string  AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists ="Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated ="Token oluşturuldu";
    }
}

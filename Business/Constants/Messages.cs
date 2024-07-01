using Core.Entities.Concrete;
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
        internal static string MaintenanceTime = "Sistem bakımda";
        internal static string AuthorizationDenied = "Yetkiniz yok";
        internal static string UserRegistered = "Kayıt oldu";
        internal static string UserNotFound = "Kayıt bulunamadı";
        internal static string PasswordError = "Parola hatası";
        internal static string SuccessfulLogin = "Başarılı giriş";
        internal static string UserAlreadyExists="Kullanıcı mevcut";
        internal static string AccessTokenCreated = "Token oluşturuldu";
    }
}

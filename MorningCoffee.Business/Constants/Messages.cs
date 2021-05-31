using MorningCoffee.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MorningCoffee.Business.Constants
{
    public static class Messages
    {

        // ------------------------------------------------------------------------------------
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordNotMatch = "Parola Eşleşmedi";
        public static string UserAlreadyExist = "Kullanıcı zaten var";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserRegistered = "Kayıt olundu";
        public static string AccessTokenCreated = "Token oluşturuldu";
        // ------------------------------------------------------------------------------------
        public static string AuthorizationDenied = "Yetkiniz yok";
        // ------------------------------------------------------------------------------------

        public static string CoffeeAdded = "Kahve Eklendi";
        public static string CoffeeDeleted = "Kahve Silindi";
        public static string CoffeeListed = "Kahveler getirildi";
        public static string CoffeeBrought = "Kahve Getirildi";
        public static string CoffeeUpdated = "Kahve Güncellendi";
        public static string CoffeeNameAlreadyExists = "Bu isimde başka bir kahve zaten var";
        public static string CoffeeCountOfHotCoffeeError = "Maksimum kahve satış sayısına ulaşıldı";
        // ------------------------------------------------------------------------------------
        public static string FrappuccinoAdded = "Frappuccino Eklendi";
        public static string FrappuccinoDeleted = "Frappuccino Silindi";
        public static string FrappuccinoListed = "Frappuccino Listelendi";
        public static string FrappuccinoBrought = "Frappuccino Getirildi";
        public static string FrappuccinoUpdated = "Frappuccino Güncellendi";
        public static string FrappuccinoNameAlreadyExists = "Bu isimde başka bir frappuccino zaten var";
        public static string FrappuccinoCountFrappuccinoBlendedBeverageOfError = "Maksimum frappuccino satış sayısına ulaşıldı";
        // ------------------------------------------------------------------------------------
        public static string TeaAdded = "Çay eklendi";
        public static string TeaDeleted = "Çay silindi";
        public static string TeaListed = "Çay listelendi";
        public static string TeaBrought = "Çay getirildi";
        public static string TeaUpdated = "Çay güncellendi";
        public static string TeaNameAlreadyExists = "Bu isimde başka bir çay zaten var";
        public static string TeaCountOfIcedTeaError = "Maksimum tea satış sayısına ulaşıldı";
    }
}

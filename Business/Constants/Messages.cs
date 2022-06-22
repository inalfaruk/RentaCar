using Entities.Concrete;
using System;
using System.Collections.Generic;
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
        internal static string ColorLimitExceded = "renk sayısı fazla";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static  class Messages<T>
    {
        public static readonly string EntityName = typeof(T).Name;

        public static string EntityAdded => $"{EntityName} nesnesi başarıyla eklendi";
        public static string EntityUpdated => $"{EntityName} nesnesi başarıyla güncellendi";
        public static string EntityDeleted => $"{EntityName} nesnesine başarıyla soft delete yapıldı";
        public static string EntityNotFound => $"Girdiğiniz id değerine sahip bir {EntityName} nesnesi bulunamadı";
        public static string EntityNameDuplicated => $"Bu isme sahip bir {EntityName} nesnesi zaten var, lütfen ismini değiştirin";
        public static string EntityAlreadyDeleted => $"Girdiginiz id değerine sahip {EntityName} nesnesine zaten soft delete yapılmış";
        public static string EntityCantMatches => "Email veya sifre uyusmuyor";

        public static string EntityCantGet => $"{EntityName} alanına ait veri bulunamadı.";
    }
}

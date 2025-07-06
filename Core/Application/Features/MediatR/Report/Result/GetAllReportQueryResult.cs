using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Report.Result
{
    public class GetAllReportQueryResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }           // Kim şikayet etti
        public int? QuestionId { get; set; }         // Şikayet edilen soru
        public int? AnswerId { get; set; }           // Şikayet edilen cevap
        public string Reason { get; set; }           // Açıklama
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DeletedAt { get; set; }
    }
}

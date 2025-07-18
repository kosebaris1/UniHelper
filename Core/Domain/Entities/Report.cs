using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public int UserId { get; set; }           // Kim şikayet etti
        public int? QuestionId { get; set; }         // Şikayet edilen soru
        public int? AnswerId { get; set; }           // Şikayet edilen cevap
        public string Reason { get; set; }           // Açıklama
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
      

        // Navigation
        public User User { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}

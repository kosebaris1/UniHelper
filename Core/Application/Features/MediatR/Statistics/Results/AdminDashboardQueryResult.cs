namespace Application.Features.MediatR.Statistics.Results
{
    public class AdminDashboardQueryResult
    {
        public int TotalUsers { get; set; }
        public int VerifiedUsers { get; set; }
        public int PendingUserApprovals { get; set; }

        public int PublishedQuestions { get; set; }
        public int PendingQuestions { get; set; }

        public int TotalAnswers { get; set; }

        public string MostLikedAnswerUser { get; set; }
        public int MostLikedAnswerUserTotalLikes { get; set; }

        public string MostLikedQuestionUser { get; set; }
        public int MostLikedQuestionUserTotalLikes { get; set; }
    }
}

using UniDto.QuestionDtos;

namespace UniWebUI.Models
{
    public class QuestionDetailViewModel:GetQuestionDetailDto
    {
        public int CurrentUserId { get; set; }
        public bool CanAnswer { get; set; }
    }
}

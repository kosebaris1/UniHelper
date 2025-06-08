﻿namespace UniDto.QuestionDtos
{
    public class GetFilteredQuestionDto
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public string DepartmentName { get; set; }
        public string UniversityName { get; set; }
        public List<string> QuestionTags { get; set; }
        public int LikeCount { get; set; }
        public int AnswerCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

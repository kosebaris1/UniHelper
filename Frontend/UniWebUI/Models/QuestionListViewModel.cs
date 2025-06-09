using UniDto.QuestionDtos;

namespace UniWebUI.Models
{
    public class QuestionListViewModel
    {
        public List<GetFilteredQuestionDto> Questions { get; set; } = new List<GetFilteredQuestionDto>();
        public int? SelectedCityId { get; set; }
        public int? SelectedUniversityId { get; set; }
        public int? SelectedDepartmentId { get; set; }
        public List<int>? SelectedTagsId { get; set; }

        public string SortBy { get; set; } = "new"; // default değer

    }
}

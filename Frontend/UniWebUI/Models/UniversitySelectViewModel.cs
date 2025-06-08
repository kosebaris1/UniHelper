using UniDto.UniversityDtos;

namespace UniWebUI.Models
{
    public class UniversitySelectViewModel
    {
        public int? UniversityId { get; set; } // Form ile gönderilecek kısım
        public List<GetAllUniversityDto> Universities { get; set; } // Dropdown verisi
    }
}

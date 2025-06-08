using UniDto.RegisterDtos;

namespace UniWebUI.Models
{
    public class RegisterViewModel
    {
       
            public CreateRegisterDto RegisterDto { get; set; } = new CreateRegisterDto();
            public List<GetUniversityDto> Universities { get; set; } = new List<GetUniversityDto>();
            

    }
}

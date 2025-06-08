using MediatR;

namespace Application.Features.MediatR.Tags.Commands
{
    public class CreateTagCommand:IRequest<Unit>
    {
        public string Name { get; set; }
    }
}

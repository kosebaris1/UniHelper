using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AnswerLikes.Commands
{
    public class CreateAnswerLikeCommand:IRequest<Unit>
    {
        public int UserId { get; set; }
        public int AnswerId { get; set; }
    }
}

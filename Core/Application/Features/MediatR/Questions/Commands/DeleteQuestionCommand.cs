using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Commands
{
    public class DeleteQuestionCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteQuestionCommand(int ıd)
        {
            Id = ıd;
        }
    }
}

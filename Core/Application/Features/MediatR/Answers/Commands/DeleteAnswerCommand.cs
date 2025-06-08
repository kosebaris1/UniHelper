using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Answers.Commands
{
    public class DeleteAnswerCommand:IRequest<Unit>
    {
        public int AnswerId { get; set; }

        public DeleteAnswerCommand(int answerId)
        {
            AnswerId = answerId;
        }
    }
}

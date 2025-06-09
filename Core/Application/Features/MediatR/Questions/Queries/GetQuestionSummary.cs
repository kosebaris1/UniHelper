using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Queries
{
    public class GetQuestionSummaryQuery : IRequest<string>
    {
        public int QuestionId { get; set; }

        public GetQuestionSummaryQuery(int questionId)
        {
            QuestionId = questionId;
        }
    }
}

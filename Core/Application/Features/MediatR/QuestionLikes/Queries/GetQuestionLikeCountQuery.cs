using Application.Features.MediatR.QuestionLikes.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.QuestionLikes.Queries
{
    public class GetQuestionLikeCountQuery:IRequest<GetQuestionLikeCountQueryResult>
    {
        public int QuestionId { get; set; }

        public GetQuestionLikeCountQuery(int questionId)
        {
            QuestionId = questionId;
        }
    }
}

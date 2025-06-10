using Application.Features.MediatR.Questions.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Questions.Queries
{
    public class GetMyAllLikedQuestionQuery:IRequest<List<GetMyAllLikedQuestionQueryResult>>
    {
        public int UserId { get; set; }

        public GetMyAllLikedQuestionQuery(int userId)
        {
            UserId = userId;
        }
    }
}

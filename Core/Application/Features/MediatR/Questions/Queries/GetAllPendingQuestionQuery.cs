using Application.Features.MediatR.Questions.Results;
using MediatR;

namespace Application.Features.MediatR.Questions.Queries
{
    public class GetAllPendingQuestionQuery:IRequest<List<GetAllPendingQuestionQueryResult>>
    {
    }
}

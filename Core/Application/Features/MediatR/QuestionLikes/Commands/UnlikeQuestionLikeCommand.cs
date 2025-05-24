using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.QuestionLikes.Commands
{
    public class UnlikeQuestionLikeCommand:IRequest<Unit>
    {
        //public UnlikeQuestionLikeCommand(int userId, int questionId)
        //{
        //    UserId = userId;
        //    QuestionId = questionId;
        //}
        //public UnlikeQuestionLikeCommand() { }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}

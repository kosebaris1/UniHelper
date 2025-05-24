using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Universities.Results
{
    public class GetAllUniversityQueryResult
    {
        public int UniversityId { get; set; }
        public string Name { get; set; }
    }
}

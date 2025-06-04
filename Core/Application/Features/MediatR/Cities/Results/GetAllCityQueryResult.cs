using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Cities.Results
{
    public class GetAllCityQueryResult
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}

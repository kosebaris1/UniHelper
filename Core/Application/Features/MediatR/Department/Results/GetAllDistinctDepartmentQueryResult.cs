﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Department.Results
{
    public class GetAllDistinctDepartmentQueryResult
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        
    }
}

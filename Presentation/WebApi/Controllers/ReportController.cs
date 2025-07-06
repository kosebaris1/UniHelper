﻿using Application.Features.MediatR.Report.Command;
using Application.Features.MediatR.Report.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
    public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _mediator.Send(new GetAllReportQuery());
            return Ok(reports);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(CreateReportCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid report data.");
            }

            await _mediator.Send(command);
            return Ok("Şikayetiniz başarıyla alındı. Teşekkür ederiz!");
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UniDto.ReportDtos;
using UniWebUI.Models;

namespace UniWebUI.Controllers
{
    public class ReportController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Create(int? questionId, int? answerId, string userId)
        {
            var vm = new CreateReportViewModel
            {
                QuestionId = questionId,
                AnswerId = answerId,
                UserId = userId
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReportViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(new
            {
                userId = model.UserId,
                questionId = model.QuestionId,
                answerId = model.AnswerId,
                reason = model.Reason
            });

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

         
            var response = await client.PostAsync("https://localhost:7224/api/Report", content);

            if (response.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index", "Question");
            }

          
            return View(model);
        }
       
        [HttpGet]
        public async Task<IActionResult> AnswerReports(int answerId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($" https://localhost:7224/api/Report/{answerId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var reports = JsonConvert.DeserializeObject<List<GetReportDto>>(json);
                return View(reports);
            }

            return View(new List<GetReportDto>());
        }


    }
}

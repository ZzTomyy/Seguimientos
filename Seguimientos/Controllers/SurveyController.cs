using Microsoft.AspNetCore.Mvc;
using Seguimientos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seguimientos.Controllers
{
    public class SurveyController : Controller
    {
        private static List<Survey> surveys = new();

        public IActionResult Index()
        {
            return View(surveys);
        }

        [HttpPost]
        public IActionResult Create(string title, string option1, string option2)
        {
            var survey = new Survey
            {
                Id = surveys.Count + 1,
                Title = title,
                CreatedAt = DateTime.Now,
                Options = new List<SurveyOption>
                {
                    new SurveyOption { Id = 1, Text = option1, Votes = 0 },
                    new SurveyOption { Id = 2, Text = option2, Votes = 0 }
                }
            };

            surveys.Add(survey);
            return RedirectToAction("Index");
        }

        public IActionResult Vote(int surveyId, int optionId)
        {
            var survey = surveys.FirstOrDefault(s => s.Id == surveyId);
            var option = survey?.Options.FirstOrDefault(o => o.Id == optionId);

            if (option != null)
                option.Votes++;

            return RedirectToAction("Index");
        }
    }
}

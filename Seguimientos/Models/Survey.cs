using System;
using System.Collections.Generic;

namespace Seguimientos.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<SurveyOption> Options { get; set; } = new();
    }
}


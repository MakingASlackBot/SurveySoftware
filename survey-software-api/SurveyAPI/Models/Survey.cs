using System;
using System.Collections.Generic;

namespace SurveyAPI.Models
{
    public partial class Survey
    {
        public int Id { get; set; }
        public string SurveyCode { get; set; } = null!;
        public string Jsoncontents { get; set; } = null!;
        public string? Summary { get; set; }
    }
}

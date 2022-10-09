using Microsoft.AspNetCore.Mvc;
using SurveyAPI.Contexts;
using SurveyAPI.Models;
using System.Data.SqlClient;

namespace SurveyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {

        private readonly ILogger<SurveyController> _logger;
        public IConfigurationRoot Configuration { get; set; }

        public SurveyController(ILogger<SurveyController> logger)
        {
            _logger = logger;
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, false);
            Configuration = configBuilder.Build();
        }

        [HttpGet(Name = "EFTestGet")]
        public Survey EFTest()
        {
            using (var db = new SurveySoftwareContext())
            {
                var surveyCount = db.Surveys.Count();
                return db.Surveys.FirstOrDefault() ?? new Survey();
            }

            return new Survey();
        }
    }
}
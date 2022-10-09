using Microsoft.AspNetCore.Mvc;
using survey_software_api;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
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

        [HttpGet(Name = "GetSurvey")]
        public Survey Get()
        {
            var connectionString = Configuration["ConnectionStrings:Dev"];

            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = connectionString;
                var selectStatement = "SELECT TOP 1 * FROM [survey-software].dbo.Survey;";

                using (var cmd = new SqlCommand() { Connection = cn })
                {
                    cmd.CommandText = selectStatement;
                    cn.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        return new Survey
                        {
                            Id = (int)reader["Id"],
                            SurveyCode = new Guid((string)reader["SurveyCode"]),
                            JSONContents = (string)reader["JSONContents"],
                            Summary = (string)reader["Summary"]
                        };
                    }
                }
            }

            return new Survey
            {
                Id = 1,
                SurveyCode = new Guid(),
                JSONContents = "",
                Summary = "sigh"
            };
        }
    }
}
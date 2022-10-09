namespace survey_software_api
{
    public class Survey
    {
        public int Id { get; set; }

        public Guid SurveyCode { get; set; }

        public string? JSONContents { get; set; }
        public string? Summary { get; set; }
    }
}
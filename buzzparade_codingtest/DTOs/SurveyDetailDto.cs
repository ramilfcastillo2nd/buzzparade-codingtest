using System.Collections.Generic;

namespace buzzparade_codingtest.DTOs
{
    public class SurveyDetailDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool IsMultipleChoice { get; set; }
        public List<SurveyAnswerMultipleDto> SurveyAnswers { get; set; }
        public SurveyAnswerTextDto SurveyAnswer { get; set; }
    }
}
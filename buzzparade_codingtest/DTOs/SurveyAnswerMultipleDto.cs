using buzzparade_codingtest.Enums;

namespace buzzparade_codingtest.DTOs
{
    public class SurveyAnswerMultipleDto
    {
        public int Id { get; set; }
        public SurveyAnswerOptions Answer { get; set; }
        public bool IsSelected { get; set; }
    }
}
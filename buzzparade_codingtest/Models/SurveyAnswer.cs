using buzzparade_codingtest.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buzzparade_codingtest.Models
{
    public class SurveyAnswer
    {
        [Key]
        public int Id { get; set; }
        public SurveyAnswerOptions? Answer { get; set; }
        public string AnswerText { get; set; }
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }
    }
}
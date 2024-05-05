using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buzzparade_codingtest.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public bool IsMultipleChoice { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual IEnumerable<SurveyAnswer> SurveyAnswers { get; set; }
    }
}
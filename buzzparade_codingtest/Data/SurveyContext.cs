using buzzparade_codingtest.Models;
using System.Data.Entity;

namespace buzzparade_codingtest.Data
{
    public class SurveyContext: DbContext
    {
        public SurveyContext() : base("DefaultConnection")
        {
        }

        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public virtual DbSet<User> Users { get; set; }  
    }
}
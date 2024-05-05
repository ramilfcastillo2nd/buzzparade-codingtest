using buzzparade_codingtest.Models;
using System.Collections.Generic;
using System.Linq;

namespace buzzparade_codingtest.Data.Repositories
{
    public class SurverAnswerRepository
    {
        //Get all survey answers by survey id
        public List<SurveyAnswer> GetSurveyAnswers(int surveyId)
        {
            using (var context = new SurveyContext())
            {
                return context.SurveyAnswers.Where(s => s.SurveyId == surveyId).ToList();
            }
        }

        public void DeleteSurveyAnswer(int id)
        {
            using (var context = new SurveyContext())
            {
                var surveyAnswer = context.SurveyAnswers.FirstOrDefault(s => s.Id == id);
                context.Entry(surveyAnswer).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void AddSurveyAnswer(SurveyAnswer surveyAnswer)
        {
            using (var context = new SurveyContext())
            {
                context.SurveyAnswers.Add(surveyAnswer);
                context.SaveChanges();
            }
        }

        public void UpdateSurveyAnswer(SurveyAnswer surveyAnswer)
        {
            using (var context = new SurveyContext())
            {
                var existingSurveyAnswer = context.SurveyAnswers.FirstOrDefault(s => s.Id == surveyAnswer.Id);
                if (existingSurveyAnswer != null)
                {
                    existingSurveyAnswer.Answer = surveyAnswer.Answer;
                    existingSurveyAnswer.AnswerText = surveyAnswer.AnswerText;
                    context.SaveChanges();
                }
            }
        }
    }
}
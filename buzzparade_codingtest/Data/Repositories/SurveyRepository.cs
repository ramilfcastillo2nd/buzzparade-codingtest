using buzzparade_codingtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace buzzparade_codingtest.Data.Repositories
{
    public class SurveyRepository
    {
        public SurveyRepository() { }

        public List<Survey> GetSurveys()
        {
            using (var context = new SurveyContext())
            {
                return context.Surveys.Include("User").ToList();
            }
        }

        public Survey GetSurvey(int id)
        {
            using (var context = new SurveyContext())
            {
                return context.Surveys.FirstOrDefault(s => s.Id == id);
            }
        }   
    }
}
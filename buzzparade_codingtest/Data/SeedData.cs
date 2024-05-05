using buzzparade_codingtest.Enums;
using buzzparade_codingtest.Models;
using System.Collections.Generic;
using System.Linq;

namespace buzzparade_codingtest.Data
{
    public class SeedData
    {
        //initiale method to seed data
        public static void Initialize(SurveyContext context)
        {
            // Look for any surveys.
            if (!context.Users.Any())
            {
                InsertUsers(context);
            }

            if (!context.Surveys.Any())
            {
                InsertSurveys(context);
            }

            if (!context.SurveyAnswers.Any())
            {
                InsertSurveyAnswers(context);
            }

        }
        //Create seed data for users
        public static List<User> Users = new List<User>
        {
            new User { Id = 1, Name = "Doe John", Email = "test@gmail.com"}
        };

        public static List<Survey> surveys = new List<Survey>
        {
            new Survey { Id = 1, Question = "Survey 1", UserId = 1, IsMultipleChoice = false },
            new Survey { Id = 2, Question = "Survey 2", UserId = 1, IsMultipleChoice = true },
            new Survey { Id = 3, Question = "Survey 3", UserId = 1, IsMultipleChoice = false },
        };

        public static List<SurveyAnswer> surveyAnswers = new List<SurveyAnswer>
        {
            new SurveyAnswer { Id = 1, SurveyId = 2, Answer =  SurveyAnswerOptions.OnlineJobsPH, AnswerText= string.Empty },
            new SurveyAnswer { Id = 2, SurveyId = 2, Answer = SurveyAnswerOptions.JobStreet, AnswerText = string.Empty },
            new SurveyAnswer { Id = 3, SurveyId = 2, Answer = SurveyAnswerOptions.Indeed },
            new SurveyAnswer { Id = 4, SurveyId = 1, Answer =  null, AnswerText = "Test Answer" },
            new SurveyAnswer { Id = 5, SurveyId = 3, Answer =  null, AnswerText = "Test Answer"}
        };

        //insert users to users table
        public static void InsertUsers(SurveyContext context)
        {
            context.Users.AddRange(Users);
            context.SaveChanges();
        }

        public static void InsertSurveys(SurveyContext context)
        {
            context.Surveys.AddRange(surveys);
            context.SaveChanges();
        }
        public static void InsertSurveyAnswers(SurveyContext context)
        {
            context.SurveyAnswers.AddRange(surveyAnswers);
            context.SaveChanges();
        }
    }
}
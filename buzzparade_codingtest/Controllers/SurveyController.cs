using buzzparade_codingtest.DTOs;
using buzzparade_codingtest.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buzzparade_codingtest.Controllers
{
    public class SurveyController : Controller
    {
        public ActionResult Index()
        {
            var surveyRepository = new Data.Repositories.SurveyRepository();
            var surveys = surveyRepository.GetSurveys();

            var surveyList = new List<SurveyListDto>();
            if (surveys != null)
            {
                foreach (var survey in surveys)
                {
                    surveyList.Add(new SurveyListDto
                    {
                        Id = survey.Id,
                        FullName = survey.User.Name,
                        Email = survey.User.Email,
                        Question = survey.Question
                    });
                }
            }

            return View(surveyList);
        }

        public ActionResult Edit(int id)
        {
            var surveyRepository = new Data.Repositories.SurveyRepository();
            var survey = surveyRepository.GetSurvey(id);
            var result = new SurveyDetailDto();
            var surveyAnswerList = new List<SurveyAnswerMultipleDto>();
            var surveyAnswer = new SurveyAnswerTextDto();
            if (survey != null)
            {
                result = new SurveyDetailDto
                {
                    Id = survey.Id,
                    Question = survey.Question,
                    IsMultipleChoice = survey.IsMultipleChoice
                };
                var surveyAnswerRepository = new Data.Repositories.SurverAnswerRepository();
                var surveyAnswers = surveyAnswerRepository.GetSurveyAnswers(id);

                if (survey.IsMultipleChoice)
                {
                    foreach (SurveyAnswerOptions option in Enum.GetValues(typeof(SurveyAnswerOptions)))
                    {
                        //check if the option is in the surveyAnswers
                        var surveyAnswerOption = surveyAnswers.FirstOrDefault(x => x.Answer.Value == option);
                        //if the option is in the surveyAnswers, add it to the list
                        if (surveyAnswerOption != null)
                        {
                            surveyAnswerList.Add(new SurveyAnswerMultipleDto
                            {
                                Id = surveyAnswerOption.Id,
                                Answer = surveyAnswerOption.Answer.Value,
                                IsSelected = true
                            });
                        }
                        //if the option is not in the surveyAnswers, add it to the list with an empty value
                        else
                        {
                            surveyAnswerList.Add(new SurveyAnswerMultipleDto
                            {
                                Id = 0,
                                Answer = option,
                                IsSelected = false
                            });
                        }
                    }
                }
                else
                {
                    var surveySingleAnswer = surveyAnswers.FirstOrDefault();

                    surveyAnswer = new SurveyAnswerTextDto
                    {
                        Id = surveySingleAnswer.Id,
                        AnswerText = surveySingleAnswer.AnswerText
                    };

                }
            }

            result.SurveyAnswers = surveyAnswerList;
            result.SurveyAnswer = surveyAnswer;
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(SurveyDetailDto input)
        {
            var surveyRepository = new Data.Repositories.SurveyRepository();
            var survey = surveyRepository.GetSurvey(input.Id);

            if(survey != null   )
            {
                var surveyAnswerRepository = new Data.Repositories.SurverAnswerRepository();
                var surveyAnswers = surveyAnswerRepository.GetSurveyAnswers(input.Id);

                if (survey.IsMultipleChoice)
                {
                    foreach (var answer in input.SurveyAnswers)
                    {
                        var surveyAnswer = surveyAnswers.FirstOrDefault(x => x.Answer.Value == answer.Answer);
                        if (surveyAnswer != null)
                        {
                            if (!answer.IsSelected)
                            {
                                surveyAnswerRepository.DeleteSurveyAnswer(surveyAnswer.Id);
                            }
                        }
                        else
                        {
                            if (answer.IsSelected)
                            {
                                surveyAnswerRepository.AddSurveyAnswer(new Models.SurveyAnswer
                                {
                                    SurveyId = input.Id,
                                    Answer = answer.Answer
                                });
                            }
                        }
                    }
                }
                else
                {
                    var surveyAnswer = surveyAnswers.FirstOrDefault();
                    if (surveyAnswer != null)
                    {
                        surveyAnswerRepository.UpdateSurveyAnswer(new Models.SurveyAnswer
                        {
                            Id = surveyAnswer.Id,
                            SurveyId = input.Id,
                            AnswerText = input.SurveyAnswer.AnswerText
                        });
                    }
                    else
                    {
                        surveyAnswerRepository.AddSurveyAnswer(new Models.SurveyAnswer
                        {
                            SurveyId = input.Id,
                            AnswerText = input.SurveyAnswer.AnswerText
                        });
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}
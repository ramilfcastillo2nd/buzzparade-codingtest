namespace buzzparade_codingtest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChangesToSurveyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyAnswers", "AnswerText", c => c.String());
            AlterColumn("dbo.SurveyAnswers", "Answer", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SurveyAnswers", "Answer", c => c.String());
            DropColumn("dbo.SurveyAnswers", "AnswerText");
        }
    }
}

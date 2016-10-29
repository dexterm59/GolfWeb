namespace GolfWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GolfCourses",
                c => new
                    {
                        GolfCourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CourseSlope = c.Int(nullable: false),
                        CourseRating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.GolfCourseID);
            
            CreateTable(
                "dbo.GolfHoles",
                c => new
                    {
                        GolfHoleID = c.Int(nullable: false, identity: true),
                        GolfCourseID = c.Int(nullable: false),
                        HoleNum = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        Handicap = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GolfHoleID)
                .ForeignKey("dbo.GolfCourses", t => t.GolfCourseID, cascadeDelete: true)
                .Index(t => t.GolfCourseID);
            
            CreateTable(
                "dbo.Golfers",
                c => new
                    {
                        GolferID = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        GhinNum = c.String(maxLength: 7),
                    })
                .PrimaryKey(t => t.GolferID);
            
            CreateTable(
                "dbo.GolfRounds",
                c => new
                    {
                        GolfRoundID = c.Int(nullable: false, identity: true),
                        GolferID = c.Int(nullable: false),
                        Index = c.Single(nullable: false),
                        RoundTime = c.DateTime(nullable: false),
                        GolfCourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GolfRoundID)
                .ForeignKey("dbo.GolfCourses", t => t.GolfCourseID, cascadeDelete: true)
                .ForeignKey("dbo.Golfers", t => t.GolferID, cascadeDelete: true)
                .Index(t => t.GolferID)
                .Index(t => t.GolfCourseID);
            
            CreateTable(
                "dbo.HoleScores",
                c => new
                    {
                        HoleScoreID = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        FairwayAccuracy = c.Int(nullable: false),
                        ApproachAccuracy = c.Int(nullable: false),
                        Putts = c.Int(nullable: false),
                        FirstPuttLength = c.Int(nullable: false),
                        MadePuttLength = c.Int(nullable: false),
                        Chip = c.Boolean(nullable: false),
                        Pitch = c.Boolean(nullable: false),
                        Sand = c.Boolean(nullable: false),
                        Penalty = c.Int(nullable: false),
                        RoundID = c.Int(nullable: false),
                        GolfHoleID = c.Int(nullable: false),
                        GolfRound_GolfRoundID = c.Int(),
                    })
                .PrimaryKey(t => t.HoleScoreID)
                .ForeignKey("dbo.GolfHoles", t => t.GolfHoleID, cascadeDelete: true)
                .ForeignKey("dbo.GolfRounds", t => t.GolfRound_GolfRoundID)
                .Index(t => t.GolfHoleID)
                .Index(t => t.GolfRound_GolfRoundID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoleScores", "GolfRound_GolfRoundID", "dbo.GolfRounds");
            DropForeignKey("dbo.HoleScores", "GolfHoleID", "dbo.GolfHoles");
            DropForeignKey("dbo.GolfRounds", "GolferID", "dbo.Golfers");
            DropForeignKey("dbo.GolfRounds", "GolfCourseID", "dbo.GolfCourses");
            DropForeignKey("dbo.GolfHoles", "GolfCourseID", "dbo.GolfCourses");
            DropIndex("dbo.HoleScores", new[] { "GolfRound_GolfRoundID" });
            DropIndex("dbo.HoleScores", new[] { "GolfHoleID" });
            DropIndex("dbo.GolfRounds", new[] { "GolfCourseID" });
            DropIndex("dbo.GolfRounds", new[] { "GolferID" });
            DropIndex("dbo.GolfHoles", new[] { "GolfCourseID" });
            DropTable("dbo.HoleScores");
            DropTable("dbo.GolfRounds");
            DropTable("dbo.Golfers");
            DropTable("dbo.GolfHoles");
            DropTable("dbo.GolfCourses");
        }
    }
}

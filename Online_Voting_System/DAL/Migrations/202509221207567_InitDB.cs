namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(nullable: false, maxLength: 20, unicode: false),
                        Party = c.String(nullable: false, maxLength: 20, unicode: false),
                        Bio = c.String(nullable: false, maxLength: 50, unicode: false),
                        ElectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId)
                .ForeignKey("dbo.Elections", t => t.ElectionId, cascadeDelete: true)
                .Index(t => t.ElectionId);
            
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        ElectionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30, unicode: false),
                        Description = c.String(nullable: false, maxLength: 100, unicode: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ElectionId)
                .ForeignKey("dbo.Users", t => t.CreatedBy, cascadeDelete: true)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 20, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        VoterId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        ElectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoterId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: false)
                .ForeignKey("dbo.Elections", t => t.ElectionId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.CandidateId)
                .Index(t => t.ElectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voters", "UserId", "dbo.Users");
            DropForeignKey("dbo.Voters", "ElectionId", "dbo.Elections");
            DropForeignKey("dbo.Voters", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "ElectionId", "dbo.Elections");
            DropForeignKey("dbo.Elections", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Voters", new[] { "ElectionId" });
            DropIndex("dbo.Voters", new[] { "CandidateId" });
            DropIndex("dbo.Voters", new[] { "UserId" });
            DropIndex("dbo.Elections", new[] { "CreatedBy" });
            DropIndex("dbo.Candidates", new[] { "ElectionId" });
            DropTable("dbo.Voters");
            DropTable("dbo.Users");
            DropTable("dbo.Elections");
            DropTable("dbo.Candidates");
        }
    }
}

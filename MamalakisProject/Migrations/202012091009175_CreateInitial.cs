namespace MamalakisProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Creators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Creators", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.IngredientsPerRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                        MetricId = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Metrics", t => t.MetricId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.IngredientId)
                .Index(t => t.MetricId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IngredientTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IngredientTypes", t => t.IngredientTypeId, cascadeDelete: true)
                .Index(t => t.IngredientTypeId);
            
            CreateTable(
                "dbo.IngredientTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Metrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientsPerRecipes", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.IngredientsPerRecipes", "MetricId", "dbo.Metrics");
            DropForeignKey("dbo.Ingredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropForeignKey("dbo.IngredientsPerRecipes", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Recipes", "CreatorId", "dbo.Creators");
            DropIndex("dbo.Ingredients", new[] { "IngredientTypeId" });
            DropIndex("dbo.IngredientsPerRecipes", new[] { "MetricId" });
            DropIndex("dbo.IngredientsPerRecipes", new[] { "IngredientId" });
            DropIndex("dbo.IngredientsPerRecipes", new[] { "RecipeId" });
            DropIndex("dbo.Recipes", new[] { "CreatorId" });
            DropTable("dbo.Metrics");
            DropTable("dbo.IngredientTypes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.IngredientsPerRecipes");
            DropTable("dbo.Recipes");
            DropTable("dbo.Creators");
        }
    }
}

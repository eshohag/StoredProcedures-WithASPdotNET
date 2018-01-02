namespace StoredProcedures_WithASPdotNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreProcedures : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Album_Insert",
                p => new
                    {
                        Title = p.String(),
                        Price = p.Double(),
                    },
                body:
                    @"INSERT [dbo].[Albums]([Title], [Price])
                      VALUES (@Title, @Price)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Albums]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Albums] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Album_Update",
                p => new
                    {
                        Id = p.Int(),
                        Title = p.String(),
                        Price = p.Double(),
                    },
                body:
                    @"UPDATE [dbo].[Albums]
                      SET [Title] = @Title, [Price] = @Price
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Album_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Albums]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Album_Delete");
            DropStoredProcedure("dbo.Album_Update");
            DropStoredProcedure("dbo.Album_Insert");
        }
    }
}

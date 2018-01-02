namespace StoredProcedures_WithASPdotNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreProceduresOverriding : DbMigration
    {
        public override void Up()
        {
            RenameStoredProcedure(name: "dbo.Album_Insert", newName: "InsertAlbum");
            RenameStoredProcedure(name: "dbo.Album_Update", newName: "UpdateAlbum");
            RenameStoredProcedure(name: "dbo.Album_Delete", newName: "DeleteAlbum");
        }
        
        public override void Down()
        {
            RenameStoredProcedure(name: "dbo.DeleteAlbum", newName: "Album_Delete");
            RenameStoredProcedure(name: "dbo.UpdateAlbum", newName: "Album_Update");
            RenameStoredProcedure(name: "dbo.InsertAlbum", newName: "Album_Insert");
        }
    }
}

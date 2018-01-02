using System.Data.Entity;

namespace StoredProcedures_WithASPdotNET.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("StoredProceduresWithASPdotNET")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Create storeProcedures
            modelBuilder.Entity<Album>().MapToStoredProcedures();

            modelBuilder.Entity<Album>().MapToStoredProcedures(a => a
            .Insert(b => b.HasName("InsertAlbum"))
            .Delete(c => c.HasName("DeleteAlbum"))
            .Update(d => d.HasName("UpdateAlbum")));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Album> Albums { get; set; }
    }
}
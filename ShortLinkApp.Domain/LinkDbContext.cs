namespace ShortLinkApp.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class LinkDbContext : DbContext
    {
        static LinkDbContext()
        {
            Database.SetInitializer<LinkDbContext>(new CreateDatabaseIfNotExists<LinkDbContext>());
        }

        public LinkDbContext(string connectionString):base(connectionString)
        {

        }
        public LinkDbContext()
            : base("name=LinkDbConnection")
        {

        }

        public virtual DbSet<LinkRecord> LinkRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("HR");
        }
    }
}

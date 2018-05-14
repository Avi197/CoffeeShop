namespace Coffee3.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Coffee : DbContext
    {
        public Coffee()
            : base("name=Coffee")
        {
        }

        public virtual DbSet<adminaccount> adminaccounts { get; set; }
        public virtual DbSet<drink> drinks { get; set; }
        public virtual DbSet<drinktype> drinktypes { get; set; }
        public virtual DbSet<whatsup> whatsups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adminaccount>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<adminaccount>()
                .Property(e => e.passwordhash)
                .IsUnicode(false);

            modelBuilder.Entity<drink>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<drink>()
                .Property(e => e.drinktypecode)
                .IsUnicode(false);

            modelBuilder.Entity<drinktype>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<drinktype>()
                .HasMany(e => e.drinks)
                .WithRequired(e => e.drinktype)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<whatsup>()
                .Property(e => e.code)
                .IsUnicode(false);
        }
    }
}

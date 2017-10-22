namespace Festo.DataTables.Tables
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FestoContext : DbContext
    {
        public FestoContext()
            : base("name=FestoContext")
        {
        }

        public virtual DbSet<ALARM> ALARM { get; set; }
        public virtual DbSet<ALARMSTATUS> ALARMSTATUS { get; set; }
        public virtual DbSet<ALARMTRACKER> ALARMTRACKER { get; set; }
        public virtual DbSet<CLIENT> CLIENT { get; set; }
        public virtual DbSet<CLIENTTYPE> CLIENTTYPE { get; set; }
        public virtual DbSet<ITEM> ITEM { get; set; }
        public virtual DbSet<ITEMSIZE> ITEMSIZE { get; set; }
        public virtual DbSet<ITEMSTATUS> ITEMSTATUS { get; set; }
        public virtual DbSet<ITEMTRACKER> ITEMTRACKER { get; set; }
        public virtual DbSet<ORDERS> ORDERS { get; set; }
        public virtual DbSet<ORDERSTATUS> ORDERSTATUS { get; set; }
        public virtual DbSet<ORDERTRACKER> ORDERTRACKER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALARM>()
                .Property(e => e.AlarmType)
                .IsUnicode(false);

            modelBuilder.Entity<ALARM>()
                .HasMany(e => e.ALARMTRACKER)
                .WithRequired(e => e.ALARM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ALARMSTATUS>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ALARMSTATUS>()
                .HasMany(e => e.ALARMTRACKER)
                .WithRequired(e => e.ALARMSTATUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENT>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.CLIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTTYPE>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTTYPE>()
                .HasMany(e => e.CLIENT)
                .WithRequired(e => e.CLIENTTYPE1)
                .HasForeignKey(e => e.ClientType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ItemPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.ItemColour)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ITEMTRACKER)
                .WithRequired(e => e.ITEM)
                .HasForeignKey(e => new { e.ItemID, e.OrderID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEMSIZE>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMSIZE>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMSIZE>()
                .HasMany(e => e.ITEM)
                .WithRequired(e => e.ITEMSIZE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEMSTATUS>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMSTATUS>()
                .HasMany(e => e.ITEMTRACKER)
                .WithRequired(e => e.ITEMSTATUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.OrderPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<ORDERS>()
                .HasMany(e => e.ITEM)
                .WithRequired(e => e.ORDERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERS>()
                .HasMany(e => e.ORDERTRACKER)
                .WithRequired(e => e.ORDERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERSTATUS>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERSTATUS>()
                .HasMany(e => e.ORDERTRACKER)
                .WithRequired(e => e.ORDERSTATUS)
                .WillCascadeOnDelete(false);
        }
    }
}

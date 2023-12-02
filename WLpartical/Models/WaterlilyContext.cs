using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WLpartical.Models;

public partial class WaterlilyContext : DbContext
{
    public WaterlilyContext()
    {
    }

    public WaterlilyContext(DbContextOptions<WaterlilyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Holiday> Holidays { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Waterlily;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.EmailAdress).HasMaxLength(150);
            entity.Property(e => e.JobPosition)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UserName).HasMaxLength(150);
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Holidays__3214EC076532F521");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

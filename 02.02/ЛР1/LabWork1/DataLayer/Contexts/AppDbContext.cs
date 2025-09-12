using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<CompleteLection> CompleteLections { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Lection> Lections { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=mssql;Initial Catalog=ispp2109;User ID=ispp2109;Password=2109;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("Answer");

            entity.Property(e => e.Text).HasMaxLength(100);

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK_Answer_Question");
        });

        modelBuilder.Entity<CompleteLection>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LectionId });

            entity.ToTable("CompleteLection");

            entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");

            entity.HasOne(d => d.Lection).WithMany(p => p.CompleteLections)
                .HasForeignKey(d => d.LectionId)
                .HasConstraintName("FK_CompleteLection_Course");

            entity.HasOne(d => d.User).WithMany(p => p.CompleteLections)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_CompleteLection_User");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.Descrtiption).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Lection>(entity =>
        {
            entity.ToTable("Lection");

            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Course).WithMany(p => p.Lections)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Lection_Course");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.Text).HasMaxLength(500);

            entity.HasOne(d => d.Test).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK_Question_Test");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("Test");

            entity.Property(e => e.MinScore).HasDefaultValue(3);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Lection).WithMany(p => p.Tests)
                .HasForeignKey(d => d.LectionId)
                .HasConstraintName("FK_Test_Lection");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.HashPassword).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasDefaultValue(1);
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
